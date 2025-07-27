using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "WorkoutSessions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAiGenerated",
                table: "WorkoutSessions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Goal",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "IsAiGenerated",
                table: "WorkoutSessions");
        }
    }
}
