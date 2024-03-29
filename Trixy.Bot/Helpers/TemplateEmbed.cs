﻿using System;
using System.Text;
using System.Threading.Tasks;
using OneOf;
using Remora.Discord.API.Objects;
using Remora.Discord.Core;
using Trixy.Common;
using static Trixy.Bot.Helpers.SocialTheme;

namespace Trixy.Bot.Helpers;

internal static class TemplateEmbed
{
    internal static async Task<Embed> GetSocialEmbed(string header, OneOf<SafeForWork, NotSafeForWork> category)
    {
        var image = await ExternalFetcher.GetRandomThemeGif(category);
        return new Embed(Description: header,
            Colour: Colors.Embed.TransparentColor,
            Image: new EmbedImage(image!),
            Footer: new EmbedFooter($"{category.Value} · {DateTime.Now.ToShortTimeString()}"));
    }

    internal static Embed GetAboutMeEmbed(string? botAvatarUrl, Snowflake botId)
    {
        var builder = new StringBuilder();
        builder
            .AppendLine(
                $"Hello, I'm {botId.Mention()}, the bot that will make your discord server in a new era of __modernity__")
            .AppendLine(
                "I dont have any prefix as my peers, you can access my commands with `/`, cool right ?\n")
            .AppendLine(
                "I'm open-source, you can contribute to my development and raise an issue (even a typo) in my [GitHub repository](https://github.com/Inerska/Trixy)")
            .AppendLine(
                "If you want to add me in your own server, you can just [click here](https://discord.com/api/oauth2/authorize?client_id=870605243891744859&permissions=8&scope=applications.commands%20bot)\n\n")
            .AppendLine("See you soon :)");

        return new Embed
        (
            Description: builder.ToString(),
            Thumbnail: new EmbedThumbnail(botAvatarUrl!),
            Colour: Colors.Embed.TransparentColor
        );
    }

    internal static Embed GetSingleMessageEmbed(string message)
    {
        var embed = new Embed(
            Description: message,
            Colour: Colors.Embed.ModerationColor);

        return embed;
    }
}