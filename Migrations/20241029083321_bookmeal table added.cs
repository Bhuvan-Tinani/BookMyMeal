using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyMeal.Migrations
{
    public partial class bookmealtableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Meals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookMeals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payment = table.Column<double>(type: "float", nullable: false),
                    numberOfMeal = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookMeals", x => x.id);
                    table.ForeignKey(
                        name: "FK_BookMeals_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

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
                name: "IX_Meals_EmployeeId",
                table: "Meals",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookMealMeal_MealsId",
                table: "BookMealMeal",
                column: "MealsId");

            migrationBuilder.CreateIndex(
                name: "IX_BookMeals_EmployeeId",
                table: "BookMeals",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Employees_EmployeeId",
                table: "Meals",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Employees_EmployeeId",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "BookMealMeal");

            migrationBuilder.DropTable(
                name: "BookMeals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_EmployeeId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Meals");
        }
    }
}
