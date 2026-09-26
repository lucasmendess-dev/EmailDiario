using Microsoft.EntityFrameworkCore;
using EmailDiario.Models;

namespace EmailDiario.Data
{
    public class EmailDiarioDbContext : DbContext
    {
        public EmailDiarioDbContext(
            DbContextOptions<EmailDiarioDbContext> options)
            : base(options)
        {
        }

        public DbSet<Destinatario> Destinatarios { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<VinculoEnvio> VinculosEnvio { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Destinatario>()
                .Property(d => d.Nome)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Destinatario>()
                .Property(d => d.Email)
                .HasMaxLength(254)
                .IsRequired();
            
            modelBuilder.Entity<Destinatario>()
                .HasIndex(d => d.Email)
                .IsUnique();
        }
    }
}
