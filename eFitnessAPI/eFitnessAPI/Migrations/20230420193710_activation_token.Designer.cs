﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eFitnessAPI.Data;

#nullable disable

namespace eFitnessAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230420193710_activation_token")]
    partial class activationtoken
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("korisnik_id")
                        .HasColumnType("int");

                    b.Property<int>("vrsta_clanarine_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("korisnik_id");

                    b.HasIndex("vrsta_clanarine_id");

                    b.ToTable("Clanarina");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Favorites", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("korisnik_id")
                        .HasColumnType("int");

                    b.Property<int>("vjezba_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("korisnik_id");

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

            modelBuilder.Entity("eFitnessAPI.Class.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Item");
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

                    b.Property<DateTime>("DatumAktivacije")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("isAktiviran")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("eFitnessAPI.Class.Narudzba", b =>
                {
                    b.Property<int>("narudzbaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("narudzbaID"));

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("VrijemePravljenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("korisnik_id")
                        .HasColumnType("int");

                    b.HasKey("narudzbaID");

                    b.HasIndex("korisnik_id");

                    b.ToTable("Narudzba");
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("datumPrijave")
                        .HasColumnType("datetime2");

                    b.Property<int>("grupni_trening_id")
                        .HasColumnType("int");

                    b.Property<int>("korisnik_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("grupni_trening_id");

                    b.HasIndex("korisnik_id");

                    b.ToTable("PrijavaGrupniTrening");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Spol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Spol");
                });

            modelBuilder.Entity("eFitnessAPI.Class.StavkeNarudzbe", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("kolicina")
                        .HasColumnType("int");

                    b.Property<int>("narudzba_id")
                        .HasColumnType("int");

                    b.Property<int>("suplement_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("narudzba_id");

                    b.HasIndex("suplement_id");

                    b.ToTable("StavkeNarudzbe");
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

                    b.Property<int>("cijena")
                        .HasColumnType("int");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("VrstaClanarine");
                });

            modelBuilder.Entity("eFitnessAPI.Controllers.Autentifikacija.AutentifikacijaToken", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<string>("ipAdresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vrijednost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("AutentifikacijaToken");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Osoblje", b =>
                {
                    b.HasBaseType("eFitnessAPI.Class.Korisnik");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("spol_id")
                        .HasColumnType("int");

                    b.HasIndex("spol_id");

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
                    b.HasOne("eFitnessAPI.Class.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnik_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFitnessAPI.Class.VrstaClanarine", "vrstaClanarine")
                        .WithMany()
                        .HasForeignKey("vrsta_clanarine_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");

                    b.Navigation("vrstaClanarine");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Favorites", b =>
                {
                    b.HasOne("eFitnessAPI.Class.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnik_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFitnessAPI.Class.Vjezba", "vjezba")
                        .WithMany()
                        .HasForeignKey("vjezba_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");

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

            modelBuilder.Entity("eFitnessAPI.Class.Narudzba", b =>
                {
                    b.HasOne("eFitnessAPI.Class.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnik_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");
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
                    b.HasOne("eFitnessAPI.Class.GrupniTrening", "grupniTrening")
                        .WithMany()
                        .HasForeignKey("grupni_trening_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFitnessAPI.Class.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnik_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("grupniTrening");

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("eFitnessAPI.Class.StavkeNarudzbe", b =>
                {
                    b.HasOne("eFitnessAPI.Class.Narudzba", "narudzba")
                        .WithMany()
                        .HasForeignKey("narudzba_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFitnessAPI.Class.Suplement", "suplement")
                        .WithMany()
                        .HasForeignKey("suplement_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("narudzba");

                    b.Navigation("suplement");
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

            modelBuilder.Entity("eFitnessAPI.Controllers.Autentifikacija.AutentifikacijaToken", b =>
                {
                    b.HasOne("eFitnessAPI.Class.Korisnik", "korisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnickiNalog");
                });

            modelBuilder.Entity("eFitnessAPI.Class.Osoblje", b =>
                {
                    b.HasOne("eFitnessAPI.Class.Korisnik", null)
                        .WithOne()
                        .HasForeignKey("eFitnessAPI.Class.Osoblje", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFitnessAPI.Class.Spol", "spol")
                        .WithMany()
                        .HasForeignKey("spol_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("spol");
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
