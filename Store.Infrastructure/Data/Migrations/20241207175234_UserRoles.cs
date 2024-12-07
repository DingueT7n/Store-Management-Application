using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock_Id = table.Column<int>(type: "int", nullable: false),
                    UserProfit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBuys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    NewBuy = table.Column<bool>(type: "bit", nullable: false),
                    BuyReports = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBuys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBuys_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCaissesAndBanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    CaissesAndBanks = table.Column<bool>(type: "bit", nullable: false),
                    DepositToCaisse = table.Column<bool>(type: "bit", nullable: false),
                    DepositToBank = table.Column<bool>(type: "bit", nullable: false),
                    WithdrawFromCaisse = table.Column<bool>(type: "bit", nullable: false),
                    WithdrawFromBank = table.Column<bool>(type: "bit", nullable: false),
                    TransfertBetweenCaisse = table.Column<bool>(type: "bit", nullable: false),
                    TransfertBetweenCaisseAndBank = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCaissesAndBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCaissesAndBanks_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    AllCustomers = table.Column<bool>(type: "bit", nullable: false),
                    AddCustomer = table.Column<bool>(type: "bit", nullable: false),
                    CustomerAccount = table.Column<bool>(type: "bit", nullable: false),
                    CustomerReport = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCustomers_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDeservedAndTaxs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Deserved = table.Column<bool>(type: "bit", nullable: false),
                    Vouchers = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeservedAndTaxs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDeservedAndTaxs_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    AllEmployee = table.Column<bool>(type: "bit", nullable: false),
                    AddEmployee = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeBorrowItem = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeBorrowMoney = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeSalaries = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeBorrowItemsReport = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeBorrowMoneyReport = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeSalariesReport = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEmployees_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProductsAndStores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    AllProducts = table.Column<bool>(type: "bit", nullable: false),
                    AddProduct = table.Column<bool>(type: "bit", nullable: false),
                    AllCategories = table.Column<bool>(type: "bit", nullable: false),
                    StoreInventory = table.Column<bool>(type: "bit", nullable: false),
                    TransfertReport = table.Column<bool>(type: "bit", nullable: false),
                    ProductOutStoreReport = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProductsAndStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProductsAndStores_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRefunds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    RefundProduct = table.Column<bool>(type: "bit", nullable: false),
                    RefundReport = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefunds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefunds_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    NewSale = table.Column<bool>(type: "bit", nullable: false),
                    SaleReports = table.Column<bool>(type: "bit", nullable: false),
                    SaleProfits = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSales_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    UserPermession = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationSettings = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSuppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    AllSuppliers = table.Column<bool>(type: "bit", nullable: false),
                    AddSuppliers = table.Column<bool>(type: "bit", nullable: false),
                    SuppliersAccount = table.Column<bool>(type: "bit", nullable: false),
                    SuppliersReport = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSuppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSuppliers_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBuys_User_Id",
                table: "UserBuys",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserCaissesAndBanks_User_Id",
                table: "UserCaissesAndBanks",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomers_User_Id",
                table: "UserCustomers",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserDeservedAndTaxs_User_Id",
                table: "UserDeservedAndTaxs",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserEmployees_User_Id",
                table: "UserEmployees",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductsAndStores_User_Id",
                table: "UserProductsAndStores",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefunds_User_Id",
                table: "UserRefunds",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSales_User_Id",
                table: "UserSales",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_User_Id",
                table: "UserSettings",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSuppliers_User_Id",
                table: "UserSuppliers",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBuys");

            migrationBuilder.DropTable(
                name: "UserCaissesAndBanks");

            migrationBuilder.DropTable(
                name: "UserCustomers");

            migrationBuilder.DropTable(
                name: "UserDeservedAndTaxs");

            migrationBuilder.DropTable(
                name: "UserEmployees");

            migrationBuilder.DropTable(
                name: "UserProductsAndStores");

            migrationBuilder.DropTable(
                name: "UserRefunds");

            migrationBuilder.DropTable(
                name: "UserSales");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "UserSuppliers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
