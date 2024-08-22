using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Money = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "BankDeposit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDeposit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankWithdraw",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankWithdraw", x => x.Id);
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
                    MoneyinCaisse = table.Column<float>(type: "real", nullable: false)
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
                    Money = table.Column<float>(type: "real", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
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
                    Barcode = table.Column<float>(type: "real", nullable: true)
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
                    Price = table.Column<float>(type: "real", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalOrder = table.Column<float>(type: "real", nullable: false),
                    PaidUP = table.Column<float>(type: "real", nullable: false),
                    Remain = table.Column<float>(type: "real", nullable: false)
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
                    Price = table.Column<float>(type: "real", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Order_Num = table.Column<int>(type: "int", nullable: true),
                    Order_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalOrder = table.Column<float>(type: "real", nullable: false),
                    TotalTax = table.Column<float>(type: "real", nullable: true),
                    TotalAfterTax = table.Column<float>(type: "real", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Money = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaissesTransferes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaissesWithdraws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caisse_ID = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeBar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quentity = table.Column<float>(type: "real", nullable: false),
                    BuyPrice = table.Column<float>(type: "real", nullable: false),
                    SalePrice = table.Column<float>(type: "real", nullable: false),
                    WholesalePrice = table.Column<float>(type: "real", nullable: false),
                    TaxValue = table.Column<float>(type: "real", nullable: false),
                    SalePriceTax = table.Column<float>(type: "real", nullable: false),
                    IsTaxed = table.Column<bool>(type: "bit", nullable: false),
                    DateExperation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinQty = table.Column<float>(type: "real", nullable: true),
                    MaxDiscount = table.Column<float>(type: "real", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalOrder = table.Column<float>(type: "real", nullable: false),
                    PaidUP = table.Column<float>(type: "real", nullable: false),
                    Remain = table.Column<float>(type: "real", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deserveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<float>(type: "real", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    DeservedTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deserveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deserveds_DeservedsTypes_DeservedTypeId",
                        column: x => x.DeservedTypeId,
                        principalTable: "DeservedsTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Deserveds_DeservedsTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DeservedsTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Buys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Total = table.Column<float>(type: "real", nullable: false),
                    PaidUP = table.Column<float>(type: "real", nullable: false),
                    Remain = table.Column<float>(type: "real", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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
                    Quentity = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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
                    Qty = table.Column<float>(type: "real", nullable: false),
                    Buy_Price = table.Column<float>(type: "real", nullable: false),
                    Sale_PriceTax = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsQuantities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsQuantities_Products_Pro_ID",
                        column: x => x.Pro_ID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Quentity = table.Column<float>(type: "real", nullable: false),
                    BuyPrice = table.Column<float>(type: "real", nullable: false),
                    SalePrice = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxValue = table.Column<float>(type: "real", nullable: false),
                    PriceTax = table.Column<float>(type: "real", nullable: false),
                    SalePriceTax = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsTransfers_Products_Pro_ID",
                        column: x => x.Pro_ID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReturnsDetails",
                columns: table => new
                {
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Pro_ID = table.Column<int>(type: "int", nullable: false),
                    Sup_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cust_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    TaxValue = table.Column<float>(type: "real", nullable: false),
                    PriceWithTax = table.Column<float>(type: "real", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnsDetails", x => new { x.Pro_ID, x.Order_ID });
                    table.ForeignKey(
                        name: "FK_ReturnsDetails_Products_Pro_ID",
                        column: x => x.Pro_ID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturnsDetails_Returns_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Returns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMoney",
                columns: table => new
                {
                    Cust_ID = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Cust_Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reminder_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMoney", x => new { x.Order_ID, x.Cust_ID });
                    table.ForeignKey(
                        name: "FK_CustomerMoney_Customer_Cust_ID",
                        column: x => x.Cust_ID,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerMoney_Sales_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerReport",
                columns: table => new
                {
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Cust_ID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cust_Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerReport", x => new { x.Order_ID, x.Cust_ID });
                    table.ForeignKey(
                        name: "FK_CustomerReport_Customer_Cust_ID",
                        column: x => x.Cust_ID,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerReport_Sales_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetails",
                columns: table => new
                {
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Cust_ID = table.Column<int>(type: "int", nullable: false),
                    Pro_ID = table.Column<int>(type: "int", nullable: false),
                    Quentity = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    TaxValue = table.Column<float>(type: "real", nullable: false),
                    PriceWithTax = table.Column<float>(type: "real", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => new { x.Pro_ID, x.Cust_ID, x.Order_ID });
                    table.ForeignKey(
                        name: "FK_SalesDetails_Customer_Cust_ID",
                        column: x => x.Cust_ID,
                        principalTable: "Customer",
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
                    table.ForeignKey(
                        name: "FK_SalesDetails_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesProfits",
                columns: table => new
                {
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Pro_ID = table.Column<int>(type: "int", nullable: false),
                    Cust_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quentity = table.Column<float>(type: "real", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    Discount = table.Column<float>(type: "real", nullable: true),
                    Total = table.Column<float>(type: "real", nullable: true),
                    Tax_Value = table.Column<float>(type: "real", nullable: true),
                    Price_Tax = table.Column<float>(type: "real", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buy_Price = table.Column<float>(type: "real", nullable: true),
                    SaleId = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProfits", x => new { x.Pro_ID, x.Order_ID });
                    table.ForeignKey(
                        name: "FK_SalesProfits_Products_Pro_ID",
                        column: x => x.Pro_ID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesProfits_Sales_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesProfits_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BuyDetails",
                columns: table => new
                {
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Sup_ID = table.Column<int>(type: "int", nullable: false),
                    Pro_ID = table.Column<int>(type: "int", nullable: false),
                    Quentity = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    TaxValue = table.Column<float>(type: "real", nullable: false),
                    PriceWithTax = table.Column<float>(type: "real", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyDetails", x => new { x.Pro_ID, x.Sup_ID, x.Order_ID });
                    table.ForeignKey(
                        name: "FK_BuyDetails_Buys_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Buys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Sup_ID = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reminder_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuppliersMoneys", x => new { x.Order_ID, x.Sup_ID });
                    table.ForeignKey(
                        name: "FK_SuppliersMoneys_Buys_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Buys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Sup_ID = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuppliersReports", x => new { x.Order_ID, x.Sup_ID });
                    table.ForeignKey(
                        name: "FK_SuppliersReports_Buys_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Buys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SuppliersReports_Suppliers_Sup_ID",
                        column: x => x.Sup_ID,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Category One " },
                    { 2, "Category two " },
                    { 3, "Category Three " }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "CustomerName", "Notes", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Ben Smara", "Customer One ", "Seeded Data", "0697357397" },
                    { 2, "Mermad", "Customer two ", "Seeded Data", "0754653721" },
                    { 3, "HadjMEssaoud", "Customer Three ", "Seeded Data", "0697357546" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "Notes", "PhoneNumber", "SupplierName" },
                values: new object[,]
                {
                    { 1, "Ben Smara", "Seeded Data", "0697357397", "Supplier One " },
                    { 2, "Mermad", "Seeded Data", "0754653721", "Supplier two " },
                    { 3, "HadjMEssaoud", "Seeded Data", "0697357546", "Supplier Three " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyDetails_Order_ID",
                table: "BuyDetails",
                column: "Order_ID");

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
                name: "IX_CustomerMoney_Cust_ID",
                table: "CustomerMoney",
                column: "Cust_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerReport_Cust_ID",
                table: "CustomerReport",
                column: "Cust_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Deserveds_DeservedTypeId",
                table: "Deserveds",
                column: "DeservedTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Deserveds_TypeId",
                table: "Deserveds",
                column: "TypeId");

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
                name: "IX_SalesDetails_SaleId",
                table: "SalesDetails",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesProfits_Order_ID",
                table: "SalesProfits",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesProfits_SaleId",
                table: "SalesProfits",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SuppliersMoneys_Sup_ID",
                table: "SuppliersMoneys",
                column: "Sup_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SuppliersReports_Sup_ID",
                table: "SuppliersReports",
                column: "Sup_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "BankDeposit");

            migrationBuilder.DropTable(
                name: "BankWithdraw");

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
                name: "CustomerMoney");

            migrationBuilder.DropTable(
                name: "CustomerReport");

            migrationBuilder.DropTable(
                name: "Deserveds");

            migrationBuilder.DropTable(
                name: "OrderPrintData");

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
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
