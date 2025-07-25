using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSessionDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 6);

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

            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkoutPlans",
                columns: new[] { "Id", "Duration", "Experience", "Goal", "Intensity", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 20, "Beginner", "Lose Weight", "Low", "Bodyweight", null },
                    { 2, 40, "Intermediate", "Strength", "Medium", "Gym", null },
                    { 3, 30, "Beginner", "General Fitness", "Low", "Bodyweight", null },
                    { 4, 50, "Advanced", "Build Muscle", "High", "Gym", null },
                    { 5, 35, "Beginner", "Build Muscle", "Medium", "Gym", null },
                    { 6, 30, "Beginner", "Lose Weight", "Low", "Gym", null }
                });

            migrationBuilder.InsertData(
                table: "WorkoutSessions",
                columns: new[] { "Id", "Category", "Day", "Duration", "ImagePath", "Title", "Week", "WorkoutPlanId" },
                values: new object[,]
                {
                    { 1, "Recommended", "Monday", 30, "images/workout1.jpg", "Full Body", 1, 1 },
                    { 2, "Popular", "Tuesday", 30, "images/cardiocore.jpg", "Cardio & Core", 1, 1 },
                    { 3, "Recovery", "Wednesday", 20, "images/activerecovery1.jpg", "Active Recovery", 1, 1 },
                    { 4, "", "Thursday", 25, "images/lowerbody.jpg", "Lower Body", 1, 1 },
                    { 5, "", "Friday", 30, "images/hiit.jpg", "HIIT", 1, 1 },
                    { 6, "", "Saturday", 20, "images/yoga.jpg", "Yoga", 1, 1 },
                    { 7, "", "Monday", 25, "images/fullbodyblast.jpg", "Full-Body Blast", 2, 1 },
                    { 8, "", "Tuesday", 25, "images/coreburn.jpg", "Core Focus Burn", 2, 1 },
                    { 9, "", "Monday", 30, "images/powercore.jpg", "Power Core", 3, 1 },
                    { 10, "", "Tuesday", 20, "images/mobility.jpg", "Light Flow & Mobility", 3, 1 },
                    { 11, "", "Monday", 40, "images/strength.jpg", "Strength Circuit", 4, 1 },
                    { 12, "", "Tuesday", 30, "images/agility.jpg", "Agility", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Details", "ImagePath", "Name", "WorkoutSessionId" },
                values: new object[,]
                {
                    { 1, "40 secs", "images/jumping-jack.png", "Jumping Jacks", 1 },
                    { 2, "12 reps", "images/squat.png", "Squats", 1 },
                    { 3, "10 reps", "images/pushup.png", "Push Ups", 1 },
                    { 4, "15 reps", "images/glutebridges.png", "Glute Bridges", 1 },
                    { 5, "1 min", "images/plank.png", "Plank", 1 }
                });
        }
    }
}
