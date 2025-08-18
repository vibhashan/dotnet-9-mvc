using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyApp.Models
{
    [EntityTypeConfiguration(typeof(ItemConfiguration))]
    public class Item
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public double Price { get; set; }
    }

    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .ToTable("ITEM_TAB")
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.Name)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR2(100)")
                .IsRequired();

            builder
                .Property(b => b.Price)
                .HasColumnName("PRICE")
                .HasColumnType("NUMBER")
                .IsRequired();
        }
    }
}


