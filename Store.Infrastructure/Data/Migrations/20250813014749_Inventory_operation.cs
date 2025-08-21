using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inventory_operation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProformaInvoices_Customers_CustomerId",
                table: "ProformaInvoices");

            migrationBuilder.CreateTable(
                name: "InventorySessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    PerformedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventorySessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventorySessions_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "InventoryChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ExpectedQty = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ActualQty = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    InventorySessionId = table.Column<int>(type: "int", nullable: false),
                    CheckedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryChecks_InventorySessions_InventorySessionId",
                        column: x => x.InventorySessionId,
                        principalTable: "InventorySessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryChecks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryChecks_InventorySessionId",
                table: "InventoryChecks",
                column: "InventorySessionId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryChecks_ProductId",
                table: "InventoryChecks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventorySessions_StoreId",
                table: "InventorySessions",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProformaInvoices_Customers_CustomerId",
                table: "ProformaInvoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProformaInvoices_Customers_CustomerId",
                table: "ProformaInvoices");

            migrationBuilder.DropTable(
                name: "InventoryChecks");

            migrationBuilder.DropTable(
                name: "InventorySessions");

            migrationBuilder.AddForeignKey(
                name: "FK_ProformaInvoices_Customers_CustomerId",
                table: "ProformaInvoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
