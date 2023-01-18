using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eFitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class novaBazaKeno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.id);
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
                    kategorijaid = table.Column<int>(name: "kategorija_id", type: "int", nullable: false),
                    slikabase64 = table.Column<byte[]>(name: "slika_base64", type: "varbinary(max)", nullable: false)
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
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    spol = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    aktivna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanarina", x => x.id);
                    table.ForeignKey(
                        name: "FK_Clanarina_VrstaClanarine_vrsta_clanarine_id",
                        column: x => x.vrstaclanarineid,
                        principalTable: "VrstaClanarine",
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

            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clanarinaid = table.Column<int>(name: "clanarina_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.id);
                    table.ForeignKey(
                        name: "FK_Clan_Clanarina_clanarina_id",
                        column: x => x.clanarinaid,
                        principalTable: "Clanarina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clan_Korisnik_id",
                        column: x => x.id,
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
                    clanid = table.Column<int>(name: "clan_id", type: "int", nullable: false),
                    vjezbaid = table.Column<int>(name: "vjezba_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.id);
                    table.ForeignKey(
                        name: "FK_Favorites_Clan_clan_id",
                        column: x => x.clanid,
                        principalTable: "Clan",
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
                name: "PrijavaGrupniTrening",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clanid = table.Column<int>(name: "clan_id", type: "int", nullable: false),
                    grupnitreningid = table.Column<int>(name: "grupni_trening_id", type: "int", nullable: false),
                    datumPrijave = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijavaGrupniTrening", x => x.id);
                    table.ForeignKey(
                        name: "FK_PrijavaGrupniTrening_Clan_clan_id",
                        column: x => x.clanid,
                        principalTable: "Clan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrijavaGrupniTrening_GrupniTrening_grupni_trening_id",
                        column: x => x.grupnitreningid,
                        principalTable: "GrupniTrening",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Clan_clanarina_id",
                table: "Clan",
                column: "clanarina_id");

            migrationBuilder.CreateIndex(
                name: "IX_Clanarina_vrsta_clanarine_id",
                table: "Clanarina",
                column: "vrsta_clanarine_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_clan_id",
                table: "Favorites",
                column: "clan_id");

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
                name: "IX_PrijavaGrupniTrening_clan_id",
                table: "PrijavaGrupniTrening",
                column: "clan_id");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaGrupniTrening_grupni_trening_id",
                table: "PrijavaGrupniTrening",
                column: "grupni_trening_id");

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
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "ObjavaSuplementa");

            migrationBuilder.DropTable(
                name: "PrijavaGrupniTrening");

            migrationBuilder.DropTable(
                name: "Trener");

            migrationBuilder.DropTable(
                name: "Vjezba");

            migrationBuilder.DropTable(
                name: "Suplement");

            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "GrupniTrening");

            migrationBuilder.DropTable(
                name: "Osoblje");

            migrationBuilder.DropTable(
                name: "KategorijaVjezbe");

            migrationBuilder.DropTable(
                name: "KategorijaSuplementa");

            migrationBuilder.DropTable(
                name: "Clanarina");

            migrationBuilder.DropTable(
                name: "KategorijaTreninga");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "VrstaClanarine");
        }
    }
}
