using System.Data;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.Core.Entities.Customers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.CustomersGui
{
    public partial class CustomersUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly ICustomersRepository _customersRepository;
        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager;

        public CustomersUserControl(
             MainForm main,
             ICustomersRepository customersRepository,
             ApplicationDbContext context
             , ControlManager controlManager)
        {
            InitializeComponent();

            _main = main;
            _customersRepository = customersRepository;
            _context = context;
            _controlManager = controlManager;

        }



        public async Task SetProductsToDgv()
        {
            //DgvِCustomer.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));

            DgvِCustomer.DataSource = new List<Customer>();
            DgvِCustomer.DataSource = await _customersRepository.GetAllAsync();

        }

        public async Task LoadData()
        {
            LoadingForm.Instance(_main).Show();

            if (await _customersRepository.IsConnectedAsync())
            {
                await SetProductsToDgv();
                SetColumns();
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                // Add menu items
                ToolStripMenuItem editItem = new ToolStripMenuItem("التعديل");
                ToolStripMenuItem deleteItem = new ToolStripMenuItem("الحذف");
                ToolStripMenuItem similarItem = new ToolStripMenuItem("تصفية جميع الديون للعميل المحدد");
                // Add click events
                editItem.Click += EditItem_Click;
                deleteItem.Click += DeleteItem_Click;
                similarItem.Click += similarItem_Click;


                // Add items to the menu
                contextMenu.Items.AddRange(new ToolStripItem[] { editItem, deleteItem, similarItem });

                // Assign context menu to DataGridView
                DgvِCustomer.ContextMenuStrip = contextMenu;
            }
            else
            {
                LoadingForm.Instance(_main).Hide();
                MsgHelper.ShowServerError();
            }

            LoadingForm.Instance(_main).Hide();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            btnEditCustomer_Click(sender, e);
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Delete option clicked");
            btnDeleteCustomer_Click(sender, e);

        }
        private void similarItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Delete option clicked");
            clearAlldebtOfCustomer();

        }

        private async void clearAlldebtOfCustomer()
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowClearDebtDialog(DgvِCustomer.CurrentRow.Cells[0].Value.ToString()))
            {
                if (DgvِCustomer.SelectedRows.Count > 0)
                {
                    var query2 = await _context.CustomersMoneys.
                    Where(x => x.Cust_ID.ToString() == DgvِCustomer.CurrentRow.Cells[6].Value.ToString()).ToListAsync();
                    if (query2.Any())
                    {
                        _context.CustomersMoneys.RemoveRange(query2);
                    }
                    var customer = await _context.Customers
                        .FirstOrDefaultAsync(x => x.Id.ToString() == DgvِCustomer.CurrentRow.Cells[6].Value.ToString());
                    if (customer != null)
                    {
                        customer.TotalDebts = 0;

                        await _customersRepository.UpdateAsync(customer.Id.ToString(), customer);
                    }
                    await _context.SaveChangesAsync();

                }
            }
            Code.Helper.ToasterHelper.ShowDeletedToast();

            await LoadData();
        }

        private void SetColumns()
        {
            //DgvِCustomer.Columns[0].HeaderCell.Value = "المعرف";
            DgvِCustomer.Columns[0].HeaderCell.Value = "اسم العميل";
            DgvِCustomer.Columns[1].HeaderCell.Value = "العنوان";
            DgvِCustomer.Columns[2].HeaderCell.Value = "رقم الهاتف";
            DgvِCustomer.Columns[3].HeaderCell.Value = "ملاحظة";
            DgvِCustomer.Columns[4].HeaderCell.Value = "اعلى دين مسموح به";
            DgvِCustomer.Columns[5].HeaderCell.Value = "مجموع الديون";
            DgvِCustomer.Columns[6].HeaderCell.Value = "معرف العميل";
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            await LoadData();
        }

        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();

            var addCustomerForm = await _controlManager.GetFAsync<AddCustomerForm>();
            addCustomerForm.ShowDialog();

        }

        private async void btnEditCustomer_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (DgvِCustomer.Rows.Count > 0)
            {
                var form = await _controlManager.GetFAsync<AddCustomerForm>();


                //form.SetDataToEdit(
                //    DgvِCustomer.CurrentRow.Cells[0].Value.ToString(),
                //    DgvِCustomer.CurrentRow.Cells[1].Value.ToString(),
                //    DgvِCustomer.CurrentRow.Cells[2].Value.ToString(),
                //    DgvِCustomer.CurrentRow.Cells[4].Value.ToString(),
                //    DgvِCustomer.CurrentRow.Cells[3].Value.ToString(),
                //    DgvِCustomer.CurrentRow.Cells[6].Value.ToString());
                form.SetDataToEditFromId(
                 DgvِCustomer.CurrentRow.Cells[6].Value.ToString());
                form.ShowDialog();

            }
        }

        private async void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ToasterHelper.PlayNotificationSound();
                if (MsgHelper.ShowDeleteDialog())
                {
                    var customerId = Convert.ToInt32(DgvِCustomer.CurrentRow.Cells[6].Value);

                    // Step 1: Load all ProformaInvoices for this customer
                    var invoices = await _context.ProformaInvoices
                        .Where(p => p.CustomerId == customerId)
                        .ToListAsync();

                    if (invoices.Any())
                    {
                        // Step 2: Extract all invoice IDs
                        var invoiceIds = invoices.Select(i => i.Id).ToList();

                        // Step 3: Load and delete all ProformaInvoiceDetails first
                        var details = await _context.ProformaInvoiceDetails
                            .Where(d => invoiceIds.Contains(d.ProformaId))
                            .ToListAsync();

                        _context.ProformaInvoiceDetails.RemoveRange(details);
                        await _context.SaveChangesAsync();

                        // Step 4: Delete ProformaInvoices
                        _context.ProformaInvoices.RemoveRange(invoices);
                        await _context.SaveChangesAsync();
                    }


                    // Step 2: Now safely delete the customer
                    var customer = await _customersRepository.GetByIdAsync(customerId);
                    if (customer != null)
                    {
                        await _customersRepository.DeleteAsync(customerId.ToString());
                        await _context.SaveChangesAsync();
                    }

                    Code.Helper.ToasterHelper.ShowDeletedToast();

                }
                if (_context.Customers.Count() < 1)
                {
                    var cust = new Customer
                    {
                        CustomerName = "مشتري عادي",
                        MaxDebtAllowed = 0,
                        TotalDebts = 0,

                    };
                    await _context.AddAsync(cust);
                    await _context.SaveChangesAsync();

                    Properties.Settings.Default.DefaultCustomerSale = Properties.Settings.Default.IdCustomerSale = cust.Id.ToString();

                    Properties.Settings.Default.Save();
                }
                await LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private List<Core.Entities.Customers.Customer> data;

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "");

            DgvِCustomer.DataSource = await _customersRepository.SearchAll(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvِCustomer);
            txtSearch.Text = string.Empty;
        }

        private async void btnExportCustomer_Click(object sender, EventArgs e)
        {

            data = await _context.Customers.ToListAsync();



            LoadingForm.Instance(_main).Hide();

            ExportExcel(data);
        }
        private void ExportExcel(List<Core.Entities.Customers.Customer> data)
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
            ExcelHelper.Export(dataTable, "Customers");
        }
        private DataTable arrangedDataTable(DataTable dataTable)
        {
            dataTable.Columns["Id"].SetOrdinal(0);
            dataTable.Columns["Id"].ColumnName = "معرف";

            dataTable.Columns["CustomerName"].SetOrdinal(1);
            dataTable.Columns["CustomerName"].ColumnName = "اسم العميل";


            dataTable.Columns["Address"].SetOrdinal(2);
            dataTable.Columns["Address"].ColumnName = "عنوان العميل";


            dataTable.Columns["PhoneNumber"].SetOrdinal(3);
            dataTable.Columns["PhoneNumber"].ColumnName = "رقم هاتف العميل";

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
