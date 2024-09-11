using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankDeposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDeposits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankWithdraws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankWithdraws", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BarcodePrints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductBarcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarcodePrints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caisses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaisseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MoneyinCaisse = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caisses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaissesBankTransferes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From_ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To_ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaissesBankTransferes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxDebtAllowed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDebts = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeservedsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeservedsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderPrintData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPrintData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RandomBarcode",
                columns: table => new
                {
                    Barcode = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ReceiptVouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReciverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptVouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidUP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remain = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SendVouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendVouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxDebtAllowed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDebts = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxesReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Num = table.Column<int>(type: "int", nullable: false),
                    Order_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAfterTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxesReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaissesDeposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caisse_ID = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaissesDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaissesDeposits_Caisses_Caisse_ID",
                        column: x => x.Caisse_ID,
                        principalTable: "Caisses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaissesTransferes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caisse_From = table.Column<int>(type: "int", nullable: false),
                    Caisse_To = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaissesTransferes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaissesTransferes_Caisses_Caisse_From",
                        column: x => x.Caisse_From,
                        principalTable: "Caisses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaissesTransferes_Caisses_Caisse_To",
                        column: x => x.Caisse_To,
                        principalTable: "Caisses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaissesWithdraws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caisse_ID = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaissesWithdraws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaissesWithdraws_Caisses_Caisse_ID",
                        column: x => x.Caisse_ID,
                        principalTable: "Caisses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeBar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WholesalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePriceTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsTaxed = table.Column<bool>(type: "bit", nullable: false),
                    DateExperation = table.Column<DateTime>(type: "date", nullable: false),
                    MinQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidUP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remain = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deserveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deserveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deserveds_DeservedsTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DeservedsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidUP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remain = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buys_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pro_Id = table.Column<int>(type: "int", nullable: false),
                    Store_Id = table.Column<int>(type: "int", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "date", nullable: true),
                    TimeStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "date", nullable: true),
                    TimeEnd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDiscounts_Products_Pro_Id",
                        column: x => x.Pro_Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductQuickAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pro_Id = table.Column<int>(type: "int", nullable: false),
                    CodeBar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQuickAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductQuickAccess_Products_Pro_Id",
                        column: x => x.Pro_Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsOutStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pro_ID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StoreName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOutStore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsOutStore_Products_Pro_ID",
                        column: x => x.Pro_ID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pro_ID = table.Column<int>(type: "int", nullable: false),
                    Store_ID = table.Column<int>(type: "int", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Buy_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sale_PriceTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsQuantities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsQuantities_Products_Pro_ID",
                        column: x => x.Pro_ID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsQuantities_Stores_Store_ID",
                        column: x => x.Store_ID,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pro_ID = table.Column<int>(type: "int", nullable: false),
                    Pro_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreFrom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StoreTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePriceTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsTransfers_Products_Pro_ID",
                        column: x => x.Pro_ID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Pro_ID = table.Column<int>(type: "int", nullable: false),
                    Sup_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cust_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceWithTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnsDetails_Products_Pro_ID",
                        column: x => x.Pro_ID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnsDetails_Returns_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Returns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomersMoneys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cust_ID = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Cust_Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Reminder_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersMoneys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersMoneys_Customers_Cust_ID",
                        column: x => x.Cust_ID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersMoneys_Sales_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomersReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cust_ID = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Cust_Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersReports_Customers_Cust_ID",
                        column: x => x.Cust_ID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersReports_Sales_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Cust_ID = table.Column<int>(type: "int", nullable: false),
                    Pro_ID = table.Column<int>(type: "int", nullable: false),
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceWithTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesDetails_Customers_Cust_ID",
                        column: x => x.Cust_ID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesDetails_Products_Pro_ID",
                        column: x => x.Pro_ID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesDetails_Sales_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesProfits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Cust_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pro_ID = table.Column<int>(type: "int", nullable: false),
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price_Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buy_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProfits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesProfits_Products_Pro_ID",
                        column: x => x.Pro_ID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesProfits_Sales_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Sup_ID = table.Column<int>(type: "int", nullable: false),
                    Pro_ID = table.Column<int>(type: "int", nullable: false),
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceWithTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyDetails_Buys_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Buys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyDetails_Products_Pro_ID",
                        column: x => x.Pro_ID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuyDetails_Suppliers_Sup_ID",
                        column: x => x.Sup_ID,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuppliersMoneys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sup_ID = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reminder_Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuppliersMoneys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuppliersMoneys_Buys_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Buys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuppliersMoneys_Suppliers_Sup_ID",
                        column: x => x.Sup_ID,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuppliersReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sup_ID = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuppliersReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuppliersReports_Buys_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Buys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuppliersReports_Suppliers_Sup_ID",
                        column: x => x.Sup_ID,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Money" },
                values: new object[] { 1, 0m });

            migrationBuilder.InsertData(
                table: "Caisses",
                columns: new[] { "Id", "CaisseName", "MoneyinCaisse" },
                values: new object[,]
                {
                    { 1, "الصندوق الأول", 0m },
                    { 2, "الصندوق الثاني", 0m },
                    { 3, "الصندوق الثالث", 0m }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "اغذية عادية" },
                    { 2, "اغذية الاطفال" },
                    { 3, "محفظات اطفال" },
                    { 4, "اغذية الاطفال" },
                    { 5, "مشروبات غازية" },
                    { 6, "هواتف رادمي" },
                    { 7, "هاتف سامسونغ" },
                    { 8, "فرماج" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CustomerName", "MaxDebtAllowed", "Notes", "PhoneNumber", "TotalDebts" },
                values: new object[,]
                {
                    { 1, "بن سمارة", "قربوز علاء", 0m, "معلومات مشحونة", "0697357397", 0m },
                    { 2, "مرماد", "بن خليفة", 0m, "معلومات مشحونة", "0754653721", 0m },
                    { 3, "حاج مسعود", "دوادي", 0m, "معلومات مشحونة", "0697357546", 0m },
                    { 4, "", "مشتري عادي", 0m, "معلومات مشحونة", "", 0m }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "StoreName" },
                values: new object[] { 1, "مخزن رئيسي" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "MaxDebtAllowed", "Notes", "PhoneNumber", "SupplierName", "TotalDebts" },
                values: new object[,]
                {
                    { 1, "بوهراوة", 400m, "معلومات مشحونة", "0697357397", "مورد سعيدة", 0m },
                    { 2, "مراماد", 5000m, "معلومات مشحونة", "0754653721", "مورد الزعيم", 0m },
                    { 3, "العطف", 5500m, "معلومات مشحونة", "0697357546", "مورد القولية", 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyDetails_Order_ID",
                table: "BuyDetails",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BuyDetails_Pro_ID",
                table: "BuyDetails",
                column: "Pro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BuyDetails_Sup_ID",
                table: "BuyDetails",
                column: "Sup_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Buys_SupplierId",
                table: "Buys",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_CaissesDeposits_Caisse_ID",
                table: "CaissesDeposits",
                column: "Caisse_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CaissesTransferes_Caisse_From",
                table: "CaissesTransferes",
                column: "Caisse_From");

            migrationBuilder.CreateIndex(
                name: "IX_CaissesTransferes_Caisse_To",
                table: "CaissesTransferes",
                column: "Caisse_To");

            migrationBuilder.CreateIndex(
                name: "IX_CaissesWithdraws_Caisse_ID",
                table: "CaissesWithdraws",
                column: "Caisse_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersMoneys_Cust_ID",
                table: "CustomersMoneys",
                column: "Cust_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersMoneys_Order_ID",
                table: "CustomersMoneys",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersReports_Cust_ID",
                table: "CustomersReports",
                column: "Cust_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersReports_Order_ID",
                table: "CustomersReports",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Deserveds_TypeId",
                table: "Deserveds",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscounts_Pro_Id",
                table: "ProductDiscounts",
                column: "Pro_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuickAccess_Pro_Id",
                table: "ProductQuickAccess",
                column: "Pro_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOutStore_Pro_ID",
                table: "ProductsOutStore",
                column: "Pro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsQuantities_Pro_ID",
                table: "ProductsQuantities",
                column: "Pro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsQuantities_Store_ID",
                table: "ProductsQuantities",
                column: "Store_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTransfers_Pro_ID",
                table: "ProductsTransfers",
                column: "Pro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsDetails_Order_ID",
                table: "ReturnsDetails",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsDetails_Pro_ID",
                table: "ReturnsDetails",
                column: "Pro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_Cust_ID",
                table: "SalesDetails",
                column: "Cust_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_Order_ID",
                table: "SalesDetails",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_Pro_ID",
                table: "SalesDetails",
                column: "Pro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesProfits_Order_ID",
                table: "SalesProfits",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesProfits_Pro_ID",
                table: "SalesProfits",
                column: "Pro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SuppliersMoneys_Order_ID",
                table: "SuppliersMoneys",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SuppliersMoneys_Sup_ID",
                table: "SuppliersMoneys",
                column: "Sup_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SuppliersReports_Order_ID",
                table: "SuppliersReports",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SuppliersReports_Sup_ID",
                table: "SuppliersReports",
                column: "Sup_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDeposits");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "BankWithdraws");

            migrationBuilder.DropTable(
                name: "BarcodePrints");

            migrationBuilder.DropTable(
                name: "BuyDetails");

            migrationBuilder.DropTable(
                name: "CaissesBankTransferes");

            migrationBuilder.DropTable(
                name: "CaissesDeposits");

            migrationBuilder.DropTable(
                name: "CaissesTransferes");

            migrationBuilder.DropTable(
                name: "CaissesWithdraws");

            migrationBuilder.DropTable(
                name: "CustomersMoneys");

            migrationBuilder.DropTable(
                name: "CustomersReports");

            migrationBuilder.DropTable(
                name: "Deserveds");

            migrationBuilder.DropTable(
                name: "OrderPrintData");

            migrationBuilder.DropTable(
                name: "ProductDiscounts");

            migrationBuilder.DropTable(
                name: "ProductQuickAccess");

            migrationBuilder.DropTable(
                name: "ProductsOutStore");

            migrationBuilder.DropTable(
                name: "ProductsQuantities");

            migrationBuilder.DropTable(
                name: "ProductsTransfers");

            migrationBuilder.DropTable(
                name: "RandomBarcode");

            migrationBuilder.DropTable(
                name: "ReceiptVouchers");

            migrationBuilder.DropTable(
                name: "ReturnsDetails");

            migrationBuilder.DropTable(
                name: "SalesDetails");

            migrationBuilder.DropTable(
                name: "SalesProfits");

            migrationBuilder.DropTable(
                name: "SendVouchers");

            migrationBuilder.DropTable(
                name: "SuppliersMoneys");

            migrationBuilder.DropTable(
                name: "SuppliersReports");

            migrationBuilder.DropTable(
                name: "TaxesReports");

            migrationBuilder.DropTable(
                name: "Caisses");

            migrationBuilder.DropTable(
                name: "DeservedsTypes");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Buys");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
