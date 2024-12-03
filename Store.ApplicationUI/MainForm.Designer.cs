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
            btnComptoire = new Button();
            btnHomeSummary = new Button();
            BtnProducts = new Button();
            ProductsflowLayoutPanel = new FlowLayoutPanel();
            btnAllProducts = new Button();
            btnAddProduct = new Button();
            btnAllCategories = new Button();
            button5 = new Button();
            btnCustomers = new Button();
            CustomersflowLayoutPaneel = new FlowLayoutPanel();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button1 = new Button();
            btnSupplierPanel = new Button();
            SuppliersflowLayoutPanel = new FlowLayoutPanel();
            btnAllSuppliers = new Button();
            btnAddSupplier = new Button();
            btnSupplierAccount = new Button();
            btnSupplierReports = new Button();
            btnBuysPanel = new Button();
            BuysflowLayoutPanel = new FlowLayoutPanel();
            btnNewBuy = new Button();
            btnBuysReports = new Button();
            btnEditBuy = new Button();
            btnSalesPanel = new Button();
            SalesflowLayoutPanel = new FlowLayoutPanel();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button6 = new Button();
            button10 = new Button();
            DeservedflowLayoutPanel = new FlowLayoutPanel();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            ContainerPanel = new Panel();
            animationTimer = new System.Windows.Forms.Timer(components);
            button14 = new Button();
            flowLayoutPanelNavBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ProductsflowLayoutPanel.SuspendLayout();
            CustomersflowLayoutPaneel.SuspendLayout();
            SuppliersflowLayoutPanel.SuspendLayout();
            BuysflowLayoutPanel.SuspendLayout();
            SalesflowLayoutPanel.SuspendLayout();
            DeservedflowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelNavBar
            // 
            flowLayoutPanelNavBar.AutoScroll = true;
            flowLayoutPanelNavBar.AutoScrollMargin = new Size(5, 5);
            flowLayoutPanelNavBar.BackColor = Color.WhiteSmoke;
            flowLayoutPanelNavBar.Controls.Add(pictureBox1);
            flowLayoutPanelNavBar.Controls.Add(btnComptoire);
            flowLayoutPanelNavBar.Controls.Add(btnHomeSummary);
            flowLayoutPanelNavBar.Controls.Add(BtnProducts);
            flowLayoutPanelNavBar.Controls.Add(ProductsflowLayoutPanel);
            flowLayoutPanelNavBar.Controls.Add(btnCustomers);
            flowLayoutPanelNavBar.Controls.Add(CustomersflowLayoutPaneel);
            flowLayoutPanelNavBar.Controls.Add(btnSupplierPanel);
            flowLayoutPanelNavBar.Controls.Add(SuppliersflowLayoutPanel);
            flowLayoutPanelNavBar.Controls.Add(btnBuysPanel);
            flowLayoutPanelNavBar.Controls.Add(BuysflowLayoutPanel);
            flowLayoutPanelNavBar.Controls.Add(btnSalesPanel);
            flowLayoutPanelNavBar.Controls.Add(SalesflowLayoutPanel);
            flowLayoutPanelNavBar.Controls.Add(button6);
            flowLayoutPanelNavBar.Controls.Add(button10);
            flowLayoutPanelNavBar.Controls.Add(DeservedflowLayoutPanel);
            flowLayoutPanelNavBar.Controls.Add(button14);
            flowLayoutPanelNavBar.Dock = DockStyle.Left;
            flowLayoutPanelNavBar.Location = new Point(0, 0);
            flowLayoutPanelNavBar.Name = "flowLayoutPanelNavBar";
            flowLayoutPanelNavBar.Padding = new Padding(3);
            flowLayoutPanelNavBar.Size = new Size(237, 679);
            flowLayoutPanelNavBar.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-2, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(213, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnComptoire
            // 
            btnComptoire.Anchor = AnchorStyles.None;
            btnComptoire.Image = Properties.Resources.Open_Box;
            btnComptoire.ImageAlign = ContentAlignment.MiddleLeft;
            btnComptoire.Location = new Point(6, 126);
            btnComptoire.Margin = new Padding(4, 5, 4, 5);
            btnComptoire.Name = "btnComptoire";
            btnComptoire.Size = new Size(204, 37);
            btnComptoire.TabIndex = 13;
            btnComptoire.Text = "شاشة البيع السريع";
            btnComptoire.UseVisualStyleBackColor = true;
            btnComptoire.Click += btnComptoire_Click;
            // 
            // btnHomeSummary
            // 
            btnHomeSummary.Anchor = AnchorStyles.None;
            btnHomeSummary.Image = Properties.Resources.Open_Box;
            btnHomeSummary.ImageAlign = ContentAlignment.MiddleLeft;
            btnHomeSummary.Location = new Point(6, 173);
            btnHomeSummary.Margin = new Padding(4, 5, 4, 5);
            btnHomeSummary.Name = "btnHomeSummary";
            btnHomeSummary.Size = new Size(204, 37);
            btnHomeSummary.TabIndex = 2;
            btnHomeSummary.Text = "الصفحة الرئيسية";
            btnHomeSummary.UseVisualStyleBackColor = true;
            btnHomeSummary.Click += btnHomeSummary_Click;
            // 
            // BtnProducts
            // 
            BtnProducts.Image = Properties.Resources.Open_Box;
            BtnProducts.ImageAlign = ContentAlignment.MiddleLeft;
            BtnProducts.Location = new Point(6, 220);
            BtnProducts.Margin = new Padding(4, 5, 4, 5);
            BtnProducts.Name = "BtnProducts";
            BtnProducts.Size = new Size(204, 37);
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
            ProductsflowLayoutPanel.Controls.Add(button5);
            ProductsflowLayoutPanel.Location = new Point(24, 265);
            ProductsflowLayoutPanel.MaximumSize = new Size(209, 187);
            ProductsflowLayoutPanel.Name = "ProductsflowLayoutPanel";
            ProductsflowLayoutPanel.Size = new Size(187, 187);
            ProductsflowLayoutPanel.TabIndex = 3;
            ProductsflowLayoutPanel.Visible = false;
            // 
            // btnAllProducts
            // 
            btnAllProducts.Image = Properties.Resources.Open_Box;
            btnAllProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnAllProducts.Location = new Point(0, 5);
            btnAllProducts.Margin = new Padding(4, 5, 4, 5);
            btnAllProducts.Name = "btnAllProducts";
            btnAllProducts.Size = new Size(183, 37);
            btnAllProducts.TabIndex = 2;
            btnAllProducts.Text = "جميع المنتجات";
            btnAllProducts.UseVisualStyleBackColor = true;
            btnAllProducts.Click += button1_Click;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Image = Properties.Resources.Open_Box;
            btnAddProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddProduct.Location = new Point(0, 52);
            btnAddProduct.Margin = new Padding(4, 5, 4, 5);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(183, 37);
            btnAddProduct.TabIndex = 3;
            btnAddProduct.Text = "اضافة منتوج";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += button2_Click;
            // 
            // btnAllCategories
            // 
            btnAllCategories.Image = Properties.Resources.Open_Box;
            btnAllCategories.ImageAlign = ContentAlignment.MiddleLeft;
            btnAllCategories.Location = new Point(0, 99);
            btnAllCategories.Margin = new Padding(4, 5, 4, 5);
            btnAllCategories.Name = "btnAllCategories";
            btnAllCategories.Size = new Size(183, 37);
            btnAllCategories.TabIndex = 4;
            btnAllCategories.Text = "جميع الاصناف";
            btnAllCategories.UseVisualStyleBackColor = true;
            btnAllCategories.Click += button3_Click;
            // 
            // button5
            // 
            button5.Image = Properties.Resources.Open_Box;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(0, 146);
            button5.Margin = new Padding(4, 5, 4, 5);
            button5.Name = "button5";
            button5.Size = new Size(183, 37);
            button5.TabIndex = 5;
            button5.Text = "جميع المخازن";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.Image = Properties.Resources.Open_Box;
            btnCustomers.ImageAlign = ContentAlignment.MiddleLeft;
            btnCustomers.Location = new Point(6, 460);
            btnCustomers.Margin = new Padding(4, 5, 4, 5);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(204, 37);
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
            CustomersflowLayoutPaneel.Location = new Point(24, 505);
            CustomersflowLayoutPaneel.MaximumSize = new Size(209, 190);
            CustomersflowLayoutPaneel.Name = "CustomersflowLayoutPaneel";
            CustomersflowLayoutPaneel.Size = new Size(187, 190);
            CustomersflowLayoutPaneel.TabIndex = 6;
            CustomersflowLayoutPaneel.Visible = false;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.Open_Box;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 5);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(183, 37);
            button2.TabIndex = 2;
            button2.Text = "جميع العملاء";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.Open_Box;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(0, 52);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(183, 37);
            button3.TabIndex = 3;
            button3.Text = "اضافة عميل";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // button4
            // 
            button4.Image = Properties.Resources.Open_Box;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(0, 99);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(183, 37);
            button4.TabIndex = 4;
            button4.Text = "حسابات العملاء";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.Open_Box;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 146);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(183, 37);
            button1.TabIndex = 5;
            button1.Text = "تقارير العملاء";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // btnSupplierPanel
            // 
            btnSupplierPanel.Image = Properties.Resources.Open_Box;
            btnSupplierPanel.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupplierPanel.Location = new Point(6, 703);
            btnSupplierPanel.Margin = new Padding(4, 5, 4, 5);
            btnSupplierPanel.Name = "btnSupplierPanel";
            btnSupplierPanel.Size = new Size(204, 37);
            btnSupplierPanel.TabIndex = 7;
            btnSupplierPanel.Text = "الموردين";
            btnSupplierPanel.UseVisualStyleBackColor = true;
            btnSupplierPanel.Click += btnSupplierPanel_Click;
            // 
            // SuppliersflowLayoutPanel
            // 
            SuppliersflowLayoutPanel.Controls.Add(btnAllSuppliers);
            SuppliersflowLayoutPanel.Controls.Add(btnAddSupplier);
            SuppliersflowLayoutPanel.Controls.Add(btnSupplierAccount);
            SuppliersflowLayoutPanel.Controls.Add(btnSupplierReports);
            SuppliersflowLayoutPanel.Location = new Point(24, 748);
            SuppliersflowLayoutPanel.MaximumSize = new Size(209, 190);
            SuppliersflowLayoutPanel.Name = "SuppliersflowLayoutPanel";
            SuppliersflowLayoutPanel.Size = new Size(187, 190);
            SuppliersflowLayoutPanel.TabIndex = 8;
            SuppliersflowLayoutPanel.Visible = false;
            // 
            // btnAllSuppliers
            // 
            btnAllSuppliers.Image = Properties.Resources.Open_Box;
            btnAllSuppliers.ImageAlign = ContentAlignment.MiddleLeft;
            btnAllSuppliers.Location = new Point(0, 5);
            btnAllSuppliers.Margin = new Padding(4, 5, 4, 5);
            btnAllSuppliers.Name = "btnAllSuppliers";
            btnAllSuppliers.Size = new Size(183, 37);
            btnAllSuppliers.TabIndex = 2;
            btnAllSuppliers.Text = "جميع الموردين";
            btnAllSuppliers.UseVisualStyleBackColor = true;
            btnAllSuppliers.Click += btnAllSuppliers_Click;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Image = Properties.Resources.Open_Box;
            btnAddSupplier.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddSupplier.Location = new Point(0, 52);
            btnAddSupplier.Margin = new Padding(4, 5, 4, 5);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(183, 37);
            btnAddSupplier.TabIndex = 3;
            btnAddSupplier.Text = "اضافة مورد";
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // btnSupplierAccount
            // 
            btnSupplierAccount.Image = Properties.Resources.Open_Box;
            btnSupplierAccount.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupplierAccount.Location = new Point(0, 99);
            btnSupplierAccount.Margin = new Padding(4, 5, 4, 5);
            btnSupplierAccount.Name = "btnSupplierAccount";
            btnSupplierAccount.Size = new Size(183, 37);
            btnSupplierAccount.TabIndex = 4;
            btnSupplierAccount.Text = "حسابات الموردين";
            btnSupplierAccount.UseVisualStyleBackColor = true;
            btnSupplierAccount.Click += btnSupplierAccount_Click;
            // 
            // btnSupplierReports
            // 
            btnSupplierReports.Image = Properties.Resources.Open_Box;
            btnSupplierReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupplierReports.Location = new Point(0, 146);
            btnSupplierReports.Margin = new Padding(4, 5, 4, 5);
            btnSupplierReports.Name = "btnSupplierReports";
            btnSupplierReports.Size = new Size(183, 37);
            btnSupplierReports.TabIndex = 5;
            btnSupplierReports.Text = "تقارير الموردين";
            btnSupplierReports.UseVisualStyleBackColor = true;
            btnSupplierReports.Click += btnSupplierReports_Click;
            // 
            // btnBuysPanel
            // 
            btnBuysPanel.Image = Properties.Resources.Open_Box;
            btnBuysPanel.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuysPanel.Location = new Point(6, 946);
            btnBuysPanel.Margin = new Padding(4, 5, 4, 5);
            btnBuysPanel.Name = "btnBuysPanel";
            btnBuysPanel.Size = new Size(204, 37);
            btnBuysPanel.TabIndex = 9;
            btnBuysPanel.Text = "المشتريات";
            btnBuysPanel.UseVisualStyleBackColor = true;
            btnBuysPanel.Click += btnBuysPanel_Click;
            // 
            // BuysflowLayoutPanel
            // 
            BuysflowLayoutPanel.Controls.Add(btnNewBuy);
            BuysflowLayoutPanel.Controls.Add(btnBuysReports);
            BuysflowLayoutPanel.Controls.Add(btnEditBuy);
            BuysflowLayoutPanel.Location = new Point(24, 991);
            BuysflowLayoutPanel.MaximumSize = new Size(209, 143);
            BuysflowLayoutPanel.Name = "BuysflowLayoutPanel";
            BuysflowLayoutPanel.Size = new Size(187, 143);
            BuysflowLayoutPanel.TabIndex = 10;
            BuysflowLayoutPanel.Visible = false;
            // 
            // btnNewBuy
            // 
            btnNewBuy.Image = Properties.Resources.Open_Box;
            btnNewBuy.ImageAlign = ContentAlignment.MiddleLeft;
            btnNewBuy.Location = new Point(0, 5);
            btnNewBuy.Margin = new Padding(4, 5, 4, 5);
            btnNewBuy.Name = "btnNewBuy";
            btnNewBuy.Size = new Size(183, 37);
            btnNewBuy.TabIndex = 2;
            btnNewBuy.Text = "شراء جديد";
            btnNewBuy.UseVisualStyleBackColor = true;
            btnNewBuy.Click += btnNewBuy_Click;
            // 
            // btnBuysReports
            // 
            btnBuysReports.Image = Properties.Resources.Open_Box;
            btnBuysReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuysReports.Location = new Point(0, 52);
            btnBuysReports.Margin = new Padding(4, 5, 4, 5);
            btnBuysReports.Name = "btnBuysReports";
            btnBuysReports.Size = new Size(183, 37);
            btnBuysReports.TabIndex = 3;
            btnBuysReports.Text = "تقارير المشتريات";
            btnBuysReports.UseVisualStyleBackColor = true;
            btnBuysReports.Click += btnBuysReports_Click;
            // 
            // btnEditBuy
            // 
            btnEditBuy.Image = Properties.Resources.Open_Box;
            btnEditBuy.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditBuy.Location = new Point(0, 99);
            btnEditBuy.Margin = new Padding(4, 5, 4, 5);
            btnEditBuy.Name = "btnEditBuy";
            btnEditBuy.Size = new Size(183, 37);
            btnEditBuy.TabIndex = 4;
            btnEditBuy.Text = "تعديل فاتورة";
            btnEditBuy.UseVisualStyleBackColor = true;
            // 
            // btnSalesPanel
            // 
            btnSalesPanel.FlatAppearance.BorderSize = 4;
            btnSalesPanel.Image = Properties.Resources.Open_Box;
            btnSalesPanel.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalesPanel.Location = new Point(6, 1142);
            btnSalesPanel.Margin = new Padding(4, 5, 4, 5);
            btnSalesPanel.Name = "btnSalesPanel";
            btnSalesPanel.Size = new Size(204, 37);
            btnSalesPanel.TabIndex = 11;
            btnSalesPanel.Text = "المبيعات";
            btnSalesPanel.UseVisualStyleBackColor = true;
            btnSalesPanel.Click += btnSalesPanel_Click;
            // 
            // SalesflowLayoutPanel
            // 
            SalesflowLayoutPanel.Controls.Add(button7);
            SalesflowLayoutPanel.Controls.Add(button8);
            SalesflowLayoutPanel.Controls.Add(button9);
            SalesflowLayoutPanel.Location = new Point(24, 1187);
            SalesflowLayoutPanel.MaximumSize = new Size(209, 143);
            SalesflowLayoutPanel.Name = "SalesflowLayoutPanel";
            SalesflowLayoutPanel.Size = new Size(187, 143);
            SalesflowLayoutPanel.TabIndex = 12;
            SalesflowLayoutPanel.Visible = false;
            // 
            // button7
            // 
            button7.Image = Properties.Resources.Open_Box;
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(0, 5);
            button7.Margin = new Padding(4, 5, 4, 5);
            button7.Name = "button7";
            button7.Size = new Size(183, 37);
            button7.TabIndex = 2;
            button7.Text = "مبيعة جديدة";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Image = Properties.Resources.Open_Box;
            button8.ImageAlign = ContentAlignment.MiddleLeft;
            button8.Location = new Point(0, 52);
            button8.Margin = new Padding(4, 5, 4, 5);
            button8.Name = "button8";
            button8.Size = new Size(183, 37);
            button8.TabIndex = 3;
            button8.Text = "تقارير المبيعات";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Image = Properties.Resources.Open_Box;
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Location = new Point(0, 99);
            button9.Margin = new Padding(4, 5, 4, 5);
            button9.Name = "button9";
            button9.Size = new Size(183, 37);
            button9.TabIndex = 4;
            button9.Text = "الارباح ";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderSize = 4;
            button6.Image = Properties.Resources.Open_Box;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(6, 1338);
            button6.Margin = new Padding(4, 5, 4, 5);
            button6.Name = "button6";
            button6.Size = new Size(204, 37);
            button6.TabIndex = 14;
            button6.Text = "الصانديق والبنك";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button10
            // 
            button10.FlatAppearance.BorderSize = 4;
            button10.Image = Properties.Resources.Open_Box;
            button10.ImageAlign = ContentAlignment.MiddleLeft;
            button10.Location = new Point(6, 1385);
            button10.Margin = new Padding(4, 5, 4, 5);
            button10.Name = "button10";
            button10.Size = new Size(204, 37);
            button10.TabIndex = 15;
            button10.Text = "المصاريف والضرائب";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // DeservedflowLayoutPanel
            // 
            DeservedflowLayoutPanel.Controls.Add(button11);
            DeservedflowLayoutPanel.Controls.Add(button12);
            DeservedflowLayoutPanel.Controls.Add(button13);
            DeservedflowLayoutPanel.Location = new Point(24, 1430);
            DeservedflowLayoutPanel.MaximumSize = new Size(209, 143);
            DeservedflowLayoutPanel.Name = "DeservedflowLayoutPanel";
            DeservedflowLayoutPanel.Size = new Size(187, 143);
            DeservedflowLayoutPanel.TabIndex = 16;
            DeservedflowLayoutPanel.Visible = false;
            // 
            // button11
            // 
            button11.Image = Properties.Resources.Open_Box;
            button11.ImageAlign = ContentAlignment.MiddleLeft;
            button11.Location = new Point(0, 5);
            button11.Margin = new Padding(4, 5, 4, 5);
            button11.Name = "button11";
            button11.Size = new Size(183, 37);
            button11.TabIndex = 2;
            button11.Text = "جميع المصروفات";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Image = Properties.Resources.Open_Box;
            button12.ImageAlign = ContentAlignment.MiddleLeft;
            button12.Location = new Point(0, 52);
            button12.Margin = new Padding(4, 5, 4, 5);
            button12.Name = "button12";
            button12.Size = new Size(183, 37);
            button12.TabIndex = 3;
            button12.Text = "السندات";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Image = Properties.Resources.Open_Box;
            button13.ImageAlign = ContentAlignment.MiddleLeft;
            button13.Location = new Point(0, 99);
            button13.Margin = new Padding(4, 5, 4, 5);
            button13.Name = "button13";
            button13.Size = new Size(183, 37);
            button13.TabIndex = 4;
            button13.Text = "الارباح ";
            button13.UseVisualStyleBackColor = true;
            // 
            // ContainerPanel
            // 
            ContainerPanel.BackColor = Color.White;
            ContainerPanel.Dock = DockStyle.Fill;
            ContainerPanel.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ContainerPanel.Location = new Point(237, 0);
            ContainerPanel.Name = "ContainerPanel";
            ContainerPanel.Size = new Size(1047, 679);
            ContainerPanel.TabIndex = 1;
            // 
            // animationTimer
            // 
            animationTimer.Enabled = true;
            animationTimer.Interval = 15;
            animationTimer.Tick += animationTimer_Tick;
            // 
            // button14
            // 
            button14.FlatAppearance.BorderSize = 4;
            button14.Image = Properties.Resources.Open_Box;
            button14.ImageAlign = ContentAlignment.MiddleLeft;
            button14.Location = new Point(6, 1581);
            button14.Margin = new Padding(4, 5, 4, 5);
            button14.Name = "button14";
            button14.Size = new Size(204, 37);
            button14.TabIndex = 17;
            button14.Text = "المرتجعات";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
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
            SuppliersflowLayoutPanel.ResumeLayout(false);
            BuysflowLayoutPanel.ResumeLayout(false);
            SalesflowLayoutPanel.ResumeLayout(false);
            DeservedflowLayoutPanel.ResumeLayout(false);
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
        private Button btnSupplierPanel;
        private FlowLayoutPanel SuppliersflowLayoutPanel;
        private Button btnAllSuppliers;
        private Button btnAddSupplier;
        private Button btnSupplierAccount;
        private Button btnSupplierReports;
        private Button button5;
        private Button btnBuysPanel;
        private FlowLayoutPanel BuysflowLayoutPanel;
        private Button btnNewBuy;
        private Button btnBuysReports;
        private Button btnEditBuy;
        private Button btnSalesPanel;
        private FlowLayoutPanel SalesflowLayoutPanel;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button btnComptoire;
        private Button button6;
        private Button button10;
        private FlowLayoutPanel DeservedflowLayoutPanel;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
    }
}
