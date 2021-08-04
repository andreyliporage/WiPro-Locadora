using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiPro.Domain.Entities;

namespace WiPro.Data.Mapping
{
    public class LocacaoMap : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("Locacao");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.DiaLocao).IsRequired();

            builder.Property(l => l.Devolucao).IsRequired();

            builder.HasOne(l => l.Cliente).WithOne(c => c.Locacao).HasForeignKey<Cliente>(c => c.LocacaoId);

            builder.HasMany(l => l.Filmes).WithOne(f => f.Locacao).HasForeignKey(f => f.LocacaoId);
        }
    }
}