using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicianFinder_Back.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModMusician : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TextColor",
                table: "Musician",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "#052d3d",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "#052d3d");

            migrationBuilder.AlterColumn<string>(
                name: "FontFamily",
                table: "Musician",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "SourceSans3",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "SourceSans3");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Musician",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<string>(
                name: "BgColor",
                table: "Musician",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "#FFFFFF",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "#FFFFFF");

            migrationBuilder.AlterColumn<int>(
                name: "Availability",
                table: "Musician",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<int>(
                name: "Ability",
                table: "Musician",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
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
                defaultValue: "#052d3d",
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldDefaultValue: "#052d3d");

            migrationBuilder.AlterColumn<string>(
                name: "FontFamily",
                table: "Musician",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "SourceSans3",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "SourceSans3");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Musician",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BgColor",
                table: "Musician",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "#FFFFFF",
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldDefaultValue: "#FFFFFF");

            migrationBuilder.AlterColumn<string>(
                name: "Availability",
                table: "Musician",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ability",
                table: "Musician",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
