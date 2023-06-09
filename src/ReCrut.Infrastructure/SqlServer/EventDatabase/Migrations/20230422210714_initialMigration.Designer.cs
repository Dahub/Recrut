﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReCrut.Infrastructure.SqlServer.EventDatabase;

#nullable disable

namespace ReCrut.Infrastructure.SqlServer.EventDatabase.Migrations
{
    [DbContext(typeof(EventDbContext))]
    [Migration("20230422210714_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReCrut.Infrastructure.SqlServer.EventEfEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueIdentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("AggregateId")
                        .HasColumnType("uniqueIdentifier")
                        .HasColumnName("AggregateId");

                    b.Property<string>("AggregateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)")
                        .HasColumnName("AggregateName");

                    b.Property<byte[]>("EventDatas")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Datas");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime")
                        .HasColumnName("CreationDate");

                    b.Property<int>("Version")
                        .HasColumnType("integer")
                        .HasColumnName("Version");

                    b.HasKey("Id");

                    b.HasIndex("AggregateId");

                    b.HasIndex("AggregateId", "AggregateName", "Version")
                        .IsUnique();

                    b.ToTable("Events", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
