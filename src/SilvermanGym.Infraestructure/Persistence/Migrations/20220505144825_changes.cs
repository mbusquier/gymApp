using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SilvermanGym.Infraestructure.Persistence.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WORKOUTS_USERS_UserId",
                schema: "public",
                table: "WORKOUTS");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "WORKOUTS",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                schema: "public",
                table: "WORKOUT_EXERCISES",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                schema: "public",
                table: "WORKOUT_EXERCISES",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_WORKOUTS_USERS_UserId",
                schema: "public",
                table: "WORKOUTS",
                column: "UserId",
                principalSchema: "public",
                principalTable: "USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WORKOUTS_USERS_UserId",
                schema: "public",
                table: "WORKOUTS");

            migrationBuilder.DropTable(
                name: "ExerciseWorkout",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "Reps",
                schema: "public",
                table: "WORKOUT_EXERCISES");

            migrationBuilder.DropColumn(
                name: "Sets",
                schema: "public",
                table: "WORKOUT_EXERCISES");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "WORKOUTS",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_WORKOUTS_USERS_UserId",
                schema: "public",
                table: "WORKOUTS",
                column: "UserId",
                principalSchema: "public",
                principalTable: "USERS",
                principalColumn: "Id");
        }
    }
}
