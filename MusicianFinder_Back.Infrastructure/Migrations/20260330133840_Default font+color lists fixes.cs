using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicianFinder_Back.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Defaultfontcolorlistsfixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TextColor",
                table: "Musician",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "#052d3d",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "#49444e");

            migrationBuilder.AlterColumn<string>(
                name: "FontFamily",
                table: "Musician",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "SourceSans3",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "Arial");

            migrationBuilder.UpdateData(
                table: "Instrument",
                keyColumn: "InstrumentId",
                keyValue: 10,
                column: "InstrumentName",
                value: "Claviers / Synth");

            migrationBuilder.UpdateData(
                table: "Instrument",
                keyColumn: "InstrumentId",
                keyValue: 13,
                column: "InstrumentName",
                value: "Violon / Alto");

            migrationBuilder.UpdateData(
                table: "Instrument",
                keyColumn: "InstrumentId",
                keyValue: 22,
                column: "InstrumentName",
                value: "Hautbois / Basson");

            migrationBuilder.UpdateData(
                table: "Instrument",
                keyColumn: "InstrumentId",
                keyValue: 27,
                column: "InstrumentName",
                value: "Turntable / DJ");

            migrationBuilder.UpdateData(
                table: "Location",
                keyColumn: "LocationId",
                keyValue: 7,
                column: "LocationName",
                value: "Hainaut / Charleroi");

            migrationBuilder.UpdateData(
                table: "Location",
                keyColumn: "LocationId",
                keyValue: 8,
                column: "LocationName",
                value: "Hainaut / Mons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TextColor",
                table: "Musician",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "#49444e",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "#052d3d");

            migrationBuilder.AlterColumn<string>(
                name: "FontFamily",
                table: "Musician",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "Arial",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "SourceSans3");

            migrationBuilder.UpdateData(
                table: "Instrument",
                keyColumn: "InstrumentId",
                keyValue: 10,
                column: "InstrumentName",
                value: "Claviers/Synth");

            migrationBuilder.UpdateData(
                table: "Instrument",
                keyColumn: "InstrumentId",
                keyValue: 13,
                column: "InstrumentName",
                value: "Violon/Alto");

            migrationBuilder.UpdateData(
                table: "Instrument",
                keyColumn: "InstrumentId",
                keyValue: 22,
                column: "InstrumentName",
                value: "Hautbois/Basson");

            migrationBuilder.UpdateData(
                table: "Instrument",
                keyColumn: "InstrumentId",
                keyValue: 27,
                column: "InstrumentName",
                value: "Turntable/DJ");

            migrationBuilder.UpdateData(
                table: "Location",
                keyColumn: "LocationId",
                keyValue: 7,
                column: "LocationName",
                value: "Hainaut/Mons");

            migrationBuilder.UpdateData(
                table: "Location",
                keyColumn: "LocationId",
                keyValue: 8,
                column: "LocationName",
                value: "Hainaut/Charleroi");
        }
    }
}
