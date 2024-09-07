using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.SalesGui.PosGui;

namespace Store.ApplicationUI.Gui.PaymentGui
{

    public partial class SelectCustomerForm : Form
    {
        private static MainForm _main;
        private static PosForm _PosForm;
        private static SelectCustomerForm _selectCustomerForm;
        public SelectCustomerForm(MainForm main)
        {
            InitializeComponent();

            this.Owner = _main;
        }
        public SelectCustomerForm(PosForm main)
        {
            InitializeComponent();

            this.Owner = _PosForm;
        }
        public static SelectCustomerForm Instance(MainForm main)
        {
            _main = main;

            _selectCustomerForm = new SelectCustomerForm(_main);

            _selectCustomerForm.LoadData();
            return _selectCustomerForm;
        }
        public static SelectCustomerForm Instance(PosForm main)
        {
            _PosForm = main;

            _selectCustomerForm = new SelectCustomerForm(_PosForm);

            _selectCustomerForm.LoadData();
            return _selectCustomerForm;
        }
        private void SetColumns()
        {
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
        public async void LoadData()
        {
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => MainForm.Context.Database.CanConnect()))
            {

                DgvProducts.DataSource = MainForm.Context.Customers.ToList();
                SetColumns();







            }
            else
            {

                LoadingForm.Instance(_main).Hide();
                //No Connection
                MsgHelper.ShowServerError();
            }
            //Hideloading
            LoadingForm.Instance(_main).Hide();
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);
            // Show EmptyDAta

        }

        private void DgvProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvHelper.IsEmpty(DgvProducts))
                if (PosForm.GetPosUserControl() is not null)
                {
                    PosForm.GetPosUserControl().setCustomerFromSelector(DgvProducts.CurrentRow.Cells[6].Value.ToString(), DgvProducts.CurrentRow.Cells[0].Value.ToString());
                }
        }

        private void btnChooseCustomer_Click(object sender, EventArgs e)
        {
            if (!dgvHelper.IsEmpty(DgvProducts))
                if (PosForm.GetPosUserControl() is not null)
                {
                    PosForm.GetPosUserControl().setCustomerFromSelector(DgvProducts.CurrentRow.Cells[6].Value.ToString(), DgvProducts.CurrentRow.Cells[0].Value.ToString());
                }
        }

        private void SelectCustomerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (!dgvHelper.IsEmpty(DgvProducts))
                    if (PosForm.GetPosUserControl() is not null)
                    {
                        PosForm.GetPosUserControl().setCustomerFromSelector(DgvProducts.CurrentRow.Cells[6].Value.ToString(), DgvProducts.CurrentRow.Cells[0].Value.ToString());
                    }
            }
        }
    }
}
