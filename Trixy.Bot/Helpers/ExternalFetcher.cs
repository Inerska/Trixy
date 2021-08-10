using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OneOf;
using Remora.Discord.API.Objects;
using static Trixy.Bot.Helpers.SocialTheme;

namespace Trixy.Bot.Helpers
{
    internal static class ExternalFetcher
    {
        public static async Task<string?> GetRandomThemeGif(OneOf<SafeForWork, NotSafeForWork> category)
        {
            var baseUrl = category.IsT0
                ? Environment.GetEnvironmentVariable("SFW_ANIME_API_BASE_URL_")
                : Environment.GetEnvironmentVariable("NSFW_ANIME_API_BASE_URL_");

            if (baseUrl is null)
                throw new ArgumentNullException(nameof(baseUrl));

            Uri url = new(baseUrl + category.Value.ToString()?.ToLower());
            var request = WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Timeout = 5000;

            var response = await request.GetResponseAsync();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();
            var result = JsonConvert.DeserializeObject<RandomThemeApiResponse>(json);

            return result?.Url;
        }
        private sealed record RandomThemeApiResponse(string Url);
    }
}

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit
    {
    }
}