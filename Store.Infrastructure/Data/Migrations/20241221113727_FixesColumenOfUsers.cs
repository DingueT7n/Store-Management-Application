using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixesColumenOfUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserBuyId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCaisseAndBankId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCustomerId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDeservedAndTaxId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserEmployeeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserProductAndStoreId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRefundId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserSaleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserSettingId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserSupplierId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserBuyId",
                table: "Users",
                column: "UserBuyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCaisseAndBankId",
                table: "Users",
                column: "UserCaisseAndBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCustomerId",
                table: "Users",
                column: "UserCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserDeservedAndTaxId",
                table: "Users",
                column: "UserDeservedAndTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmployeeId",
                table: "Users",
                column: "UserEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserProductAndStoreId",
                table: "Users",
                column: "UserProductAndStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRefundId",
                table: "Users",
                column: "UserRefundId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserSaleId",
                table: "Users",
                column: "UserSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserSettingId",
                table: "Users",
                column: "UserSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserSupplierId",
                table: "Users",
                column: "UserSupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserBuys_UserBuyId",
                table: "Users",
                column: "UserBuyId",
                principalTable: "UserBuys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCaissesAndBanks_UserCaisseAndBankId",
                table: "Users",
                column: "UserCaisseAndBankId",
                principalTable: "UserCaissesAndBanks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCustomers_UserCustomerId",
                table: "Users",
                column: "UserCustomerId",
                principalTable: "UserCustomers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDeservedAndTaxs_UserDeservedAndTaxId",
                table: "Users",
                column: "UserDeservedAndTaxId",
                principalTable: "UserDeservedAndTaxs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserEmployees_UserEmployeeId",
                table: "Users",
                column: "UserEmployeeId",
                principalTable: "UserEmployees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserProductsAndStores_UserProductAndStoreId",
                table: "Users",
                column: "UserProductAndStoreId",
                principalTable: "UserProductsAndStores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRefunds_UserRefundId",
                table: "Users",
                column: "UserRefundId",
                principalTable: "UserRefunds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserSales_UserSaleId",
                table: "Users",
                column: "UserSaleId",
                principalTable: "UserSales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserSettings_UserSettingId",
                table: "Users",
                column: "UserSettingId",
                principalTable: "UserSettings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserSuppliers_UserSupplierId",
                table: "Users",
                column: "UserSupplierId",
                principalTable: "UserSuppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserBuys_UserBuyId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCaissesAndBanks_UserCaisseAndBankId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCustomers_UserCustomerId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDeservedAndTaxs_UserDeservedAndTaxId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserEmployees_UserEmployeeId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserProductsAndStores_UserProductAndStoreId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRefunds_UserRefundId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserSales_UserSaleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserSettings_UserSettingId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserSuppliers_UserSupplierId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserBuyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCaisseAndBankId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCustomerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserDeservedAndTaxId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserEmployeeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserProductAndStoreId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRefundId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserSaleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserSettingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserSupplierId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserBuyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCaisseAndBankId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCustomerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserDeservedAndTaxId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserEmployeeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserProductAndStoreId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRefundId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserSaleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserSettingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserSupplierId",
                table: "Users");
        }
    }
}
