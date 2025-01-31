using System.ComponentModel;
using System.IO;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.BuysGui;
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

        public SelectProductsForm(MainForm main, bool buy)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            this.Owner = _main;
            this.buy = buy;
            pos = false;
        }
        public SelectProductsForm(PosForm main, bool pos)
        {
            _context = new ApplicationDbContext();
            buy = false;
            this.pos = pos;
            InitializeComponent();
            this.Owner = _PosForm;
        }
        bool buy = false;
        bool pos = false;
        public static SelectProductsForm Instance(MainForm main, bool buy)
        {
            _main = main;
            _selectProductsForm = new SelectProductsForm(_main, buy);



            _selectProductsForm.LoadData();
            return _selectProductsForm;
        }
        public static SelectProductsForm Instance(PosForm main, bool pos)
        {
            _PosForm = main;
            _selectProductsForm = new SelectProductsForm(_PosForm, pos);
            _selectProductsForm._context = new ApplicationDbContext();


            _selectProductsForm.LoadData();
            return _selectProductsForm;
        }
        ////private void PictureBox_Click(object sender, EventArgs e)
        ////{

        ////    PictureBox clickedPictureBox = sender as PictureBox;


        ////    foreach (Control control in flowLayoutPanel.Controls)
        ////    {
        ////        if (control is Panel productPanel)
        ////        {
        ////            foreach (Control innerControl in productPanel.Controls)
        ////            {
        ////                if (innerControl is PictureBox pictureBox)
        ////                {
        ////          

        ////                   pictureBox.BorderStyle = BorderStyle.None;
        ////                }
        ////            }
        ////        }
        ////    }



        ////   clickedPictureBox.BorderStyle = BorderStyle.FixedSingle;
        ////    clickedPictureBox.BorderColor = Color.Green; // Custom border color (requires custom PictureBox)
        ////}
        public Image SetImage(byte[] retrivedData)
        {
            try
            {
                if (retrivedData == null || retrivedData.Length == 0)
                {
                    return null; // Handle null or empty image data
                }

                using (MemoryStream ms = new MemoryStream(retrivedData))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                return null; // Avoid rethrowing unless needed
            }
        }


        void AddProductToDgvIfNotExist(PictureBox pictureBox)
        {
            ToasterHelper.PlayNotificationSound();
            int productId = 0;
            if (pictureBox != null)
            {

                productId = (int)pictureBox.Tag;

            }


            if (!SalesUserControl.CheckInstance() && !buy && !pos)
            {
                if (SalesUserControl.setProductFromSelector(_context.Products.FirstOrDefault(x => x.Id == productId)))
                {

                }

            }
            if (!BuysUserControl.CheckInstance() && buy && !pos)
            {
                if (BuysUserControl.setProductFromSelector(_context.Products.FirstOrDefault(x => x.Id == productId)))
                {

                }

            }

            {
                var posUserControl = PosForm.GetPosUserControl();
                if (posUserControl != null && pos)
                {
                    posUserControl.setProductFromSelector(_context.Products.FirstOrDefault(x => x.Id == productId));
                }


                // Get the parent Panel of the clicked PictureBox
                Panel parentPanel = pictureBox.Parent as Panel;



                // Set the background color of the parent Panel to light green
                parentPanel.BackColor = Color.LightGreen;
            }
            //else if (!BuysUserControl.CheckInstance())
            //{
            //    SalesUserControl.setProductFromSelector(MainForm.Context.Products.FirstOrDefault(x => x.Id == productId));
            //}

        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Get the clicked PictureBox
            ToasterHelper.PlayNotificationSound();
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
            // Show loading form
            LoadingForm.Instance(_main).Show();

            if (await Task.Run(() => _context.Database.CanConnect()))
            {
                // Fetch data from the database
                List<ProductQuickAccess> productQuicks = await Task.Run(() => _context.ProductQuickAccess.ToList());

                // Clear existing controls in the FlowLayoutPanel
                flowLayoutPanel.Controls.Clear();

                foreach (var productImage in productQuicks)
                {
                    // Create the main panel for the product
                    Panel productPanel = new Panel
                    {
                        BackColor = Color.White,
                        Width = flowLayoutPanel.Width / 4 - 10, // Adjust based on FlowLayoutPanel width
                        Height = 150,
                        Margin = new Padding(7),
                        Padding = new Padding(2),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    // Add rounded corners and shadow effect
                    productPanel.Paint += (s, e) =>
                    {
                        ControlPaint.DrawBorder(e.Graphics, productPanel.ClientRectangle,
                            Color.Gray, 1, ButtonBorderStyle.Solid,
                            Color.Gray, 1, ButtonBorderStyle.Solid,
                            Color.Gray, 1, ButtonBorderStyle.Solid,
                            Color.Gray, 1, ButtonBorderStyle.Solid);
                    };

                    // Add product image
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = SetImage(productImage.ProductImage),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Width = productPanel.Width - 10,
                        Height = 75,
                        Dock = DockStyle.Top,
                        Cursor = Cursors.Hand
                    };

                    // Handle click event
                    pictureBox.Click += PictureBox_Click;
                    pictureBox.Tag = productImage.Pro_Id;

                    productPanel.Controls.Add(pictureBox);

                    // Create a label for the product name
                    Label labelName = new Label
                    {
                        Text = productImage.ProductName,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        ForeColor = Color.Black,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top,
                        AutoSize = false,
                        Height = 30
                    };

                    productPanel.Controls.Add(labelName);

                    // Create a label for the product ID
                    Label labelId = new Label
                    {
                        Text = $"ID: {productImage.Pro_Id}",
                        Font = new Font("Arial", 8, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top,
                        AutoSize = false,
                        Height = 20
                    };

                    productPanel.Controls.Add(labelId);

                    // Add the product panel to the FlowLayoutPanel
                    flowLayoutPanel.Controls.Add(productPanel);
                }
            }
            else
            {
                // Hide loading form and show error message
                LoadingForm.Instance(_main).Hide();
                MsgHelper.ShowServerError();
            }

            // Hide loading form
            LoadingForm.Instance(_main).Hide();
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
        public class CustomPictureBox : PictureBox
        {
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Color BorderColor { get; set; } = Color.Green;
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int BorderWidth { get; set; } = 2;

            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);
                if (BorderStyle == BorderStyle.FixedSingle)
                {
                    using (Pen pen = new Pen(BorderColor, BorderWidth))
                    {
                        pe.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
                    }
                }
            }
        }
    }

}
