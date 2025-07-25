using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class FinalSessionFieldsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "WorkoutSessions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "WorkoutSessions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "WorkoutSessions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetMuscles",
                table: "WorkoutSessions",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "TargetMuscles",
                table: "WorkoutSessions");
        }
    }
}
