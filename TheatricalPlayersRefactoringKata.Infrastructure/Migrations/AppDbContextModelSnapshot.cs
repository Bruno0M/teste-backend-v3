﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TheatricalPlayersRefactoringKata.Infrastructure.Data;

#nullable disable

namespace TheatricalPlayersRefactoringKata.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InvoicePerformance", b =>
                {
                    b.Property<Guid>("InvoicesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PerformancesId")
                        .HasColumnType("uuid");

                    b.HasKey("InvoicesId", "PerformancesId");

                    b.HasIndex("PerformancesId");

                    b.ToTable("tb_invoice_performance", (string)null);
                });

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Domain.Entities.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Customer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("customer");

                    b.Property<Guid>("PerformanceId")
                        .HasColumnType("uuid")
                        .HasColumnName("performance_id");

                    b.HasKey("Id");

                    b.ToTable("tb_invoices", (string)null);
                });

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Domain.Entities.Performance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Audience")
                        .HasColumnType("integer")
                        .HasColumnName("audience");

                    b.Property<int>("Credits")
                        .HasColumnType("integer")
                        .HasColumnName("credits");

                    b.Property<Guid>("PlayId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlayId");

                    b.ToTable("tb_performances", (string)null);
                });

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Domain.Entities.Play", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Genre")
                        .HasColumnType("integer")
                        .HasColumnName("genre");

                    b.Property<int>("Lines")
                        .HasColumnType("integer")
                        .HasColumnName("lines");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_plays", (string)null);
                });

            modelBuilder.Entity("InvoicePerformance", b =>
                {
                    b.HasOne("TheatricalPlayersRefactoringKata.Domain.Entities.Invoice", null)
                        .WithMany()
                        .HasForeignKey("InvoicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheatricalPlayersRefactoringKata.Domain.Entities.Performance", null)
                        .WithMany()
                        .HasForeignKey("PerformancesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Domain.Entities.Performance", b =>
                {
                    b.HasOne("TheatricalPlayersRefactoringKata.Domain.Entities.Play", "Play")
                        .WithMany("Performances")
                        .HasForeignKey("PlayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Play");
                });

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Domain.Entities.Play", b =>
                {
                    b.Navigation("Performances");
                });
#pragma warning restore 612, 618
        }
    }
}
