using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDurationToWorkoutSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "WorkoutSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 0);

            migrationBuilder.InsertData(
                table: "WorkoutSessions",
                columns: new[] { "Id", "Duration", "ImagePath", "Title", "Week", "WorkoutPlanId" },
                values: new object[,]
                {
                    { 2, 0, "images/cardiocore.jpg", "Cardio & Core", 1, 1 },
                    { 3, 0, "images/activerecovery.jpg", "Active Recovery", 1, 1 },
                    { 4, 0, "images/lowerbody.jpg", "Lower Body", 1, 1 },
                    { 5, 0, "images/hiit.jpg", " HIIT", 1, 1 },
                    { 6, 0, "images/yoga.jpg", "Yoga", 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "WorkoutSessions");
        }
    }
}
