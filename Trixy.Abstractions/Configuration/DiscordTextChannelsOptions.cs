using Trixy.Abstractions.Interfaces;

namespace Trixy.Abstractions.Configuration;

public sealed class DiscordTextChannelsOptions
    : IModuleOptions
{
    public string ReportTextChannelId { get; set; }
    public string ConfigurationModuleName { get; set; } = "TextChannels";
}