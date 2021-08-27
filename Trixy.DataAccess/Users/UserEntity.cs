using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trixy.DataAccess.Models
{
    public sealed record UserEntity(
        [Required] int Id,
        [Required] ulong Snowflake,
        [Required] ulong Experience,
        [Required] uint Level);
}


namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit
    {
    }
}