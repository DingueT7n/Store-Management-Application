using System.Data;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.SupplierGui
{
    public partial class SuppliersUserControl : UserControl
    {
        private static SuppliersUserControl? _suppliersUserControl;
        private static MainForm? _main;
        private static ApplicationDbContext? _context;
        public static SuppliersRepository? suppliersRepository;
        private AddSupplierForm addSupplierrForm;
        public SuppliersUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_suppliersUserControl == null);
        }

        public static SuppliersUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _context = new ApplicationDbContext();
            if (CheckInstance())
            {
                suppliersRepository = new SuppliersRepository(_context);


                _suppliersUserControl = new SuppliersUserControl();

            }

            // Return the singleton instance
            _suppliersUserControl?.LoadData();
            return _suppliersUserControl;
        }
        public async void SetProductsToDgv()
        {
            //DgvِSupplier.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            DgvِSupplier.DataSource = await _context.Suppliers.AsNoTracking().OrderBy(x => x.SupplierName)
                .ToListAsync();
        }

        public static void RefreshDgv()
        {
            //DgvِSupplier.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _suppliersUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => suppliersRepository.IsConnected()))
            {
                //Start Load Data

                // if its an admin or Normal user 

                SetProductsToDgv();
                SetColumns();
                //_data.Clear();
            }
            else
            {

                LoadingForm.Instance(_main).Hide();
                //No Connection
                MsgHelper.ShowServerError();
            }
            //Hideloading
            LoadingForm.Instance(_main).Hide();
            // Show EmptyDAta
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِSupplier);
        }

        private void SetColumns()
        {
            //DgvِSupplier.Columns[0].HeaderCell.Value = "المعرف";
            DgvِSupplier.Columns[0].HeaderCell.Value = "اسم المورد";
            DgvِSupplier.Columns[1].HeaderCell.Value = "العنوان";
            DgvِSupplier.Columns[2].HeaderCell.Value = "رقم الهاتف";
            DgvِSupplier.Columns[3].HeaderCell.Value = "ملاحظة";
            DgvِSupplier.Columns[4].HeaderCell.Value = "اعلى دين مسموح به";
            DgvِSupplier.Columns[5].HeaderCell.Value = "مجموع الديون";
            DgvِSupplier.Columns[6].HeaderCell.Value = "معرف المورد";
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {

            ToasterHelper.PlayNotificationSound();
            addSupplierrForm = AddSupplierForm.Instance(_main);
            addSupplierrForm.Show();

        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (DgvِSupplier.Rows.Count > 0)
            {
                if (addSupplierrForm == null || addSupplierrForm.IsDisposed)
                {
                    addSupplierrForm = AddSupplierForm.Instance(_main);
                    addSupplierrForm.SetDataToEdit(
                        DgvِSupplier.CurrentRow.Cells[0].Value.ToString(),
                        DgvِSupplier.CurrentRow.Cells[1].Value.ToString(),
                        DgvِSupplier.CurrentRow.Cells[2].Value.ToString(),
                        DgvِSupplier.CurrentRow.Cells[4].Value.ToString(),
                        DgvِSupplier.CurrentRow.Cells[3].Value.ToString(),
                        DgvِSupplier.CurrentRow.Cells[6].Value.ToString());
                    addSupplierrForm.Show();
                }
                else
                {
                    addSupplierrForm.Focus();
                }
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                suppliersRepository.DeleteAsync(DgvِSupplier.CurrentRow.Cells[6].Value.ToString());
                Code.Helper.ToasterHelper.ShowDeletedToast();

            }
            RefreshDgv();
        }
        private List<Core.Entities.Suppliers.Supplier> data;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");

            DgvِSupplier.DataSource = suppliersRepository.SearchAll(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِSupplier);
            txtSearch.Text = string.Empty;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            LoadData();
        }

        private async void btnExportSupplier_Click(object sender, EventArgs e)
        {

            data = await _context.Suppliers.ToListAsync();



            LoadingForm.Instance(_main).Hide();

            ExportExcel(data);
        }
        private void ExportExcel(List<Core.Entities.Suppliers.Supplier> data)
        {
            // Define Data Table
            DataTable dataTable = new DataTable();

            // Convert to Data Table
            using (var reader = FastMember.ObjectReader.Create(data))
            {
                dataTable.Load(reader);
            }

            // Re-Set DataTable
            dataTable = arrangedDataTable(dataTable);

            // Send to export
            ExcelHelper.Export(dataTable, "Suppliers");
        }
        private DataTable arrangedDataTable(DataTable dataTable)
        {
            dataTable.Columns["Id"].SetOrdinal(0);
            dataTable.Columns["Id"].ColumnName = "معرف";

            dataTable.Columns["SupplierName"].SetOrdinal(1);
            dataTable.Columns["SupplierName"].ColumnName = "اسم المورد";


            dataTable.Columns["Address"].SetOrdinal(2);
            dataTable.Columns["Address"].ColumnName = "عنوان المورد";


            dataTable.Columns["PhoneNumber"].SetOrdinal(3);
            dataTable.Columns["PhoneNumber"].ColumnName = "رقم هاتف المورد";

            dataTable.Columns["Notes"].SetOrdinal(4);
            dataTable.Columns["Notes"].ColumnName = "الملاحظة";

            dataTable.Columns["MaxDebtAllowed"].SetOrdinal(5);
            dataTable.Columns["MaxDebtAllowed"].ColumnName = "اقصى دين";

            dataTable.Columns["TotalDebts"].SetOrdinal(6);
            dataTable.Columns["TotalDebts"].ColumnName = "مجموع الديون الغير مسددة";
            return dataTable;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
