using ConsultaCEP.Models;
using ConsultaCEP.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ConsultaCEP.Repositories.Data
{
    public class CepContext : DbContext
    {
        public CepContext(DbContextOptions<CepContext> options) : base(options)
        {
        }

        public DbSet<CEP> CEP { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CEP>()
               .HasKey(c=> c.cep);

        }
    }
}
