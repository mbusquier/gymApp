using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SilvermanGym.Infraestructure.Persistence.Migrations
{
    public partial class cambioTablaRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WORKOUT_EXERCISES",
                schema: "public",
                table: "WORKOUT_EXERCISES");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "WORKOUT_EXERCISES",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WORKOUT_EXERCISES",
                schema: "public",
                table: "WORKOUT_EXERCISES",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WORKOUT_EXERCISES_ExerciseId",
                schema: "public",
                table: "WORKOUT_EXERCISES",
                column: "ExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WORKOUT_EXERCISES",
                schema: "public",
                table: "WORKOUT_EXERCISES");

            migrationBuilder.DropIndex(
                name: "IX_WORKOUT_EXERCISES_ExerciseId",
                schema: "public",
                table: "WORKOUT_EXERCISES");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "public",
                table: "WORKOUT_EXERCISES");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WORKOUT_EXERCISES",
                schema: "public",
                table: "WORKOUT_EXERCISES",
                columns: new[] { "ExerciseId", "WorkoutId" });

            migrationBuilder.CreateTable(
                name: "ExerciseWorkout",
                schema: "public",
                columns: table => new
                {
                    ExercisesId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkoutsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseWorkout", x => new { x.ExercisesId, x.WorkoutsId });
                    table.ForeignKey(
                        name: "FK_ExerciseWorkout_EXERCISES_ExercisesId",
                        column: x => x.ExercisesId,
                        principalSchema: "public",
                        principalTable: "EXERCISES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseWorkout_WORKOUTS_WorkoutsId",
                        column: x => x.WorkoutsId,
                        principalSchema: "public",
                        principalTable: "WORKOUTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkout_WorkoutsId",
                schema: "public",
                table: "ExerciseWorkout",
                column: "WorkoutsId");
        }
    }
}
