using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedWorkoutData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Week",
                table: "WorkoutSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "WorkoutPlans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Intensity",
                table: "WorkoutPlans",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "WorkoutPlans",
                columns: new[] { "Id", "Duration", "Experience", "Goal", "Intensity", "Type", "UserId" },
                values: new object[] { 1, 20, "Beginner", "Lose Weight", "Low", "Bodyweight", null });

            migrationBuilder.InsertData(
                table: "WorkoutSessions",
                columns: new[] { "Id", "Title", "Week", "WorkoutPlanId" },
                values: new object[] { 1, "Core Burn", 1, 1 });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Details", "ImagePath", "Name", "WorkoutSessionId" },
                values: new object[,]
                {
                    { 1, "40 secs", "images/jumping-jack.png", "Jumping Jacks", 1 },
                    { 2, "12 reps", "images/squat.png", "Squats", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Week",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "WorkoutPlans");

            migrationBuilder.DropColumn(
                name: "Intensity",
                table: "WorkoutPlans");
        }
    }
}
