using System.IO;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.SalesGui;
using Store.ApplicationUI.Gui.SalesGui.PosGui;
using Store.Core.Entities.Products;
using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Gui.PaymentGui
{
    public partial class SelectProductsForm : Form
    {
        private static MainForm _main;
        private static PosForm _PosForm;
        private static SelectProductsForm _selectProductsForm;
        private ApplicationDbContext _context;

        public SelectProductsForm(MainForm main)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            this.Owner = _main;
        }
        public SelectProductsForm(PosForm main)
        {
            _context = new ApplicationDbContext();

            InitializeComponent();
            this.Owner = _PosForm;
        }
        public static SelectProductsForm Instance(MainForm main)
        {
            _main = main;
            _selectProductsForm = new SelectProductsForm(_main);
            _selectProductsForm._context = new ApplicationDbContext();


            _selectProductsForm.LoadData();
            return _selectProductsForm;
        }
        public static SelectProductsForm Instance(PosForm main)
        {
            _PosForm = main;
            _selectProductsForm = new SelectProductsForm(_PosForm);
            _selectProductsForm._context = new ApplicationDbContext();


            _selectProductsForm.LoadData();
            return _selectProductsForm;
        }
        public Image SetImage(byte[] retrivedData)
        {
            try
            {
                byte[] Picture = retrivedData;
                MemoryStream ms = new MemoryStream(Picture);
                return Image.FromStream(ms);
            }
            catch (Exception)
            {

                throw;
            }

        }

        void AddProductToDgvIfNotExist(PictureBox pictureBox)
        {
            int productId = 0;
            if (pictureBox != null)
            {

                productId = (int)pictureBox.Tag;

            }


            if (!SalesUserControl.CheckInstance())
            {
                if (SalesUserControl.setProductFromSelector(_context.Products.FirstOrDefault(x => x.Id == productId)))
                {

                }

            }

            {
                var posUserControl = PosForm.GetPosUserControl();
                if (posUserControl != null)
                {
                    posUserControl.setProductFromSelector(_context.Products.FirstOrDefault(x => x.Id == productId));
                }


            }
            //else if (!BuysUserControl.CheckInstance())
            //{
            //    SalesUserControl.setProductFromSelector(MainForm.Context.Products.FirstOrDefault(x => x.Id == productId));
            //}

        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Get the clicked PictureBox
            PictureBox pictureBox = sender as PictureBox;
            AddProductToDgvIfNotExist(pictureBox);

        }
        //private void SetColumns()
        //{

        //    DgvProducts.Columns[0].HeaderCell.Value = "معرف المنتوج";
        //    DgvProducts.Columns[1].HeaderCell.Value = "باركود";
        //    DgvProducts.Columns[2].HeaderCell.Value = "اسم المنتج";
        //    DgvProducts.Columns[3].HeaderCell.Value = "صورة المنتج";
        //    DgvProducts.Columns[4].HeaderCell.Value = "المنتج";

        //    DgvProducts.Columns[5].HeaderCell.Value = "معرف السرعة";
        //    DgvProducts.Columns[3].Visible = false;
        //    DgvProducts.Columns[4].Visible = false;


        //}
        public async void LoadData()
        {
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => _context.Database.CanConnect()))
            {

                //DgvProducts.DataSource = _context.ProductQuickAccess.ToList();
                //SetColumns();
                List<ProductQuickAccess> productQuicks = _context.ProductQuickAccess.ToList();
                foreach (var productImage in productQuicks)
                {
                    Panel qucikPan = new Panel
                    {
                        BackColor = Color.White,
                        Width = 110,
                        Height = 105,
                    };
                    Label labelName = new Label
                    {
                        Text = productImage.ProductName,
                        BackColor = Color.White,
                        ForeColor = Color.Red,
                        Margin = new(40, 3, 3, 3)
                    };

                    Label labelid = new Label
                    {
                        Text = productImage.Pro_Id.ToString(),
                        BackColor = Color.White,
                        ForeColor = Color.Red,
                        Margin = new(40, 3, 3, 3)

                    };
                    FlowLayoutPanel flowLayoutPanelfortext = new FlowLayoutPanel
                    {
                        FlowDirection = FlowDirection.RightToLeft,
                        Dock = DockStyle.Bottom,
                        Size = new Size(110, 50)


                    };
                    flowLayoutPanelfortext.Controls.Add(labelName);
                    flowLayoutPanelfortext.Controls.Add(labelid);
                    qucikPan.Controls.Add(flowLayoutPanelfortext);



                    PictureBox pictureBox = new PictureBox
                    {
                        Image = SetImage(productImage.ProductImage),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 75,
                        Height = 45,
                        Tag = productImage.Pro_Id,
                        Dock = DockStyle.Top,


                    };

                    // Add click event handler
                    pictureBox.Click += PictureBox_Click;
                    qucikPan.Controls.Add(pictureBox);
                    // Add PictureBox to FlowLayoutPanel
                    flowLayoutPanel.Controls.Add(qucikPan);
                }
            }
            else
            {

                LoadingForm.Instance(_main).Hide();
                //No Connection
                MsgHelper.ShowServerError();
            }
            //Hideloading
            LoadingForm.Instance(_main).Hide();
            //lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);
            // Show EmptyDAta

        }

        private void DgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void DgvProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (!dgvHelper.IsEmpty(DgvProducts))
        //    {
        //        int Id = Convert.ToInt32(DgvProducts.CurrentRow.Cells[0].Value.ToString());
        //        if (!SalesUserControl.CheckInstance())
        //        {
        //            if (SalesUserControl.setProductFromSelector(_context.Products.FirstOrDefault(x => x.Id == Id))) { }
        //        }

        //        {

        //            if (PosForm.GetPosUserControl() is not null)
        //            {
        //                PosForm.GetPosUserControl().setProductFromSelector(_context.Products.FirstOrDefault(x => x.Id == Id));
        //            }

        //        }
        //    }
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
