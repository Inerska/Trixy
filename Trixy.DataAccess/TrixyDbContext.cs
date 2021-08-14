using System;
using Microsoft.EntityFrameworkCore;
using Trixy.DataAccess.Models;

namespace Trixy.DataAccess
{
    public class TrixyDbContext
        : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING_");
            if (connectionString is null)
                throw new ArgumentNullException(nameof(connectionString));

            optionsBuilder.UseSqlite(connectionString);
        }
    }
}