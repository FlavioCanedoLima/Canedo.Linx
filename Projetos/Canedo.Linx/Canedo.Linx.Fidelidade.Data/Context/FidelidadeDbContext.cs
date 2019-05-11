using Canedo.Linx.Fidelidade.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Canedo.Linx.Fidelidade.Data.Context
{
    public class FidelidadeDbContext : DbContext
    {
        readonly IConfiguration configuration_;
        public FidelidadeDbContext(IConfiguration configuration)
        {
            configuration_ = configuration;
        }

        public DbSet<Fidelizacao> Fidelizacoes { get; set; }
        public DbSet<Integracao> Integracoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration_.GetSection("ConnectionStrings:Fidelidade").Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fidelizacao>().ToTable("Fidelizacao");
            modelBuilder.Entity<Integracao>().ToTable("Integracao");
        }
    }
}
