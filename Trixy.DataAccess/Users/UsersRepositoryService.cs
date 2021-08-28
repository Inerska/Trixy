using System;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Trixy.DataAccess.Models;

namespace Trixy.DataAccess.Users
{
    internal class UsersRepositoryService
        : IEntitiesRepository<UserEntity>
    {
        private readonly TrixyDbContext _context;

        public UsersRepositoryService(TrixyDbContext context)
        {
            _context = context;
        }

        public async void AddEntityAsync(UserEntity entity)
        {
            var containsUserAsync = await _context.Users.ContainsAsync(entity);
            if (containsUserAsync)
                throw new DuplicateNameException(nameof(entity));
            
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async void RemoveEntityAsync(UserEntity entity)
        {
            var containsUserAsync = await _context.Users.ContainsAsync(entity);
            if (!containsUserAsync)
                throw new ArgumentNullException(nameof(entity));

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}