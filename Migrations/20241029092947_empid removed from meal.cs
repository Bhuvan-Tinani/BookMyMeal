using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyMeal.Migrations
{
    public partial class empidremovedfrommeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookMeals_Employees_EmployeeId",
                table: "BookMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Employees_EmployeeId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_EmployeeId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "BookMeals",
                newName: "employeeId");

            migrationBuilder.RenameIndex(
                name: "IX_BookMeals_EmployeeId",
                table: "BookMeals",
                newName: "IX_BookMeals_employeeId");

            migrationBuilder.AlterColumn<Guid>(
                name: "employeeId",
                table: "BookMeals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookMeals_Employees_employeeId",
                table: "BookMeals",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookMeals_Employees_employeeId",
                table: "BookMeals");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "BookMeals",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_BookMeals_employeeId",
                table: "BookMeals",
                newName: "IX_BookMeals_EmployeeId");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Meals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "BookMeals",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_EmployeeId",
                table: "Meals",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookMeals_Employees_EmployeeId",
                table: "BookMeals",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Employees_EmployeeId",
                table: "Meals",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
