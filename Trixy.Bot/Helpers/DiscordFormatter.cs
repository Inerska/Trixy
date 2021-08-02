using Remora.Discord.Core;

namespace Trixy.Bot.Helpers
{
    public static class DiscordFormatter
    {
        public static string Mention(this Snowflake snowflake) => $"<@{snowflake.Value}>";
    }
}
