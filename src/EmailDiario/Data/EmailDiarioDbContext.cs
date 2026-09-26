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

            modelBuilder.Entity<Mensagem>()
                .Property(m => m.Titulo)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Mensagem>()
                .Property(m => m.Assunto)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Mensagem>()
                .Property(m => m.Conteudo)
                .HasMaxLength(10000)
                .IsRequired();

            modelBuilder.Entity<VinculoEnvio>()
                .HasOne(v => v.Destinatario)
                .WithOne()
                .HasForeignKey<VinculoEnvio>(v => v.DestinatarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VinculoEnvio>()
                .HasOne(v => v.Mensagem)
                .WithMany()
                .HasForeignKey(v => v.MensagemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
