using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Objects;
using System;
using System.Threading.Tasks;
using Trixy.Common;

namespace Trixy.Bot.Helpers
{
    public static class TemplateEmbed
    {
        public async static Task<Embed> GetSocialEmbed(string header, SocialTheme socialTheme)
        {
            var image = await ExternalFetcher.GetRandomThemeGif(socialTheme);
            Embed embed = new(Description: header,
                              Colour: Colors.Embed.TransparentColor,
                              Image: new EmbedImage(Url: image),
                              Footer: new EmbedFooter($"{socialTheme} · {DateTime.Now.ToShortTimeString()}"));

            return embed;
        }
    }
}
