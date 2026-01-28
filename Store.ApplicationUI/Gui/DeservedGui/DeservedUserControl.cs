using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.AllDeserved;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.DeservedGui
{
    public partial class DeservedUserControl : UserControl
    {
        private readonly MainForm _main;
        private readonly ApplicationDbContext _context;
        public readonly IDeservedsRepository deservedsRepository;
        private readonly ControlManager _controlManager;

        //public static CategorysRepository? categoryRepository;
        public DeservedUserControl(MainForm main, ApplicationDbContext context, IDeservedsRepository deservedsRepository, ControlManager controlManager)
        {
            InitializeComponent();
            dtpTo.Value = DateTime.Now;
            _main = main;
            _context = context;
            this.deservedsRepository = deservedsRepository;
            _controlManager = controlManager;
        }
        public async Task SetProductsToDgv()
        {
            //DgvProducts.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));

            var data = await deservedsRepository.GetAllAsync(x => x.DeservedType);
            DgvProducts.DataSource = data;
        }
        public async Task LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await deservedsRepository.IsConnectedAsync())
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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);
        }

        private void SetColumns()
        {
            DgvProducts.DataSource = new List<Deserved>();
            DgvProducts.Columns[0].HeaderCell.Value = "اسم المستخدم";
            DgvProducts.Columns[1].HeaderCell.Value = "الثمن المدفوع";
            DgvProducts.Columns[2].HeaderCell.Value = "تاريخ المصروفة";
            DgvProducts.Columns[3].HeaderCell.Value = "وقت المصروفة";
            DgvProducts.Columns[4].HeaderCell.Value = "الملاحظة";
            DgvProducts.Columns[5].HeaderCell.Value = "معرف النوع";
            DgvProducts.Columns[6].HeaderCell.Value = "نوع المصروفة";
            DgvProducts.Columns[7].HeaderCell.Value = "معرف المصروفة";
        }

        private async void btnAddDeserved_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            AddDeservedForm addDeservedForm = await _controlManager.GetFAsync<AddDeservedForm>();
            addDeservedForm.ShowDialog();
        }

        private async void btnEditDeserved_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (DgvProducts.Rows.Count > 0)
            {
                AddDeservedForm addDeservedForm = await _controlManager.GetFAsync<AddDeservedForm>();


                await addDeservedForm.SetDataToEdit(
                      DgvProducts.CurrentRow.Cells[0].Value.ToString(),
                      DgvProducts.CurrentRow.Cells[1].Value.ToString(),
                      DgvProducts.CurrentRow.Cells[4].Value.ToString(),
                      DgvProducts.CurrentRow.Cells[5].Value.ToString(),
                      DgvProducts.CurrentRow.Cells[7].Value.ToString(),
                      Convert.ToDateTime(DgvProducts.CurrentRow.Cells[2].Value)
                  );

                addDeservedForm.ShowDialog();

            }
        }

        private void btnAddDeservedType_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            AddDeservedTypeForm addDeservedType = _controlManager.GetF<AddDeservedTypeForm>();
            addDeservedType.ShowDialog();


        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            await LoadData();
        }

        private async void btnDeleteDeserved_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                await deservedsRepository.DeleteAsync(DgvProducts.CurrentRow.Cells[7].Value.ToString());
                Code.Helper.ToasterHelper.ShowDeletedToast();

            }
            await LoadData();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Replace("\r\n", "").Trim();
            List<Deserved> a = new();
            DgvProducts.DataSource = new List<Deserved>();
            if (rbBoth.Checked)
            {
                a = await deservedsRepository.SearchBoth(txtSearch.Text, dtpFrom.Value, dtpTo.Value);


            }
            else if (rbSupplierAndOrder.Checked)
            {
                a = await deservedsRepository.SearchOnlyDeserved(txtSearch.Text);

            }
            else
            {
                a = await deservedsRepository.SearchOnlyDate(dtpFrom.Value, dtpTo.Value);
            }
            DgvProducts.DataSource = a;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (MsgHelper.ShowDeleteDialog())
            {
                for (int i = 0; i < DgvProducts.Rows.Count; i++)
                {

                    await deservedsRepository.DeleteAsync(DgvProducts.Rows[i].Cells[7].Value.ToString());

                    Code.Helper.ToasterHelper.ShowDeletedToast();

                }
            }
            await LoadData();
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
