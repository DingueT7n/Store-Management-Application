using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.FondCaisseGui
{
    public partial class CaisseStatusAndOperationUserControl : UserControl
    {

        private static MainForm? _main;
        private static ApplicationDbContext _contex;
        public static CaisseStatusDetailRepository? repository1;
        public static CaisseOperationRepository? repository2;
        private static CaisseStatusAndOperationUserControl? _UserControl;
        public CaisseStatusAndOperationUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_UserControl == null);
        }
        public static CaisseStatusAndOperationUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            _contex = new ApplicationDbContext();
            if (CheckInstance())
            {
                repository1 = new CaisseStatusDetailRepository(_contex);
                repository2 = new CaisseOperationRepository(_contex);

                _UserControl = new CaisseStatusAndOperationUserControl();

            }

            // Return the singleton instance
            _UserControl.LoadDataAsync();
            return _UserControl;
        }
        public async Task SetProductsToDgvAsync1(string t1, string status, int skip)
        {
            try
            {
                var data = repository1
                    .GetAllStatus(t1, status, dtpFrom.Value, dtpTo.Value, Properties.Settings.Default.NoOfDataInDgvs, skip);

                // Set data source
                Dgv1.DataSource = data.Deposits;

                // Calculate total pages
                double value = data.TotalCount / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
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

                PaginationHide1();
            }
            catch (Exception)
            {

            }
        }
        public async Task SetProductsToDgvAsync2(string t1, string status, int skip)
        {
            try
            {
                var data = repository1
                    .GetAllStatusOperations(t1, status, dtpFrom2.Value, dtpTo2.Value, Properties.Settings.Default.NoOfDataInDgvs, skip);

                // Set data source
                Dgv2.DataSource = data.Deposits;

                // Calculate total pages
                double value = data.TotalCount / Convert.ToDouble(Properties.Settings.Default.NoOfDataInDgvs);
                int pageCount = Convert.ToInt32(Math.Ceiling(value));

                // Update pagination combo box
                cmbpagination2.Items.Clear();
                for (int i = 0; i < pageCount; i++)
                {
                    cmbpagination2.Items.Add(i + 1);
                }

                if (cmbpagination2.Items.Count > 0)
                {
                    cmbpagination2.SelectedIndex = skip / Properties.Settings.Default.NoOfDataInDgvs;
                }

                PaginationHide2();
            }
            catch (Exception)
            {

            }
        }
        void PaginationHide1()
        {
            btnNext.Enabled = cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1 && !dgvHelper.IsEmpty(Dgv1);
            btnPrev.Enabled = cmbpagination.SelectedIndex > 0 && !dgvHelper.IsEmpty(Dgv1);
            cmbpagination.Enabled = !dgvHelper.IsEmpty(Dgv1);
        }
        void PaginationHide2()
        {
            btnNext2.Enabled = cmbpagination2.SelectedIndex < cmbpagination2.Items.Count - 1 && !dgvHelper.IsEmpty(Dgv2);
            btnPrev2.Enabled = cmbpagination2.SelectedIndex > 0 && !dgvHelper.IsEmpty(Dgv2);
            cmbpagination2.Enabled = !dgvHelper.IsEmpty(Dgv2);
        }
        private async Task RefreshDgvAsync1(int skip)
        {
            try
            {
                string t1 = rbStoresFrom.Checked ? cmbCaisse.Text : string.Empty;

                await SetProductsToDgvAsync1(t1, txtSearch.Text, skip);
                SetColumns();
                lblEmptyData.Visible = dgvHelper.IsEmpty(Dgv1);
            }
            catch (Exception ex)
            {
            }
        }
        private async Task RefreshDgvAsync2(int skip)
        {
            try
            {
                string t1 = rbStoresFrom2.Checked ? cmbCaisse2.Text : string.Empty;

                await SetProductsToDgvAsync2(t1, txtSearch2.Text, skip);
                SetColumns2();
                lblEmptyData2.Visible = dgvHelper.IsEmpty(Dgv2);
            }
            catch (Exception ex)
            {
            }
        }
        public async Task LoadDataAsync()
        {
            try
            {
                dtpTo2.Value = DateTime.Now;
                dtpTo.Value = DateTime.Now;

                // Show loading indicator
                LoadingForm.Instance(_main).Show();

                if (await Task.Run(() => repository1.IsConnected()))
                {
                    cmbCaisse.DataSource = _contex.Caisses.ToList();
                    cmbCaisse.DisplayMember = "CaisseName";
                    cmbCaisse.ValueMember = "Id";

                    cmbCaisse2.DataSource = _contex.Caisses.ToList();
                    cmbCaisse2.DisplayMember = "CaisseName";
                    cmbCaisse2.ValueMember = "Id";

                    // Load initial data
                    await RefreshDgvAsync1(0);
                    await RefreshDgvAsync2(0);
                }
                else
                {
                    MsgHelper.ShowServerError();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                LoadingForm.Instance(_main).Hide();
                lblEmptyData.Visible = dgvHelper.IsEmpty(Dgv1);

                lblEmptyData2.Visible = dgvHelper.IsEmpty(Dgv2);
            }
        }

        private void SetColumns()
        {
            string[] headers = { "معرف الصندوق", "اسم الصندوق", "تم الفتح بواسطة", "تم الغلق بواسطة", "الاموال في البرنامج قبل الفتح",
                "الاموال المصرح بها قبل الفتح", "الاموال في البرنامج بعد الغلق",
                "الاموال المصرح بها بعد الغلق", "وقت الفتح","وقت الغلق","الحالة الان",
                "المدة","متوافقة؟","معرف العملية","معرف العملية" };
            //int[] widths = { 105, 0, 100, 95, 0, 0, 150, 110, 100 };

            for (int i = 0; i < headers.Length; i++)
            {
                Dgv1.Columns[i].HeaderCell.Value = headers[i];
                //if (widths[i] > 0)
                //{
                //    Dgv1.Columns[i].Width = widths[i];
                //}
            }

            Dgv1.Columns[13].Visible = false;
            Dgv1.Columns[0].Visible = false;
            //Dgv1.Columns[4].Visible = false;
            //Dgv1.Columns[4].Visible = false;

        }
        private void SetColumns2()
        {
            string[] headers = { "حالة الصندوق", "الشخص الذي قام بها", "تاريخ العملية","عدد 2000DA","عدد 1000DA","عدد 500DA",
                "عدد 200DA","عدد 100DA","عدد 50DA","عدد 20DA",
                "عدد 10DA","عدد 5DA","الاموال التي تمت اضافتها",
                "الوقت","معرف الحالة","الصندوق","معرف العملية" };
            //int[] widths = { 105, 0, 100, 95, 0, 0, 150, 110, 100 };

            for (int i = 0; i < headers.Length; i++)
            {
                Dgv2.Columns[i].HeaderCell.Value = headers[i];
                //if (widths[i] > 0)
                //{
                //    Dgv1.Columns[i].Width = widths[i];
                //}
            }

            //Dgv2.Columns[17].Visible = false;
            //Dgv2.Columns[0].Visible = false;
            //Dgv1.Columns[4].Visible = false;
            //Dgv1.Columns[4].Visible = false;

        }
        private async void rbStoresFromAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbCaisse.Enabled = rbStoresFrom.Checked;
            await RefreshDgvAsync1(0);
        }
        private async void rbStoresFrom_CheckedChanged(object sender, EventArgs e)
        {
            cmbCaisse.Enabled = rbStoresFrom.Checked;
            await RefreshDgvAsync1(0);
        }
        private void btnSearch_Click(object sender, EventArgs e) => RefreshDgvAsync1(0);
        private void cmbCaisse_SelectionChangeCommitted(object sender, EventArgs e) => RefreshDgvAsync1(0);

        private async void btnNext_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex < cmbpagination.Items.Count - 1)
            {
                cmbpagination.SelectedIndex++;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                await RefreshDgvAsync1(skip);

            }
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex > 0)
            {
                cmbpagination.SelectedIndex--;
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;

                await RefreshDgvAsync1(skip);
            }
        }

        private async void cmbpagination_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination.SelectedIndex != -1)
            {
                int skip = cmbpagination.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                await RefreshDgvAsync1(skip);
            }
        }

        private async void rbStoresFromAll2_CheckedChanged(object sender, EventArgs e)
        {
            cmbCaisse2.Enabled = rbStoresFrom2.Checked;
            await RefreshDgvAsync2(0);
        }

        private async void rbStoresFrom2_CheckedChanged(object sender, EventArgs e)
        {
            cmbCaisse.Enabled = rbStoresFrom.Checked;
            await RefreshDgvAsync2(0);
        }

        private async void btnSearch2_Click(object sender, EventArgs e)
        {
            await RefreshDgvAsync2(0);
        }

        private async void cmbCaisse2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await RefreshDgvAsync2(0);
        }

        private async void btnNext2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination2.SelectedIndex < cmbpagination2.Items.Count - 1)
            {
                cmbpagination2.SelectedIndex++;
                int skip = cmbpagination2.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                await RefreshDgvAsync2(skip);

            }
        }

        private async void btnPrev2_Click(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination2.SelectedIndex > 0)
            {
                cmbpagination2.SelectedIndex--;
                int skip = cmbpagination2.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;

                await RefreshDgvAsync2(skip);
            }
        }

        private async void cmbpagination2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ToasterHelper.PlayNotificationSound();
            if (cmbpagination2.SelectedIndex != -1)
            {
                int skip = cmbpagination2.SelectedIndex * Properties.Settings.Default.NoOfDataInDgvs;
                await RefreshDgvAsync2(skip);
            }
        }
    }
}
