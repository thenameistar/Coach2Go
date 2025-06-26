using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserWorkoutFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_User_UserId",
                table: "WorkoutPlans");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutPlans_UserId",
                table: "WorkoutPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutPlanId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Experience", "Goal", "Type", "Username", "WorkoutPlanId" },
                values: new object[] { 1, "ana@test.com", "Beginner", "Lose Weight", "Bodyweight", "Ana", 1 });

            migrationBuilder.InsertData(
                table: "WorkoutPlans",
                columns: new[] { "Id", "Duration", "Experience", "Goal", "Intensity", "Type", "UserId" },
                values: new object[,]
                {
                    { 2, 40, "Intermediate", "Strength", "Medium", "Gym", null },
                    { 3, 30, "Beginner", "General Fitness", "Low", "Bodyweight", null },
                    { 4, 50, "Advanced", "Build Muscle", "High", "Gym", null },
                    { 5, 35, "Beginner", "Build Muscle", "Medium", "Gym", null },
                    { 6, 30, "Beginner", "Lose Weight", "Low", "Gym", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Experience", "Goal", "Type", "Username", "WorkoutPlanId" },
                values: new object[,]
                {
                    { 2, "elijah@test.com", "Intermediate", "Strength", "Gym", "Elijah", 2 },
                    { 3, "charlie@test.com", "Beginner", "General Fitness", "Bodyweight", "Charlie", 3 },
                    { 4, "sasha@test.com", "Advanced", "Build Muscle", "Gym", "Sasha", 4 },
                    { 5, "sham@test.com", "Beginner", "Build Muscle", "Gym", "Sham", 5 },
                    { 6, "blessing@test.com", "Beginner", "Lose weight", "Gym", "Blessing", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_WorkoutPlanId",
                table: "Users",
                column: "WorkoutPlanId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WorkoutPlans_WorkoutPlanId",
                table: "Users",
                column: "WorkoutPlanId",
                principalTable: "WorkoutPlans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_WorkoutPlans_WorkoutPlanId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_WorkoutPlanId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

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

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Goal",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WorkoutPlanId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_UserId",
                table: "WorkoutPlans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlans_User_UserId",
                table: "WorkoutPlans",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
