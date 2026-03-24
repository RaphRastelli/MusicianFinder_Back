using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicianFinder_Back.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Many_To_many2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Instruments_Instrument_InstrumentId",
                table: "Musician_Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Instruments_Instrument_InstrumentId1",
                table: "Musician_Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Instruments_Musician_MusicianId",
                table: "Musician_Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Locations_Location_LocationId",
                table: "Musician_Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Locations_Musician_MusicianId",
                table: "Musician_Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Project_Types_Musician_MusicianId",
                table: "Musician_Project_Types");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Project_Types_Project_Type_ProjectTypeId",
                table: "Musician_Project_Types");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Styles_Music_Style_MusicianStyleId",
                table: "Musician_Styles");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Styles_Musician_MusicianId",
                table: "Musician_Styles");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Instruments_InstrumentId1",
                table: "Musician_Instruments");

            migrationBuilder.DropColumn(
                name: "InstrumentId1",
                table: "Musician_Instruments");

            migrationBuilder.RenameColumn(
                name: "StyleId",
                table: "Musician_Styles",
                newName: "StyleIdFK");

            migrationBuilder.RenameColumn(
                name: "MusicianId",
                table: "Musician_Styles",
                newName: "MusicianIdFK");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Styles_MusicianId",
                table: "Musician_Styles",
                newName: "IX_Musician_Styles_MusicianIdFK");

            migrationBuilder.RenameColumn(
                name: "ProjectTypeId",
                table: "Musician_Project_Types",
                newName: "ProjectTypeIdFK");

            migrationBuilder.RenameColumn(
                name: "MusicianId",
                table: "Musician_Project_Types",
                newName: "MusicianIdFK");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Project_Types_ProjectTypeId",
                table: "Musician_Project_Types",
                newName: "IX_Musician_Project_Types_ProjectTypeIdFK");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Project_Types_MusicianId",
                table: "Musician_Project_Types",
                newName: "IX_Musician_Project_Types_MusicianIdFK");

            migrationBuilder.RenameColumn(
                name: "MusicianId",
                table: "Musician_Locations",
                newName: "MusicianIdFK");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Musician_Locations",
                newName: "LocationIdFK");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Locations_MusicianId",
                table: "Musician_Locations",
                newName: "IX_Musician_Locations_MusicianIdFK");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Locations_LocationId",
                table: "Musician_Locations",
                newName: "IX_Musician_Locations_LocationIdFK");

            migrationBuilder.RenameColumn(
                name: "MusicianId",
                table: "Musician_Instruments",
                newName: "MusicianIdFK");

            migrationBuilder.RenameColumn(
                name: "InstrumentId",
                table: "Musician_Instruments",
                newName: "InstrumentIdFK");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Instruments_MusicianId",
                table: "Musician_Instruments",
                newName: "IX_Musician_Instruments_MusicianIdFK");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Instruments_InstrumentId",
                table: "Musician_Instruments",
                newName: "IX_Musician_Instruments_InstrumentIdFK");

            migrationBuilder.AlterColumn<int>(
                name: "MusicianStyleId",
                table: "Musician_Styles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Styles_StyleIdFK",
                table: "Musician_Styles",
                column: "StyleIdFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Instruments_Instrument_InstrumentIdFK",
                table: "Musician_Instruments",
                column: "InstrumentIdFK",
                principalTable: "Instrument",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Instruments_Musician_MusicianIdFK",
                table: "Musician_Instruments",
                column: "MusicianIdFK",
                principalTable: "Musician",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Locations_Location_LocationIdFK",
                table: "Musician_Locations",
                column: "LocationIdFK",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Locations_Musician_MusicianIdFK",
                table: "Musician_Locations",
                column: "MusicianIdFK",
                principalTable: "Musician",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Project_Types_Musician_MusicianIdFK",
                table: "Musician_Project_Types",
                column: "MusicianIdFK",
                principalTable: "Musician",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Project_Types_Project_Type_ProjectTypeIdFK",
                table: "Musician_Project_Types",
                column: "ProjectTypeIdFK",
                principalTable: "Project_Type",
                principalColumn: "ProjectTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Styles_Music_Style_StyleIdFK",
                table: "Musician_Styles",
                column: "StyleIdFK",
                principalTable: "Music_Style",
                principalColumn: "StyleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Styles_Musician_MusicianIdFK",
                table: "Musician_Styles",
                column: "MusicianIdFK",
                principalTable: "Musician",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Instruments_Instrument_InstrumentIdFK",
                table: "Musician_Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Instruments_Musician_MusicianIdFK",
                table: "Musician_Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Locations_Location_LocationIdFK",
                table: "Musician_Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Locations_Musician_MusicianIdFK",
                table: "Musician_Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Project_Types_Musician_MusicianIdFK",
                table: "Musician_Project_Types");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Project_Types_Project_Type_ProjectTypeIdFK",
                table: "Musician_Project_Types");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Styles_Music_Style_StyleIdFK",
                table: "Musician_Styles");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Styles_Musician_MusicianIdFK",
                table: "Musician_Styles");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Styles_StyleIdFK",
                table: "Musician_Styles");

            migrationBuilder.RenameColumn(
                name: "StyleIdFK",
                table: "Musician_Styles",
                newName: "StyleId");

            migrationBuilder.RenameColumn(
                name: "MusicianIdFK",
                table: "Musician_Styles",
                newName: "MusicianId");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Styles_MusicianIdFK",
                table: "Musician_Styles",
                newName: "IX_Musician_Styles_MusicianId");

            migrationBuilder.RenameColumn(
                name: "ProjectTypeIdFK",
                table: "Musician_Project_Types",
                newName: "ProjectTypeId");

            migrationBuilder.RenameColumn(
                name: "MusicianIdFK",
                table: "Musician_Project_Types",
                newName: "MusicianId");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Project_Types_ProjectTypeIdFK",
                table: "Musician_Project_Types",
                newName: "IX_Musician_Project_Types_ProjectTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Project_Types_MusicianIdFK",
                table: "Musician_Project_Types",
                newName: "IX_Musician_Project_Types_MusicianId");

            migrationBuilder.RenameColumn(
                name: "MusicianIdFK",
                table: "Musician_Locations",
                newName: "MusicianId");

            migrationBuilder.RenameColumn(
                name: "LocationIdFK",
                table: "Musician_Locations",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Locations_MusicianIdFK",
                table: "Musician_Locations",
                newName: "IX_Musician_Locations_MusicianId");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Locations_LocationIdFK",
                table: "Musician_Locations",
                newName: "IX_Musician_Locations_LocationId");

            migrationBuilder.RenameColumn(
                name: "MusicianIdFK",
                table: "Musician_Instruments",
                newName: "MusicianId");

            migrationBuilder.RenameColumn(
                name: "InstrumentIdFK",
                table: "Musician_Instruments",
                newName: "InstrumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Instruments_MusicianIdFK",
                table: "Musician_Instruments",
                newName: "IX_Musician_Instruments_MusicianId");

            migrationBuilder.RenameIndex(
                name: "IX_Musician_Instruments_InstrumentIdFK",
                table: "Musician_Instruments",
                newName: "IX_Musician_Instruments_InstrumentId");

            migrationBuilder.AlterColumn<int>(
                name: "MusicianStyleId",
                table: "Musician_Styles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "InstrumentId1",
                table: "Musician_Instruments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Instruments_InstrumentId1",
                table: "Musician_Instruments",
                column: "InstrumentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Instruments_Instrument_InstrumentId",
                table: "Musician_Instruments",
                column: "InstrumentId",
                principalTable: "Instrument",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Instruments_Instrument_InstrumentId1",
                table: "Musician_Instruments",
                column: "InstrumentId1",
                principalTable: "Instrument",
                principalColumn: "InstrumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Instruments_Musician_MusicianId",
                table: "Musician_Instruments",
                column: "MusicianId",
                principalTable: "Musician",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Locations_Location_LocationId",
                table: "Musician_Locations",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Locations_Musician_MusicianId",
                table: "Musician_Locations",
                column: "MusicianId",
                principalTable: "Musician",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Project_Types_Musician_MusicianId",
                table: "Musician_Project_Types",
                column: "MusicianId",
                principalTable: "Musician",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Project_Types_Project_Type_ProjectTypeId",
                table: "Musician_Project_Types",
                column: "ProjectTypeId",
                principalTable: "Project_Type",
                principalColumn: "ProjectTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Styles_Music_Style_MusicianStyleId",
                table: "Musician_Styles",
                column: "MusicianStyleId",
                principalTable: "Music_Style",
                principalColumn: "StyleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Styles_Musician_MusicianId",
                table: "Musician_Styles",
                column: "MusicianId",
                principalTable: "Musician",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
