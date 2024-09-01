using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.ProductsGui;
using Store.ApplicationUI.Gui.ProductsGui.Category;
using Store.ApplicationUI.Gui.ProductsGui.StoreGui;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI
{
    public partial class MainForm : Form
    {
        private PageHelper pageHelper;

        public static ApplicationDbContext? Context { get; set; }
        public MainForm()
        {
            InitializeComponent();
            KeyPreview = true;

            pageHelper = new(this);
            pageHelper.SetNewPage(Gui.HomeGui.HomeUserControl.Instance());


            Context = new ApplicationDbContext();
            SetScreenState(Properties.Settings.Default.IsMaxScreen);

            isPanelNull = true;
        }
        private void SetScreenState(bool isMax)
        {
            if (isMax)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }

        }
        private int panelHeightIncrement = 5;
        FlowLayoutPanel generalFlowLayout;

        public bool isPanelOpen()
        {

            return isPanelNull;
        }
        public void CloseSubPanels()
        {
            if (isPanelAnimating)
                return;

            if (generalFlowLayout is null) return;
            if (generalFlowLayout.Height == generalFlowLayout.MaximumSize.Height)
            {
                isPanelCollapsing = true;
                isPanelAnimating = true;
                animationTimer.Start();

            }
        }

        public void ShowSubPanel(FlowLayoutPanel flowLayoutPanel)
        {

            if (isPanelAnimating)
                return;

            generalFlowLayout = flowLayoutPanel;

            if (generalFlowLayout.Visible == true)
            {
                CloseSubPanels();
                return;
            }
            generalFlowLayout.Height = 0;

            if (generalFlowLayout.Height == 0)
            {
                isPanelExpanding = true;
                isPanelAnimating = true;
                generalFlowLayout.Show();
                animationTimer.Start();
            }
        }

        private bool isPanelExpanding = false;
        private bool isPanelCollapsing = false;
        private bool isPanelAnimating = false;
        private bool isPanelNull;

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            Properties.Settings.Default.IsMaxScreen = this.WindowState == FormWindowState.Maximized;
            Properties.Settings.Default.Save();
        }

        private void btnHomeSummary_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.HomeGui.HomeUserControl.Instance());
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            //pageHelper.SetNewPage(Gui.ProductsGui.ProductsUserControl.Instance(this));
            CloseSubPanels();
            ShowSubPanel(ProductsflowLayoutPanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.ProductsGui.ProductsUserControl.Instance(this));
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {

            if (!isPanelAnimating)
                return;

            if (isPanelExpanding)
            {
                if (generalFlowLayout.Height < generalFlowLayout.MaximumSize.Height)
                {
                    generalFlowLayout.Height += panelHeightIncrement;
                }
                else
                {
                    generalFlowLayout.Height = generalFlowLayout.MaximumSize.Height;
                    isPanelExpanding = false;
                    isPanelAnimating = false;
                    animationTimer.Stop();
                }
            }

            if (isPanelCollapsing)
            {
                if (generalFlowLayout.Height > 0)
                {
                    generalFlowLayout.Height -= panelHeightIncrement;
                }
                else
                {
                    generalFlowLayout.Height = 0;
                    isPanelCollapsing = false;
                    isPanelAnimating = false;
                    generalFlowLayout.Hide();
                    animationTimer.Stop();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            AddProductForm addProductForm = new AddProductForm(this);

            addProductForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddCategoryForm addCategoryForm = AddCategoryForm.Instance(this); ;
            addCategoryForm.ShowDialog();

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(CustomersflowLayoutPaneel);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CustomersGui.CustomersUserControl.Instance(this));
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AddCustomerForm addProductForm = new AddCustomerForm(this);

            addProductForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CustomersGui.CustomerAccountGui.CustomerAccountUserControl.Instance(this));

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.CustomersGui.CustomerReportsGui.CustomerReportsUserControl.Instance(this));

        }

        private void btnSupplierPanel_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(SuppliersflowLayoutPanel);
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            AddSupplierForm addSupplierForm = new AddSupplierForm(this);

            addSupplierForm.Show();
        }

        private void btnAllSuppliers_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.SupplierGui.SuppliersUserControl.Instance(this));
        }

        private void btnSupplierAccount_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.SupplierGui.SupplierAccountGui.SupplierAccountUserControl.Instance(this));

        }

        private void btnSupplierReports_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.SupplierGui.SupplierReportsGui.SupplierReportsUserControl.Instance(this));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddStoreForm addStoreForm = AddStoreForm.Instance(this); ;
            addStoreForm.ShowDialog();
        }
        public float ConvertToFloat(string value)
        {
            float quantity;
            if (float.TryParse(value, out quantity))
            {
                return quantity;
            }
            return quantity;
        }

        private void btnBuysPanel_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(BuysflowLayoutPanel);
        }

        private void btnNewBuy_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.BuysGui.BuysUserControl.Instance(this));
        }

        private void btnSalesPanel_Click(object sender, EventArgs e)
        {
            CloseSubPanels();

            ShowSubPanel(SalesflowLayoutPanel);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pageHelper.SetNewPage(Gui.SalesGui.SalesUserControl.Instance(this));
        }
    }
}
