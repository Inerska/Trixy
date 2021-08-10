using System.ComponentModel;
using OneOf;

namespace Trixy.Bot.Helpers
{
    internal static class SocialTheme
    {
        internal static string Stringify(OneOf<SafeForWork, NotSafeForWork> category)
        {
            return category.Value switch
            {
                SafeForWork.BULLY => "bullies",
                SafeForWork.CUDDLE => "cuddles",
                SafeForWork.CRY => "cries",
                SafeForWork.HUG => "hugs",
                SafeForWork.KISS => "kisses",
                SafeForWork.LICK => "licks",
                SafeForWork.PAT => "pats",
                SafeForWork.SMUG => "smugs",
                SafeForWork.BLUSH => "blushes",
                SafeForWork.SMILE => "smiles",
                SafeForWork.WAVE => "waves",
                SafeForWork.HIGHFIVE => "highfives",
                SafeForWork.NOM => "noms",
                SafeForWork.BITE => "bites",
                SafeForWork.SLAP => "slaps",
                SafeForWork.KILL => "kills",
                SafeForWork.KICK => "kicks",
                SafeForWork.WINK => "winks",
                SafeForWork.POKE => "pokes",
                SafeForWork.DANCE => "dances",
                _ => throw new InvalidEnumArgumentException(nameof(category), (int)category.Value, typeof(SafeForWork))
            };
        }

        internal enum NotSafeForWork
        {
            WAIFU,
            NEKO,
            TRAP,
            BLOWJOB
        }

        internal enum SafeForWork
        {
            WAIFU,
            NEKO,
            SHINOBU,
            MEGUMIN,

            BULLY,
            CUDDLE,
            CRY,
            HUG,
            KISS,
            LICK,
            PAT,
            SMUG,
            BLUSH,
            SMILE,
            WAVE,
            HIGHFIVE,
            NOM,
            BITE,
            SLAP,
            KILL,
            KICK,
            WINK,
            POKE,
            DANCE
        }
    }
}