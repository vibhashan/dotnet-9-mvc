using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyApp.Models
{
    [EntityTypeConfiguration(typeof(CategoryConfiguration))]
    public class Category
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public List<Item>? Items { get; set; }

    }

    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .ToTable("CATEGORY_TAB")
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
        }
    }
}
