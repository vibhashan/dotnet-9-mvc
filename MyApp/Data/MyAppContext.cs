using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext(DbContextOptions<MyAppContext> options) : DbContext(options)
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<SerialNumber> SerialNumbers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ItemClient> ItemClients { get; set; }

        protected void DropTableIfExists()
        {
            Database.ExecuteSqlRaw("DROP TABLE IF EXISTS ITEM_CLIENT_TAB");
            Database.ExecuteSqlRaw("DROP TABLE IF EXISTS SERIAL_NUMBER_TAB");
            Database.ExecuteSqlRaw("DROP TABLE IF EXISTS CATEGORY_TAB");
            Database.ExecuteSqlRaw("DROP TABLE IF EXISTS ITEM_TAB");
            Database.ExecuteSqlRaw("DROP TABLE IF EXISTS CLIENT_TAB");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Insert seed data
            builder.Entity<Item>().HasData(
                new { Id = 1, Name = "Microphone", Price = 40D, CategoryId = 1 }
            );

            builder.Entity<SerialNumber>().HasData(
                new { Id = 1, Number = "MIC150", ItemId = 1 }
            );

            builder.Entity<Category>().HasData(
                new { Id = 1, Name = "Electronics" },
                new { Id = 2, Name = "Clothing" },
                new { Id = 3, Name = "Books" }
            );

            builder.Entity<Client>().HasData(
                new { Id = 1, Name = "John Doe" },
                new { Id = 2, Name = "Jane Doe" }
            );

            builder.Entity<ItemClient>().HasData(
                new { ItemId = 1, ClientId = 1 }
            );
        }
    }
}

