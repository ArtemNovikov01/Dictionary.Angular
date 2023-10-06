﻿using Dictionary.Domain.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dictionary.Infrastructure.Data
{
    public class DictionaryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<ConfirmationData> ConfirmationData { get; set; }
        public DictionaryContext(DbContextOptions<DictionaryContext> options)
            :base(options) 
        {
           // Database.EnsureDeleted();

            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
