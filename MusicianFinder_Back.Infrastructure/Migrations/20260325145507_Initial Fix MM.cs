using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicianFinder_Back.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialFixMM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Musician_Styles_MusicianIdFK",
                table: "Musician_Styles");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Project_Types_MusicianIdFK",
                table: "Musician_Project_Types");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Locations_MusicianIdFK",
                table: "Musician_Locations");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Instruments_MusicianIdFK",
                table: "Musician_Instruments");

            migrationBuilder.DeleteData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 22);

            migrationBuilder.RenameIndex(
                name: "IX_Misicians__Email",
                table: "Musician",
                newName: "IX_Musicians__Email");

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "Project_Type",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StyleName",
                table: "Music_Style",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Location",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InstrumentName",
                table: "Instrument",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 1,
                column: "StyleName",
                value: "Chanson");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 2,
                column: "StyleName",
                value: "Pop");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 3,
                column: "StyleName",
                value: "Rock / Rock alternatif");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 4,
                column: "StyleName",
                value: "Metal");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 5,
                column: "StyleName",
                value: "Punk");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 6,
                column: "StyleName",
                value: "Folk / Acoustique");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 7,
                column: "StyleName",
                value: "Jazz");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 8,
                column: "StyleName",
                value: "Blues");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 9,
                column: "StyleName",
                value: "Soul / R&B / Funk");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 10,
                column: "StyleName",
                value: "Rap / Hip‑Hop / Slam");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 11,
                column: "StyleName",
                value: "Electro / EDM / Ambient");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 12,
                column: "StyleName",
                value: "Classique / Contemporain");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 13,
                column: "StyleName",
                value: "Baroque / Ancien");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 14,
                column: "StyleName",
                value: "Chorale / Voix d'ensemble");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 15,
                column: "StyleName",
                value: "Trad / World");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 16,
                column: "StyleName",
                value: "Reggae / Ska");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 17,
                column: "StyleName",
                value: "Country");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 18,
                column: "StyleName",
                value: "Jeune Public");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 19,
                column: "StyleName",
                value: "Covers");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 20,
                column: "StyleName",
                value: "Expérimental / Avant‑garde");

            migrationBuilder.CreateIndex(
                name: "UX_Musician_Style_Unique",
                table: "Musician_Styles",
                columns: new[] { "MusicianIdFK", "StyleIdFK" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Musician_Project_Unique",
                table: "Musician_Project_Types",
                columns: new[] { "MusicianIdFK", "ProjectTypeIdFK" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Musician_Location_Unique",
                table: "Musician_Locations",
                columns: new[] { "MusicianIdFK", "LocationIdFK" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Musician_Instrument_Unique",
                table: "Musician_Instruments",
                columns: new[] { "MusicianIdFK", "InstrumentIdFK" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UX_Musician_Style_Unique",
                table: "Musician_Styles");

            migrationBuilder.DropIndex(
                name: "UX_Musician_Project_Unique",
                table: "Musician_Project_Types");

            migrationBuilder.DropIndex(
                name: "UX_Musician_Location_Unique",
                table: "Musician_Locations");

            migrationBuilder.DropIndex(
                name: "UX_Musician_Instrument_Unique",
                table: "Musician_Instruments");

            migrationBuilder.RenameIndex(
                name: "IX_Musicians__Email",
                table: "Musician",
                newName: "IX_Misicians__Email");

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "Project_Type",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "StyleName",
                table: "Music_Style",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Location",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "InstrumentName",
                table: "Instrument",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 1,
                column: "StyleName",
                value: "Pop");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 2,
                column: "StyleName",
                value: "Rock");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 3,
                column: "StyleName",
                value: "Metal");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 4,
                column: "StyleName",
                value: "Punk/Hardcore");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 5,
                column: "StyleName",
                value: "Rock alternatif/post/indie");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 6,
                column: "StyleName",
                value: "Folk");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 7,
                column: "StyleName",
                value: "Chanson");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 8,
                column: "StyleName",
                value: "Electro");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 9,
                column: "StyleName",
                value: "Rap/Hip-Hop");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 10,
                column: "StyleName",
                value: "Soul");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 11,
                column: "StyleName",
                value: "Funk");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 12,
                column: "StyleName",
                value: "Jeune Public");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 13,
                column: "StyleName",
                value: "Jazz");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 14,
                column: "StyleName",
                value: "Classique/Contemporain");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 15,
                column: "StyleName",
                value: "Baroque/Ancien");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 16,
                column: "StyleName",
                value: "Chorale");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 17,
                column: "StyleName",
                value: "Reggae");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 18,
                column: "StyleName",
                value: "Blues");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 19,
                column: "StyleName",
                value: "Trad/World");

            migrationBuilder.UpdateData(
                table: "Music_Style",
                keyColumn: "StyleId",
                keyValue: 20,
                column: "StyleName",
                value: "Country");

            migrationBuilder.InsertData(
                table: "Music_Style",
                columns: new[] { "StyleId", "StyleName" },
                values: new object[] { 22, "Cover" });

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Styles_MusicianIdFK",
                table: "Musician_Styles",
                column: "MusicianIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Project_Types_MusicianIdFK",
                table: "Musician_Project_Types",
                column: "MusicianIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Locations_MusicianIdFK",
                table: "Musician_Locations",
                column: "MusicianIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Instruments_MusicianIdFK",
                table: "Musician_Instruments",
                column: "MusicianIdFK");
        }
    }
}
