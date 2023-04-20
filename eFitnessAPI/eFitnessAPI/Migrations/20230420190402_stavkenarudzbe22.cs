using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eFitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class stavkenarudzbe22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KategorijaSuplementa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaSuplementa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "KategorijaTreninga",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaTreninga", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "KategorijaVjezbe",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaVjezbe", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    narudzbaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VrijemePravljenja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.narudzbaID);
                });

            migrationBuilder.CreateTable(
                name: "Spol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaClanarine",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cijena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaClanarine", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Suplement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rokTrajanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cijena = table.Column<double>(type: "float", nullable: false),
                    kategorijaid = table.Column<int>(name: "kategorija_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplement", x => x.id);
                    table.ForeignKey(
                        name: "FK_Suplement_KategorijaSuplementa_kategorija_id",
                        column: x => x.kategorijaid,
                        principalTable: "KategorijaSuplementa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrupniTrening",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kategorijaid = table.Column<int>(name: "kategorija_id", type: "int", nullable: false),
                    vrijemeOdrzavanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupniTrening", x => x.id);
                    table.ForeignKey(
                        name: "FK_GrupniTrening_KategorijaTreninga_kategorija_id",
                        column: x => x.kategorijaid,
                        principalTable: "KategorijaTreninga",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vjezba",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kategorijaid = table.Column<int>(name: "kategorija_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vjezba", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vjezba_KategorijaVjezbe_kategorija_id",
                        column: x => x.kategorijaid,
                        principalTable: "KategorijaVjezbe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickiNalogId = table.Column<int>(type: "int", nullable: false),
                    vrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ipAdresa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_Korisnik_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Osoblje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    spolid = table.Column<int>(name: "spol_id", type: "int", nullable: false),
                    datumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoblje", x => x.id);
                    table.ForeignKey(
                        name: "FK_Osoblje_Korisnik_id",
                        column: x => x.id,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Osoblje_Spol_spol_id",
                        column: x => x.spolid,
                        principalTable: "Spol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clanarina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumIsteka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vrstaclanarineid = table.Column<int>(name: "vrsta_clanarine_id", type: "int", nullable: false),
                    aktivna = table.Column<bool>(type: "bit", nullable: false),
                    korisnikid = table.Column<int>(name: "korisnik_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanarina", x => x.id);
                    table.ForeignKey(
                        name: "FK_Clanarina_Korisnik_korisnik_id",
                        column: x => x.korisnikid,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clanarina_VrstaClanarine_vrsta_clanarine_id",
                        column: x => x.vrstaclanarineid,
                        principalTable: "VrstaClanarine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkeNarudzbe",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    narudzbaid = table.Column<int>(name: "narudzba_id", type: "int", nullable: false),
                    suplementid = table.Column<int>(name: "suplement_id", type: "int", nullable: false),
                    kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeNarudzbe", x => x.id);
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbe_Narudzba_narudzba_id",
                        column: x => x.narudzbaid,
                        principalTable: "Narudzba",
                        principalColumn: "narudzbaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbe_Suplement_suplement_id",
                        column: x => x.suplementid,
                        principalTable: "Suplement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrijavaGrupniTrening",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikid = table.Column<int>(name: "korisnik_id", type: "int", nullable: false),
                    grupnitreningid = table.Column<int>(name: "grupni_trening_id", type: "int", nullable: false),
                    datumPrijave = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijavaGrupniTrening", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrijavaGrupniTrening_GrupniTrening_grupni_trening_id",
                        column: x => x.grupnitreningid,
                        principalTable: "GrupniTrening",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrijavaGrupniTrening_Korisnik_korisnik_id",
                        column: x => x.korisnikid,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnikid = table.Column<int>(name: "korisnik_id", type: "int", nullable: false),
                    vjezbaid = table.Column<int>(name: "vjezba_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.id);
                    table.ForeignKey(
                        name: "FK_Favorites_Korisnik_korisnik_id",
                        column: x => x.korisnikid,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Vjezba_vjezba_id",
                        column: x => x.vjezbaid,
                        principalTable: "Vjezba",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjavaSuplementa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    osobljeid = table.Column<int>(name: "osoblje_id", type: "int", nullable: false),
                    suplementid = table.Column<int>(name: "suplement_id", type: "int", nullable: false),
                    datumDodavanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjavaSuplementa", x => x.id);
                    table.ForeignKey(
                        name: "FK_ObjavaSuplementa_Osoblje_osoblje_id",
                        column: x => x.osobljeid,
                        principalTable: "Osoblje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjavaSuplementa_Suplement_suplement_id",
                        column: x => x.suplementid,
                        principalTable: "Suplement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trener",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Specijalnost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trener", x => x.id);
                    table.ForeignKey(
                        name: "FK_Trener_Osoblje_id",
                        column: x => x.id,
                        principalTable: "Osoblje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Clanarina_korisnik_id",
                table: "Clanarina",
                column: "korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_Clanarina_vrsta_clanarine_id",
                table: "Clanarina",
                column: "vrsta_clanarine_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_korisnik_id",
                table: "Favorites",
                column: "korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_vjezba_id",
                table: "Favorites",
                column: "vjezba_id");

            migrationBuilder.CreateIndex(
                name: "IX_GrupniTrening_kategorija_id",
                table: "GrupniTrening",
                column: "kategorija_id");

            migrationBuilder.CreateIndex(
                name: "IX_ObjavaSuplementa_osoblje_id",
                table: "ObjavaSuplementa",
                column: "osoblje_id");

            migrationBuilder.CreateIndex(
                name: "IX_ObjavaSuplementa_suplement_id",
                table: "ObjavaSuplementa",
                column: "suplement_id");

            migrationBuilder.CreateIndex(
                name: "IX_Osoblje_spol_id",
                table: "Osoblje",
                column: "spol_id");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaGrupniTrening_grupni_trening_id",
                table: "PrijavaGrupniTrening",
                column: "grupni_trening_id");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaGrupniTrening_korisnik_id",
                table: "PrijavaGrupniTrening",
                column: "korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeNarudzbe_narudzba_id",
                table: "StavkeNarudzbe",
                column: "narudzba_id");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeNarudzbe_suplement_id",
                table: "StavkeNarudzbe",
                column: "suplement_id");

            migrationBuilder.CreateIndex(
                name: "IX_Suplement_kategorija_id",
                table: "Suplement",
                column: "kategorija_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vjezba_kategorija_id",
                table: "Vjezba",
                column: "kategorija_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "Clanarina");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ObjavaSuplementa");

            migrationBuilder.DropTable(
                name: "PrijavaGrupniTrening");

            migrationBuilder.DropTable(
                name: "StavkeNarudzbe");

            migrationBuilder.DropTable(
                name: "Trener");

            migrationBuilder.DropTable(
                name: "VrstaClanarine");

            migrationBuilder.DropTable(
                name: "Vjezba");

            migrationBuilder.DropTable(
                name: "GrupniTrening");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Suplement");

            migrationBuilder.DropTable(
                name: "Osoblje");

            migrationBuilder.DropTable(
                name: "KategorijaVjezbe");

            migrationBuilder.DropTable(
                name: "KategorijaTreninga");

            migrationBuilder.DropTable(
                name: "KategorijaSuplementa");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Spol");
        }
    }
}
