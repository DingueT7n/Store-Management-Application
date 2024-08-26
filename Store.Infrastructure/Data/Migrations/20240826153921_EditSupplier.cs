using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyId",
                table: "SuppliersMoneys",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MaxDebtAllowed",
                table: "Suppliers",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TotalDebts",
                table: "Suppliers",
                type: "real",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxDebtAllowed", "TotalDebts" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxDebtAllowed", "TotalDebts" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MaxDebtAllowed", "TotalDebts" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_SuppliersMoneys_BuyId",
                table: "SuppliersMoneys",
                column: "BuyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuppliersMoneys_Buys_BuyId",
                table: "SuppliersMoneys",
                column: "BuyId",
                principalTable: "Buys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuppliersMoneys_Buys_BuyId",
                table: "SuppliersMoneys");

            migrationBuilder.DropIndex(
                name: "IX_SuppliersMoneys_BuyId",
                table: "SuppliersMoneys");

            migrationBuilder.DropColumn(
                name: "BuyId",
                table: "SuppliersMoneys");

            migrationBuilder.DropColumn(
                name: "MaxDebtAllowed",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "TotalDebts",
                table: "Suppliers");
        }
    }
}
