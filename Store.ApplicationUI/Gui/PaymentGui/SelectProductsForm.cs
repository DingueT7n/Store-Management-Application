using System.IO;
using Microsoft.EntityFrameworkCore;
using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.System;
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
        private readonly MainForm _main;

        private readonly ApplicationDbContext _context;

        public SelectProductsForm(MainForm main, ControlManager controlManager, PosForm posForm, ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;


            _main = main;

            _controlManager = controlManager;
            _posForm = posForm;
            pos = false;
            // Add these lines:
            this.KeyPreview = true; // Allow form to see key events first
            flowLayoutPanel.TabStop = true; // Make sure it can receive focus

        }
        bool buy = false;
        bool sale = false;
        bool pos = false;
        private readonly ControlManager _controlManager;
        private readonly PosForm _posForm;

        public void SetBuy() => buy = !buy;
        public void SetPos() => pos = !pos;
        public void SetSale() => sale = !sale;


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


        async void AddProductToDgvIfNotExist(PictureBox pictureBox)
        {
            ToasterHelper.PlayNotificationSound();
            int productId = 0;
            if (pictureBox != null)
            {

                productId = (int)pictureBox.Tag;

            }

            if (_controlManager.TryGet<SalesUserControl>(out var UCS) && null != UCS)

            {

                if (sale && !pos && _main.GetUserControl() == UCS)
                {
                    await UCS.setPrivateProductAndAdditTotable(await _context.Products.FirstOrDefaultAsync(x => x.Id == productId));
                }
            }
            if (_controlManager.TryGet<BuysUserControl>(out BuysUserControl? UCB) && null != UCB)

            {
                if (buy && !pos && _main.GetUserControl() == UCB)

                {

                    UCB.setPrivateProductAndAdditTotable(await _context.Products.FirstOrDefaultAsync(x => x.Id == productId));
                }
            }



            if (_posForm != null && pos)
            {
                _posForm.GetPosUserControl().setProductFromSelector(await _context.Products.FirstOrDefaultAsync(x => x.Id == productId));
            }





            // Get the parent Panel of the clicked PictureBox
            Panel parentPanel = pictureBox.Parent as Panel;



            // Set the background color of the parent Panel to light green
            parentPanel.BackColor = Color.LightGreen;



        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Get the clicked PictureBox
            ToasterHelper.PlayNotificationSound();
            PictureBox pictureBox = sender as PictureBox;
            AddProductToDgvIfNotExist(pictureBox);
            // Update selection
            if (pictureBox != null && pictureBox.Parent is Panel panel)
            {
                // Clear previous selection
                foreach (var p in _productPanels)
                {
                    if (p.BackColor == Color.LightSkyBlue)
                        p.BackColor = Color.White;
                }

                // Set new selection
                panel.BackColor = Color.LightGreen;
                _currentSelectedIndex = _productPanels.IndexOf(panel);
            }

        }
        private int _currentSelectedIndex = 0;
        private List<Panel> _productPanels = new List<Panel>();
        public async Task LoadData()
        {
            // Show loading form
            LoadingForm.Instance(_main).Show();

            if (await _context.Database.CanConnectAsync())
            {
                // Fetch data from the database
                List<ProductQuickAccess> productQuicks = await _context.ProductQuickAccess.ToListAsync();

                // Clear existing controls in the FlowLayoutPanel
                flowLayoutPanel.Controls.Clear();
                _productPanels.Clear();

                // Calculate panel size based on container width to fit at least 15 items
                int panelsPerRow = Math.Max(5, flowLayoutPanel.Width / 150); // Adjust 150 as needed
                int panelWidth = flowLayoutPanel.Width / panelsPerRow - 10;
                // Set up keyboard navigation

                foreach (var productImage in productQuicks)
                {
                    // Create the main panel for the product
                    Panel productPanel = new Panel
                    {
                        BackColor = Color.White,
                        Width = panelWidth,
                        Height = 120, // Reduced height
                        Margin = new Padding(5),
                        Padding = new Padding(2),
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = productImage.Pro_Id
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
                        Height = 60, // Reduced height
                        Top = 5,
                        Left = (productPanel.Width - (productPanel.Width - 10)) / 2,
                        Cursor = Cursors.Hand
                    };

                    pictureBox.Click += PictureBox_Click;
                    pictureBox.Tag = productImage.Pro_Id;
                    productPanel.Controls.Add(pictureBox);

                    // Create a label for the product name
                    Label labelName = new Label
                    {
                        Text = productImage.ProductName,
                        Font = new Font("Arial", 9, FontStyle.Bold), // Smaller font
                        ForeColor = Color.Black,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Top = pictureBox.Bottom + 2,
                        Width = productPanel.Width - 10,
                        Height = 20, // Reduced height
                        Left = (productPanel.Width - (productPanel.Width - 10)) / 2
                    };

                    productPanel.Controls.Add(labelName);

                    // Create a label for the product ID
                    Label labelId = new Label
                    {
                        Text = $"ID: {productImage.Pro_Id}",
                        Font = new Font("Arial", 7, FontStyle.Italic), // Smaller font
                        ForeColor = Color.Gray,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Top = labelName.Bottom,
                        Width = productPanel.Width - 10,
                        Height = 15, // Reduced height
                        Left = (productPanel.Width - (productPanel.Width - 10)) / 2
                    };

                    productPanel.Controls.Add(labelId);

                    // Add click handler to the entire panel
                    productPanel.Click += (s, e) =>
                    {
                        PictureBox_Click(pictureBox, e);
                    };
                    productPanel.Cursor = Cursors.Hand;

                    flowLayoutPanel.Controls.Add(productPanel);
                    _productPanels.Add(productPanel);
                }

                // Set up keyboard navigation
                if (_productPanels.Count > 0)
                {
                    _productPanels[0].BackColor = Color.LightSkyBlue; // Initial selection
                    flowLayoutPanel.PreviewKeyDown += FlowLayoutPanel_PreviewKeyDown;
                    flowLayoutPanel.KeyDown += FlowLayoutPanel_KeyDown;
                    flowLayoutPanel.Focus();
                }
                if (_productPanels.Count > 0)
                {
                    _productPanels[0].BackColor = Color.LightSkyBlue; // Initial selection
                    this.KeyDown += SelectProductsForm_KeyDown; // Changed to form-level handler
                    flowLayoutPanel.Focus();
                }
            }
            else
            {
                LoadingForm.Instance(_main).Hide();
                MsgHelper.ShowServerError();
            }

            LoadingForm.Instance(_main).Hide();

        }
        private void FlowLayoutPanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Mark arrow keys as input keys so KeyDown event will fire
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
        private void SelectProductsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_productPanels.Count == 0) return;

            int columns = flowLayoutPanel.Width / _productPanels[0].Width;
            if (columns == 0) columns = 1;

            switch (e.KeyCode)
            {
                case Keys.Right:
                    // Move right
                    if (_currentSelectedIndex < _productPanels.Count - 1)
                    {
                        _productPanels[_currentSelectedIndex].BackColor = Color.White;
                        _currentSelectedIndex++;
                        _productPanels[_currentSelectedIndex].BackColor = Color.LightSkyBlue;
                        EnsurePanelVisible(_productPanels[_currentSelectedIndex]);
                    }
                    e.Handled = true;
                    break;

                case Keys.Left:
                    // Move left
                    if (_currentSelectedIndex > 0)
                    {
                        _productPanels[_currentSelectedIndex].BackColor = Color.White;
                        _currentSelectedIndex--;
                        _productPanels[_currentSelectedIndex].BackColor = Color.LightSkyBlue;
                        EnsurePanelVisible(_productPanels[_currentSelectedIndex]);
                    }
                    e.Handled = true;
                    break;

                case Keys.Down:
                    // Move down
                    if (_currentSelectedIndex + columns < _productPanels.Count)
                    {
                        _productPanels[_currentSelectedIndex].BackColor = Color.White;
                        _currentSelectedIndex += columns;
                        _productPanels[_currentSelectedIndex].BackColor = Color.LightSkyBlue;
                        EnsurePanelVisible(_productPanels[_currentSelectedIndex]);
                    }
                    e.Handled = true;
                    break;

                case Keys.Up:
                    // Move up
                    if (_currentSelectedIndex - columns >= 0)
                    {
                        _productPanels[_currentSelectedIndex].BackColor = Color.White;
                        _currentSelectedIndex -= columns;
                        _productPanels[_currentSelectedIndex].BackColor = Color.LightSkyBlue;
                        EnsurePanelVisible(_productPanels[_currentSelectedIndex]);
                    }
                    e.Handled = true;
                    break;

                case Keys.Enter:
                    // Trigger add to table function
                    if (_currentSelectedIndex >= 0 && _currentSelectedIndex < _productPanels.Count)
                    {
                        PictureBox pictureBox = _productPanels[_currentSelectedIndex].Controls.OfType<PictureBox>().FirstOrDefault();
                        if (pictureBox != null)
                        {
                            AddProductToDgvIfNotExist(pictureBox);
                            _productPanels[_currentSelectedIndex].BackColor = Color.LightGreen;
                        }
                    }
                    e.Handled = true;
                    break;
            }
        }
        private void FlowLayoutPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (_productPanels.Count == 0) return;

            int columns = flowLayoutPanel.Width / _productPanels[0].Width;
            if (columns == 0) columns = 1;

            switch (e.KeyCode)
            {
                case Keys.Right:
                    // Move right
                    if (_currentSelectedIndex < _productPanels.Count - 1)
                    {
                        _productPanels[_currentSelectedIndex].BackColor = Color.White;
                        _currentSelectedIndex++;
                        _productPanels[_currentSelectedIndex].BackColor = Color.LightSkyBlue;
                        EnsurePanelVisible(_productPanels[_currentSelectedIndex]);
                    }
                    break;

                case Keys.Left:
                    // Move left
                    if (_currentSelectedIndex > 0)
                    {
                        _productPanels[_currentSelectedIndex].BackColor = Color.White;
                        _currentSelectedIndex--;
                        _productPanels[_currentSelectedIndex].BackColor = Color.LightSkyBlue;
                        EnsurePanelVisible(_productPanels[_currentSelectedIndex]);
                    }
                    break;

                case Keys.Down:
                    // Move down
                    if (_currentSelectedIndex + columns < _productPanels.Count)
                    {
                        _productPanels[_currentSelectedIndex].BackColor = Color.White;
                        _currentSelectedIndex += columns;
                        _productPanels[_currentSelectedIndex].BackColor = Color.LightSkyBlue;
                        EnsurePanelVisible(_productPanels[_currentSelectedIndex]);
                    }
                    break;

                case Keys.Up:
                    // Move up
                    if (_currentSelectedIndex - columns >= 0)
                    {
                        _productPanels[_currentSelectedIndex].BackColor = Color.White;
                        _currentSelectedIndex -= columns;
                        _productPanels[_currentSelectedIndex].BackColor = Color.LightSkyBlue;
                        EnsurePanelVisible(_productPanels[_currentSelectedIndex]);
                    }
                    break;

                case Keys.Enter:
                    // Trigger add to table function
                    if (_currentSelectedIndex >= 0 && _currentSelectedIndex < _productPanels.Count)
                    {
                        PictureBox pictureBox = _productPanels[_currentSelectedIndex].Controls.OfType<PictureBox>().FirstOrDefault();
                        if (pictureBox != null)
                        {
                            AddProductToDgvIfNotExist(pictureBox);
                            _productPanels[_currentSelectedIndex].BackColor = Color.LightGreen;
                        }
                    }
                    break;
            }
        }

        private void EnsurePanelVisible(Panel panel)
        {
            // Scroll the flowLayoutPanel to make the selected panel visible
            flowLayoutPanel.ScrollControlIntoView(panel);
        }




        private void SelectProductsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            flowLayoutPanel.Controls.Clear();
            buy = false;
            sale = false;
            pos = false;

        }
    }

}
