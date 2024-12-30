using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditsonDiscountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscounts_Store_Id",
                table: "ProductDiscounts",
                column: "Store_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDiscounts_Stores_Store_Id",
                table: "ProductDiscounts",
                column: "Store_Id",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDiscounts_Stores_Store_Id",
                table: "ProductDiscounts");

            migrationBuilder.DropIndex(
                name: "IX_ProductDiscounts_Store_Id",
                table: "ProductDiscounts");
        }
    }
}
