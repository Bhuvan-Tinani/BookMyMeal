using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyMeal.Migrations
{
    public partial class bookingchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookMealMeal");

            migrationBuilder.DropColumn(
                name: "numberOfMeal",
                table: "BookMeals");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "BookMeals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BookedMealsDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookMealid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    NumberOfMeal = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedMealsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookedMealsDetails_BookMeals_BookMealid",
                        column: x => x.BookMealid,
                        principalTable: "BookMeals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookedMealsDetails_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedMealsDetails_BookMealid",
                table: "BookedMealsDetails",
                column: "BookMealid");

            migrationBuilder.CreateIndex(
                name: "IX_BookedMealsDetails_MealId",
                table: "BookedMealsDetails",
                column: "MealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedMealsDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BookMeals");

            migrationBuilder.AddColumn<int>(
                name: "numberOfMeal",
                table: "BookMeals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookMealMeal",
                columns: table => new
                {
                    BookMealid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookMealMeal", x => new { x.BookMealid, x.MealsId });
                    table.ForeignKey(
                        name: "FK_BookMealMeal_BookMeals_BookMealid",
                        column: x => x.BookMealid,
                        principalTable: "BookMeals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookMealMeal_Meals_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookMealMeal_MealsId",
                table: "BookMealMeal",
                column: "MealsId");
        }
    }
}
