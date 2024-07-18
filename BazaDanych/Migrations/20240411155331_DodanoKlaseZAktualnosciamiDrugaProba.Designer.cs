﻿// <auto-generated />
using System;
using BazaDanych.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BazaDanych.Migrations
{
    [DbContext(typeof(BazaContext))]
    [Migration("20240411155331_DodanoKlaseZAktualnosciamiDrugaProba")]
    partial class DodanoKlaseZAktualnosciamiDrugaProba
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BazaDanych.Data.CMS.Pojazd", b =>
                {
                    b.Property<int>("IdPojazd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPojazd"));

                    b.Property<bool>("CzyMaABS")
                        .HasColumnType("bit");

                    b.Property<bool>("CzyMaCentralnyZamek")
                        .HasColumnType("bit");

                    b.Property<bool>("CzyMaElektryczneLusterka")
                        .HasColumnType("bit");

                    b.Property<bool>("CzyMaElektryczneSzyby")
                        .HasColumnType("bit");

                    b.Property<bool>("CzyMaKlimatyzacje")
                        .HasColumnType("bit");

                    b.Property<bool>("CzyMaKomputerPokladowy")
                        .HasColumnType("bit");

                    b.Property<bool>("CzyMaPodgrzewaneLusterka")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("DataProdukcji")
                        .HasColumnType("date");

                    b.Property<int>("IdSegmentPojazdu")
                        .HasColumnType("int");

                    b.Property<int>("IdSlownikMarka")
                        .HasColumnType("int");

                    b.Property<int>("IdTypSilnika")
                        .HasColumnType("int");

                    b.Property<int>("IdTypSkrzyniBiegow")
                        .HasColumnType("int");

                    b.Property<int>("IloscDrzwi")
                        .HasColumnType("int");

                    b.Property<int>("IloscPoduszek")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<float>("MocSilnika")
                        .HasColumnType("real");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NazwaWSerwisie")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OpisPojazdu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PojemnoscSilnika")
                        .HasColumnType("real");

                    b.Property<string>("SciezkaDoZdjecia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SpalanieMiejskie")
                        .HasColumnType("real");

                    b.HasKey("IdPojazd");

                    b.HasIndex("IdSegmentPojazdu");

                    b.HasIndex("IdSlownikMarka");

                    b.HasIndex("IdTypSilnika");

                    b.HasIndex("IdTypSkrzyniBiegow");

                    b.ToTable("Pojazdy");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.PojazdSlCechaPojazdu", b =>
                {
                    b.Property<int>("PojazdyId")
                        .HasColumnType("int");

                    b.Property<int>("SlCechyPojazdowId")
                        .HasColumnType("int");

                    b.HasKey("PojazdyId", "SlCechyPojazdowId");

                    b.HasIndex("SlCechyPojazdowId");

                    b.ToTable("PojazdSlCechaPojazdu");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.SlCechaPojazdu", b =>
                {
                    b.Property<int>("IdSlCechaPojazdu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSlCechaPojazdu"));

                    b.Property<string>("CechaPojazdu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("IdSlCechaPojazdu");

                    b.ToTable("SlCechyPojazdow");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.SlMarka", b =>
                {
                    b.Property<int>("IdSlMarka")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSlMarka"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MarkaPojazdu")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdSlMarka");

                    b.ToTable("SlMarkiPojazdow");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.SlSegmentPojazdu", b =>
                {
                    b.Property<int>("IdSlSegmentPojazdu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSlSegmentPojazdu"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NazwaSegmentuPojazdu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdSlSegmentPojazdu");

                    b.ToTable("SlSegmentyPojazdow");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.SlTypSilnika", b =>
                {
                    b.Property<int>("IdSlTypSilnika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSlTypSilnika"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NazwaTypuSilnika")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdSlTypSilnika");

                    b.ToTable("SlTypySilnikow");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.SlTypSkrzyniBiegow", b =>
                {
                    b.Property<int>("IdSlTypSkrzyniBiegow")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSlTypSkrzyniBiegow"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NazwaTypuSkrzyniBiegow")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdSlTypSkrzyniBiegow");

                    b.ToTable("SlTypySkrzyniBiegow");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.Pojazd", b =>
                {
                    b.HasOne("BazaDanych.Data.CMS.SlSegmentPojazdu", "SlSegmentPojazdu")
                        .WithMany("Pojazdy")
                        .HasForeignKey("IdSegmentPojazdu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BazaDanych.Data.CMS.SlMarka", "SlMarka")
                        .WithMany("Pojazdy")
                        .HasForeignKey("IdSlownikMarka")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BazaDanych.Data.CMS.SlTypSilnika", "SlTypSilnika")
                        .WithMany("Pojazdy")
                        .HasForeignKey("IdTypSilnika")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BazaDanych.Data.CMS.SlTypSkrzyniBiegow", "SlTypSkrzyniBiegow")
                        .WithMany("Pojazdy")
                        .HasForeignKey("IdTypSkrzyniBiegow")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SlMarka");

                    b.Navigation("SlSegmentPojazdu");

                    b.Navigation("SlTypSilnika");

                    b.Navigation("SlTypSkrzyniBiegow");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.PojazdSlCechaPojazdu", b =>
                {
                    b.HasOne("BazaDanych.Data.CMS.Pojazd", "Pojazd")
                        .WithMany("PojazdySlCechyPojazdow")
                        .HasForeignKey("PojazdyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BazaDanych.Data.CMS.SlCechaPojazdu", "SlCechaPojazdu")
                        .WithMany("PojazdySlCechyPojazdow")
                        .HasForeignKey("SlCechyPojazdowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pojazd");

                    b.Navigation("SlCechaPojazdu");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.Pojazd", b =>
                {
                    b.Navigation("PojazdySlCechyPojazdow");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.SlCechaPojazdu", b =>
                {
                    b.Navigation("PojazdySlCechyPojazdow");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.SlMarka", b =>
                {
                    b.Navigation("Pojazdy");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.SlSegmentPojazdu", b =>
                {
                    b.Navigation("Pojazdy");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.SlTypSilnika", b =>
                {
                    b.Navigation("Pojazdy");
                });

            modelBuilder.Entity("BazaDanych.Data.CMS.SlTypSkrzyniBiegow", b =>
                {
                    b.Navigation("Pojazdy");
                });
#pragma warning restore 612, 618
        }
    }
}
