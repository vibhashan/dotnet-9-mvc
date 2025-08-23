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

        public int? CategoryId { get; set; }

        public SerialNumber? SerialNumber { get; set; }

        public Category? Category { get; set; }

        public List<ItemClient>? ItemClients { get; set; }
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
                .HasColumnType("NUMBER(38,0)")
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

            builder
                .Property(b => b.CategoryId)
                .HasColumnName("CATEGORY_ID")
                .HasColumnType("NUMBER(38,0)");

            // 1:N relationship(s)
            builder
                .HasOne(b => b.Category)
                .WithMany(b => b.Items)
                .HasForeignKey(b => b.CategoryId);
        }
    }
}


