using System;
using Microsoft.EntityFrameworkCore;
using Trixy.DataAccess.Models;

namespace Trixy.DataAccess;

public class TrixyDbContext
    : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING_")
                               ?? throw new ArgumentNullException("DAL connection string cannot be null.");

        optionsBuilder
            .UseSqlite($"Data Source={connectionString};");
    }
}