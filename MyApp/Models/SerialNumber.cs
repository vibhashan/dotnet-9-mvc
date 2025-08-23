using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyApp.Models
{
    [EntityTypeConfiguration(typeof(SerialNumberConfiguration))]
    public class SerialNumber
    {
        public int Id { get; set; }

        public required string Number { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; } = null!;
    }

    internal class SerialNumberConfiguration : IEntityTypeConfiguration<SerialNumber>
    {
        public void Configure(EntityTypeBuilder<SerialNumber> builder)
        {
            builder
                .ToTable("SERIAL_NUMBER_TAB")
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .HasColumnName("ID")
                .HasColumnType("NUMBER(38,0)")
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.Number)
                .HasColumnName("NUMBER")
                .HasColumnType("VARCHAR2(100)")
                .IsRequired();

            builder
                .Property(b => b.ItemId)
                .HasColumnName("ITEM_ID")
                .HasColumnType("NUMBER(38,0)")
                .IsRequired();

            // 1:1 relationship
            builder
                .HasOne(b => b.Item)
                .WithOne(b => b.SerialNumber)
                .HasForeignKey<SerialNumber>(b => b.ItemId);
        }

    }
}
