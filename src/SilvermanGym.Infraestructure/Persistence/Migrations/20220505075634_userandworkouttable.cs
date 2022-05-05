using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SilvermanGym.Infraestructure.Persistence.Migrations
{
    public partial class userandworkouttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "varchar(70)", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    IMC = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WORKOUTS",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(70)", nullable: false),
                    WorkoutDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WORKOUTS_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WORKOUTS_UserId",
                schema: "public",
                table: "WORKOUTS",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WORKOUTS",
                schema: "public");

            migrationBuilder.DropTable(
                name: "USERS",
                schema: "public");
        }
    }
}
