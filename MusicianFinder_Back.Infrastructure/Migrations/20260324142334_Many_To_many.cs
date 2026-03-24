using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicianFinder_Back.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Many_To_many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Instruments_Musician_MusicianId1",
                table: "Musician_Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Locations_Musician_MusicianId1",
                table: "Musician_Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Project_Types_Musician_MusicianId1",
                table: "Musician_Project_Types");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Styles_Musician_MusicianId1",
                table: "Musician_Styles");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Styles_MusicianId1",
                table: "Musician_Styles");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Project_Types_MusicianId1",
                table: "Musician_Project_Types");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Locations_MusicianId1",
                table: "Musician_Locations");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Instruments_MusicianId1",
                table: "Musician_Instruments");

            migrationBuilder.DropColumn(
                name: "MusicianId1",
                table: "Musician_Styles");

            migrationBuilder.DropColumn(
                name: "MusicianId1",
                table: "Musician_Project_Types");

            migrationBuilder.DropColumn(
                name: "MusicianId1",
                table: "Musician_Locations");

            migrationBuilder.DropColumn(
                name: "MusicianId1",
                table: "Musician_Instruments");

            migrationBuilder.AddColumn<int>(
                name: "InstrumentId1",
                table: "Musician_Instruments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ConversationId",
                table: "Musician",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Instruments_InstrumentId1",
                table: "Musician_Instruments",
                column: "InstrumentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_ConversationId",
                table: "Musician",
                column: "ConversationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Conversations_ConversationId",
                table: "Musician",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "ConversationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Instruments_Instrument_InstrumentId1",
                table: "Musician_Instruments",
                column: "InstrumentId1",
                principalTable: "Instrument",
                principalColumn: "InstrumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Conversations_ConversationId",
                table: "Musician");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Instruments_Instrument_InstrumentId1",
                table: "Musician_Instruments");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Instruments_InstrumentId1",
                table: "Musician_Instruments");

            migrationBuilder.DropIndex(
                name: "IX_Musician_ConversationId",
                table: "Musician");

            migrationBuilder.DropColumn(
                name: "InstrumentId1",
                table: "Musician_Instruments");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Musician");

            migrationBuilder.AddColumn<long>(
                name: "MusicianId1",
                table: "Musician_Styles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MusicianId1",
                table: "Musician_Project_Types",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MusicianId1",
                table: "Musician_Locations",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MusicianId1",
                table: "Musician_Instruments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Styles_MusicianId1",
                table: "Musician_Styles",
                column: "MusicianId1");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Project_Types_MusicianId1",
                table: "Musician_Project_Types",
                column: "MusicianId1");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Locations_MusicianId1",
                table: "Musician_Locations",
                column: "MusicianId1");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Instruments_MusicianId1",
                table: "Musician_Instruments",
                column: "MusicianId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Instruments_Musician_MusicianId1",
                table: "Musician_Instruments",
                column: "MusicianId1",
                principalTable: "Musician",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Locations_Musician_MusicianId1",
                table: "Musician_Locations",
                column: "MusicianId1",
                principalTable: "Musician",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Project_Types_Musician_MusicianId1",
                table: "Musician_Project_Types",
                column: "MusicianId1",
                principalTable: "Musician",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Styles_Musician_MusicianId1",
                table: "Musician_Styles",
                column: "MusicianId1",
                principalTable: "Musician",
                principalColumn: "Id");
        }
    }
}
