using Microsoft.EntityFrameworkCore;
using WiPro.Data.Mapping;
using WiPro.Domain.Entities;

namespace WiPro.Data.Context
{
    public class WiProContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        public WiProContext(DbContextOptions<WiProContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Filme>(new FilmeMap().Configure);
            modelBuilder.Entity<Locacao>(new LocacaoMap().Configure);
        }
    }
}