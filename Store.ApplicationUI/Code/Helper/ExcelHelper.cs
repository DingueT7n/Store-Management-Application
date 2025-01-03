using System.Data;
using System.IO;
using ClosedXML.Excel;

namespace Store.ApplicationUI.Code.Helper
{
    public class ExcelHelper
    {
        public static void Export(DataTable dataTable, string sheetName)
        {
            // Define Save Dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "Excel File (.xlsx)|*.xlsx";
            saveFileDialog.Title = "Export Excel File";
            saveFileDialog.FileName = sheetName + " In " + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "  At " + DateTime.Now.Hour + " ; " + DateTime.Now.Minute;

            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Export
                try
                {
                    using (XLWorkbook xLWorkbook = new XLWorkbook())
                    {
                        xLWorkbook.AddWorksheet(dataTable, sheetName);
                        using (MemoryStream ma = new MemoryStream())
                        {
                            xLWorkbook.SaveAs(ma);
                            File.WriteAllBytes(saveFileDialog.FileName, ma.ToArray());
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

        }
    }
}
