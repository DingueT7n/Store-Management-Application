using System.Data;
using System.Globalization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Code.Helper
{
    public static class FactureHelper
    {
        public static decimal CalculateDiscountPercentage(decimal originalPrice, decimal discountedPrice)
        {
            if (originalPrice <= 0 || discountedPrice < 0)
                return 0;

            decimal discount = originalPrice - discountedPrice;
            decimal percentage = (discount / originalPrice) * 100;

            return Math.Round(percentage, 2); // Rounds to 2 decimal places
        }
        public static async Task<DataTable> GetSellDetailsDataTableAsync(int orderId)
        {

            using (var context = new ApplicationDbContext())
            {
                var orderIdParam = new SqlParameter("@orderID", orderId);
                var connection = context.Database.GetDbConnection();

                try
                {
                    await connection.OpenAsync();


                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "EXEC [dbo].[get_all_sell_details] @orderID";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(orderIdParam);


                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            DataTable sellDetailsTable = new DataTable();
                            sellDetailsTable.Load(reader);
                            return sellDetailsTable;
                        }
                    }
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
        public static async Task<DataTable> GetVoucherRecieptDataTableAsync(int orderId)
        {

            using (var context = new ApplicationDbContext())
            {
                var orderIdParam = new SqlParameter("@Vou_id", orderId);
                var connection = context.Database.GetDbConnection();

                try
                {
                    await connection.OpenAsync();


                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "EXEC [dbo].get_Voucher_Reciept_reports @Vou_id";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(orderIdParam);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            DataTable sellDetailsTable = new DataTable();
                            sellDetailsTable.Load(reader);
                            return sellDetailsTable;
                        }
                    }
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
        public static async Task<DataTable> GetVoucherSenderDataTableAsync(int orderId)
        {

            using (var context = new ApplicationDbContext())
            {
                var orderIdParam = new SqlParameter("@Vou_id", orderId);
                var connection = context.Database.GetDbConnection();

                try
                {
                    await connection.OpenAsync();


                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "EXEC [dbo].get_Voucher_send_reports @Vou_id";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(orderIdParam);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            DataTable sellDetailsTable = new DataTable();
                            sellDetailsTable.Load(reader);
                            return sellDetailsTable;
                        }
                    }
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
        public static async Task<DataTable> GetBuyDetailsDataTableAsync(int orderId)
        {

            using (var context = new ApplicationDbContext())
            {
                var orderIdParam = new SqlParameter("@orderID", orderId);
                var connection = context.Database.GetDbConnection();

                try
                {
                    await connection.OpenAsync();


                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "EXEC [dbo].[get_all_buy_details] @orderID";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(orderIdParam);


                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            DataTable sellDetailsTable = new DataTable();
                            sellDetailsTable.Load(reader);
                            return sellDetailsTable;
                        }
                    }
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
        public static async Task<DataTable> GetProformaFactureDataTableAsync(int orderId)
        {

            using (var context = new ApplicationDbContext())
            {
                var orderIdParam = new SqlParameter("@orderID", orderId);
                var connection = context.Database.GetDbConnection();

                try
                {
                    await connection.OpenAsync();


                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "EXEC [dbo].[get_proforma_facture] @orderID";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(orderIdParam);


                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            DataTable sellDetailsTable = new DataTable();
                            sellDetailsTable.Load(reader);
                            return sellDetailsTable;
                        }
                    }
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
        public static async Task<DataTable> GetSupplierAccountDataTableAsync(int sup_id)
        {

            using (var context = new ApplicationDbContext())
            {
                var orderIdParam = new SqlParameter("@Sup_iD", sup_id);
                var connection = context.Database.GetDbConnection();

                try
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "EXEC [dbo].[get_all_supplier_Accounts_reports] @Sup_iD";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(orderIdParam);


                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            DataTable sellDetailsTable = new DataTable();
                            sellDetailsTable.Load(reader);
                            return sellDetailsTable;
                        }
                    }
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
        public static async Task<DataTable> GetCustomerAccountDataTableAsync(int Cust_iD)
        {

            using (var context = new ApplicationDbContext())
            {
                var orderIdParam = new SqlParameter("@Cust_iD", Cust_iD);
                var connection = context.Database.GetDbConnection();

                try
                {
                    await connection.OpenAsync();


                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "EXEC [dbo].[get_all_Customer_Accounts_reports] @Cust_iD";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(orderIdParam);


                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            DataTable sellDetailsTable = new DataTable();
                            sellDetailsTable.Load(reader);
                            return sellDetailsTable;
                        }
                    }
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
        public static async Task<DataTable> GetBuyReportDataTableAsync(DateTime datefrom, DateTime dateto)
        {

            using (var context = new ApplicationDbContext())
            {
                var orderFromParam = new SqlParameter("@orderFrom", datefrom);
                var orderToParam = new SqlParameter("@orderTo", dateto);
                var connection = context.Database.GetDbConnection();

                try
                {
                    await connection.OpenAsync();


                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "EXEC [dbo].get_all_buy_details_reports @orderFrom,@orderTo";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(orderFromParam);
                        command.Parameters.Add(orderToParam);


                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            DataTable sellDetailsTable = new DataTable();
                            sellDetailsTable.Load(reader);
                            return sellDetailsTable;
                        }
                    }
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
        public static async Task<DataTable> GetProfitReportDataTableAsync(DateTime datefrom, DateTime dateto)
        {

            using (var context = new ApplicationDbContext())
            {
                var orderFromParam = new SqlParameter("@orderFrom", datefrom);
                var orderToParam = new SqlParameter("@orderTo", dateto);
                var connection = context.Database.GetDbConnection();

                try
                {
                    await connection.OpenAsync();


                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "EXEC [dbo].get_all_profit_reports @orderFrom,@orderTo";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(orderFromParam);
                        command.Parameters.Add(orderToParam);


                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            DataTable sellDetailsTable = new DataTable();
                            sellDetailsTable.Load(reader);
                            return sellDetailsTable;
                        }
                    }
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
        public static string GetHijriDate(bool withDay = true)
        {

            // Set Algeria's timezone (CET: UTC+1)
            TimeZoneInfo algeriaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            DateTime algeriaTime = TimeZoneInfo.ConvertTime(DateTime.Now, algeriaTimeZone);

            // Use UmAlQuraCalendar (More accurate than HijriCalendar)
            UmAlQuraCalendar umAlQuraCalendar = new UmAlQuraCalendar();
            CultureInfo hijriCulture = new CultureInfo("ar-SA"); // Saudi Arabic Culture
            hijriCulture.DateTimeFormat.Calendar = umAlQuraCalendar; // Use UmAlQuraCalendar

            // Get Hijri Date Components
            int hijriYear = umAlQuraCalendar.GetYear(algeriaTime);
            int hijriMonth = umAlQuraCalendar.GetMonth(algeriaTime);
            int hijriDay = umAlQuraCalendar.GetDayOfMonth(algeriaTime);
            // Create the Correct Hijri Date
            DateTime hijriDate = umAlQuraCalendar.ToDateTime(hijriYear, hijriMonth, hijriDay,
                                                             algeriaTime.Hour, algeriaTime.Minute,
                                                             algeriaTime.Second, algeriaTime.Millisecond);
            if (!withDay)
            {
                return hijriDate.ToString("dd MMMM yyyy", hijriCulture);
            }
            else
                return hijriDate.ToString("dddd, dd MMMM yyyy", hijriCulture);

        }
        public static string GetGregorianDate()
        {

            // Get current Gregorian date in Arabic
            CultureInfo gregorianCulture = new CultureInfo("ar-DZ");
            gregorianCulture.DateTimeFormat.Calendar = new GregorianCalendar(); // Force Gregorian calendar
            return DateTime.Now.ToString("dddd, dd MMMM yyyy", gregorianCulture);

        }

    }
}
