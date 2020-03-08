using Microsoft.EntityFrameworkCore.Migrations;

namespace PodaciBiblioteke.Migrations
{
    public partial class RenameDolazaka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dolasci_Djelo_DjeloID",
                table: "Dolasci");

            migrationBuilder.DropForeignKey(
                name: "FK_Dolasci_Kartice_KarticaId",
                table: "Dolasci");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorijeDolazaka_Djelo_DjeloID",
                table: "HistorijeDolazaka");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorijeDolazaka_Kartice_KarticaId",
                table: "HistorijeDolazaka");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistorijeDolazaka",
                table: "HistorijeDolazaka");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dolasci",
                table: "Dolasci");

            migrationBuilder.RenameTable(
                name: "HistorijeDolazaka",
                newName: "HistorijaIznajmljivanja");

            migrationBuilder.RenameTable(
                name: "Dolasci",
                newName: "Iznajmljivanje");

            migrationBuilder.RenameIndex(
                name: "IX_HistorijeDolazaka_KarticaId",
                table: "HistorijaIznajmljivanja",
                newName: "IX_HistorijaIznajmljivanja_KarticaId");

            migrationBuilder.RenameIndex(
                name: "IX_HistorijeDolazaka_DjeloID",
                table: "HistorijaIznajmljivanja",
                newName: "IX_HistorijaIznajmljivanja_DjeloID");

            migrationBuilder.RenameIndex(
                name: "IX_Dolasci_KarticaId",
                table: "Iznajmljivanje",
                newName: "IX_Iznajmljivanje_KarticaId");

            migrationBuilder.RenameIndex(
                name: "IX_Dolasci_DjeloID",
                table: "Iznajmljivanje",
                newName: "IX_Iznajmljivanje_DjeloID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistorijaIznajmljivanja",
                table: "HistorijaIznajmljivanja",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Iznajmljivanje",
                table: "Iznajmljivanje",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorijaIznajmljivanja_Djelo_DjeloID",
                table: "HistorijaIznajmljivanja",
                column: "DjeloID",
                principalTable: "Djelo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorijaIznajmljivanja_Kartice_KarticaId",
                table: "HistorijaIznajmljivanja",
                column: "KarticaId",
                principalTable: "Kartice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Iznajmljivanje_Djelo_DjeloID",
                table: "Iznajmljivanje",
                column: "DjeloID",
                principalTable: "Djelo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Iznajmljivanje_Kartice_KarticaId",
                table: "Iznajmljivanje",
                column: "KarticaId",
                principalTable: "Kartice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorijaIznajmljivanja_Djelo_DjeloID",
                table: "HistorijaIznajmljivanja");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorijaIznajmljivanja_Kartice_KarticaId",
                table: "HistorijaIznajmljivanja");

            migrationBuilder.DropForeignKey(
                name: "FK_Iznajmljivanje_Djelo_DjeloID",
                table: "Iznajmljivanje");

            migrationBuilder.DropForeignKey(
                name: "FK_Iznajmljivanje_Kartice_KarticaId",
                table: "Iznajmljivanje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Iznajmljivanje",
                table: "Iznajmljivanje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistorijaIznajmljivanja",
                table: "HistorijaIznajmljivanja");

            migrationBuilder.RenameTable(
                name: "Iznajmljivanje",
                newName: "Dolasci");

            migrationBuilder.RenameTable(
                name: "HistorijaIznajmljivanja",
                newName: "HistorijeDolazaka");

            migrationBuilder.RenameIndex(
                name: "IX_Iznajmljivanje_KarticaId",
                table: "Dolasci",
                newName: "IX_Dolasci_KarticaId");

            migrationBuilder.RenameIndex(
                name: "IX_Iznajmljivanje_DjeloID",
                table: "Dolasci",
                newName: "IX_Dolasci_DjeloID");

            migrationBuilder.RenameIndex(
                name: "IX_HistorijaIznajmljivanja_KarticaId",
                table: "HistorijeDolazaka",
                newName: "IX_HistorijeDolazaka_KarticaId");

            migrationBuilder.RenameIndex(
                name: "IX_HistorijaIznajmljivanja_DjeloID",
                table: "HistorijeDolazaka",
                newName: "IX_HistorijeDolazaka_DjeloID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dolasci",
                table: "Dolasci",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistorijeDolazaka",
                table: "HistorijeDolazaka",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dolasci_Djelo_DjeloID",
                table: "Dolasci",
                column: "DjeloID",
                principalTable: "Djelo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dolasci_Kartice_KarticaId",
                table: "Dolasci",
                column: "KarticaId",
                principalTable: "Kartice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorijeDolazaka_Djelo_DjeloID",
                table: "HistorijeDolazaka",
                column: "DjeloID",
                principalTable: "Djelo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorijeDolazaka_Kartice_KarticaId",
                table: "HistorijeDolazaka",
                column: "KarticaId",
                principalTable: "Kartice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
