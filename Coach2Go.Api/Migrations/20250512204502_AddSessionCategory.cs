using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSessionCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "WorkoutSessions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Category",
                value: "Recommended");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Category",
                value: "Popular");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Category",
                value: "Recovery");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Category",
                value: "");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Category",
                value: "");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Category",
                value: "");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Category",
                value: "");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Category",
                value: "");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Category",
                value: "");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Category",
                value: "");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Category",
                value: "");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Category",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "WorkoutSessions");
        }
    }
}
