using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiPro.Domain.Entities;

namespace WiPro.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(60);

            builder.Property(c => c.CPF).IsRequired().HasMaxLength(11);

            builder.HasIndex(c => c.CPF).IsUnique();

            builder.HasOne(c => c.Locacao).WithOne(l => l.Cliente).HasForeignKey<Cliente>(c => c.LocacaoId);
        }
    }
}