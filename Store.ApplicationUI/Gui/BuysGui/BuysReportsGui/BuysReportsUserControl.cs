using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.BuysGui.BuysReportsGui
{
    public partial class BuysReportsUserControl : UserControl
    {
        private static MainForm? _main;
        public static BuysRepository? buysRepository;
        private static BuysReportsUserControl? _buyReportsUserControl;
        public BuysReportsUserControl()
        {
            InitializeComponent();
        }
        public static bool CheckInstance()
        {
            return (_buyReportsUserControl == null);
        }
        public static BuysReportsUserControl Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field
            if (CheckInstance())
            {
                buysRepository = new BuysRepository(MainForm.Context);

                _buyReportsUserControl = new BuysReportsUserControl();

            }

            // Return the singleton instance
            _buyReportsUserControl.LoadData();
            return _buyReportsUserControl;
        }
        public async void SetProductsToDgv()
        {
            ////DgvBuys.DataSource = await Task.Run(() => productsRepository.GetAll(p => p.Category));
            //var CustomerMoneyList = MainForm.Context.CustomersReports.
            //    Include(x => x.Customer).Include(x => x.Sale)
            //    .ToList();
            DgvBuys.DataSource = buysRepository.GetAllBuysWithDetails();
            //var uniqueCustomerCount = CustomerMoneyList
            //    .Select(x => x.Customer.Id) // Replace CustomerId with the actual unique identifier property
            //    .Distinct()
            //    .Count();
            //DgvBuys.DataSource = CustomerMoneyList;
            //if (DgvBuys.Rows.Count > 0)
            //{
            //    if (DgvBuys.SelectedRows.Count > 0)
            //    {
            //        //lblPayFacture.Text = $" فاتورة رقم {DgvBuys.Columns[7].HeaderCell.Value} الدين : {DgvBuys.Columns[1].HeaderCell.Value} دج";
            //        //lblPayAllDebts.Text = $"دج {CustomerMoneyList.Sum(x => x.Price)}";
            //        lblTotalDebt.Text = $"مجموع مدفوعات الموردين في الجدول:{CustomerMoneyList.Sum(x => x.Price)}";
            //        lblTotalCustomers.Text = $"مجموع الموردين:{uniqueCustomerCount}";

            //    }
            //}
        }

        public static void RefreshDgv()
        {
            //DgvBuys.DataSource = await Task.Run(() => productsRepository.GetAllProducts());
            _buyReportsUserControl.LoadData();
        }
        // methodes 
        public async void LoadData()
        {


            //ShowLoading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => buysRepository.IsConnected()))
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
            Thread.Sleep(1000);
            LoadingForm.Instance(_main).Hide();
            // Show EmptyDAta
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvBuys);
        }

        private void SetColumns()
        {
            //DgvBuys.Columns[0].HeaderCell.Value = "المعرف";



            DgvBuys.Columns[0].HeaderCell.Value = "معرف الفاتورة";
            DgvBuys.Columns[1].HeaderCell.Value = "اسم المورد";
            DgvBuys.Columns[2].HeaderCell.Value = "التاريخ";
            DgvBuys.Columns[3].HeaderCell.Value = "الوقت";
            DgvBuys.Columns[4].HeaderCell.Value = "اسم المنتج";
            DgvBuys.Columns[5].HeaderCell.Value = "الكمية";
            DgvBuys.Columns[6].HeaderCell.Value = "سعر المنتج";
            DgvBuys.Columns[7].HeaderCell.Value = "التخفيض";
            DgvBuys.Columns[8].HeaderCell.Value = "السعر الاجمالي";
            DgvBuys.Columns[9].HeaderCell.Value = "البائع";
            DgvBuys.Columns[10].HeaderCell.Value = "حسبة الفاتورة";
            DgvBuys.Columns[11].HeaderCell.Value = "المدفوع";
            DgvBuys.Columns[12].HeaderCell.Value = "الباقي";


            DgvBuys.Columns[3].Width = 50;
            //DgvBuys.Columns[6].Visible = false;
            //DgvBuys.Columns[7].Visible = false;
            //DgvBuys.Columns[4].Visible = false;



        }


    }
}
