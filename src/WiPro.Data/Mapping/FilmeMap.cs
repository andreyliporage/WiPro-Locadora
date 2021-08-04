using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiPro.Domain.Entities;

namespace WiPro.Data.Mapping
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filme");

            builder.HasKey(f => f.Id);

            builder.HasIndex(f => f.Nome).IsUnique();

            builder.Property(f => f.Nome).IsRequired().HasMaxLength(60);

            builder.Property(f => f.Genero).IsRequired().HasMaxLength(10);

            builder.Property(f => f.Disponivel).IsRequired();
        }
    }
}