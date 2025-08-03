using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.SalesGui.PosGui;
using Store.Core.Entities.Customers;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.PaymentGui
{

    public partial class SelectCustomerForm : Form
    {

        private readonly ApplicationDbContext _context;
        private readonly ControlManager _controlManager;
        private readonly ICustomersRepository _customersRepository;
        private readonly PosForm _posForm;

        public SelectCustomerForm(
            ApplicationDbContext context, ControlManager controlManager, ICustomersRepository customersRepository
           , PosForm posForm)
        {
            InitializeComponent();
            _context = context;
            _controlManager = controlManager;
            _customersRepository = customersRepository;
            _posForm = posForm;
        }

        private void SetColumns()
        {
            DgvProducts.DataSource = new List<Customer>();

            DgvProducts.Columns[0].HeaderCell.Value = "اسم العميل";
            DgvProducts.Columns[1].HeaderCell.Value = "العنوان";
            DgvProducts.Columns[2].HeaderCell.Value = "رقم الهاتف";
            DgvProducts.Columns[3].HeaderCell.Value = "ملاحظة";
            DgvProducts.Columns[4].HeaderCell.Value = "اعلى دين مسموح به";
            DgvProducts.Columns[5].HeaderCell.Value = "مجموع الديون";
            DgvProducts.Columns[6].HeaderCell.Value = "معرف العميل";

            DgvProducts.Columns[4].Visible = false;
            DgvProducts.Columns[1].Visible = false;



        }
        public async Task LoadData()
        {

            if (await _context.Database.CanConnectAsync())
            {

                SetColumns();
                DgvProducts.DataSource = await _context.Customers.ToListAsync();

            }

            //Hideloading

            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);
            // Show EmptyDAta

        }

        private void DgvProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvHelper.IsEmpty(DgvProducts))
                //if (PosForm.GetPosUserControl() is not null)
                //{
                //    PosForm.GetPosUserControl().setCustomerFromSelector(DgvProducts.CurrentRow.Cells[6].Value.ToString(), DgvProducts.CurrentRow.Cells[0].Value.ToString());
                //}
                if (_posForm != null)
                {
                    _posForm.GetPosUserControl().setCustomerFromSelector(DgvProducts.CurrentRow.Cells[6].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[0].Value.ToString());
                }
        }

        private void btnChooseCustomer_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            //if (!dgvHelper.IsEmpty(DgvProducts))
            //    //if (PosForm.GetPosUserControl() is not null)
            //    //{
            //    //    PosForm.GetPosUserControl().setCustomerFromSelector(DgvProducts.CurrentRow.Cells[6].Value.ToString(), DgvProducts.CurrentRow.Cells[0].Value.ToString());
            //    //}
            //    if (_controlManager.TryGet<PosUserControl>(out var UCP))
            //    {
            //        UCP.setCustomerFromSelector(DgvProducts.CurrentRow.Cells[6].Value.ToString(), DgvProducts.CurrentRow.Cells[0].Value.ToString());
            //    }
            if (!dgvHelper.IsEmpty(DgvProducts))
            {

                if (_posForm != null)
                {
                    _posForm.GetPosUserControl().setCustomerFromSelector(DgvProducts.CurrentRow.Cells[6].Value.ToString(),
                        DgvProducts.CurrentRow.Cells[0].Value.ToString());
                }
            }

        }

        private void SelectCustomerForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private async void SelectCustomerForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            DgvProducts.DataSource = await _customersRepository.SearchAll(txtSearch.Text);
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);
            txtSearch.Text = string.Empty;


        }
    }
}
