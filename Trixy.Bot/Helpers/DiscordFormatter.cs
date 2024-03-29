﻿using Remora.Discord.Core;

namespace Trixy.Bot.Helpers;

internal static class DiscordFormatter
{
    internal static string Mention(this Snowflake snowflake)
    {
        return $"<@!{snowflake.Value}>";
    }

    internal static string SurroundWithAsterisks(string? value)
    {
        return $"**{value}**";
    }
}