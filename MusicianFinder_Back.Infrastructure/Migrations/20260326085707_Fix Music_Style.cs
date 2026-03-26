using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicianFinder_Back.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixMusic_Style : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 6,
                column: "StyleName",
                value: "Folk");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 11,
                column: "StyleName",
                value: "Electro / EDM");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 14,
                column: "StyleName",
                value: "Chorale / Ensemble vocal");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 20,
                column: "StyleName",
                value: "Expérimental");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 6,
                column: "StyleName",
                value: "Folk / Acoustique");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 11,
                column: "StyleName",
                value: "Electro / EDM / Ambient");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 14,
                column: "StyleName",
                value: "Chorale / Voix d'ensemble");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 20,
                column: "StyleName",
                value: "Expérimental / Avant‑garde");
        }
    }
}
