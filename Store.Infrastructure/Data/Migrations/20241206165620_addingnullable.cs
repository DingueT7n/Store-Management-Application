using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesBorrowMonies_Employees_Emp_Id",
                table: "EmployeesBorrowMonies");

            migrationBuilder.AlterColumn<int>(
                name: "Emp_Id",
                table: "EmployeesBorrowMonies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesBorrowMonies_Employees_Emp_Id",
                table: "EmployeesBorrowMonies",
                column: "Emp_Id",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesBorrowMonies_Employees_Emp_Id",
                table: "EmployeesBorrowMonies");

            migrationBuilder.AlterColumn<int>(
                name: "Emp_Id",
                table: "EmployeesBorrowMonies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesBorrowMonies_Employees_Emp_Id",
                table: "EmployeesBorrowMonies",
                column: "Emp_Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
