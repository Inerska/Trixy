using System;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Trixy.Bot.Helpers
{
    internal static class ExternalFetcher
    {
        public static async Task<string?> GetRandomThemeGif(SocialTheme theme)
        {
            var baseUrl = Environment.GetEnvironmentVariable("ANIME_API_BASE_URL_");
            if (baseUrl is null)
                throw new ArgumentNullException(nameof(baseUrl));

            Uri url = new(baseUrl + theme.ToString().ToLower());
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


        private record RandomThemeApiResponse(int Code, string Url);
    }

}

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit { }
}