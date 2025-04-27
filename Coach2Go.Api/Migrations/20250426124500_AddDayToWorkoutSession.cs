using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDayToWorkoutSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "WorkoutSessions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Day", "Duration" },
                values: new object[] { "Monday", 30 });

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Day", "Duration" },
                values: new object[] { "Tuesday", 30 });

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Day", "Duration" },
                values: new object[] { "Wednesday", 20 });

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Day", "Duration" },
                values: new object[] { "Thursday", 25 });

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Day", "Duration", "Title" },
                values: new object[] { "Friday", 30, "HIIT" });

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Day", "Duration" },
                values: new object[] { "Saturday", 20 });

            migrationBuilder.InsertData(
                table: "WorkoutSessions",
                columns: new[] { "Id", "Day", "Duration", "ImagePath", "Title", "Week", "WorkoutPlanId" },
                values: new object[,]
                {
                    { 7, "Monday", 25, "images/fullbodyblast.jpg", "Full-Body Blast", 2, 1 },
                    { 8, "Tuesday", 25, "images/coreburn.jpg", "Core Focus Burn", 2, 1 },
                    { 9, "Monday", 30, "images/powercore.jpg", "Power Core", 3, 1 },
                    { 10, "Tuesday", 20, "images/mobility.jpg", "Light Flow & Mobility", 3, 1 },
                    { 11, "Monday", 40, "images/strength.jpg", "Strength Circuit", 4, 1 },
                    { 12, "Tuesday", 30, "images/agility.jpg", "Agility", 4, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Day",
                table: "WorkoutSessions");

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Duration", "Title" },
                values: new object[] { 0, " HIIT" });

            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Duration",
                value: 0);
        }
    }
}
