using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Remora.Discord.Core;

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
    }
}


namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit
    {
    }
}