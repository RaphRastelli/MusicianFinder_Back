using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicianFinder_Back.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    ConversationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastRead = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.ConversationId);
                });

            migrationBuilder.CreateTable(
                name: "Instrument",
                columns: table => new
                {
                    InstrumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument", x => x.InstrumentId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Music_Style",
                columns: table => new
                {
                    StyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music_Style", x => x.StyleId);
                });

            migrationBuilder.CreateTable(
                name: "Project_Type",
                columns: table => new
                {
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Type", x => x.ProjectTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Musician",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password_hashed = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "User"),
                    Ability = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BgColor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "#FFFFFF"),
                    FontFamily = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Arial"),
                    TextColor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "#000000"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConversationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Musician_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "ConversationId");
                });

            migrationBuilder.CreateTable(
                name: "Convers_Particip",
                columns: table => new
                {
                    ConvPartId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicianId = table.Column<long>(type: "bigint", nullable: false),
                    ConversationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversParticip", x => x.ConvPartId);
                    table.ForeignKey(
                        name: "FK_Convers_Particip_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Convers_Particip_Musician_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversationId = table.Column<long>(type: "bigint", nullable: false),
                    SenderMusicianId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsSuppressed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Musician_SenderMusicianId",
                        column: x => x.SenderMusicianId,
                        principalTable: "Musician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musician_Instruments",
                columns: table => new
                {
                    MusInstrumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicianIdFK = table.Column<long>(type: "bigint", nullable: false),
                    InstrumentIdFK = table.Column<int>(type: "int", nullable: false),
                    Is_Main_Instrument = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician_Instruments", x => x.MusInstrumentId);
                    table.ForeignKey(
                        name: "FK_Musician_Instruments_Instrument_InstrumentIdFK",
                        column: x => x.InstrumentIdFK,
                        principalTable: "Instrument",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musician_Instruments_Musician_MusicianIdFK",
                        column: x => x.MusicianIdFK,
                        principalTable: "Musician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musician_Locations",
                columns: table => new
                {
                    MusicianLocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicianIdFK = table.Column<long>(type: "bigint", nullable: false),
                    LocationIdFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician_Locations", x => x.MusicianLocId);
                    table.ForeignKey(
                        name: "FK_Musician_Locations_Location_LocationIdFK",
                        column: x => x.LocationIdFK,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musician_Locations_Musician_MusicianIdFK",
                        column: x => x.MusicianIdFK,
                        principalTable: "Musician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musician_Project_Types",
                columns: table => new
                {
                    MusProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicianIdFK = table.Column<long>(type: "bigint", nullable: false),
                    ProjectTypeIdFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician_Project_Types", x => x.MusProjectId);
                    table.ForeignKey(
                        name: "FK_Musician_Project_Types_Musician_MusicianIdFK",
                        column: x => x.MusicianIdFK,
                        principalTable: "Musician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musician_Project_Types_Project_Type_ProjectTypeIdFK",
                        column: x => x.ProjectTypeIdFK,
                        principalTable: "Project_Type",
                        principalColumn: "ProjectTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musician_Styles",
                columns: table => new
                {
                    MusicianStyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicianIdFK = table.Column<long>(type: "bigint", nullable: false),
                    StyleIdFK = table.Column<int>(type: "int", nullable: false),
                    Is_Main_Style = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician_Styles", x => x.MusicianStyleId);
                    table.ForeignKey(
                        name: "FK_Musician_Styles_Music_Style_StyleIdFK",
                        column: x => x.StyleIdFK,
                        principalTable: "Music_Style",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musician_Styles_Musician_MusicianIdFK",
                        column: x => x.MusicianIdFK,
                        principalTable: "Musician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instrument",
                columns: new[] { "InstrumentId", "InstrumentName" },
                values: new object[,]
                {
                    { 1, "Chant masculin" },
                    { 2, "Chant féminin" },
                    { 3, "Guitare acoustique" },
                    { 4, "Guitare électrique" },
                    { 5, "Lap-Steel" },
                    { 6, "Basse" },
                    { 7, "Batterie" },
                    { 8, "Percussions d’orchestre" },
                    { 9, "Piano" },
                    { 10, "Claviers/Synth" },
                    { 11, "Clavecin" },
                    { 12, "Orgue classique" },
                    { 13, "Violon/Alto" },
                    { 14, "Violoncelle" },
                    { 15, "Contrebasse" },
                    { 16, "Trompette" },
                    { 17, "Trombone" },
                    { 18, "Saxophone" },
                    { 19, "Tuba" },
                    { 20, "Clarinette" },
                    { 21, "Flûte traversière" },
                    { 22, "Hautbois/Basson" },
                    { 23, "Cornemuse" },
                    { 24, "Accordéon" },
                    { 25, "Banjo" },
                    { 26, "Luth" },
                    { 27, "Turntable/DJ" },
                    { 28, "Autre instrument acoustique" },
                    { 29, "Autre instrument électrique" },
                    { 30, "Autre instrument électronique" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationId", "LocationName" },
                values: new object[,]
                {
                    { 1, "Bruxelles" },
                    { 2, "Brabant" },
                    { 3, "Namur (ville)" },
                    { 4, "Namur (province)" },
                    { 5, "Liège (ville)" },
                    { 6, "Liège (province)" },
                    { 7, "Hainaut/Mons" },
                    { 8, "Hainaut/Charleroi" },
                    { 9, "Luxembourg" },
                    { 10, "Anvers (ville)" },
                    { 11, "Anvers (province)" },
                    { 12, "Limbourg" },
                    { 13, "Flandre Orientale" },
                    { 14, "Flandre Occidentale" }
                });

            migrationBuilder.InsertData(
                table: "Music_Style",
                columns: new[] { "StyleId", "StyleName" },
                values: new object[,]
                {
                    { 1, "Pop" },
                    { 2, "Rock" },
                    { 3, "Metal" },
                    { 4, "Punk/Hardcore" },
                    { 5, "Rock alternatif/post/indie" },
                    { 6, "Folk" },
                    { 7, "Chanson" },
                    { 8, "Electro" },
                    { 9, "Rap/Hip-Hop" },
                    { 10, "Soul" },
                    { 11, "Funk" },
                    { 12, "Jeune Public" },
                    { 13, "Jazz" },
                    { 14, "Classique/Contemporain" },
                    { 15, "Baroque/Ancien" },
                    { 16, "Chorale" },
                    { 17, "Reggae" },
                    { 18, "Blues" },
                    { 19, "Trad/World" },
                    { 20, "Country" },
                    { 21, "Fanfare" },
                    { 22, "Cover" }
                });

            migrationBuilder.InsertData(
                table: "Project_Type",
                columns: new[] { "ProjectTypeId", "TypeName" },
                values: new object[,]
                {
                    { 1, "LongTermeSansGarantie" },
                    { 2, "LongTermAvecGarantie" },
                    { 3, "PonctuelSansGarantie" },
                    { 4, "PonctuelAvecGarantie" },
                    { 5, "Cours" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Convers_Particip_ConversationId",
                table: "Convers_Particip",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Convers_Particip_MusicianId",
                table: "Convers_Particip",
                column: "MusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationId",
                table: "Messages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderMusicianId",
                table: "Messages",
                column: "SenderMusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Misicians__Email",
                table: "Musician",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musician_ConversationId",
                table: "Musician",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Instruments_InstrumentIdFK",
                table: "Musician_Instruments",
                column: "InstrumentIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Instruments_MusicianIdFK",
                table: "Musician_Instruments",
                column: "MusicianIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Locations_LocationIdFK",
                table: "Musician_Locations",
                column: "LocationIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Locations_MusicianIdFK",
                table: "Musician_Locations",
                column: "MusicianIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Project_Types_MusicianIdFK",
                table: "Musician_Project_Types",
                column: "MusicianIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Project_Types_ProjectTypeIdFK",
                table: "Musician_Project_Types",
                column: "ProjectTypeIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Styles_MusicianIdFK",
                table: "Musician_Styles",
                column: "MusicianIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Styles_StyleIdFK",
                table: "Musician_Styles",
                column: "StyleIdFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Convers_Particip");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Musician_Instruments");

            migrationBuilder.DropTable(
                name: "Musician_Locations");

            migrationBuilder.DropTable(
                name: "Musician_Project_Types");

            migrationBuilder.DropTable(
                name: "Musician_Styles");

            migrationBuilder.DropTable(
                name: "Instrument");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Project_Type");

            migrationBuilder.DropTable(
                name: "Music_Style");

            migrationBuilder.DropTable(
                name: "Musician");

            migrationBuilder.DropTable(
                name: "Conversations");
        }
    }
}
