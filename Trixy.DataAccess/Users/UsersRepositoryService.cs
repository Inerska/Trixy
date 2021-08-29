#nullable enable
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Remora.Discord.Core;
using Trixy.DataAccess.Models;

namespace Trixy.DataAccess.Users
{
    public class UsersRepositoryService
        : IEntityRepository<UserEntity>
    {
        private readonly TrixyDbContext _context;

        public UsersRepositoryService(TrixyDbContext context)
        {
            _context = context;
        }

        public async void AddEntityAsync(UserEntity entity)
        {
            var contains = await _context.Users.ContainsAsync(entity);
            if (contains)
                throw new DuplicateNameException(nameof(entity));

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async void RemoveEntityAsync(UserEntity entity)
        {
            var contains = await _context.Users.ContainsAsync(entity);
            if (!contains)
                throw new ArgumentNullException(nameof(entity));

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public bool ExistsBySnowflake(Snowflake snowflake)
        {
            return _context.Users.Any(entity => entity.Snowflake == snowflake.Value);
        }

        public async Task<UserEntity> GetEntityBySnowflakeAsync(Snowflake snowflake)
        {
            var exists = ExistsBySnowflake(snowflake: snowflake);
            if (!exists)
                throw new ArgumentNullException(nameof(snowflake));

            return await _context.Users.SingleAsync(entity => entity.Snowflake == snowflake.Value);
        }
    }
}