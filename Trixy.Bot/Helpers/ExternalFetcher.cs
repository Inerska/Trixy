using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Remora.Discord.Core;

namespace Trixy.Bot.Helpers
{
    internal static class ExternalFetcher
    {
        internal static async Task<Optional<string>> RandomThemeGifFromApi(SocialTheme theme)
        {
            string baseUrl = $"https://neko-love.xyz/api/v1/{theme.ToString().ToLower()}";

            using HttpClient client = new();
            using HttpResponseMessage res = await client.GetAsync(baseUrl);
            using HttpContent content = res.Content;
            var data = await content.ReadAsStringAsync();

            System.Console.WriteLine(data);
            return (string)JObject.Parse(data)["url"]! ?? string.Empty;
        }
    }
}
