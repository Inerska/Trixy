using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Trixy.DataAccess.Models;

namespace Trixy.DataAccess
{
    public class TrixyDbContext
        : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            /*var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING_");
            if (connectionString is null)
                throw new ArgumentNullException(nameof(connectionString));*/ 

            var connectionString = 
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "trixy.db");
            optionsBuilder
                .UseSqlite($"Data Source={connectionString};");
            
        }

    }
}