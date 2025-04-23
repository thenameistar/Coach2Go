using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Coach2Go.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutPlanStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_WorkoutPlans_WorkoutPlanId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_Users_UserId",
                table: "WorkoutPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "WorkoutPlanId",
                table: "Exercises",
                newName: "WorkoutSessionId");

            migrationBuilder.RenameColumn(
                name: "RepsOrDuration",
                table: "Exercises",
                newName: "Details");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_WorkoutPlanId",
                table: "Exercises",
                newName: "IX_Exercises_WorkoutSessionId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WorkoutPlans",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
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
                name: "FK_WorkoutPlans_User_UserId",
                table: "WorkoutPlans",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_WorkoutSessions_WorkoutSessionId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_User_UserId",
                table: "WorkoutPlans");

            migrationBuilder.DropTable(
                name: "WorkoutSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "WorkoutSessionId",
                table: "Exercises",
                newName: "WorkoutPlanId");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Exercises",
                newName: "RepsOrDuration");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_WorkoutSessionId",
                table: "Exercises",
                newName: "IX_Exercises_WorkoutPlanId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WorkoutPlans",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_WorkoutPlans_WorkoutPlanId",
                table: "Exercises",
                column: "WorkoutPlanId",
                principalTable: "WorkoutPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlans_Users_UserId",
                table: "WorkoutPlans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
