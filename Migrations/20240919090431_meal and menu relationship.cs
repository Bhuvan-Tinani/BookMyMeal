using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyMeal.Migrations
{
    public partial class mealandmenurelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MealMenu",
                columns: table => new
                {
                    MealsId = table.Column<int>(type: "int", nullable: false),
                    Menusid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealMenu", x => new { x.MealsId, x.Menusid });
                    table.ForeignKey(
                        name: "FK_MealMenu_Meals_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealMenu_Menu_Menusid",
                        column: x => x.Menusid,
                        principalTable: "Menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealMenu_Menusid",
                table: "MealMenu",
                column: "Menusid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealMenu");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
