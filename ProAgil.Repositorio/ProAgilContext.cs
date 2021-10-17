using Microsoft.EntityFrameworkCore;
using ProAgil.Dominio;

namespace ProAgil.Repositorio
{
    public class ProAgilContext : DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedeSocials { get; set; }

        // Define quem é a tabela n:n e as chaves-estrangeiras
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestranteEvento>().HasKey(PE => new { PE.EventoId, PE.PalestranteId });
        }
    }
}