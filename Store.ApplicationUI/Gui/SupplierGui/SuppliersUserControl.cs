using System.Data;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.Core.Entities.Suppliers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.SupplierGui
{
    public partial class SuppliersUserControl : UserControl
    {
        private readonly MainForm _main;
        private static ApplicationDbContext? _context;
        public static ISuppliersRepository? _suppliersRepository;
        private readonly ControlManager _controlManager;

        public SuppliersUserControl(MainForm main, ApplicationDbContext context, ISuppliersRepository suppliersRepository, ControlManager controlManager)
        {
            InitializeComponent();
            _main = main;
            _context = context;
            _suppliersRepository = suppliersRepository;
            _controlManager = controlManager;


        }


        public async Task SetProductsToDgv()
        {
            //DgvِSupplier.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));

            DgvِSupplier.DataSource = await _suppliersRepository
                .GetAllAsync();
        }


        // methodes 
        public async Task LoadData()
        {

            dgvHelper.ResetForm(this);

            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await _suppliersRepository.IsConnectedAsync())
            {
                //Start Load Data

                // if its an admin or Normal user 

                SetColumns();
                await SetProductsToDgv();
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
            DgvِSupplier.DataSource = new List<Supplier>();
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

            AddSupplierForm form = _controlManager.GetF<AddSupplierForm>();

            form.ShowDialog();

        }

        private async void btnEditSupplier_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (DgvِSupplier.Rows.Count > 0)
            {
                AddSupplierForm form = await _controlManager.GetFAsync<AddSupplierForm>();


                await form.SetDataToEdit(DgvِSupplier.CurrentRow.Cells[6].Value.ToString());
                form.ShowDialog();

            }
        }

        private async void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                await _suppliersRepository.DeleteAsync(DgvِSupplier.CurrentRow.Cells[6].Value.ToString());
                Code.Helper.ToasterHelper.ShowDeletedToast();

                await SetProductsToDgv();
            }
        }
        private List<Core.Entities.Suppliers.Supplier> data;

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");

            DgvِSupplier.DataSource = await _suppliersRepository.SearchAll(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِSupplier);
            txtSearch.Text = string.Empty;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            await LoadData();
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

        private async void SuppliersUserControl_Load(object sender, EventArgs e)
        {
            await LoadData();
        }
    }
}
