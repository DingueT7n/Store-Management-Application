using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditSaleANdCustomerDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "CustomersReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "CustomersMoneys",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "CustomersReports");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "CustomersMoneys");
        }
    }
}
