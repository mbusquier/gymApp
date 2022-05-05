using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SilvermanGym.Infraestructure.Persistence.Migrations
{
    public partial class nmworkoutexercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WORKOUT_EXERCISES",
                schema: "public",
                columns: table => new
                {
                    ExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUT_EXERCISES", x => new { x.ExerciseId, x.WorkoutId });
                    table.ForeignKey(
                        name: "FK_WORKOUT_EXERCISES_EXERCISES_ExerciseId",
                        column: x => x.ExerciseId,
                        principalSchema: "public",
                        principalTable: "EXERCISES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WORKOUT_EXERCISES_WORKOUTS_WorkoutId",
                        column: x => x.WorkoutId,
                        principalSchema: "public",
                        principalTable: "WORKOUTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WORKOUT_EXERCISES_WorkoutId",
                schema: "public",
                table: "WORKOUT_EXERCISES",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WORKOUT_EXERCISES",
                schema: "public");
        }
    }
}
