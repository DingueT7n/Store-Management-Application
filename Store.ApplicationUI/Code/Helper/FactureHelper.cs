using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Code.Helper
{
    public static class FactureHelper
    {
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
    }
}
