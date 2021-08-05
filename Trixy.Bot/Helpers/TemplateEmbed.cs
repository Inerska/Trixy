using OneOf;
using Remora.Discord.API.Objects;
using static Trixy.Bot.Helpers.SocialTheme;
using System;
using System.Threading.Tasks;
using Trixy.Common;

namespace Trixy.Bot.Helpers
{
    public static class TemplateEmbed
    {
        public async static Task<Embed> GetSocialEmbed(string header, OneOf<SafeForWork, NotSafeForWork> category)
        {
            var image = await ExternalFetcher.GetRandomThemeGif(category);
            return new Embed(Description: header,
                              Colour: Colors.Embed.TransparentColor,
                              Image: new EmbedImage(Url: image),
                              Footer: new EmbedFooter($"{category.Value} · {DateTime.Now.ToShortTimeString()}"));
        }
    }
}
