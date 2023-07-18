using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrammarPulse.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVersionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Versions");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Versions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Versions",
                columns: new[] { "Id", "Version" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Versions");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Versions",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");
        }
    }
}
