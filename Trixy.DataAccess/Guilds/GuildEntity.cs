using System.Collections.Generic;
using Trixy.DataAccess.Models;

namespace Trixy.DataAccess.Guilds;

public class GuildEntity
{
    public int Id { get; set; }
    public ulong Snowflake { get; set; }
    public List<UserEntity> Users { get; set; }
}