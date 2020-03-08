using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PodaciBiblioteke.Migrations
{
    public partial class DodavanjeEntiteta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KarticaId",
                table: "Klijent",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrenutnaBibliotekaID",
                table: "Klijent",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kartice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naknade = table.Column<decimal>(nullable: false),
                    DatumKreiranja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kartice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poslovnice",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 30, nullable: false),
                    Adresa = table.Column<string>(nullable: false),
                    Telefon = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    DatumOtvaranja = table.Column<DateTime>(nullable: false),
                    UrlSlike = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poslovnice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Statusi",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statusi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RadnoVrijemePoslovnica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoslovnicaID = table.Column<int>(nullable: true),
                    DanUSedmici = table.Column<int>(nullable: false),
                    VrijemeOtvaranja = table.Column<int>(nullable: false),
                    VrijemeZatvaranja = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadnoVrijemePoslovnica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadnoVrijemePoslovnica_Poslovnice_PoslovnicaID",
                        column: x => x.PoslovnicaID,
                        principalTable: "Poslovnice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Djelo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Godina = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    Cijena = table.Column<decimal>(nullable: false),
                    UrlSlike = table.Column<string>(nullable: true),
                    BrojKopija = table.Column<int>(nullable: false),
                    PoslovnicaBibliotekeID = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: true),
                    Autor = table.Column<string>(nullable: true),
                    DeweyIndex = table.Column<string>(nullable: true),
                    Reziser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Djelo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Djelo_Poslovnice_PoslovnicaBibliotekeID",
                        column: x => x.PoslovnicaBibliotekeID,
                        principalTable: "Poslovnice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Djelo_Statusi_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statusi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dolasci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DjeloID = table.Column<int>(nullable: false),
                    KarticaId = table.Column<int>(nullable: true),
                    DatumPrijave = table.Column<DateTime>(nullable: false),
                    DatumOdjave = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dolasci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dolasci_Djelo_DjeloID",
                        column: x => x.DjeloID,
                        principalTable: "Djelo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dolasci_Kartice_KarticaId",
                        column: x => x.KarticaId,
                        principalTable: "Kartice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistorijeDolazaka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DjeloID = table.Column<int>(nullable: false),
                    KarticaId = table.Column<int>(nullable: false),
                    DatumPrijave = table.Column<DateTime>(nullable: false),
                    DatumOdjave = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorijeDolazaka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorijeDolazaka_Djelo_DjeloID",
                        column: x => x.DjeloID,
                        principalTable: "Djelo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorijeDolazaka_Kartice_KarticaId",
                        column: x => x.KarticaId,
                        principalTable: "Kartice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZahtjeviZaIznajmljivanje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DjeloID = table.Column<int>(nullable: true),
                    KarticaId = table.Column<int>(nullable: true),
                    DatumPodnosenjaZahtjeva = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtjeviZaIznajmljivanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZahtjeviZaIznajmljivanje_Djelo_DjeloID",
                        column: x => x.DjeloID,
                        principalTable: "Djelo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZahtjeviZaIznajmljivanje_Kartice_KarticaId",
                        column: x => x.KarticaId,
                        principalTable: "Kartice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_KarticaId",
                table: "Klijent",
                column: "KarticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_TrenutnaBibliotekaID",
                table: "Klijent",
                column: "TrenutnaBibliotekaID");

            migrationBuilder.CreateIndex(
                name: "IX_Djelo_PoslovnicaBibliotekeID",
                table: "Djelo",
                column: "PoslovnicaBibliotekeID");

            migrationBuilder.CreateIndex(
                name: "IX_Djelo_StatusID",
                table: "Djelo",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Dolasci_DjeloID",
                table: "Dolasci",
                column: "DjeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Dolasci_KarticaId",
                table: "Dolasci",
                column: "KarticaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorijeDolazaka_DjeloID",
                table: "HistorijeDolazaka",
                column: "DjeloID");

            migrationBuilder.CreateIndex(
                name: "IX_HistorijeDolazaka_KarticaId",
                table: "HistorijeDolazaka",
                column: "KarticaId");

            migrationBuilder.CreateIndex(
                name: "IX_RadnoVrijemePoslovnica_PoslovnicaID",
                table: "RadnoVrijemePoslovnica",
                column: "PoslovnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtjeviZaIznajmljivanje_DjeloID",
                table: "ZahtjeviZaIznajmljivanje",
                column: "DjeloID");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtjeviZaIznajmljivanje_KarticaId",
                table: "ZahtjeviZaIznajmljivanje",
                column: "KarticaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klijent_Kartice_KarticaId",
                table: "Klijent",
                column: "KarticaId",
                principalTable: "Kartice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Klijent_Poslovnice_TrenutnaBibliotekaID",
                table: "Klijent",
                column: "TrenutnaBibliotekaID",
                principalTable: "Poslovnice",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klijent_Kartice_KarticaId",
                table: "Klijent");

            migrationBuilder.DropForeignKey(
                name: "FK_Klijent_Poslovnice_TrenutnaBibliotekaID",
                table: "Klijent");

            migrationBuilder.DropTable(
                name: "Dolasci");

            migrationBuilder.DropTable(
                name: "HistorijeDolazaka");

            migrationBuilder.DropTable(
                name: "RadnoVrijemePoslovnica");

            migrationBuilder.DropTable(
                name: "ZahtjeviZaIznajmljivanje");

            migrationBuilder.DropTable(
                name: "Djelo");

            migrationBuilder.DropTable(
                name: "Kartice");

            migrationBuilder.DropTable(
                name: "Poslovnice");

            migrationBuilder.DropTable(
                name: "Statusi");

            migrationBuilder.DropIndex(
                name: "IX_Klijent_KarticaId",
                table: "Klijent");

            migrationBuilder.DropIndex(
                name: "IX_Klijent_TrenutnaBibliotekaID",
                table: "Klijent");

            migrationBuilder.DropColumn(
                name: "KarticaId",
                table: "Klijent");

            migrationBuilder.DropColumn(
                name: "TrenutnaBibliotekaID",
                table: "Klijent");
        }
    }
}
