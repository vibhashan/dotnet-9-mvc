using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext(DbContextOptions<MyAppContext> options) : DbContext(options)
    {
        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Item>()
                .ToTable("item_tab")
                .HasKey(b => b.Id);

            builder.Entity<Item>()
                .Property(b => b.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Entity<Item>()
                .Property(b => b.Name)
                .HasColumnName("name")
                .HasColumnType("varchar2(100)")
                .IsRequired();
        }
    }
}

