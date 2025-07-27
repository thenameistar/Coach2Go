using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeToWorkoutSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "WorkoutSessions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "WorkoutSessions");
        }
    }
}
