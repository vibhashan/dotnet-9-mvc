using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyApp.Models
{
    [EntityTypeConfiguration(typeof(ClientConfiguration))]
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<ItemClient>? ItemClients { get; set; }
    }

    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .ToTable("CLIENT_TAB")
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .HasColumnName("ID")
                .HasColumnType("NUMBER(38,0)")
                .ValueGeneratedOnAdd();
        }
    }
}
