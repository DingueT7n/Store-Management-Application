using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReportStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.Sql(@"

CREATE OR ALTER PROCEDURE [dbo].[get_all_buy_details]
@orderID int
as
SELECT [ORDER_ID] as 'رقم الفاتورة',
       Buys.Date,
       Buys.Time,
       Buys.User_Name,
       Buys.Total,
       Buys.PaidUP,
       Buys.Remain,
       SupplierName as 'اسم المورد',
       ProductName as 'اسم المنتج',
       BuyDetails.Quentity as 'الكمية' ,
       Price as ' الوحدة سعر',
       Discount as 'التخفيض',
       BuyDetails.Total as 'سعر منتج كلي'
     
FROM [dbo].BuyDetails
JOIN [dbo].Suppliers ON BuyDetails.Sup_ID = Suppliers.Id
JOIN [dbo].Products ON BuyDetails.Pro_ID = Products.Id
JOIN [dbo].Buys ON BuyDetails.Order_ID = Buys.Id
where Order_ID = @orderID
order by ProductName asc

");
            migrationBuilder.Sql(@"


CREATE OR ALTER PROCEDURE [dbo].[get_all_buy_details_reports]
@orderFrom date,
@orderTo date

AS
BEGIN

    DECLARE @TotalFactures DECIMAL(18, 2);

	SELECT @TotalFactures = SUM(TotalPaidPerInvoice)
		FROM (
			SELECT 
				B.Id AS InvoiceId,
				MAX(B.Total) AS TotalPaidPerInvoice -- Use MAX to ensure only one PaidUP per invoice
			FROM [dbo].Buys AS B
			WHERE CAST(B.Date AS DATE) BETWEEN @orderFrom AND @orderTo
			GROUP BY B.Id
		) AS PaidUpSummary;
    -- Calculate the total PaidUP for the specified date range
    DECLARE @TotalPaidUP DECIMAL(18, 2);

    SELECT @TotalPaidUP = SUM(TotalPaidPerInvoice)
    FROM (
        SELECT 
            B.Id AS InvoiceId,
            MAX(B.PaidUP) AS TotalPaidPerInvoice -- Use MAX to ensure only one PaidUP per invoice
        FROM [dbo].Buys AS B
        WHERE CAST(B.Date AS DATE) BETWEEN @orderFrom AND @orderTo
        GROUP BY B.Id
    ) AS PaidUpSummary;

	DECLARE @TotalRemain DECIMAL(18, 2);

    SELECT @TotalRemain = SUM(TotalRemainPerInvoice)
    FROM (
        SELECT 
            B.Id AS InvoiceId,
            MAX(B.Remain) AS TotalRemainPerInvoice -- Use MAX to ensure only one PaidUP per invoice
        FROM [dbo].Buys AS B
        WHERE CAST(B.Date AS DATE) BETWEEN @orderFrom AND @orderTo
        GROUP BY B.Id
    ) AS RemainpSummary;

    -- Calculate the maximum count of distinct products per invoice
    DECLARE @MaxUniqueProducts INT;

    SELECT @MaxUniqueProducts = MAX(ProductCount)
    FROM (
        SELECT 
            BD.Order_ID,
            COUNT(DISTINCT BD.Pro_ID) AS ProductCount
        FROM [dbo].BuyDetails AS BD
        JOIN [dbo].Buys AS B ON BD.Order_ID = B.Id
        WHERE CAST(B.Date AS DATE) BETWEEN @orderFrom AND @orderTo
        GROUP BY BD.Order_ID
    ) AS ProductCounts;

    -- Main query
    SELECT 
        [ORDER_ID] as 'رقم الفاتورة',
        Buys.Date,
        Buys.Time,
        Buys.User_Name,
        Buys.Total,
        Buys.PaidUP,
        Buys.Remain,
        SupplierName as 'اسم المورد',
        ProductName as 'اسم المنتج',
        BuyDetails.Quentity as 'الكمية',
        Price as 'سعر الشراء',
        Discount as 'التخفيض',
        BuyDetails.Total as 'سعر منتج كلي',
        (SELECT COUNT(DISTINCT Pro_ID) 
         FROM [dbo].BuyDetails AS BD 
         WHERE BD.Order_ID = BuyDetails.Order_ID) AS 'عدد المنتجات الفريدة',
        @TotalPaidUP AS 'إجمالي المدفوع',
        @MaxUniqueProducts AS 'أقصى عدد منتجات فريدة',
		@TotalRemain as 'اجمالي المتبقي',
		@TotalFactures as  'اجمالي الفاتورات'
	
    FROM [dbo].BuyDetails
    JOIN [dbo].Suppliers ON BuyDetails.Sup_ID = Suppliers.Id
    JOIN [dbo].Products ON BuyDetails.Pro_ID = Products.Id
    JOIN [dbo].Buys ON BuyDetails.Order_ID = Buys.Id
    WHERE CAST(Buys.Date AS DATE) BETWEEN @orderFrom AND @orderTo
    ORDER BY Order_ID ASC;
END


");
            migrationBuilder.Sql(@"


CREATE OR ALTER PROCEDURE [dbo].[get_all_Customer_Accounts_reports]
@Cust_iD int
AS
BEGIN
    -- Calculate the total PaidUP for the specified date range
  
    -- Main query
    SELECT 
        [ORDER_ID] as 'رقم الفاتورة',
        Customers.CustomerName as 'اسم العميل',
        Price as 'الدين',
        Order_Date as 'تاريخ اخذ الدين',
        CustomersMoneys.Reminder_Date as 'تاريخ الاستحقاق'
	
    FROM [dbo].CustomersMoneys
    JOIN [dbo].Customers ON CustomersMoneys.Cust_ID = Customers.Id
    JOIN [dbo].Sales ON CustomersMoneys.Order_ID = Sales.Id
    WHERE CustomersMoneys.Cust_ID= @Cust_iD
    ORDER BY Order_ID ASC;
END



");
            migrationBuilder.Sql(@"


CREATE OR ALTER PROCEDURE [dbo].[get_all_profit_reports]
@orderFrom date,
@orderTo date

AS
BEGIN
    -- Calculate the total PaidUP for the specified date range
    DECLARE @TotalFactures DECIMAL(18, 2);

    SELECT @TotalFactures = SUM(TotalPaidPerInvoice)
    FROM (
        SELECT 
            B.Id AS InvoiceId,
            MAX(B.TotalOrder) AS TotalPaidPerInvoice -- Use MAX to ensure only one PaidUP per invoice
        FROM [dbo].Sales AS B
        WHERE CAST(B.Date AS DATE) BETWEEN @orderFrom AND @orderTo
        GROUP BY B.Id
    ) AS PaidUpSummary;

	  DECLARE @TotalPaidUP DECIMAL(18, 2);

    SELECT @TotalPaidUP = SUM(TotalPaidPerInvoice)
    FROM (
        SELECT 
            B.Id AS InvoiceId,
            MAX(B.PaidUP) AS TotalPaidPerInvoice -- Use MAX to ensure only one PaidUP per invoice
        FROM [dbo].Sales AS B
        WHERE CAST(B.Date AS DATE) BETWEEN @orderFrom AND @orderTo
        GROUP BY B.Id
    ) AS PaidUpSummary;

	DECLARE @TotalRemain DECIMAL(18, 2);

    SELECT @TotalRemain = SUM(TotalRemainPerInvoice)
    FROM (
        SELECT 
            B.Id AS InvoiceId,
            MAX(B.Remain) AS TotalRemainPerInvoice -- Use MAX to ensure only one PaidUP per invoice
        FROM [dbo].Sales AS B
        WHERE CAST(B.Date AS DATE) BETWEEN @orderFrom AND @orderTo
        GROUP BY B.Id
    ) AS RemainpSummary;

	

    -- Calculate the maximum count of distinct products per invoice
    DECLARE @MaxUniqueProducts INT;

    SELECT @MaxUniqueProducts = MAX(ProductCount)
    FROM (
        SELECT 
            BD.Order_ID,
            COUNT(DISTINCT BD.Pro_ID) AS ProductCount
        FROM [dbo].SalesDetails AS BD
        JOIN [dbo].Sales AS B ON BD.Order_ID = B.Id
        WHERE CAST(B.Date AS DATE) BETWEEN @orderFrom AND @orderTo
        GROUP BY BD.Order_ID
    ) AS ProductCounts;

    -- Main query
    SELECT 
        [ORDER_ID] as 'رقم الفاتورة',
        Sales.Date,
        Sales.Time,
        Sales.User_Name,
        Sales.TotalOrder,
        Sales.PaidUP,
        Sales.Remain,
        Cust_Name as 'اسم العميل',
        ProductName as 'اسم المنتج',
        Buy_Price as 'سعر الشراء',
        Price as 'سعر البيع',
        SalesProfits.Quentity as 'الكمية',
        SalesProfits.Total as 'سعر منتج كلي',
        ((SalesProfits.Price -Buy_Price)*SalesProfits.Quentity) as 'الربح',
        @TotalPaidUP AS 'إجمالي المدفوع',
        @MaxUniqueProducts AS 'أقصى عدد منتجات فريدة',
		@TotalRemain as 'اجمالي المتبقي',
		@TotalFactures as  'اجمالي الفاتورات'
    FROM [dbo].SalesProfits
    JOIN [dbo].Products ON SalesProfits.Pro_ID = Products.Id
    JOIN [dbo].Sales ON SalesProfits.Order_ID = Sales.Id

    WHERE CAST(Sales.Date AS DATE) BETWEEN @orderFrom AND @orderTo
    ORDER BY Order_ID ASC;
END


");
            migrationBuilder.Sql(@"


CREATE OR ALTER PROCEDURE [dbo].[get_all_sell_details]
@orderID int
as
SELECT [ORDER_ID] as 'رقم الفاتورة',
       Sales.Date,
       Sales.Time,
       Sales.User_Name,
       Sales.TotalOrder,
       Sales.PaidUP,
       Sales.Remain,
       CustomerName as 'اسم العميل',
       ProductName as 'اسم المنتج',
       SalesDetails.Quentity as 'الكمية' ,
       Price as ' الوحدة سعر',
       Discount as 'التخفيض',
       Total as 'سعر منتج كلي'
     
FROM [dbo].SalesDetails
JOIN [dbo].Customers ON SalesDetails.Cust_ID = Customers.Id
JOIN [dbo].Products ON SalesDetails.Pro_ID = Products.Id
JOIN [dbo].Sales ON SalesDetails.Order_ID = Sales.Id
where Order_ID = @orderID
order by ProductName asc




");
            migrationBuilder.Sql(@"


CREATE OR ALTER PROCEDURE [dbo].[get_all_supplier_Accounts_reports]
@Sup_iD int
AS
BEGIN
    -- Calculate the total PaidUP for the specified date range
  
    -- Main query
    SELECT 
        [ORDER_ID] as 'رقم الفاتورة',
        Suppliers.SupplierName as 'اسم المورد',
        Price as 'الدين',
        Order_Date as 'تاريخ اخذ الدين',
        SuppliersMoneys.Time as 'وقت الدين',
        SuppliersMoneys.Reminder_Date as 'تاريخ الاستحقاق'
	
    FROM [dbo].SuppliersMoneys
    JOIN [dbo].Suppliers ON SuppliersMoneys.Sup_ID = Suppliers.Id
    JOIN [dbo].Buys ON SuppliersMoneys.Order_ID = Buys.Id
    WHERE SuppliersMoneys.Sup_ID= @Sup_iD
    ORDER BY Order_ID ASC;
END





");
            migrationBuilder.Sql(@"



CREATE OR ALTER PROCEDURE [dbo].[get_proforma_facture]
@orderID int
as
SELECT ProformaInvoices.InvoiceNumber as 'رقم الفاتورة',
       ProformaInvoices.Date,
       ProformaInvoices.UserName,
       ProformaInvoices.TotalFaacture,
       ProformaInvoiceDetails.ProductName,
       ProformaInvoiceDetails.UnitPrice,
       ProformaInvoiceDetails.Quentity,
       Discount as 'التخفيض',
       ProformaInvoiceDetails.Total,
       CustomerName as 'اسم العميل'
     
FROM [dbo].ProformaInvoiceDetails
JOIN [dbo].Products ON ProformaInvoiceDetails.ProductId = Products.Id
JOIN [dbo].ProformaInvoices ON ProformaInvoiceDetails.ProformaId = ProformaInvoices.Id
where ProformaInvoiceDetails.ProformaId = @orderID
order by ProductName asc



");
            migrationBuilder.Sql(@"


CREATE OR ALTER PROCEDURE [dbo].[get_Voucher_Reciept_reports]
@Vou_id int
AS
BEGIN
    SELECT 
    ReceiptVouchers.Id AS 'رقم السند',
    ReceiptVouchers.ReciverName AS 'اسم المورد',
    ReceiptVouchers.Price AS 'المبلغ',
    ReceiptVouchers.[From] AS 'تم القبض من',
    ReceiptVouchers.Reason AS 'السبب',
    ReceiptVouchers.[Date] AS 'تاريخ العملية',
    ReceiptVouchers.[Time] AS 'وقت العملية'
FROM [dbo].ReceiptVouchers
WHERE ReceiptVouchers.Id = @Vou_id

    
END



");
            migrationBuilder.Sql(@"

CREATE OR ALTER PROCEDURE [dbo].[get_Voucher_send_reports]
    @Vou_id INT
AS
BEGIN
   

    SELECT 
        SendVouchers.Id AS 'رقم السند',
        SendVouchers.SenderName AS 'اسم المرسل',
        SendVouchers.Price AS 'المبلغ',
        SendVouchers.[To] AS 'السند الى',
        SendVouchers.Reason AS 'السبب',
        SendVouchers.[Date] AS 'تاريخ العملية',
        SendVouchers.[Time] AS 'وقت العملية'
    FROM [dbo].SendVouchers
    WHERE SendVouchers.Id = @Vou_id;
END
");
        }
        //C:\Users\Dingue\source\repos\Store Management\Store.ApplicationUI\StoredProcedures\
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            DROP PROCEDURE IF EXISTS dbo.get_all_buy_details;
            DROP PROCEDURE IF EXISTS dbo.get_all_buy_details_reports;
            DROP PROCEDURE IF EXISTS dbo.get_all_Customer_Accounts_reports;
            DROP PROCEDURE IF EXISTS dbo.get_all_profit_reports;
            DROP PROCEDURE IF EXISTS dbo.get_all_sell_details;
            DROP PROCEDURE IF EXISTS dbo.get_all_supplier_Accounts_reports;
            DROP PROCEDURE IF EXISTS dbo.get_proforma_facture;
            DROP PROCEDURE IF EXISTS dbo.get_Voucher_Reciept_reports;
            DROP PROCEDURE IF EXISTS dbo.get_Voucher_send_reports;
        ");
        }
    }
}
