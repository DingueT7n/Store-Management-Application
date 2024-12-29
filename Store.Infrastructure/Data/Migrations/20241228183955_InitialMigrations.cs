using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
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
                    Money = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(100)", nullable: true),
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
                    Money = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
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
                    Money = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(100)", nullable: true),
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
                    ProductBarcode = table.Column<string>(type: "nvarchar(100)", nullable: true),
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
                    MoneyinCaisse = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
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
                    Money = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(100)", nullable: true),
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
                    Address = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxDebtAllowed = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalDebts = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
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
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeservedsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    National_ID = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
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
                    Barcode = table.Column<double>(type: "float", nullable: false)
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(250)", nullable: true)
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
                    Time = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalOrder = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaidUP = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Remain = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sale8cms",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalOrder = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaidUP = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Remain = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SendVouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxDebtAllowed = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalDebts = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
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
                    TotalOrder = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalTax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalAfterTax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                    Money = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaissesTransferes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaissesWithdraws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caisse_ID = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeBar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SalePriceSeconde = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    WholesalePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SalePriceTax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsTaxed = table.Column<bool>(type: "bit", nullable: false),
                    DateExperation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinQty = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MaxDiscount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NbrProductInColis = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ColisageBareCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalOrder = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaidUP = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Remain = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "EmployeesBorrowMonies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Id = table.Column<int>(type: "int", nullable: true),
                    BorrowFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BorrowTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReminder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesBorrowMonies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesBorrowMonies_Employees_Emp_Id",
                        column: x => x.Emp_Id,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeesSalaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_ID = table.Column<int>(type: "int", nullable: false),
                    TotalSalary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalBorrow = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReminder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesSalaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesSalaries_Employees_Emp_ID",
                        column: x => x.Emp_ID,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesSalaryMinus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_ID = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Pay = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesSalaryMinus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesSalaryMinus_Employees_Emp_ID",
                        column: x => x.Emp_ID,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaidUP = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Remain = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                name: "EmployeesBorrowItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emp_Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesBorrowItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesBorrowItems_Employees_Emp_Id",
                        column: x => x.Emp_Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesBorrowItems_Products_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Products",
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
                    DiscountValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "ProductFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeBar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pro_Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFamilies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFamilies_Products_Pro_Id",
                        column: x => x.Pro_Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFamilies_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
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
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                    Qty = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Buy_Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Sale_PriceTax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
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
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Qty = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PriceWithTax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reminder_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomersMoneys_Sales_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomersReports_Sales_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PriceWithTax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
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
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tax_Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Price_Tax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buy_Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProfits", x => x.Id);
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
                    Quentity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PriceWithTax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reminder_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                });

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
                    UserProfit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UserBuyId = table.Column<int>(type: "int", nullable: true),
                    UserCaisseAndBankId = table.Column<int>(type: "int", nullable: true),
                    UserCustomerId = table.Column<int>(type: "int", nullable: true),
                    UserDeservedAndTaxId = table.Column<int>(type: "int", nullable: true),
                    UserEmployeeId = table.Column<int>(type: "int", nullable: true),
                    UserProductAndStoreId = table.Column<int>(type: "int", nullable: true),
                    UserRefundId = table.Column<int>(type: "int", nullable: true),
                    UserSaleId = table.Column<int>(type: "int", nullable: true),
                    UserSettingId = table.Column<int>(type: "int", nullable: true),
                    UserSupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserBuys_UserBuyId",
                        column: x => x.UserBuyId,
                        principalTable: "UserBuys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserCaissesAndBanks_UserCaisseAndBankId",
                        column: x => x.UserCaisseAndBankId,
                        principalTable: "UserCaissesAndBanks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserCustomers_UserCustomerId",
                        column: x => x.UserCustomerId,
                        principalTable: "UserCustomers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserDeservedAndTaxs_UserDeservedAndTaxId",
                        column: x => x.UserDeservedAndTaxId,
                        principalTable: "UserDeservedAndTaxs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserEmployees_UserEmployeeId",
                        column: x => x.UserEmployeeId,
                        principalTable: "UserEmployees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserProductsAndStores_UserProductAndStoreId",
                        column: x => x.UserProductAndStoreId,
                        principalTable: "UserProductsAndStores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserRefunds_UserRefundId",
                        column: x => x.UserRefundId,
                        principalTable: "UserRefunds",
                        principalColumn: "Id");
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
                name: "IX_EmployeesBorrowItems_Emp_Id",
                table: "EmployeesBorrowItems",
                column: "Emp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesBorrowItems_Item_Id",
                table: "EmployeesBorrowItems",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesBorrowMonies_Emp_Id",
                table: "EmployeesBorrowMonies",
                column: "Emp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesSalaries_Emp_ID",
                table: "EmployeesSalaries",
                column: "Emp_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesSalaryMinus_Emp_ID",
                table: "EmployeesSalaryMinus",
                column: "Emp_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscounts_Pro_Id",
                table: "ProductDiscounts",
                column: "Pro_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFamilies_Pro_Id",
                table: "ProductFamilies",
                column: "Pro_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFamilies_ProductId",
                table: "ProductFamilies",
                column: "ProductId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserBuys_Users_User_Id",
                table: "UserBuys",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCaissesAndBanks_Users_User_Id",
                table: "UserCaissesAndBanks",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCustomers_Users_User_Id",
                table: "UserCustomers",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeservedAndTaxs_Users_User_Id",
                table: "UserDeservedAndTaxs",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEmployees_Users_User_Id",
                table: "UserEmployees",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProductsAndStores_Users_User_Id",
                table: "UserProductsAndStores",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefunds_Users_User_Id",
                table: "UserRefunds",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_UserBuys_Users_User_Id",
                table: "UserBuys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCaissesAndBanks_Users_User_Id",
                table: "UserCaissesAndBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCustomers_Users_User_Id",
                table: "UserCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDeservedAndTaxs_Users_User_Id",
                table: "UserDeservedAndTaxs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEmployees_Users_User_Id",
                table: "UserEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProductsAndStores_Users_User_Id",
                table: "UserProductsAndStores");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRefunds_Users_User_Id",
                table: "UserRefunds");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSales_Users_User_Id",
                table: "UserSales");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_Users_User_Id",
                table: "UserSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSuppliers_Users_User_Id",
                table: "UserSuppliers");

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
                name: "EmployeesBorrowItems");

            migrationBuilder.DropTable(
                name: "EmployeesBorrowMonies");

            migrationBuilder.DropTable(
                name: "EmployeesSalaries");

            migrationBuilder.DropTable(
                name: "EmployeesSalaryMinus");

            migrationBuilder.DropTable(
                name: "OrderPrintData");

            migrationBuilder.DropTable(
                name: "ProductDiscounts");

            migrationBuilder.DropTable(
                name: "ProductFamilies");

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
                name: "sale8cms");

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
                name: "Employees");

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

            migrationBuilder.DropTable(
                name: "Users");

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
        }
    }
}
