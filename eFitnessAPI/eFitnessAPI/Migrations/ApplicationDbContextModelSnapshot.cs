﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eFitnessAPI.Data;

#nullable disable

namespace eFitnessAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eFitnessAPI.Class.Clanarina", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("aktivna")
                        .HasColumnType("bit");

                    b.Property<DateTime>("datumIsteka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<int>("vrsta_clanarine_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("vrsta_clanarine_id");

                    b.ToTable("Clanarina");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Favorites", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("clan_id")
                        .HasColumnType("int");

                    b.Property<int>("vjezba_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clan_id");

                    b.HasIndex("vjezba_id");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("eFitnessAPI.Class.GrupniTrening", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("kategorija_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("vrijemeOdrzavanja")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("kategorija_id");

                    b.ToTable("GrupniTrening");
                });

            modelBuilder.Entity("eFitnessAPI.Class.KategorijaSuplementa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("KategorijaSuplementa");
                });

            modelBuilder.Entity("eFitnessAPI.Class.KategorijaTreninga", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("KategorijaTreninga");
                });

            modelBuilder.Entity("eFitnessAPI.Class.KategorijaVjezbe", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("KategorijaVjezbe");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Korisnik", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("korisnikoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Korisnik");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("eFitnessAPI.Class.ObjavaSuplementa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("datumDodavanja")
                        .HasColumnType("datetime2");

                    b.Property<int>("osoblje_id")
                        .HasColumnType("int");

                    b.Property<int>("suplement_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("osoblje_id");

                    b.HasIndex("suplement_id");

                    b.ToTable("ObjavaSuplementa");
                });

            modelBuilder.Entity("eFitnessAPI.Class.PrijavaGrupniTrening", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("clan_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("datumPrijave")
                        .HasColumnType("datetime2");

                    b.Property<int>("grupni_trening_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clan_id");

                    b.HasIndex("grupni_trening_id");

                    b.ToTable("PrijavaGrupniTrening");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Suplement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<double>("cijena")
                        .HasColumnType("float");

                    b.Property<int>("kategorija_id")
                        .HasColumnType("int");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("rokTrajanja")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("kategorija_id");

                    b.ToTable("Suplement");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Vjezba", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("kategorija_id")
                        .HasColumnType("int");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("kategorija_id");

                    b.ToTable("Vjezba");
                });

            modelBuilder.Entity("eFitnessAPI.Class.VrstaClanarine", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("VrstaClanarine");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Clan", b =>
                {
                    b.HasBaseType("eFitnessAPI.Class.Korisnik");

                    b.Property<int>("clanarina_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("datumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("jeLiClan")
                        .HasColumnType("bit");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("clanarina_id");

                    b.ToTable("Clan");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Osoblje", b =>
                {
                    b.HasBaseType("eFitnessAPI.Class.Korisnik");

                    b.Property<DateTime>("datumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Osoblje");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Trener", b =>
                {
                    b.HasBaseType("eFitnessAPI.Class.Osoblje");

                    b.Property<string>("Specijalnost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Trener");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Clanarina", b =>
                {
                    b.HasOne("eFitnessAPI.Class.VrstaClanarine", "vrstaClanarine")
                        .WithMany()
                        .HasForeignKey("vrsta_clanarine_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("vrstaClanarine");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Favorites", b =>
                {
                    b.HasOne("eFitnessAPI.Class.Clan", "clan")
                        .WithMany()
                        .HasForeignKey("clan_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFitnessAPI.Class.Vjezba", "vjezba")
                        .WithMany()
                        .HasForeignKey("vjezba_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clan");

                    b.Navigation("vjezba");
                });

            modelBuilder.Entity("eFitnessAPI.Class.GrupniTrening", b =>
                {
                    b.HasOne("eFitnessAPI.Class.KategorijaTreninga", "kategorija")
                        .WithMany()
                        .HasForeignKey("kategorija_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kategorija");
                });

            modelBuilder.Entity("eFitnessAPI.Class.ObjavaSuplementa", b =>
                {
                    b.HasOne("eFitnessAPI.Class.Osoblje", "osoblje")
                        .WithMany()
                        .HasForeignKey("osoblje_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFitnessAPI.Class.Suplement", "suplement")
                        .WithMany()
                        .HasForeignKey("suplement_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("osoblje");

                    b.Navigation("suplement");
                });

            modelBuilder.Entity("eFitnessAPI.Class.PrijavaGrupniTrening", b =>
                {
                    b.HasOne("eFitnessAPI.Class.Clan", "clan")
                        .WithMany()
                        .HasForeignKey("clan_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFitnessAPI.Class.GrupniTrening", "grupniTrening")
                        .WithMany()
                        .HasForeignKey("grupni_trening_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clan");

                    b.Navigation("grupniTrening");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Suplement", b =>
                {
                    b.HasOne("eFitnessAPI.Class.KategorijaSuplementa", "kategorija")
                        .WithMany()
                        .HasForeignKey("kategorija_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kategorija");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Vjezba", b =>
                {
                    b.HasOne("eFitnessAPI.Class.KategorijaVjezbe", "kategorijaVjezbe")
                        .WithMany()
                        .HasForeignKey("kategorija_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kategorijaVjezbe");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Clan", b =>
                {
                    b.HasOne("eFitnessAPI.Class.Clanarina", "clanarina")
                        .WithMany()
                        .HasForeignKey("clanarina_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFitnessAPI.Class.Korisnik", null)
                        .WithOne()
                        .HasForeignKey("eFitnessAPI.Class.Clan", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clanarina");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Osoblje", b =>
                {
                    b.HasOne("eFitnessAPI.Class.Korisnik", null)
                        .WithOne()
                        .HasForeignKey("eFitnessAPI.Class.Osoblje", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eFitnessAPI.Class.Trener", b =>
                {
                    b.HasOne("eFitnessAPI.Class.Osoblje", null)
                        .WithOne()
                        .HasForeignKey("eFitnessAPI.Class.Trener", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
