using Remora.Discord.Core;
using System.Collections.Generic;
using System.ComponentModel;
using Trixy.DataAccess.Guilds;

namespace Trixy.DataAccess.Models
{
    public sealed class UserEntity
    {
        public UserEntity(Snowflake snowflake)
            => Snowflake = snowflake.Value;

        public UserEntity(ulong snowflake)
            => Snowflake = snowflake;

        public int Id { get; set; }
        public ulong Snowflake { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public List<GuildEntity> Guilds { get; set; }
    }
}

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit
    {
    }
}