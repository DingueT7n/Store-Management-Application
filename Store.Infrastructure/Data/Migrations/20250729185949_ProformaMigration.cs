using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProformaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProformaInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalFaacture = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProformaInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProformaInvoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProformaInvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProformaId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProformaInvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProformaInvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProformaInvoiceDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProformaInvoiceDetails_ProformaInvoices_ProformaId",
                        column: x => x.ProformaId,
                        principalTable: "ProformaInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProformaInvoiceDetails_ProformaInvoices_ProformaInvoiceId",
                        column: x => x.ProformaInvoiceId,
                        principalTable: "ProformaInvoices",
                        principalColumn: "Id");
                });





            migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoiceDetails_ProductId",
                table: "ProformaInvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoiceDetails_ProformaId",
                table: "ProformaInvoiceDetails",
                column: "ProformaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoiceDetails_ProformaInvoiceId",
                table: "ProformaInvoiceDetails",
                column: "ProformaInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoices_CustomerId",
                table: "ProformaInvoices",
                column: "CustomerId");



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaisseOperations_Caisses_CaisseId",
                table: "CaisseOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_CaisseStatusDetails_Caisses_CaisseId1",
                table: "CaisseStatusDetails");

            migrationBuilder.DropTable(
                name: "ProformaInvoiceDetails");

            migrationBuilder.DropTable(
                name: "ProformaInvoices");

            migrationBuilder.DropIndex(
                name: "IX_CaisseStatusDetails_CaisseId1",
                table: "CaisseStatusDetails");

            migrationBuilder.DropIndex(
                name: "IX_CaisseOperations_CaisseId",
                table: "CaisseOperations");

            migrationBuilder.DropColumn(
                name: "CaisseId1",
                table: "CaisseStatusDetails");

            migrationBuilder.DropColumn(
                name: "CaisseId",
                table: "CaisseOperations");
        }
    }
}
