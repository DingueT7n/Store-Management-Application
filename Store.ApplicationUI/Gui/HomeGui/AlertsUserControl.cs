using System.Data;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.Helpers;
using Store.Core.Entities.Products;
using Store.Core.Entities.Suppliers;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.HomeGui
{
    public partial class AlertsUserControl : UserControl
    {
        private static AlertsUserControl? _homeUserControl;
        private static ApplicationDbContext _context;
        private static MainForm? _main;
        private static ProductsRepository _repository;
        public AlertsUserControl()
        {
            InitializeComponent();
        }
        public static AlertsUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (_homeUserControl == null)
            {
                _homeUserControl = new AlertsUserControl();
                _context = new ApplicationDbContext();
                _repository = new ProductsRepository(_context);
            }
            _ = _homeUserControl.LoadData();
            // Return the singleton instance
            return _homeUserControl;
        }

        public async Task LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                //Start Load Data
                flowLayoutPanel1.Controls.Clear();
                SetColumns();
                await SetAlertsToPanel();
                await SetProductsToDgv(0);
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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);
            lblEmptyData1.Visible = dgvHelper.IsEmpty(dgvDataOutdated);
            lblEmptyData2.Visible = dgvHelper.IsEmpty(dataDebtSuppliers);
            lblEmptyData3.Visible = dgvHelper.IsEmpty(dataCustomerDebts);
        }


        private void SetColumns()
        {
            try
            {
                DgvProducts.DataSource = new List<ProductMinQty>();
                DgvProducts.Columns[0].HeaderCell.Value = "باركود";
                DgvProducts.Columns[1].HeaderCell.Value = "اسم المنتج";
                DgvProducts.Columns[2].HeaderCell.Value = "الكمية";
                DgvProducts.Columns[3].HeaderCell.Value = "تاريخ انتهاء الصلاحية";
                DgvProducts.Columns[4].HeaderCell.Value = "اسم الصنف";

                //DgvProducts.Columns[6].HeaderCell.Value = "قيمة الضريبة";
                //DgvProducts.Columns[7].HeaderCell.Value = "سعر البيع باحتساب الضريبة";
                //DgvProducts.Columns[8].HeaderCell.Value = "خاضع للضريبة؟";
                //DgvProducts.Columns[9].HeaderCell.Value = "تاريخ انتهاء الصلاحية";
                //DgvProducts.Columns[10].HeaderCell.Value = "كمية التنبيه";
                //DgvProducts.Columns[11].HeaderCell.Value = "اقصى تخفيض";
                //DgvProducts.Columns[12].HeaderCell.Value = "صورة المنتج";

                //DgvProducts.Columns[13].HeaderCell.Value = "معرف الصنف";
                //DgvProducts.Columns[14].HeaderCell.Value = "اسم الصنف";
                //DgvProducts.Columns[15].HeaderCell.Value = "معرف المنتج";
                dgvDataOutdated.DataSource = new List<ProductOutdated>();

                dgvDataOutdated.Columns[0].HeaderCell.Value = "باركود";
                dgvDataOutdated.Columns[1].HeaderCell.Value = "اسم المنتج";
                dgvDataOutdated.Columns[2].HeaderCell.Value = "المخزن";
                dgvDataOutdated.Columns[3].HeaderCell.Value = "الكمية";
                dgvDataOutdated.Columns[4].HeaderCell.Value = "تاريخ انتهاء الصلاحية";

                dataDebtSuppliers.DataSource = new List<SupplierDebts>();

                dataDebtSuppliers.Columns[0].HeaderCell.Value = "رقم الفاتورة";
                dataDebtSuppliers.Columns[1].HeaderCell.Value = "اسم المورد";
                dataDebtSuppliers.Columns[2].HeaderCell.Value = "الثمن";
                dataDebtSuppliers.Columns[3].HeaderCell.Value = "تاريخ الفاتورة";
                dataDebtSuppliers.Columns[4].HeaderCell.Value = "تاريخ الاستحقاق";

                dataCustomerDebts.DataSource = new List<SupplierDebts>();
                dataCustomerDebts.Columns[0].HeaderCell.Value = "رقم الفاتورة";
                dataCustomerDebts.Columns[1].HeaderCell.Value = "اسم العميل";
                dataCustomerDebts.Columns[2].HeaderCell.Value = "الثمن";
                dataCustomerDebts.Columns[3].HeaderCell.Value = "تاريخ الفاتورة";
                dataCustomerDebts.Columns[4].HeaderCell.Value = "تاريخ الاستحقاق";
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }

        }

        public async Task SetProductsToDgv(int skip)
        {
            try
            {
                var data = await _repository.GetAllProductMinQty(skip, Properties.Settings.Default.NoOfDataInDgvs);
                DgvProducts.DataSource = data;
                var dataOutDated = await _repository.GetAllProductOutdated();
                dgvDataOutdated.DataSource = dataOutDated;

                var dataReminderDateIsUpSupplier = await GetAllDebtSuppliers();
                dataDebtSuppliers.DataSource = dataReminderDateIsUpSupplier;

                var dataReminderDateIsUpCustomer = await GetAllDebtCustomer();
                dataCustomerDebts.DataSource = dataReminderDateIsUpCustomer;

                double value = await _context.Products.AsNoTracking()
     .Where(x => x.Quentity <= x.MinQty)
     .Select(x => x.Id) // Only select ID, avoids loading full objects
     .CountAsync() / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
                int pageCount = Convert.ToInt32(Math.Ceiling(value));

                // Update pagination combo box
                cmbpagination.Items.Clear();
                for (int i = 0; i < pageCount; i++)
                {
                    cmbpagination.Items.Add(i + 1);
                }

                if (cmbpagination.Items.Count > 0)
                {
                    cmbpagination.SelectedIndex = skip / Properties.Settings.Default.NoOfDataInDgvs;
                }

                PaginationHide();
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
        }
        void PaginationHide()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(DgvProducts);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(DgvProducts);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(DgvProducts);
        }
        public async Task SetAlertsToPanel()
        {
            try
            {
                var AlertsList = await _context.AlertsTable.Where(x => x.IsResolved == false)
                    .Select(bd => new AlertDto
                    {
                        Id = bd.Id,
                        AlertType = bd.AlertType,
                        Message = bd.Message,
                        Priority = bd.Priority,
                        CreatedDate = bd.CreatedDate,
                        Category = bd.Category,

                    }).ToListAsync();

                //        var alerts = new List<AlertDto>
                //{
                //    new AlertDto {Id=1, AlertType = "Stock Low", Message = "Product X is running low on stock.", Priority = PriorityAlert.High, CreatedDate = DateTime.Now.AddDays(-3)  },
                //    new AlertDto {Id =2 ,AlertType = "Price Change", Message = "Price of Product Y has changed.", Priority = PriorityAlert.Medium, CreatedDate = DateTime.Now },
                //    new AlertDto {Id=3, AlertType = "Expired Product", Message = "Product Z has expired.", Priority = PriorityAlert.Low, CreatedDate = DateTime.Now },
                //};

                // Create a new panel for each alert and add it to the FlowLayoutPanel
                foreach (var alert in AlertsList)
                {
                    var alertPanel = new Panel
                    {
                        Width = flowLayoutPanel1.Width - 20, // Set panel width with padding consideration
                        Height = 100, // Fixed height for consistency
                        Padding = new Padding(10),
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.White, // Set background color
                        Cursor = Cursors.Hand // Change cursor on hover

                    };

                    // Add label for alert type
                    var alertTypeLabel = new Label
                    {
                        Text = $"{alert.AlertType}",
                        Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                        AutoSize = true,
                        Location = new Point(10, 10) // Position the label
                    };
                    alertPanel.Controls.Add(alertTypeLabel);

                    // Add label for the message
                    var messageLabel = new Label
                    {
                        Text = $"{alert.Message}\n",
                        Font = new System.Drawing.Font("Arial", 10),
                        AutoSize = true,
                        Location = new Point(10, 35) // Position the label below the alert type
                    };
                    alertPanel.Controls.Add(messageLabel);

                    // Add label for the created date
                    var dateLabel = new Label
                    {
                        Text = $" {alert.CreatedDate:MM/dd/yyyy hh:mm tt}\n عن طريق {alert.Category}",
                        Font = new System.Drawing.Font("Arial", 8),
                        AutoSize = true,
                        Location = new Point(10, 60) // Position the label below the message
                    };
                    alertPanel.Controls.Add(dateLabel);

                    // Set priority color
                    if (alert.Priority == PriorityAlert.High)
                        alertTypeLabel.ForeColor = Color.Red;
                    else if (alert.Priority == PriorityAlert.Medium)
                        alertTypeLabel.ForeColor = Color.Orange;
                    else
                        alertTypeLabel.ForeColor = Color.Green;

                    // Create PictureBox for resolving the alert
                    var checkBox = new PictureBox
                    {
                        Width = 30,
                        Height = 30,
                        Image = Properties.Resources.Check_Mark, // Make sure to add a green check image to Resources
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Cursor = Cursors.Hand,
                        Tag = alert.Id,
                        Location = new Point(alertPanel.Width - 40, 10) // Position the PictureBox in the top-right corner
                    };

                    checkBox.Click += (sender, e) =>
                    {
                        // Call the method to mark the alert as resolved
                        if (MsgHelper.ShowResolveDialog())
                        {
                            PictureBox? pictureBox = sender as PictureBox;
                            int alertid = 0;
                            if (pictureBox != null)
                            {
                                alertid = (int)pictureBox.Tag;
                            }
                            MarkAlertAsResolved(alertid, alertPanel);
                        }
                    };

                    // Add the PictureBox to the panel
                    alertPanel.Controls.Add(checkBox);

                    // Add hover effect
                    alertPanel.MouseEnter += (sender, e) =>
                    {
                        alertPanel.BackColor = Color.LightGray; // Change background color on hover
                    };
                    alertPanel.MouseLeave += (sender, e) =>
                    {
                        alertPanel.BackColor = Color.White; // Revert background color on leave
                    };

                    // Add the alert panel to the FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(alertPanel);
                }
                lblEmptyAlerts.Visible = flowLayoutPanel1.Controls.Count == 0;
                // Handle form resize to make panels responsive
                this.Resize += (sender, e) =>
                {
                    foreach (Control control in flowLayoutPanel1.Controls)
                    {
                        if (control is Panel panel)
                        {
                            panel.Width = flowLayoutPanel1.Width - 20; // Adjust panel width on form resize
                            var checkBox = panel.Controls.OfType<PictureBox>().FirstOrDefault();
                            if (checkBox != null)
                            {
                                checkBox.Location = new Point(panel.Width - 40, 10); // Reposition the PictureBox
                            }
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
        }
        private async void MarkAlertAsResolved(int alertId, Panel alertPanel)
        {

            try
            {
                var alert = await _context.AlertsTable.FirstOrDefaultAsync(x => x.Id == alertId);
                if (alert != null)
                {
                    alert.IsResolved = true;
                    alert.ResolvedDate = DateTime.Now;
                    alert.ResolvedBy = Code.Models.LocalUser.User.UserName;

                    _context.Update(alert);
                    await _context.SaveChangesAsync();
                    flowLayoutPanel1.Controls.Remove(alertPanel);
                    ToasterHelper.ShowResolvedAlertsToast();
                }
                lblEmptyAlerts.Visible = flowLayoutPanel1.Controls.Count == 0;
            }
            catch (Exception e)
            {
                ToasterHelper.ShowErrorHappened(e.Message);
                throw;
            }


            // Change the panel's background color to indicate resolved state
            alertPanel.BackColor = System.Drawing.Color.LightGreen;

            // Optionally, update the database here if needed
            // Example: MarkAlertAsResolvedInDb(alert.Id);
        }
        public async Task<List<SupplierDebts>> GetAllDebtSuppliers()
        {
            try
            {
                var products = await _context.SuppliersMoneys.AsNoTracking()
                                .Where(x => x.Reminder_Date <= DateTime.Now)
                    .Select(bd => new SupplierDebts
                    {
                        Order_ID = bd.Order_ID,
                        SupplierName = bd.SupplierName,
                        Price = bd.Price,
                        Order_Date = bd.Order_Date,
                        Reminder_Date = bd.Reminder_Date
                    })
                    .ToListAsync();
                return products;
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }
        public async Task<List<SupplierDebts>> GetAllDebtCustomer()
        {
            try
            {
                var products = await _context.CustomersMoneys.AsNoTracking()
                                .Where(x => x.Reminder_Date <= DateTime.Now)
                    .Select(bd => new SupplierDebts
                    {
                        Order_ID = bd.Order_ID,
                        SupplierName = bd.Cust_Name,
                        Price = bd.Price,
                        Order_Date = bd.Order_Date,
                        Reminder_Date = bd.Reminder_Date
                    })
                    .ToListAsync();
                return products;
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving the buyFactures", ex);
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1)
            {
                cmbpagination.SelectedIndex++;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                await SetProductsToDgv(skip);

            }
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex > 0)
            {
                cmbpagination.SelectedIndex--;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;

                await SetProductsToDgv(skip);
            }
        }

        private async void cmbpagination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex != -1)
            {
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                await SetProductsToDgv(skip);
            }
        }
    }
}
