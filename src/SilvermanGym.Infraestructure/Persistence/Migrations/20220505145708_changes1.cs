using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SilvermanGym.Infraestructure.Persistence.Migrations
{
    public partial class changes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sets",
                schema: "public",
                table: "WORKOUT_EXERCISES");

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                schema: "public",
                table: "WORKOUT_EXERCISES",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                schema: "public",
                table: "WORKOUT_EXERCISES");

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                schema: "public",
                table: "WORKOUT_EXERCISES",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
