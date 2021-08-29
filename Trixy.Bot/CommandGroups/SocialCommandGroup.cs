using System.ComponentModel;
using System.Threading.Tasks;
using OneOf;
using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using Trixy.Bot.Helpers;
using static Trixy.Bot.Helpers.SocialTheme;
using static Trixy.Bot.Helpers.DiscordFormatter;

namespace Trixy.Bot.CommandGroups
{
    internal class SocialCommandGroup
        : CommandGroup
    {
        private readonly IDiscordRestInteractionAPI _discordRestInteractionApi;
        private readonly InteractionContext _interactionContext;

        public SocialCommandGroup(
            IDiscordRestInteractionAPI discordRestInteractionApi,
            InteractionContext interactionContext)
        {
            _discordRestInteractionApi = discordRestInteractionApi;
            _interactionContext = interactionContext;
        }

        private async Task<IResult> SendSocialEmbedAsync(
            OneOf<SafeForWork, NotSafeForWork> theme,
            IUser? target = null)
        {
            var header = target is null
                ? $"{SurroundWithAsterisks(_interactionContext.User.Username)} {Stringify(theme)}"
                : $"{SurroundWithAsterisks(_interactionContext.User.Username)} {Stringify(theme)} {SurroundWithAsterisks(target.Username)}";

            var embed = await TemplateEmbed.GetSocialEmbed(header, theme);

            return await MessageHelper.CreateFollowupEmbedMessageHelperAsync
            (
                _discordRestInteractionApi,
                _interactionContext,
                embed,
                CancellationToken
            );
        }

        #region CommandsGroups

        [Command("wave")]
        [Description("Posts an embed with a anime gif associated to wave theme.")]
        public async Task<IResult> SocialWaveCommandAsync(
            [Description("(Mandatory) The user to wave to.")]
            IUser? target = null)
        {
            return await SendSocialEmbedAsync(SafeForWork.WAVE, target);
        }

        [Command("dance")]
        [Description("Posts an embed with a anime gif associated to dance theme.")]
        public async Task<IResult> SocialDanceCommandAsync()
        {
            return await SendSocialEmbedAsync(SafeForWork.DANCE);
        }

        [Command("poke")]
        [Description("Posts an embed with a anime gif associated to poke theme.")]
        public async Task<IResult> SocialPokeCommandAsync([Description("The user to poke to.")] IUser target)
        {
            return await SendSocialEmbedAsync(SafeForWork.POKE, target);
        }

        [Command("wink")]
        [Description("Posts an embed with a anime gif associated to wink theme.")]
        public async Task<IResult> SocialWinkCommandAsync(
            [Description("(Mandatory) The user to wink with.")]
            IUser? target = null)
        {
            return await SendSocialEmbedAsync(SafeForWork.WINK, target);
        }

        [Command("kill")]
        [Description("Posts an embed with a anime gif associated to kill theme.")]
        public async Task<IResult> SocialKillCommandAsync([Description("The user to kill.")] IUser target)
        {
            return await SendSocialEmbedAsync(SafeForWork.KILL, target);
        }

        [Command("bite")]
        [Description("Posts an embed with a anime gif associated to bite theme.")]
        public async Task<IResult> SocialBiteCommandAsync([Description("The user to bite.")] IUser target)
        {
            return await SendSocialEmbedAsync(SafeForWork.BITE, target);
        }

        [Command("nom")]
        [Description("Posts an embed with a anime gif associated to chew theme.")]
        public async Task<IResult> SocialNomCommandAsync([Description("The user to chew.")] IUser target)
        {
            return await SendSocialEmbedAsync(SafeForWork.NOM, target);
        }

        [Command("highfive")]
        [Description("Posts an embed with a anime gif associated to highfive theme.")]
        public async Task<IResult> SocialHighFiveCommandAsync([Description("The user to highfive with.")] IUser target)
        {
            return await SendSocialEmbedAsync(SafeForWork.HIGHFIVE, target);
        }

        [Command("smile")]
        [Description("Posts an embed with a anime gif associated to smile theme.")]
        public async Task<IResult> SocialSmileCommandAsync()
        {
            return await SendSocialEmbedAsync(SafeForWork.SMILE);
        }

        [Command("blush")]
        [Description("Posts an embed with a anime gif associated to blush theme.")]
        public async Task<IResult> SocialBlushCommandAsync()
        {
            return await SendSocialEmbedAsync(SafeForWork.BLUSH);
        }

        [Command("smug")]
        [Description("Posts an embed with a anime gif associated to smug theme.")]
        public async Task<IResult> SocialSmugCommandAsync()
        {
            return await SendSocialEmbedAsync(SafeForWork.SMUG);
        }

        [Command("pat", "patpat")]
        [Description("Posts an embed with a anime gif associated to pat theme.")]
        public async Task<IResult> SocialPatCommandAsync([Description("The user to pat.")] IUser target)
        {
            return await SendSocialEmbedAsync(SafeForWork.PAT, target);
        }

        [Command("lick")]
        [Description("Posts an embed with a anime gif associated to lick theme.")]
        public async Task<IResult> SocialLickCommandAsync([Description("The user to lick.")] IUser target)
        {
            return await SendSocialEmbedAsync(SafeForWork.LICK, target);
        }

        [Command("kiss")]
        [Description("Posts an embed with a anime gif associated to kiss theme.")]
        public async Task<IResult> SocialKissCommandAsync([Description("The user to kiss.")] IUser target)
        {
            return await SendSocialEmbedAsync(SafeForWork.KISS, target);
        }

        [Command("hug")]
        [Description("Posts an embed with a anime gif associated to hug theme.")]
        public async Task<IResult> SocialHugCommandAsync([Description("The user to hug.")] IUser target)
        {
            return await SendSocialEmbedAsync(SafeForWork.HUG, target);
        }

        [Command("cuddle")]
        [Description("Posts an embed with a anime gif associated to cuddle theme.")]
        public async Task<IResult> SocialCuddleCommandAsync([Description("The user to cuddle.")] IUser target)
        {
            return await SendSocialEmbedAsync(SafeForWork.CUDDLE, target);
        }

        [Command("bully")]
        [Description("Posts an embed with a anime gif associated to bully theme.")]
        public async Task<IResult> SocialBullyCommandAsync([Description("The user to bully.")] IUser target)
        {
            return await SendSocialEmbedAsync(SafeForWork.BULLY, target);
        }

        [Command("slap")]
        [Description("Posts an embed with a anime gif associated to slap theme.")]
        public async Task<IResult> SocialSlapCommandAsync([Description("The user to slap.")] IUser target)
        {
            return await SendSocialEmbedAsync(SafeForWork.SLAP, target);
        }

        #endregion
    }
}