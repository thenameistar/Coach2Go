using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GymEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GymName = table.Column<string>(type: "text", nullable: false),
                    EquipmentName = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    WorkoutSessionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    GoogleId = table.Column<string>(type: "text", nullable: true),
                    Goal = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Experience = table.Column<string>(type: "text", nullable: false),
                    WorkoutPlanId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Goal = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Experience = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Intensity = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutPlans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Week = table.Column<int>(type: "integer", nullable: false),
                    Day = table.Column<string>(type: "text", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    WorkoutPlanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_WorkoutPlans_WorkoutPlanId",
                        column: x => x.WorkoutPlanId,
                        principalTable: "WorkoutPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GymEquipment",
                columns: new[] { "Id", "EquipmentName", "GymName", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "Treadmill", "PureGym", "images/treadmill.png" },
                    { 2, "Cross Trainer", "PureGym", "images/cross_trainer.png" },
                    { 3, "Stair Climber", "PureGym", "images/stair_climber.png" },
                    { 4, "Stepper", "PureGym", "images/stepper.png" },
                    { 5, "Exercise Bike", "PureGym", "images/exercise_bike.png" },
                    { 6, "Rowing Machine", "PureGym", "images/rowing_machine.png" },
                    { 7, "Dumbbells", "PureGym", "images/dumbbells.png" },
                    { 8, "Weight Bench", "PureGym", "images/weight_bench.png" },
                    { 9, "Squat Rack", "PureGym", "images/squat_rack.png" },
                    { 10, "Plate-Loaded Machine", "PureGym", "images/plate_loaded.png" },
                    { 11, "Chest Press", "PureGym", "images/chest_press.png" },
                    { 12, "Shoulder Press", "PureGym", "images/shoulder_press.png" },
                    { 13, "Bicep Curl Machine", "PureGym", "images/bicep_curl.png" },
                    { 14, "Lateral Pulldown Machine", "PureGym", "images/lat_pulldown.png" },
                    { 15, "Leg Press", "PureGym", "images/leg_press.png" },
                    { 16, "Ab Machine", "PureGym", "images/ab_machine.png" },
                    { 17, "Multi-Gym Station", "PureGym", "images/multigym.png" },
                    { 18, "Hip Abductor", "PureGym", "images/hip_abductor.png" },
                    { 19, "Kettlebell", "PureGym", "images/kettlebell.png" },
                    { 20, "Medicine Ball", "PureGym", "images/medicine_ball.png" },
                    { 21, "Battle Ropes", "PureGym", "images/battle_ropes.png" },
                    { 22, "TRX", "PureGym", "images/trx.png" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutSessionId",
                table: "Exercises",
                column: "WorkoutSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WorkoutPlanId",
                table: "Users",
                column: "WorkoutPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_UserId",
                table: "WorkoutPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_WorkoutPlanId",
                table: "WorkoutSessions",
                column: "WorkoutPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_WorkoutSessions_WorkoutSessionId",
                table: "Exercises",
                column: "WorkoutSessionId",
                principalTable: "WorkoutSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "GymEquipment");

            migrationBuilder.DropTable(
                name: "WorkoutSessions");

            migrationBuilder.DropTable(
                name: "WorkoutPlans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
