using Newtonsoft.Json.Linq;

using System;
using System.Net.Http;
using System.Threading.Tasks;

using Remora.Discord.Core;

namespace Trixy.Bot.Helpers
{
    internal static class ExternalFetcher
    {
        internal static async Task<Optional<string>> GetRandomThemeGif(SocialTheme theme)
        {
            var baseUrl = Environment.GetEnvironmentVariable("ANIME_API_BASE_URL_");

            using HttpClient client = new();
            using HttpResponseMessage res = await client.GetAsync(baseUrl + theme.ToString().ToLower());
            using HttpContent content = res.Content;

            var data = await content.ReadAsStringAsync();

            return (string)JObject.Parse(data)["url"]!;
        }
    }
}