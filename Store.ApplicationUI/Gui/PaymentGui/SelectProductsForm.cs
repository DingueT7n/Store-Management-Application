using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.ApplicationUI.Gui.SalesGui;
using Store.Core.Entities.Products;

namespace Store.ApplicationUI.Gui.PaymentGui
{
    public partial class SelectProductsForm : Form
    {
        private static MainForm _main;
        private static SelectProductsForm _selectProductsForm;

        public SelectProductsForm(MainForm main)
        {
            InitializeComponent();
            this.Owner = _main;


        }
        public static SelectProductsForm Instance(MainForm main)
        {
            _main = main;

            _selectProductsForm = new SelectProductsForm(_main);

            _selectProductsForm.LoadData();
            return _selectProductsForm;
        }
        public Image SetImage(byte[] retrivedData)
        {
            try
            {
                byte[] Picture = (byte[])retrivedData;
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
                if (SalesUserControl.setProductFromSelector(MainForm.Context.Products.FirstOrDefault(x => x.Id == productId)))
                {

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
        private void SetColumns()
        {

            DgvProducts.Columns[0].HeaderCell.Value = "معرف المنتوج";
            DgvProducts.Columns[1].HeaderCell.Value = "باركود";
            DgvProducts.Columns[2].HeaderCell.Value = "اسم المنتج";
            DgvProducts.Columns[3].HeaderCell.Value = "صورة المنتج";
            DgvProducts.Columns[4].HeaderCell.Value = "المنتج";

            DgvProducts.Columns[5].HeaderCell.Value = "معرف السرعة";
            DgvProducts.Columns[3].Visible = false;
            DgvProducts.Columns[4].Visible = false;


        }
        public async void LoadData()
        {
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => MainForm.Context.Database.CanConnect()))
            {

                DgvProducts.DataSource = MainForm.Context.ProductQuickAccess.ToList();
                SetColumns();
                List<ProductQuickAccess> productQuicks = MainForm.Context.ProductQuickAccess.ToList();
                foreach (var productImage in productQuicks)
                {
                    Panel qucikPan = new Panel
                    {
                        BackColor = Color.White,
                        Width = 220,
                        Height = 167,
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
                        Size = new Size(219, 60)


                    };
                    flowLayoutPanelfortext.Controls.Add(labelName);
                    flowLayoutPanelfortext.Controls.Add(labelid);
                    qucikPan.Controls.Add(flowLayoutPanelfortext);



                    PictureBox pictureBox = new PictureBox
                    {
                        Image = SetImage(productImage.ProductImage),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 220,
                        Height = 105,
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
            lblEmptyData.Visible = dgvHelper.IsEmpty(DgvProducts);
            // Show EmptyDAta

        }

        private void DgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(DgvProducts.CurrentRow.Cells[0].Value.ToString());
            if (!SalesUserControl.CheckInstance())
            {
                if (SalesUserControl.setProductFromSelector(MainForm.Context.Products.FirstOrDefault(x => x.Id == Id))) { }
            }
        }
    }
}
