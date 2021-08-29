using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Trixy.DataAccess.Models;

namespace Trixy.DataAccess.Users
{
    internal class UsersRepositoryService
        : IEntityRepository<UserEntity>
    {
        private readonly TrixyDbContext _context;

        public UsersRepositoryService(TrixyDbContext context)
        {
            _context = context;
        }
    }
}