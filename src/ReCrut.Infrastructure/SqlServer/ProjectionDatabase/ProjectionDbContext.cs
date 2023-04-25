using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ReCrut.Infrastructure.SqlServer.ProjectionDatabase.EfEntities;

namespace ReCrut.Infrastructure.SqlServer.ProjectionDatabase;

public class ProjectionDbContext : DbContext
{
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    public ProjectionDbContext([NotNull] DbContextOptions<ProjectionDbContext> options) : base(options) { }
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
   
    internal DbSet<CandidatEfEntity> Candidats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.Entity<CandidatEfEntity>().ToTable("Candidats");
        modelBuilder.Entity<CandidatEfEntity>().HasKey(r => r.Id);
        modelBuilder.Entity<CandidatEfEntity>()
            .Property(r => r.Id)
            .HasColumnName("Id")
            .HasColumnType("uniqueIdentifier")
            .IsRequired();
        modelBuilder.Entity<CandidatEfEntity>()
            .Property(r => r.Nom)
            .HasColumnName("Nom")
            .HasColumnType("nvarchar(512)")
            .IsRequired();
        modelBuilder.Entity<CandidatEfEntity>()
            .Property(r => r.Prenom)
            .HasColumnName("Prenom")
            .HasColumnType("nvarchar(512)")
            .IsRequired();
        modelBuilder.Entity<CandidatEfEntity>()
            .Property(r => r.Trigramme)
            .HasColumnName("Trigramme")
            .HasColumnType("nvarchar(512)")
            .IsRequired();
        modelBuilder.Entity<CandidatEfEntity>()
            .Property(r => r.DatePriseContact)
            .HasColumnName("DatePriseContact")
            .HasColumnType("datetime")
            .IsRequired();
        modelBuilder.Entity<CandidatEfEntity>()
           .Property(r => r.CandidatStatus)
           .HasColumnName("CandidatStatus")
           .HasColumnType("nvarchar(512)")
           .IsRequired();
    }
}
