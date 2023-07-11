using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrammarPulse.DAL.Migrations
{
    /// <inheritdoc />
    public partial class LevelDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "A1", "Beginner" },
                    { 2, "A2", "Pre-Intermediate" },
                    { 3, "B1", "Intermediate" },
                    { 4, "B2", "Upper-Intermediate" },
                    { 5, "C1", "Advanced" },
                    { 6, "C2", "Proficient" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
