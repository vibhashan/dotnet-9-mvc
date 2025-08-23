using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyApp.Models
{
    [EntityTypeConfiguration(typeof(ItemClientConfiguration))]
    public class ItemClient
    {
        public int ItemId { get; set; }

        public int ClientId { get; set; }

        public Item? Item { get; set; }

        public Client? Client { get; set; }
    }

    internal class ItemClientConfiguration : IEntityTypeConfiguration<ItemClient>
    {
        public void Configure(EntityTypeBuilder<ItemClient> builder)
        {
            builder
                .ToTable("ITEM_CLIENT_TAB")
                .HasKey(b => new { b.ItemId, b.ClientId });

            builder
                .Property(b => b.ItemId)
                .HasColumnName("ITEM_ID")
                .HasColumnType("NUMBER(38,0)");

            builder
                .Property(b => b.ClientId)
                .HasColumnName("CLIENT_ID")
                .HasColumnType("NUMBER(38,0)");

            builder
                .HasOne(b => b.Item)
                .WithMany(b => b.ItemClients)
                .HasForeignKey(b => b.ItemId);

            builder
                .HasOne(b => b.Client)
                .WithMany(b => b.ItemClients)
                .HasForeignKey(b => b.ClientId);
        }
    }
}
