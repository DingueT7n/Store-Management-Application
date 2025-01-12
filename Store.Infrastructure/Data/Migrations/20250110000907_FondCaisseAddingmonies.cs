using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FondCaisseAddingmonies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Nbr1000DA",
                table: "CaisseOperations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Nbr100DA",
                table: "CaisseOperations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Nbr10DA",
                table: "CaisseOperations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Nbr2000DA",
                table: "CaisseOperations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Nbr200DA",
                table: "CaisseOperations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Nbr20DA",
                table: "CaisseOperations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Nbr500DA",
                table: "CaisseOperations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Nbr50DA",
                table: "CaisseOperations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Nbr5DA",
                table: "CaisseOperations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValueAddedDefault",
                table: "CaisseOperations",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nbr1000DA",
                table: "CaisseOperations");

            migrationBuilder.DropColumn(
                name: "Nbr100DA",
                table: "CaisseOperations");

            migrationBuilder.DropColumn(
                name: "Nbr10DA",
                table: "CaisseOperations");

            migrationBuilder.DropColumn(
                name: "Nbr2000DA",
                table: "CaisseOperations");

            migrationBuilder.DropColumn(
                name: "Nbr200DA",
                table: "CaisseOperations");

            migrationBuilder.DropColumn(
                name: "Nbr20DA",
                table: "CaisseOperations");

            migrationBuilder.DropColumn(
                name: "Nbr500DA",
                table: "CaisseOperations");

            migrationBuilder.DropColumn(
                name: "Nbr50DA",
                table: "CaisseOperations");

            migrationBuilder.DropColumn(
                name: "Nbr5DA",
                table: "CaisseOperations");

            migrationBuilder.DropColumn(
                name: "ValueAddedDefault",
                table: "CaisseOperations");
        }
    }
}
