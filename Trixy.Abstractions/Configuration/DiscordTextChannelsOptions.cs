using Trixy.Abstractions.Interaces;

namespace Trixy.Abstractions
{
    public sealed class DiscordTextChannelsOptions : IModuleOptions
    {
        public string ReportTextChannelId { get; set; }
        public string ConfigurationModuleName { get; set; } = "TextChannels";
    }
}