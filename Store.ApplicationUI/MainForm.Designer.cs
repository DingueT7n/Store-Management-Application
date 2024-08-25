namespace Store.ApplicationUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            flowLayoutPanelNavBar = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            btnHomeSummary = new Button();
            BtnProducts = new Button();
            ProductsflowLayoutPanel = new FlowLayoutPanel();
            btnAllProducts = new Button();
            btnAddProduct = new Button();
            btnAllCategories = new Button();
            btnCustomers = new Button();
            CustomersflowLayoutPaneel = new FlowLayoutPanel();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button1 = new Button();
            ContainerPanel = new Panel();
            animationTimer = new System.Windows.Forms.Timer(components);
            flowLayoutPanelNavBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ProductsflowLayoutPanel.SuspendLayout();
            CustomersflowLayoutPaneel.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelNavBar
            // 
            flowLayoutPanelNavBar.BackColor = Color.WhiteSmoke;
            flowLayoutPanelNavBar.Controls.Add(pictureBox1);
            flowLayoutPanelNavBar.Controls.Add(btnHomeSummary);
            flowLayoutPanelNavBar.Controls.Add(BtnProducts);
            flowLayoutPanelNavBar.Controls.Add(ProductsflowLayoutPanel);
            flowLayoutPanelNavBar.Controls.Add(btnCustomers);
            flowLayoutPanelNavBar.Controls.Add(CustomersflowLayoutPaneel);
            flowLayoutPanelNavBar.Dock = DockStyle.Left;
            flowLayoutPanelNavBar.Location = new Point(0, 0);
            flowLayoutPanelNavBar.Name = "flowLayoutPanelNavBar";
            flowLayoutPanelNavBar.Padding = new Padding(3);
            flowLayoutPanelNavBar.Size = new Size(222, 679);
            flowLayoutPanelNavBar.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(213, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnHomeSummary
            // 
            btnHomeSummary.Anchor = AnchorStyles.None;
            btnHomeSummary.Image = Properties.Resources.Open_Box;
            btnHomeSummary.ImageAlign = ContentAlignment.MiddleLeft;
            btnHomeSummary.Location = new Point(0, 126);
            btnHomeSummary.Margin = new Padding(4, 5, 4, 5);
            btnHomeSummary.Name = "btnHomeSummary";
            btnHomeSummary.Size = new Size(212, 37);
            btnHomeSummary.TabIndex = 2;
            btnHomeSummary.Text = "الصفحة الرئيسية";
            btnHomeSummary.UseVisualStyleBackColor = true;
            btnHomeSummary.Click += btnHomeSummary_Click;
            // 
            // BtnProducts
            // 
            BtnProducts.Image = Properties.Resources.Open_Box;
            BtnProducts.ImageAlign = ContentAlignment.MiddleLeft;
            BtnProducts.Location = new Point(0, 173);
            BtnProducts.Margin = new Padding(4, 5, 4, 5);
            BtnProducts.Name = "BtnProducts";
            BtnProducts.Size = new Size(212, 37);
            BtnProducts.TabIndex = 1;
            BtnProducts.Text = "المنتوجات";
            BtnProducts.UseVisualStyleBackColor = true;
            BtnProducts.Click += BtnProducts_Click;
            // 
            // ProductsflowLayoutPanel
            // 
            ProductsflowLayoutPanel.Controls.Add(btnAllProducts);
            ProductsflowLayoutPanel.Controls.Add(btnAddProduct);
            ProductsflowLayoutPanel.Controls.Add(btnAllCategories);
            ProductsflowLayoutPanel.Location = new Point(4, 218);
            ProductsflowLayoutPanel.MaximumSize = new Size(209, 148);
            ProductsflowLayoutPanel.Name = "ProductsflowLayoutPanel";
            ProductsflowLayoutPanel.Size = new Size(209, 148);
            ProductsflowLayoutPanel.TabIndex = 3;
            ProductsflowLayoutPanel.Visible = false;
            // 
            // btnAllProducts
            // 
            btnAllProducts.Image = Properties.Resources.Open_Box;
            btnAllProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnAllProducts.Location = new Point(2, 5);
            btnAllProducts.Margin = new Padding(4, 5, 4, 5);
            btnAllProducts.Name = "btnAllProducts";
            btnAllProducts.Size = new Size(203, 37);
            btnAllProducts.TabIndex = 2;
            btnAllProducts.Text = "جميع المنتجات";
            btnAllProducts.UseVisualStyleBackColor = true;
            btnAllProducts.Click += button1_Click;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Image = Properties.Resources.Open_Box;
            btnAddProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddProduct.Location = new Point(2, 52);
            btnAddProduct.Margin = new Padding(4, 5, 4, 5);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(203, 37);
            btnAddProduct.TabIndex = 3;
            btnAddProduct.Text = "اضافة منتوج";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += button2_Click;
            // 
            // btnAllCategories
            // 
            btnAllCategories.Image = Properties.Resources.Open_Box;
            btnAllCategories.ImageAlign = ContentAlignment.MiddleLeft;
            btnAllCategories.Location = new Point(2, 99);
            btnAllCategories.Margin = new Padding(4, 5, 4, 5);
            btnAllCategories.Name = "btnAllCategories";
            btnAllCategories.Size = new Size(203, 37);
            btnAllCategories.TabIndex = 4;
            btnAllCategories.Text = "جميع الاصناف";
            btnAllCategories.UseVisualStyleBackColor = true;
            btnAllCategories.Click += button3_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.Image = Properties.Resources.Open_Box;
            btnCustomers.ImageAlign = ContentAlignment.MiddleLeft;
            btnCustomers.Location = new Point(0, 374);
            btnCustomers.Margin = new Padding(4, 5, 4, 5);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(212, 37);
            btnCustomers.TabIndex = 4;
            btnCustomers.Text = "العملاء";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // CustomersflowLayoutPaneel
            // 
            CustomersflowLayoutPaneel.Controls.Add(button2);
            CustomersflowLayoutPaneel.Controls.Add(button3);
            CustomersflowLayoutPaneel.Controls.Add(button4);
            CustomersflowLayoutPaneel.Controls.Add(button1);
            CustomersflowLayoutPaneel.Location = new Point(4, 419);
            CustomersflowLayoutPaneel.MaximumSize = new Size(209, 190);
            CustomersflowLayoutPaneel.Name = "CustomersflowLayoutPaneel";
            CustomersflowLayoutPaneel.Size = new Size(209, 190);
            CustomersflowLayoutPaneel.TabIndex = 6;
            CustomersflowLayoutPaneel.Visible = false;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.Open_Box;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(2, 5);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(203, 37);
            button2.TabIndex = 2;
            button2.Text = "جميع العملاء";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.Open_Box;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(2, 52);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(203, 37);
            button3.TabIndex = 3;
            button3.Text = "اضافة عميل";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Image = Properties.Resources.Open_Box;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(2, 99);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(203, 37);
            button4.TabIndex = 4;
            button4.Text = "حسابات العملاء";
            button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.Open_Box;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(2, 146);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(203, 37);
            button1.TabIndex = 5;
            button1.Text = "تقارير العملاء";
            button1.UseVisualStyleBackColor = true;
            // 
            // ContainerPanel
            // 
            ContainerPanel.BackColor = Color.White;
            ContainerPanel.Dock = DockStyle.Fill;
            ContainerPanel.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ContainerPanel.Location = new Point(222, 0);
            ContainerPanel.Name = "ContainerPanel";
            ContainerPanel.Size = new Size(1062, 679);
            ContainerPanel.TabIndex = 1;
            // 
            // animationTimer
            // 
            animationTimer.Enabled = true;
            animationTimer.Interval = 15;
            animationTimer.Tick += animationTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 679);
            Controls.Add(ContainerPanel);
            Controls.Add(flowLayoutPanelNavBar);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MinimumSize = new Size(1300, 718);
            Name = "MainForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ALG-D الواجهة الرئيسية";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainForm_FormClosing;
            flowLayoutPanelNavBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ProductsflowLayoutPanel.ResumeLayout(false);
            CustomersflowLayoutPaneel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelNavBar;
        private PictureBox pictureBox1;
        private Button BtnProducts;
        public Panel ContainerPanel;
        private Button btnHomeSummary;
        private FlowLayoutPanel ProductsflowLayoutPanel;
        private Button btnAllProducts;
        private Button btnAddProduct;
        private Button btnAllCategories;
        private System.Windows.Forms.Timer animationTimer;
        private Button btnCustomers;
        private FlowLayoutPanel CustomersflowLayoutPaneel;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button1;
    }
}
