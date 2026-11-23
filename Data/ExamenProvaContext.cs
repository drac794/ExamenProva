using Microsoft.EntityFrameworkCore;
using ExamenProva.Models;

namespace ExamenProva.Data;

public class ExamenProvaContext : DbContext
{
    public DbSet<Candidatura> Candidatura { get; set; }

    public DbSet<Representant> Representant { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ExamenProva.db")
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relació entre candidatures
        modelBuilder.Entity<Candidatura>()
            .HasOne(c => c.CandidaturaPrincipal)
            .WithMany(c => c.CandidaturesRelacionades)
            .HasForeignKey(c => c.CandidaturaPrincipalID)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Candidatura>()
            .HasOne(c => c.Representant)
            .WithOne(r => r.Candidatura)
            .HasForeignKey<Candidatura>(c => c.RepresentantID)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}