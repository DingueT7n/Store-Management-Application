namespace Store.ApplicationUI.Gui.SalesGui.PosGui
{
    partial class PosUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PosUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            btnChoseCustomer = new Button();
            gbOperations = new GroupBox();
            button1 = new Button();
            btnPay = new Button();
            btnDeleteSelected = new Button();
            btnEditSelected = new Button();
            btnDown = new Button();
            btnUp = new Button();
            gpSearchAvailable = new GroupBox();
            btnPrices = new Button();
            label5 = new Label();
            lblBarCode = new Label();
            txtSearchBarCode = new TextBox();
            btnSearchImage = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            ModifiertableLayoutPanel = new TableLayoutPanel();
            txtQty = new TextBox();
            txtProductName = new TextBox();
            lblProductName = new Label();
            lblQuentity = new Label();
            lblSalePrice = new Label();
            txtSalePrice = new TextBox();
            lblBuyPrice = new Label();
            txtSaleDiscount = new TextBox();
            lblTotalSale = new Label();
            txtTotalSaleProduct = new TextBox();
            tableLayoutPanel = new TableLayoutPanel();
            lblEmptyData = new Label();
            DgvِProducts = new DataGridView();
            timer = new System.Windows.Forms.Timer(components);
            QuickPanel = new Panel();
            lblEmptyQuick = new Label();
            DgvQuickProducts = new DataGridView();
            panel1 = new Panel();
            panel5 = new Panel();
            flowLayoutPanelCusotnmer = new FlowLayoutPanel();
            label3 = new Label();
            lblCustomerName = new Label();
            gbOperation = new GroupBox();
            rbRefund = new RadioButton();
            rbSale = new RadioButton();
            IdCustomer = new Label();
            flowLayoutPanel4 = new FlowLayoutPanel();
            lblqtyshow = new Label();
            lblQuentityValue = new Label();
            labelproductintable = new Label();
            lblProductIntable = new Label();
            pictureBox1 = new PictureBox();
            flowLayoutPanelDates = new FlowLayoutPanel();
            label1 = new Label();
            lblFactureNumber = new Label();
            label4 = new Label();
            lblDatetime = new Label();
            label6 = new Label();
            lblHour = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            lblUserShow = new Label();
            lblUserName = new Label();
            lblSupportTech = new Label();
            lblSupportNumber = new Label();
            flowLayoutPanelComptoirePrice = new FlowLayoutPanel();
            lblValuePrice = new Label();
            lblCurrancy = new Label();
            labelprice = new Label();
            PanelPagination = new Panel();
            cmbpagination = new ComboBox();
            btnPrev = new Button();
            btnNext = new Button();
            gbOperations.SuspendLayout();
            gpSearchAvailable.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ModifiertableLayoutPanel.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِProducts).BeginInit();
            QuickPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvQuickProducts).BeginInit();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            flowLayoutPanelCusotnmer.SuspendLayout();
            gbOperation.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanelDates.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanelComptoirePrice.SuspendLayout();
            PanelPagination.SuspendLayout();
            SuspendLayout();
            // 
            // btnChoseCustomer
            // 
            btnChoseCustomer.Anchor = AnchorStyles.None;
            btnChoseCustomer.BackColor = Color.White;
            btnChoseCustomer.FlatStyle = FlatStyle.Flat;
            btnChoseCustomer.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChoseCustomer.ForeColor = SystemColors.ControlText;
            btnChoseCustomer.Image = (Image)resources.GetObject("btnChoseCustomer.Image");
            btnChoseCustomer.ImageAlign = ContentAlignment.TopCenter;
            btnChoseCustomer.Location = new Point(118, 24);
            btnChoseCustomer.Name = "btnChoseCustomer";
            btnChoseCustomer.Size = new Size(77, 76);
            btnChoseCustomer.TabIndex = 4;
            btnChoseCustomer.Text = "العملاء (Crtl+F5)";
            btnChoseCustomer.TextAlign = ContentAlignment.BottomCenter;
            btnChoseCustomer.UseVisualStyleBackColor = false;
            btnChoseCustomer.Click += btnChoseCustomer_Click;
            // 
            // gbOperations
            // 
            gbOperations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbOperations.Controls.Add(button1);
            gbOperations.Controls.Add(btnPay);
            gbOperations.Controls.Add(btnDeleteSelected);
            gbOperations.Controls.Add(btnChoseCustomer);
            gbOperations.Controls.Add(btnEditSelected);
            gbOperations.Controls.Add(btnDown);
            gbOperations.Controls.Add(btnUp);
            flowLayoutPanel2.SetFlowBreak(gbOperations, true);
            gbOperations.Font = new Font("Calibri", 12F, FontStyle.Bold);
            gbOperations.Location = new Point(31, 3);
            gbOperations.Name = "gbOperations";
            gbOperations.Size = new Size(523, 109);
            gbOperations.TabIndex = 24;
            gbOperations.TabStop = false;
            gbOperations.Text = "العمليات المتاحة على الجدول";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.FlatAppearance.MouseOverBackColor = Color.PaleGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.ImeMode = ImeMode.NoControl;
            button1.Location = new Point(6, 25);
            button1.Name = "button1";
            button1.Size = new Size(97, 75);
            button1.TabIndex = 32;
            button1.Text = "ادفع بالفاتورة (F11)";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnPay
            // 
            btnPay.Anchor = AnchorStyles.None;
            btnPay.FlatAppearance.MouseOverBackColor = Color.PaleGreen;
            btnPay.FlatStyle = FlatStyle.Flat;
            btnPay.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPay.Image = (Image)resources.GetObject("btnPay.Image");
            btnPay.ImageAlign = ContentAlignment.TopCenter;
            btnPay.ImeMode = ImeMode.NoControl;
            btnPay.Location = new Point(414, 23);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(97, 75);
            btnPay.TabIndex = 31;
            btnPay.Text = "ادفع (F12)";
            btnPay.TextAlign = ContentAlignment.BottomCenter;
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // btnDeleteSelected
            // 
            btnDeleteSelected.Anchor = AnchorStyles.None;
            btnDeleteSelected.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnDeleteSelected.FlatStyle = FlatStyle.Flat;
            btnDeleteSelected.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnDeleteSelected.Image = (Image)resources.GetObject("btnDeleteSelected.Image");
            btnDeleteSelected.ImageAlign = ContentAlignment.TopCenter;
            btnDeleteSelected.ImeMode = ImeMode.NoControl;
            btnDeleteSelected.Location = new Point(335, 24);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(73, 76);
            btnDeleteSelected.TabIndex = 30;
            btnDeleteSelected.Text = "حذف (Crtl+S)";
            btnDeleteSelected.TextAlign = ContentAlignment.BottomCenter;
            btnDeleteSelected.UseVisualStyleBackColor = true;
            btnDeleteSelected.Click += btnDeleteSelected_Click;
            // 
            // btnEditSelected
            // 
            btnEditSelected.Anchor = AnchorStyles.None;
            btnEditSelected.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            btnEditSelected.FlatStyle = FlatStyle.Flat;
            btnEditSelected.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnEditSelected.Image = (Image)resources.GetObject("btnEditSelected.Image");
            btnEditSelected.ImageAlign = ContentAlignment.TopCenter;
            btnEditSelected.ImeMode = ImeMode.NoControl;
            btnEditSelected.Location = new Point(201, 24);
            btnEditSelected.Name = "btnEditSelected";
            btnEditSelected.Size = new Size(73, 76);
            btnEditSelected.TabIndex = 28;
            btnEditSelected.Text = "تعديل (Crtl+E)";
            btnEditSelected.TextAlign = ContentAlignment.BottomCenter;
            btnEditSelected.UseVisualStyleBackColor = true;
            btnEditSelected.Click += btnEditSelected_Click;
            // 
            // btnDown
            // 
            btnDown.Anchor = AnchorStyles.None;
            btnDown.Image = (Image)resources.GetObject("btnDown.Image");
            btnDown.ImeMode = ImeMode.NoControl;
            btnDown.Location = new Point(280, 62);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(50, 34);
            btnDown.TabIndex = 26;
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // btnUp
            // 
            btnUp.Anchor = AnchorStyles.None;
            btnUp.Image = (Image)resources.GetObject("btnUp.Image");
            btnUp.ImeMode = ImeMode.NoControl;
            btnUp.Location = new Point(280, 25);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(50, 34);
            btnUp.TabIndex = 23;
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // gpSearchAvailable
            // 
            gpSearchAvailable.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            gpSearchAvailable.Controls.Add(btnPrices);
            gpSearchAvailable.Controls.Add(label5);
            gpSearchAvailable.Controls.Add(lblBarCode);
            gpSearchAvailable.Controls.Add(txtSearchBarCode);
            gpSearchAvailable.Controls.Add(btnSearchImage);
            gpSearchAvailable.Font = new Font("Calibri", 12F, FontStyle.Bold);
            gpSearchAvailable.Location = new Point(557, 2);
            gpSearchAvailable.Margin = new Padding(0);
            gpSearchAvailable.Name = "gpSearchAvailable";
            gpSearchAvailable.Size = new Size(485, 111);
            gpSearchAvailable.TabIndex = 18;
            gpSearchAvailable.TabStop = false;
            gpSearchAvailable.Text = "عمليات البحث المتاحة";
            // 
            // btnPrices
            // 
            btnPrices.Anchor = AnchorStyles.None;
            btnPrices.BackColor = Color.SeaGreen;
            btnPrices.FlatStyle = FlatStyle.Flat;
            btnPrices.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrices.ImageAlign = ContentAlignment.TopCenter;
            btnPrices.ImeMode = ImeMode.NoControl;
            btnPrices.Location = new Point(14, 30);
            btnPrices.Name = "btnPrices";
            btnPrices.Size = new Size(112, 60);
            btnPrices.TabIndex = 32;
            btnPrices.Text = "سعر 1 (F7)";
            btnPrices.UseVisualStyleBackColor = false;
            btnPrices.Click += btnPrices_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(386, 76);
            label5.Name = "label5";
            label5.Size = new Size(93, 19);
            label5.TabIndex = 28;
            label5.Text = "البحث السريع:";
            // 
            // lblBarCode
            // 
            lblBarCode.AutoSize = true;
            lblBarCode.ImeMode = ImeMode.NoControl;
            lblBarCode.Location = new Point(433, 30);
            lblBarCode.Name = "lblBarCode";
            lblBarCode.Size = new Size(46, 19);
            lblBarCode.TabIndex = 19;
            lblBarCode.Text = "باركود:";
            // 
            // txtSearchBarCode
            // 
            txtSearchBarCode.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearchBarCode.Location = new Point(132, 21);
            txtSearchBarCode.Multiline = true;
            txtSearchBarCode.Name = "txtSearchBarCode";
            txtSearchBarCode.PlaceholderText = "ادخل الباركود";
            txtSearchBarCode.Size = new Size(248, 36);
            txtSearchBarCode.TabIndex = 1;
            txtSearchBarCode.TextAlign = HorizontalAlignment.Center;
            txtSearchBarCode.TextChanged += txtSearchBarCode_TextChanged;
            txtSearchBarCode.KeyDown += txtSearchBarCode_KeyDown;
            txtSearchBarCode.KeyPress += txtSearchBarCode_KeyPress;
            // 
            // btnSearchImage
            // 
            btnSearchImage.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearchImage.Image = (Image)resources.GetObject("btnSearchImage.Image");
            btnSearchImage.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearchImage.ImeMode = ImeMode.NoControl;
            btnSearchImage.Location = new Point(132, 62);
            btnSearchImage.Name = "btnSearchImage";
            btnSearchImage.Size = new Size(248, 40);
            btnSearchImage.TabIndex = 2;
            btnSearchImage.Text = "  ابحث في الجدول او في الصور (F9)";
            btnSearchImage.UseVisualStyleBackColor = true;
            btnSearchImage.Click += btnSearchImage_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.None;
            flowLayoutPanel2.Controls.Add(gpSearchAvailable);
            flowLayoutPanel2.Controls.Add(gbOperations);
            flowLayoutPanel2.Controls.Add(ModifiertableLayoutPanel);
            flowLayoutPanel2.Location = new Point(12, 0);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1042, 115);
            flowLayoutPanel2.TabIndex = 25;
            // 
            // ModifiertableLayoutPanel
            // 
            ModifiertableLayoutPanel.ColumnCount = 5;
            ModifiertableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 305F));
            ModifiertableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 191F));
            ModifiertableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 129F));
            ModifiertableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 193F));
            ModifiertableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
            ModifiertableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 137F));
            ModifiertableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
            ModifiertableLayoutPanel.Controls.Add(txtQty, 2, 1);
            ModifiertableLayoutPanel.Controls.Add(txtProductName, 0, 1);
            ModifiertableLayoutPanel.Controls.Add(lblProductName, 0, 0);
            ModifiertableLayoutPanel.Controls.Add(lblQuentity, 2, 0);
            ModifiertableLayoutPanel.Controls.Add(lblSalePrice, 1, 0);
            ModifiertableLayoutPanel.Controls.Add(txtSalePrice, 1, 1);
            ModifiertableLayoutPanel.Controls.Add(lblBuyPrice, 3, 0);
            ModifiertableLayoutPanel.Controls.Add(txtSaleDiscount, 3, 1);
            ModifiertableLayoutPanel.Controls.Add(lblTotalSale, 4, 0);
            ModifiertableLayoutPanel.Controls.Add(txtTotalSaleProduct, 4, 1);
            ModifiertableLayoutPanel.Dock = DockStyle.Top;
            ModifiertableLayoutPanel.Location = new Point(3, 118);
            ModifiertableLayoutPanel.Margin = new Padding(5, 3, 5, 3);
            ModifiertableLayoutPanel.Name = "ModifiertableLayoutPanel";
            ModifiertableLayoutPanel.RowCount = 2;
            ModifiertableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 44.927536F));
            ModifiertableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 55.072464F));
            ModifiertableLayoutPanel.Size = new Size(1034, 102);
            ModifiertableLayoutPanel.TabIndex = 25;
            // 
            // txtQty
            // 
            txtQty.Anchor = AnchorStyles.None;
            txtQty.Font = new Font("Calibri", 12F, FontStyle.Bold);
            txtQty.Location = new Point(412, 57);
            txtQty.Multiline = true;
            txtQty.Name = "txtQty";
            txtQty.PlaceholderText = "9999";
            txtQty.Size = new Size(123, 32);
            txtQty.TabIndex = 21;
            txtQty.TextAlign = HorizontalAlignment.Center;
            txtQty.KeyDown += txtQty_KeyDown;
            txtQty.KeyPress += txtQty_KeyPress;
            txtQty.KeyUp += txtQty_KeyUp;
            // 
            // txtProductName
            // 
            txtProductName.Anchor = AnchorStyles.None;
            txtProductName.Enabled = false;
            txtProductName.Font = new Font("Calibri", 12F, FontStyle.Bold);
            txtProductName.Location = new Point(739, 57);
            txtProductName.Margin = new Padding(3, 3, 5, 3);
            txtProductName.Multiline = true;
            txtProductName.Name = "txtProductName";
            txtProductName.PlaceholderText = "اسم المنتج";
            txtProductName.Size = new Size(288, 32);
            txtProductName.TabIndex = 19;
            txtProductName.TextAlign = HorizontalAlignment.Center;
            // 
            // lblProductName
            // 
            lblProductName.Anchor = AnchorStyles.None;
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblProductName.Location = new Point(847, 13);
            lblProductName.Margin = new Padding(3);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(70, 19);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "اسم المنتج";
            // 
            // lblQuentity
            // 
            lblQuentity.Anchor = AnchorStyles.None;
            lblQuentity.AutoSize = true;
            lblQuentity.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblQuentity.Location = new Point(453, 13);
            lblQuentity.Margin = new Padding(3);
            lblQuentity.Name = "lblQuentity";
            lblQuentity.Size = new Size(42, 19);
            lblQuentity.TabIndex = 3;
            lblQuentity.Text = "الكمية";
            // 
            // lblSalePrice
            // 
            lblSalePrice.Anchor = AnchorStyles.None;
            lblSalePrice.AutoSize = true;
            lblSalePrice.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblSalePrice.Location = new Point(602, 13);
            lblSalePrice.Margin = new Padding(3);
            lblSalePrice.Name = "lblSalePrice";
            lblSalePrice.Size = new Size(63, 19);
            lblSalePrice.TabIndex = 4;
            lblSalePrice.Text = "سعر البيع";
            // 
            // txtSalePrice
            // 
            txtSalePrice.Anchor = AnchorStyles.None;
            txtSalePrice.Enabled = false;
            txtSalePrice.Font = new Font("Calibri", 12F, FontStyle.Bold);
            txtSalePrice.Location = new Point(554, 57);
            txtSalePrice.Multiline = true;
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.PlaceholderText = "9999";
            txtSalePrice.Size = new Size(160, 32);
            txtSalePrice.TabIndex = 23;
            txtSalePrice.TextAlign = HorizontalAlignment.Center;
            txtSalePrice.KeyPress += txtQty_KeyPress;
            // 
            // lblBuyPrice
            // 
            lblBuyPrice.Anchor = AnchorStyles.None;
            lblBuyPrice.AutoSize = true;
            lblBuyPrice.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblBuyPrice.Location = new Point(276, 13);
            lblBuyPrice.Margin = new Padding(3);
            lblBuyPrice.Name = "lblBuyPrice";
            lblBuyPrice.Size = new Size(73, 19);
            lblBuyPrice.TabIndex = 2;
            lblBuyPrice.Text = "التخفيض%";
            // 
            // txtSaleDiscount
            // 
            txtSaleDiscount.Anchor = AnchorStyles.None;
            txtSaleDiscount.Enabled = false;
            txtSaleDiscount.Font = new Font("Calibri", 12F, FontStyle.Bold);
            txtSaleDiscount.Location = new Point(247, 57);
            txtSaleDiscount.Multiline = true;
            txtSaleDiscount.Name = "txtSaleDiscount";
            txtSaleDiscount.PlaceholderText = "9999";
            txtSaleDiscount.Size = new Size(131, 32);
            txtSaleDiscount.TabIndex = 20;
            txtSaleDiscount.TextAlign = HorizontalAlignment.Center;
            txtSaleDiscount.KeyPress += txtQty_KeyPress;
            // 
            // lblTotalSale
            // 
            lblTotalSale.Anchor = AnchorStyles.None;
            lblTotalSale.AutoSize = true;
            lblTotalSale.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblTotalSale.Location = new Point(72, 13);
            lblTotalSale.Margin = new Padding(3);
            lblTotalSale.Name = "lblTotalSale";
            lblTotalSale.Size = new Size(73, 19);
            lblTotalSale.TabIndex = 6;
            lblTotalSale.Text = "اجمالي البيع";
            // 
            // txtTotalSaleProduct
            // 
            txtTotalSaleProduct.Anchor = AnchorStyles.None;
            txtTotalSaleProduct.Font = new Font("Calibri", 12F, FontStyle.Bold);
            txtTotalSaleProduct.Location = new Point(34, 57);
            txtTotalSaleProduct.Multiline = true;
            txtTotalSaleProduct.Name = "txtTotalSaleProduct";
            txtTotalSaleProduct.PlaceholderText = "9999999999";
            txtTotalSaleProduct.Size = new Size(149, 32);
            txtTotalSaleProduct.TabIndex = 22;
            txtTotalSaleProduct.TextAlign = HorizontalAlignment.Center;
            txtTotalSaleProduct.KeyDown += txtTotalSaleProduct_KeyDown;
            txtTotalSaleProduct.KeyPress += txtTotalSaleProduct_KeyPress;
            txtTotalSaleProduct.KeyUp += txtTotalSaleProduct_KeyUp;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(flowLayoutPanel2, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.Location = new Point(0, 138);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 59.1623039F));
            tableLayoutPanel.Size = new Size(1066, 115);
            tableLayoutPanel.TabIndex = 26;
            // 
            // lblEmptyData
            // 
            lblEmptyData.Anchor = AnchorStyles.None;
            lblEmptyData.AutoSize = true;
            lblEmptyData.BackColor = Color.Transparent;
            lblEmptyData.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblEmptyData.ForeColor = Color.Crimson;
            lblEmptyData.ImeMode = ImeMode.NoControl;
            lblEmptyData.Location = new Point(499, 423);
            lblEmptyData.Name = "lblEmptyData";
            lblEmptyData.Size = new Size(133, 19);
            lblEmptyData.TabIndex = 28;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvِProducts
            // 
            DgvِProducts.AllowUserToAddRows = false;
            DgvِProducts.AllowUserToResizeColumns = false;
            DgvِProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvِProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvِProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvِProducts.BackgroundColor = Color.White;
            DgvِProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvِProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(137, 207, 240);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvِProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvِProducts.ColumnHeadersHeight = 40;
            DgvِProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(137, 207, 240);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvِProducts.DefaultCellStyle = dataGridViewCellStyle3;
            DgvِProducts.Dock = DockStyle.Fill;
            DgvِProducts.EnableHeadersVisualStyles = false;
            DgvِProducts.GridColor = SystemColors.ControlDark;
            DgvِProducts.Location = new Point(0, 253);
            DgvِProducts.MultiSelect = false;
            DgvِProducts.Name = "DgvِProducts";
            DgvِProducts.ReadOnly = true;
            DgvِProducts.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(137, 207, 240);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            DgvِProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DgvِProducts.RowHeadersVisible = false;
            DgvِProducts.RowHeadersWidth = 21;
            DgvِProducts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِProducts.RowsDefaultCellStyle = dataGridViewCellStyle5;
            DgvِProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvِProducts.Size = new Size(1066, 364);
            DgvِProducts.TabIndex = 29;
            DgvِProducts.RowsAdded += DgvِProducts_RowsAdded;
            DgvِProducts.RowsRemoved += DgvِProducts_RowsRemoved;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Tick += timer_Tick;
            // 
            // QuickPanel
            // 
            QuickPanel.Controls.Add(lblEmptyQuick);
            QuickPanel.Controls.Add(DgvQuickProducts);
            QuickPanel.Dock = DockStyle.Right;
            QuickPanel.Location = new Point(1066, 138);
            QuickPanel.Name = "QuickPanel";
            QuickPanel.Size = new Size(200, 479);
            QuickPanel.TabIndex = 36;
            // 
            // lblEmptyQuick
            // 
            lblEmptyQuick.Anchor = AnchorStyles.None;
            lblEmptyQuick.AutoSize = true;
            lblEmptyQuick.BackColor = Color.Transparent;
            lblEmptyQuick.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblEmptyQuick.ForeColor = Color.Crimson;
            lblEmptyQuick.ImeMode = ImeMode.NoControl;
            lblEmptyQuick.Location = new Point(43, 161);
            lblEmptyQuick.Name = "lblEmptyQuick";
            lblEmptyQuick.Size = new Size(133, 19);
            lblEmptyQuick.TabIndex = 29;
            lblEmptyQuick.Text = "لا توجد بيانات لعرضها";
            lblEmptyQuick.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyQuick.Visible = false;
            // 
            // DgvQuickProducts
            // 
            DgvQuickProducts.AllowUserToAddRows = false;
            DgvQuickProducts.AllowUserToResizeColumns = false;
            DgvQuickProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Font = new Font("Sakkal Majalla", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DgvQuickProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            DgvQuickProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvQuickProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvQuickProducts.BackgroundColor = Color.White;
            DgvQuickProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            DgvQuickProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            DgvQuickProducts.ColumnHeadersHeight = 30;
            DgvQuickProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            DgvQuickProducts.DefaultCellStyle = dataGridViewCellStyle8;
            DgvQuickProducts.Dock = DockStyle.Fill;
            DgvQuickProducts.EnableHeadersVisualStyles = false;
            DgvQuickProducts.GridColor = SystemColors.ControlDark;
            DgvQuickProducts.Location = new Point(0, 0);
            DgvQuickProducts.MultiSelect = false;
            DgvQuickProducts.Name = "DgvQuickProducts";
            DgvQuickProducts.ReadOnly = true;
            DgvQuickProducts.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvQuickProducts.RowHeadersVisible = false;
            DgvQuickProducts.RowHeadersWidth = 15;
            DgvQuickProducts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.Font = new Font("Sakkal Majalla", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DgvQuickProducts.RowsDefaultCellStyle = dataGridViewCellStyle9;
            DgvQuickProducts.RowTemplate.Height = 15;
            DgvQuickProducts.ScrollBars = ScrollBars.Vertical;
            DgvQuickProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvQuickProducts.Size = new Size(200, 479);
            DgvQuickProducts.TabIndex = 30;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(137, 207, 240);
            panel1.Controls.Add(panel5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1266, 138);
            panel1.TabIndex = 37;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = Color.FromArgb(137, 207, 240);
            panel5.Controls.Add(flowLayoutPanelCusotnmer);
            panel5.Controls.Add(flowLayoutPanel4);
            panel5.Controls.Add(pictureBox1);
            panel5.Controls.Add(flowLayoutPanelDates);
            panel5.Controls.Add(flowLayoutPanel3);
            panel5.Controls.Add(flowLayoutPanelComptoirePrice);
            panel5.Controls.Add(labelprice);
            panel5.Location = new Point(0, 1);
            panel5.Margin = new Padding(1);
            panel5.Name = "panel5";
            panel5.Size = new Size(1265, 136);
            panel5.TabIndex = 4;
            // 
            // flowLayoutPanelCusotnmer
            // 
            flowLayoutPanelCusotnmer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanelCusotnmer.AutoScroll = true;
            flowLayoutPanelCusotnmer.BackColor = Color.FromArgb(137, 207, 240);
            flowLayoutPanelCusotnmer.Controls.Add(label3);
            flowLayoutPanelCusotnmer.Controls.Add(lblCustomerName);
            flowLayoutPanelCusotnmer.Controls.Add(gbOperation);
            flowLayoutPanelCusotnmer.Controls.Add(IdCustomer);
            flowLayoutPanelCusotnmer.Location = new Point(908, 3);
            flowLayoutPanelCusotnmer.Name = "flowLayoutPanelCusotnmer";
            flowLayoutPanelCusotnmer.Size = new Size(214, 133);
            flowLayoutPanelCusotnmer.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(109, 5);
            label3.Margin = new Padding(5);
            label3.Name = "label3";
            label3.Padding = new Padding(3);
            label3.Size = new Size(100, 29);
            label3.TabIndex = 0;
            label3.Text = "اسم العميل :";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.BackColor = Color.Transparent;
            lblCustomerName.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerName.ForeColor = Color.SeaGreen;
            lblCustomerName.Location = new Point(18, 5);
            lblCustomerName.Margin = new Padding(5);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(81, 19);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "مشتري عادي";
            lblCustomerName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbOperation
            // 
            gbOperation.Controls.Add(rbRefund);
            gbOperation.Controls.Add(rbSale);
            gbOperation.Location = new Point(47, 42);
            gbOperation.Name = "gbOperation";
            gbOperation.Size = new Size(164, 67);
            gbOperation.TabIndex = 32;
            gbOperation.TabStop = false;
            gbOperation.Text = "نوع العميلة";
            // 
            // rbRefund
            // 
            rbRefund.AutoSize = true;
            rbRefund.Location = new Point(57, 42);
            rbRefund.Name = "rbRefund";
            rbRefund.Size = new Size(103, 23);
            rbRefund.TabIndex = 1;
            rbRefund.Text = "ارجاع منتجات";
            rbRefund.UseVisualStyleBackColor = true;
            rbRefund.CheckedChanged += rbRefund_CheckedChanged_1;
            // 
            // rbSale
            // 
            rbSale.AutoSize = true;
            rbSale.Checked = true;
            rbSale.Location = new Point(69, 17);
            rbSale.Name = "rbSale";
            rbSale.Size = new Size(91, 23);
            rbSale.TabIndex = 0;
            rbSale.TabStop = true;
            rbSale.Text = "بيع منتجات";
            rbSale.UseVisualStyleBackColor = true;
            rbSale.CheckedChanged += rbSale_CheckedChanged_1;
            // 
            // IdCustomer
            // 
            IdCustomer.AutoSize = true;
            IdCustomer.BackColor = Color.Transparent;
            IdCustomer.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IdCustomer.ForeColor = Color.SeaGreen;
            IdCustomer.Location = new Point(21, 42);
            IdCustomer.Margin = new Padding(3);
            IdCustomer.Name = "IdCustomer";
            IdCustomer.Size = new Size(20, 23);
            IdCustomer.TabIndex = 2;
            IdCustomer.Text = "4";
            IdCustomer.TextAlign = ContentAlignment.MiddleRight;
            IdCustomer.Visible = false;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.BackColor = Color.FromArgb(137, 207, 240);
            flowLayoutPanel4.Controls.Add(lblqtyshow);
            flowLayoutPanel4.Controls.Add(lblQuentityValue);
            flowLayoutPanel4.Controls.Add(labelproductintable);
            flowLayoutPanel4.Controls.Add(lblProductIntable);
            flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel4.Location = new Point(129, 6);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(162, 106);
            flowLayoutPanel4.TabIndex = 35;
            // 
            // lblqtyshow
            // 
            lblqtyshow.AutoSize = true;
            lblqtyshow.BackColor = Color.Transparent;
            lblqtyshow.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblqtyshow.ForeColor = SystemColors.ControlText;
            lblqtyshow.Location = new Point(48, 0);
            lblqtyshow.Name = "lblqtyshow";
            lblqtyshow.Size = new Size(111, 19);
            lblqtyshow.TabIndex = 3;
            lblqtyshow.Text = "الكميات في الجدول";
            // 
            // lblQuentityValue
            // 
            lblQuentityValue.AutoSize = true;
            lblQuentityValue.BackColor = Color.Transparent;
            lblQuentityValue.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuentityValue.ForeColor = Color.SeaGreen;
            lblQuentityValue.Location = new Point(139, 19);
            lblQuentityValue.Name = "lblQuentityValue";
            lblQuentityValue.Size = new Size(20, 23);
            lblQuentityValue.TabIndex = 4;
            lblQuentityValue.Text = "0";
            lblQuentityValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelproductintable
            // 
            labelproductintable.AutoSize = true;
            labelproductintable.BackColor = Color.Transparent;
            labelproductintable.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelproductintable.ForeColor = SystemColors.ControlText;
            labelproductintable.Location = new Point(11, 42);
            labelproductintable.Name = "labelproductintable";
            labelproductintable.Size = new Size(148, 19);
            labelproductintable.TabIndex = 3;
            labelproductintable.Text = "عدد المنتجات في الجدول";
            // 
            // lblProductIntable
            // 
            lblProductIntable.AutoSize = true;
            lblProductIntable.BackColor = Color.Transparent;
            lblProductIntable.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductIntable.ForeColor = Color.SeaGreen;
            lblProductIntable.Location = new Point(139, 61);
            lblProductIntable.Name = "lblProductIntable";
            lblProductIntable.Size = new Size(20, 23);
            lblProductIntable.TabIndex = 4;
            lblProductIntable.Text = "0";
            lblProductIntable.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(378, 53);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(115, 68);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanelDates
            // 
            flowLayoutPanelDates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanelDates.BackColor = Color.FromArgb(137, 207, 240);
            flowLayoutPanelDates.Controls.Add(label1);
            flowLayoutPanelDates.Controls.Add(lblFactureNumber);
            flowLayoutPanelDates.Controls.Add(label4);
            flowLayoutPanelDates.Controls.Add(lblDatetime);
            flowLayoutPanelDates.Controls.Add(label6);
            flowLayoutPanelDates.Controls.Add(lblHour);
            flowLayoutPanelDates.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelDates.Location = new Point(1125, 2);
            flowLayoutPanelDates.Name = "flowLayoutPanelDates";
            flowLayoutPanelDates.Size = new Size(137, 129);
            flowLayoutPanelDates.TabIndex = 33;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(61, 0);
            label1.Name = "label1";
            label1.Size = new Size(73, 19);
            label1.TabIndex = 0;
            label1.Text = "رقم الفاتورة";
            // 
            // lblFactureNumber
            // 
            lblFactureNumber.AutoSize = true;
            lblFactureNumber.BackColor = Color.Transparent;
            lblFactureNumber.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFactureNumber.ForeColor = Color.SeaGreen;
            lblFactureNumber.Location = new Point(34, 19);
            lblFactureNumber.Name = "lblFactureNumber";
            lblFactureNumber.Size = new Size(100, 23);
            lblFactureNumber.TabIndex = 1;
            lblFactureNumber.Text = "000000001";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(52, 42);
            label4.Name = "label4";
            label4.Size = new Size(82, 19);
            label4.TabIndex = 0;
            label4.Text = "تاريخ اليوم   ";
            // 
            // lblDatetime
            // 
            lblDatetime.AutoSize = true;
            lblDatetime.BackColor = Color.Transparent;
            lblDatetime.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatetime.ForeColor = Color.SeaGreen;
            lblDatetime.Location = new Point(48, 61);
            lblDatetime.Name = "lblDatetime";
            lblDatetime.Size = new Size(86, 23);
            lblDatetime.TabIndex = 1;
            lblDatetime.Text = "9/3/2024";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlText;
            label6.Location = new Point(79, 84);
            label6.Name = "label6";
            label6.Size = new Size(55, 19);
            label6.TabIndex = 0;
            label6.Text = "الساعة  ";
            // 
            // lblHour
            // 
            lblHour.AutoSize = true;
            lblHour.BackColor = Color.Transparent;
            lblHour.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHour.ForeColor = Color.SeaGreen;
            lblHour.Location = new Point(79, 103);
            lblHour.Name = "lblHour";
            lblHour.Size = new Size(55, 23);
            lblHour.TabIndex = 1;
            lblHour.Text = "00:00";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.FromArgb(137, 207, 240);
            flowLayoutPanel3.Controls.Add(lblUserShow);
            flowLayoutPanel3.Controls.Add(lblUserName);
            flowLayoutPanel3.Controls.Add(lblSupportTech);
            flowLayoutPanel3.Controls.Add(lblSupportNumber);
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel3.Location = new Point(3, 6);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(120, 106);
            flowLayoutPanel3.TabIndex = 34;
            // 
            // lblUserShow
            // 
            lblUserShow.AutoSize = true;
            lblUserShow.BackColor = Color.Transparent;
            lblUserShow.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserShow.ForeColor = SystemColors.ControlText;
            lblUserShow.Location = new Point(25, 0);
            lblUserShow.Name = "lblUserShow";
            lblUserShow.Size = new Size(92, 19);
            lblUserShow.TabIndex = 0;
            lblUserShow.Text = "اسم المستخدم";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.BackColor = Color.Transparent;
            lblUserName.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.ForeColor = Color.SeaGreen;
            lblUserName.Location = new Point(55, 19);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(62, 23);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Admin";
            // 
            // lblSupportTech
            // 
            lblSupportTech.AutoSize = true;
            lblSupportTech.BackColor = Color.Transparent;
            lblSupportTech.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSupportTech.ForeColor = SystemColors.ControlText;
            lblSupportTech.Location = new Point(41, 42);
            lblSupportTech.Name = "lblSupportTech";
            lblSupportTech.Size = new Size(76, 19);
            lblSupportTech.TabIndex = 0;
            lblSupportTech.Text = "الدعم التقني";
            // 
            // lblSupportNumber
            // 
            lblSupportNumber.AutoSize = true;
            lblSupportNumber.BackColor = Color.Transparent;
            lblSupportNumber.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSupportNumber.ForeColor = Color.SeaGreen;
            lblSupportNumber.Location = new Point(7, 61);
            lblSupportNumber.Name = "lblSupportNumber";
            lblSupportNumber.Size = new Size(110, 23);
            lblSupportNumber.TabIndex = 1;
            lblSupportNumber.Text = "0697357307";
            // 
            // flowLayoutPanelComptoirePrice
            // 
            flowLayoutPanelComptoirePrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelComptoirePrice.BackColor = Color.FromArgb(137, 207, 240);
            flowLayoutPanelComptoirePrice.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelComptoirePrice.Controls.Add(lblValuePrice);
            flowLayoutPanelComptoirePrice.Controls.Add(lblCurrancy);
            flowLayoutPanelComptoirePrice.Location = new Point(373, 48);
            flowLayoutPanelComptoirePrice.Name = "flowLayoutPanelComptoirePrice";
            flowLayoutPanelComptoirePrice.Size = new Size(502, 80);
            flowLayoutPanelComptoirePrice.TabIndex = 33;
            // 
            // lblValuePrice
            // 
            lblValuePrice.AutoSize = true;
            lblValuePrice.BackColor = Color.FromArgb(137, 207, 240);
            lblValuePrice.Font = new Font("Calibri", 36F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblValuePrice.ForeColor = Color.SeaGreen;
            lblValuePrice.Location = new Point(159, 4);
            lblValuePrice.Margin = new Padding(4);
            lblValuePrice.Name = "lblValuePrice";
            lblValuePrice.Size = new Size(337, 59);
            lblValuePrice.TabIndex = 2;
            lblValuePrice.Text = "5090,9043,4534";
            lblValuePrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrancy
            // 
            lblCurrancy.AutoSize = true;
            lblCurrancy.BackColor = Color.Transparent;
            lblCurrancy.Font = new Font("Calibri", 36F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblCurrancy.ForeColor = Color.SeaGreen;
            lblCurrancy.Location = new Point(79, 4);
            lblCurrancy.Margin = new Padding(4);
            lblCurrancy.Name = "lblCurrancy";
            lblCurrancy.Size = new Size(72, 59);
            lblCurrancy.TabIndex = 2;
            lblCurrancy.Text = "دج";
            lblCurrancy.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelprice
            // 
            labelprice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelprice.AutoSize = true;
            labelprice.BackColor = Color.Transparent;
            labelprice.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelprice.ForeColor = SystemColors.ControlText;
            labelprice.Location = new Point(774, 3);
            labelprice.Name = "labelprice";
            labelprice.Size = new Size(101, 23);
            labelprice.TabIndex = 5;
            labelprice.Text = "الحسبة الكلية";
            labelprice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PanelPagination
            // 
            PanelPagination.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PanelPagination.Controls.Add(cmbpagination);
            PanelPagination.Controls.Add(btnPrev);
            PanelPagination.Controls.Add(btnNext);
            PanelPagination.Location = new Point(1066, 586);
            PanelPagination.Name = "PanelPagination";
            PanelPagination.Size = new Size(116, 28);
            PanelPagination.TabIndex = 31;
            // 
            // cmbpagination
            // 
            cmbpagination.Dock = DockStyle.Fill;
            cmbpagination.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbpagination.FormattingEnabled = true;
            cmbpagination.Location = new Point(31, 0);
            cmbpagination.Name = "cmbpagination";
            cmbpagination.Size = new Size(54, 37);
            cmbpagination.TabIndex = 28;
            cmbpagination.SelectionChangeCommitted += cmbpagination_SelectionChangeCommitted;
            // 
            // btnPrev
            // 
            btnPrev.Dock = DockStyle.Left;
            btnPrev.Image = (Image)resources.GetObject("btnPrev.Image");
            btnPrev.ImeMode = ImeMode.NoControl;
            btnPrev.Location = new Point(0, 0);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(31, 28);
            btnPrev.TabIndex = 26;
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Dock = DockStyle.Right;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.ImeMode = ImeMode.NoControl;
            btnNext.Location = new Point(85, 0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(31, 28);
            btnNext.TabIndex = 25;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // PosUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(PanelPagination);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvِProducts);
            Controls.Add(tableLayoutPanel);
            Controls.Add(QuickPanel);
            Controls.Add(panel1);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PosUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1266, 617);
            Load += PosUserControl_Load;
            KeyDown += PosUserControl_KeyDown;
            gbOperations.ResumeLayout(false);
            gpSearchAvailable.ResumeLayout(false);
            gpSearchAvailable.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ModifiertableLayoutPanel.ResumeLayout(false);
            ModifiertableLayoutPanel.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvِProducts).EndInit();
            QuickPanel.ResumeLayout(false);
            QuickPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvQuickProducts).EndInit();
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            flowLayoutPanelCusotnmer.ResumeLayout(false);
            flowLayoutPanelCusotnmer.PerformLayout();
            gbOperation.ResumeLayout(false);
            gbOperation.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanelDates.ResumeLayout(false);
            flowLayoutPanelDates.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanelComptoirePrice.ResumeLayout(false);
            flowLayoutPanelComptoirePrice.PerformLayout();
            PanelPagination.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnChoseCustomer;
        private GroupBox gbOperations;
        private Button btnDeleteSelected;
        private Button btnEditSelected;
        private Button btnDown;
        private Button btnUp;
        private GroupBox gpSearchAvailable;
        private Label label5;
        private Label lblBarCode;
        private TextBox txtSearchBarCode;
        private Button btnSearchImage;
        private FlowLayoutPanel flowLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel;
        private Label lblEmptyData;
        private DataGridView DgvِProducts;
        private Button btnPay;
        private TableLayoutPanel ModifiertableLayoutPanel;
        private Label lblProductName;
        private Label lblQuentity;
        private Label lblSalePrice;
        private Label lblBuyPrice;
        private TextBox txtQty;
        private TextBox txtProductName;
        private TextBox txtSalePrice;
        private TextBox txtSaleDiscount;
        private Label lblTotalSale;
        private TextBox txtTotalSaleProduct;
        private System.Windows.Forms.Timer timer;
        private Panel QuickPanel;
        private Label lblEmptyQuick;
        private DataGridView DgvQuickProducts;
        private Button button1;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanelCusotnmer;
        private Label label3;
        private Label lblCustomerName;
        private GroupBox gbOperation;
        private RadioButton rbRefund;
        private RadioButton rbSale;
        private Label IdCustomer;
        private FlowLayoutPanel flowLayoutPanelDates;
        private Label label1;
        private Label lblFactureNumber;
        private Label label4;
        private Label lblDatetime;
        private Label label6;
        private Label lblHour;
        private Panel panel5;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label lblqtyshow;
        private Label lblQuentityValue;
        private Label labelproductintable;
        private Label lblProductIntable;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label lblUserShow;
        private Label lblUserName;
        private Label lblSupportTech;
        private Label lblSupportNumber;
        private FlowLayoutPanel flowLayoutPanelComptoirePrice;
        private Label lblValuePrice;
        private Label lblCurrancy;
        private PictureBox pictureBox1;
        private Label labelprice;
        private Button btnPrices;
        private Panel PanelPagination;
        private ComboBox cmbpagination;
        private Button btnPrev;
        private Button btnNext;
    }
}
