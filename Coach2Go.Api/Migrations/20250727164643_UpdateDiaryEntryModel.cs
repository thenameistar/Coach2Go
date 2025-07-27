using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDiaryEntryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaryEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Goals = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Mood = table.Column<string>(type: "text", nullable: true),
                    StreakPercent = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryEntries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GymEquipment",
                columns: new[] { "Id", "EquipmentName", "GymName", "ImageUrl" },
                values: new object[,]
                {
                    { 23, "Treadmill", "JDGym", "images/treadmill.png" },
                    { 24, "Cross Trainer", "JDGym", "images/cross_trainer.png" },
                    { 25, "Stair Climber", "JDGym", "images/stair_climber.png" },
                    { 26, "Stepper", "JDGym", "images/stepper.png" },
                    { 27, "Exercise Bike", "JDGym", "images/exercise_bike.png" },
                    { 28, "Rowing Machine", "JDGym", "images/rowing_machine.png" },
                    { 29, "Dumbbells", "JDGym", "images/dumbbells.png" },
                    { 30, "Weight Bench", "JDGym", "images/weight_bench.png" },
                    { 31, "Squat Rack", "JDGym", "images/squat_rack.png" },
                    { 32, "Plate-Loaded Machine", "JDGym", "images/plate_loaded.png" },
                    { 33, "Chest Press", "JDGym", "images/chest_press.png" },
                    { 34, "Shoulder Press", "JDGym", "images/shoulder_press.png" },
                    { 35, "Bicep Curl Machine", "JDGym", "images/bicep_curl.png" },
                    { 36, "Lateral Pulldown Machine", "JDGym", "images/lat_pulldown.png" },
                    { 37, "Leg Press", "JDGym", "images/leg_press.png" },
                    { 38, "Ab Machine", "JDGym", "images/ab_machine.png" },
                    { 39, "Multi-Gym Station", "JDGym", "images/multigym.png" },
                    { 40, "Hip Abductor", "JDGym", "images/hip_abductor.png" },
                    { 41, "Kettlebell", "JDGym", "images/kettlebell.png" },
                    { 42, "Medicine Ball", "JDGym", "images/medicine_ball.png" },
                    { 43, "Battle Ropes", "JDGym", "images/battle_ropes.png" },
                    { 44, "TRX", "JDGym", "images/trx.png" },
                    { 45, "Treadmill", "AllamSportCentre", "images/treadmill.png" },
                    { 46, "Cross Trainer", "AllamSportCentre", "images/cross_trainer.png" },
                    { 47, "Stair Climber", "AllamSportCentre", "images/stair_climber.png" },
                    { 48, "Stepper", "AllamSportCentre", "images/stepper.png" },
                    { 49, "Exercise Bike", "AllamSportCentre", "images/exercise_bike.png" },
                    { 50, "Rowing Machine", "AllamSportCentre", "images/rowing_machine.png" },
                    { 51, "Dumbbells", "AllamSportCentre", "images/dumbbells.png" },
                    { 52, "Weight Bench", "AllamSportCentre", "images/weight_bench.png" },
                    { 53, "Squat Rack", "AllamSportCentre", "images/squat_rack.png" },
                    { 54, "Plate-Loaded Machine", "AllamSportCentre", "images/plate_loaded.png" },
                    { 55, "Chest Press", "AllamSportCentre", "images/chest_press.png" },
                    { 56, "Shoulder Press", "AllamSportCentre", "images/shoulder_press.png" },
                    { 57, "Bicep Curl Machine", "AllamSportCentre", "images/bicep_curl.png" },
                    { 58, "Lateral Pulldown Machine", "AllamSportCentre", "images/lat_pulldown.png" },
                    { 59, "Leg Press", "AllamSportCentre", "images/leg_press.png" },
                    { 60, "Ab Machine", "AllamSportCentre", "images/ab_machine.png" },
                    { 61, "Multi-Gym Station", "AllamSportCentre", "images/multigym.png" },
                    { 62, "Hip Abductor", "AllamSportCentre", "images/hip_abductor.png" },
                    { 63, "Kettlebell", "AllamSportCentre", "images/kettlebell.png" },
                    { 64, "Medicine Ball", "AllamSportCentre", "images/medicine_ball.png" },
                    { 65, "Battle Ropes", "AllamSportCentre", "images/battle_ropes.png" },
                    { 66, "TRX", "AllamSportCentre", "images/trx.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryEntries");

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "GymEquipment",
                keyColumn: "Id",
                keyValue: 66);
        }
    }
}
