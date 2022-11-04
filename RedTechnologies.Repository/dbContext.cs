using Microsoft.EntityFrameworkCore;
using RedTechnologies.Repository.Enums;
using RedTechnologies.Repository.Models;
using RedTechnologies.Shared;
using System;

namespace RedTechnologies.Repository
{
    public class dbContext : DbContext
    {
        private const string connectionString = "Server=localhost;Database=RedTechnologies;User Id=sa;Password=sa;";
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User()
               {
                   Id = Guid.NewGuid(),
                   Name = "User",
                   UserName = "user",
                   Password = Encrypt.EncryptValue("12345"),
                   CreatedDate = DateTime.UtcNow
               }
            );
            ///Setup Type property to use Enum name instead of int number
            modelBuilder.Entity<Order>()
                .Property(e => e.Type)
                .HasConversion(v => v.ToString(),v => (OrderType)Enum.Parse(typeof(OrderType), v));
        }

    }
}
