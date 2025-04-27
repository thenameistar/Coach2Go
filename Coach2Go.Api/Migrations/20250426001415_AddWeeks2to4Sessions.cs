using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddWeeks2to4Sessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "images/activerecovery1.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WorkoutSessions",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "images/activerecovery.jpg");
        }
    }
}
