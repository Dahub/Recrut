using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ReCrut.Infrastructure.SqlServer.EventDatabase.EfEntities;

namespace ReCrut.Infrastructure.SqlServer.EventDatabase;

public class EventDbContext : DbContext
{
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    public EventDbContext([NotNull] DbContextOptions<EventDbContext> options) : base(options) { }
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
   
    internal DbSet<EventEfEntity> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.Entity<EventEfEntity>().ToTable("Events");
        modelBuilder.Entity<EventEfEntity>().HasKey(r => r.Id);
        modelBuilder.Entity<EventEfEntity>()
            .Property(r => r.Id)
            .HasColumnName("Id")
            .HasColumnType("uniqueIdentifier")
            .IsRequired();
        modelBuilder.Entity<EventEfEntity>()
            .Property(r => r.AggregateId)
            .HasColumnName("AggregateId")
            .HasColumnType("uniqueIdentifier")
            .IsRequired();
        modelBuilder.Entity<EventEfEntity>()
           .Property(r => r.AggregateName)
           .HasColumnName("AggregateName")
           .HasColumnType("nvarchar(512)")
           .IsRequired();
        modelBuilder.Entity<EventEfEntity>()
            .Property(r => r.EventDatas)
            .HasColumnName("Datas")
            .HasColumnType("varbinary(max)");
        modelBuilder.Entity<EventEfEntity>()
            .Property(r => r.EventName)
            .HasColumnName("Name")
            .HasColumnType("nvarchar(512)")
            .IsRequired();
        modelBuilder.Entity<EventEfEntity>()
            .Property(r => r.TimeStamp)
            .HasColumnName("CreationDate")
            .HasColumnType("datetime")
            .IsRequired();
        modelBuilder.Entity<EventEfEntity>()
            .Property(r => r.Version)
            .HasColumnName("Version")
            .HasColumnType("integer")
            .IsRequired();
        modelBuilder.Entity<EventEfEntity>()
            .HasIndex(e => new
            {
                e.AggregateId,
                e.AggregateName,
                e.Version
            })
            .IsUnique(true);
        modelBuilder.Entity<EventEfEntity>()
            .HasIndex(e => e.AggregateId);
    }
}
