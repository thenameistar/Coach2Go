using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDailyWorkoutSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "WorkoutSessions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Details", "ImagePath", "Name", "WorkoutSessionId" },
                values: new object[,]
                {
                    { 3, "10 reps", "images/pushup.png", "Push Ups", 1 },
                    { 4, "15 reps", "images/glutebridges.png", "Glute Bridges", 1 },
                    { 5, "1 min", "images/plank.png", "Plank", 1 }
                });

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImagePath", "Title" },
                values: new object[] { "images/workout1.jpg", "Full Body" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "WorkoutSessions");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Core Burn");
        }
    }
}
