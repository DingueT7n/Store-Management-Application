namespace Store.ApplicationUI.Gui.SalesGui.ProformaGui
{
    partial class ProformaUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProformaUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            NewProforma = new TabControl();
            tabPage1 = new TabPage();
            btnRefresh = new Button();
            lblEmptyData = new Label();
            DgvِProducts = new DataGridView();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            cbWholsale = new CheckBox();
            DtpDateFacture = new DateTimePicker();
            lblDateFacture = new Label();
            cmbCustomers = new ComboBox();
            lblSuppliers = new Label();
            lblFacture = new Label();
            txtFactureNumber = new TextBox();
            gpSearchAvailable = new GroupBox();
            label2 = new Label();
            lblBarCode = new Label();
            txtSearchBarCode = new TextBox();
            btnSearchImage = new Button();
            gbOperations = new GroupBox();
            btnPay = new Button();
            rbAnalysis = new RadioButton();
            rbPrinterDirectly = new RadioButton();
            btnDeleteSelected = new Button();
            btnEditSelected = new Button();
            btnDown = new Button();
            btnUp = new Button();
            tableLayoutPanel = new TableLayoutPanel();
            txtQty = new TextBox();
            txtProductName = new TextBox();
            lblProductName = new Label();
            lblQuentity = new Label();
            lblSalePrice = new Label();
            txtSalePrice = new TextBox();
            lblBuyPrice = new Label();
            txtSaleDiscount = new TextBox();
            lblWholesaleprice = new Label();
            lblTotalSale = new Label();
            txtWholeSalePrice = new TextBox();
            txtTotalSaleProduct = new TextBox();
            ProformaReports = new TabPage();
            PanelPagination = new Panel();
            cmbpagination = new ComboBox();
            btnPrev = new Button();
            btnNext = new Button();
            label1 = new Label();
            Dgv1 = new DataGridView();
            panelstatisticsandOperations = new Panel();
            button1 = new Button();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            lblTo = new Label();
            lblFrom = new Label();
            button2 = new Button();
            lblTitleForm = new Label();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            NewProforma.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِProducts).BeginInit();
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            gpSearchAvailable.SuspendLayout();
            gbOperations.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            ProformaReports.SuspendLayout();
            PanelPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv1).BeginInit();
            panelstatisticsandOperations.SuspendLayout();
            SearchPanel.SuspendLayout();
            SuspendLayout();
            // 
            // NewProforma
            // 
            NewProforma.Controls.Add(tabPage1);
            NewProforma.Controls.Add(ProformaReports);
            NewProforma.Dock = DockStyle.Fill;
            NewProforma.Location = new Point(0, 0);
            NewProforma.Name = "NewProforma";
            NewProforma.RightToLeftLayout = true;
            NewProforma.SelectedIndex = 0;
            NewProforma.Size = new Size(1034, 681);
            NewProforma.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(btnRefresh);
            tabPage1.Controls.Add(lblEmptyData);
            tabPage1.Controls.Add(DgvِProducts);
            tabPage1.Controls.Add(OperationsflowLayoutPanel);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1026, 649);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "اضافة نموذج جديد";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImeMode = ImeMode.NoControl;
            btnRefresh.Location = new Point(6, 603);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(50, 40);
            btnRefresh.TabIndex = 29;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblEmptyData
            // 
            lblEmptyData.Anchor = AnchorStyles.None;
            lblEmptyData.AutoSize = true;
            lblEmptyData.BackColor = Color.Transparent;
            lblEmptyData.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblEmptyData.ForeColor = Color.Crimson;
            lblEmptyData.ImeMode = ImeMode.NoControl;
            lblEmptyData.Location = new Point(451, 353);
            lblEmptyData.Name = "lblEmptyData";
            lblEmptyData.Size = new Size(133, 19);
            lblEmptyData.TabIndex = 27;
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
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvِProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvِProducts.ColumnHeadersHeight = 40;
            DgvِProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvِProducts.DefaultCellStyle = dataGridViewCellStyle3;
            DgvِProducts.Dock = DockStyle.Fill;
            DgvِProducts.EnableHeadersVisualStyles = false;
            DgvِProducts.GridColor = SystemColors.ControlDark;
            DgvِProducts.Location = new Point(3, 224);
            DgvِProducts.MultiSelect = false;
            DgvِProducts.Name = "DgvِProducts";
            DgvِProducts.ReadOnly = true;
            DgvِProducts.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvِProducts.RowHeadersVisible = false;
            DgvِProducts.RowHeadersWidth = 21;
            DgvِProducts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِProducts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvِProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvِProducts.Size = new Size(1020, 422);
            DgvِProducts.TabIndex = 28;
            DgvِProducts.CellDoubleClick += DgvِProducts_CellDoubleClick;
            DgvِProducts.RowsAdded += DgvِProducts_RowsAdded;
            DgvِProducts.RowsRemoved += DgvِProducts_RowsRemoved;
            DgvِProducts.KeyDown += DgvِProducts_KeyDown;
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(gbPayChoiches);
            OperationsflowLayoutPanel.Controls.Add(gpSearchAvailable);
            OperationsflowLayoutPanel.Controls.Add(gbOperations);
            OperationsflowLayoutPanel.Controls.Add(tableLayoutPanel);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(3, 3);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1020, 221);
            OperationsflowLayoutPanel.TabIndex = 14;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(cbWholsale);
            gbPayChoiches.Controls.Add(DtpDateFacture);
            gbPayChoiches.Controls.Add(lblDateFacture);
            gbPayChoiches.Controls.Add(cmbCustomers);
            gbPayChoiches.Controls.Add(lblSuppliers);
            gbPayChoiches.Controls.Add(lblFacture);
            gbPayChoiches.Controls.Add(txtFactureNumber);
            gbPayChoiches.Location = new Point(598, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(419, 137);
            gbPayChoiches.TabIndex = 8;
            gbPayChoiches.TabStop = false;
            gbPayChoiches.Text = "معلومات حول الفاتورة:";
            // 
            // cbWholsale
            // 
            cbWholsale.AutoSize = true;
            cbWholsale.Location = new Point(30, 30);
            cbWholsale.Name = "cbWholsale";
            cbWholsale.Size = new Size(116, 23);
            cbWholsale.TabIndex = 28;
            cbWholsale.Text = "بيع بسعر الجملة";
            cbWholsale.UseVisualStyleBackColor = true;
            // 
            // DtpDateFacture
            // 
            DtpDateFacture.CustomFormat = "yyyy-MM-dd";
            DtpDateFacture.Format = DateTimePickerFormat.Short;
            DtpDateFacture.Location = new Point(152, 100);
            DtpDateFacture.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            DtpDateFacture.Name = "DtpDateFacture";
            DtpDateFacture.Size = new Size(120, 27);
            DtpDateFacture.TabIndex = 26;
            DtpDateFacture.Value = new DateTime(2024, 8, 27, 0, 0, 0, 0);
            // 
            // lblDateFacture
            // 
            lblDateFacture.AutoSize = true;
            lblDateFacture.ImeMode = ImeMode.NoControl;
            lblDateFacture.Location = new Point(325, 106);
            lblDateFacture.Name = "lblDateFacture";
            lblDateFacture.Size = new Size(87, 19);
            lblDateFacture.TabIndex = 14;
            lblDateFacture.Text = "تاريخ الفاتورة:";
            // 
            // cmbCustomers
            // 
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(152, 65);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(181, 27);
            cmbCustomers.TabIndex = 11;
            cmbCustomers.Text = "اختر العميل";
            // 
            // lblSuppliers
            // 
            lblSuppliers.AutoSize = true;
            lblSuppliers.ImeMode = ImeMode.NoControl;
            lblSuppliers.Location = new Point(365, 68);
            lblSuppliers.Name = "lblSuppliers";
            lblSuppliers.Size = new Size(48, 19);
            lblSuppliers.TabIndex = 10;
            lblSuppliers.Text = "العميل:";
            // 
            // lblFacture
            // 
            lblFacture.AutoSize = true;
            lblFacture.ImeMode = ImeMode.NoControl;
            lblFacture.Location = new Point(340, 28);
            lblFacture.Name = "lblFacture";
            lblFacture.Size = new Size(76, 19);
            lblFacture.TabIndex = 9;
            lblFacture.Text = "رقم الفاتورة:";
            // 
            // txtFactureNumber
            // 
            txtFactureNumber.Location = new Point(152, 26);
            txtFactureNumber.Name = "txtFactureNumber";
            txtFactureNumber.PlaceholderText = "ادخل رقم الفاتورة";
            txtFactureNumber.Size = new Size(181, 27);
            txtFactureNumber.TabIndex = 7;
            txtFactureNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // gpSearchAvailable
            // 
            gpSearchAvailable.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            gpSearchAvailable.Controls.Add(label2);
            gpSearchAvailable.Controls.Add(lblBarCode);
            gpSearchAvailable.Controls.Add(txtSearchBarCode);
            gpSearchAvailable.Controls.Add(btnSearchImage);
            gpSearchAvailable.Location = new Point(284, 3);
            gpSearchAvailable.Name = "gpSearchAvailable";
            gpSearchAvailable.Size = new Size(308, 137);
            gpSearchAvailable.TabIndex = 17;
            gpSearchAvailable.TabStop = false;
            gpSearchAvailable.Text = "عمليات البحث المتاحة";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(212, 84);
            label2.Name = "label2";
            label2.Size = new Size(90, 19);
            label2.TabIndex = 28;
            label2.Text = "البحث السريع:";
            // 
            // lblBarCode
            // 
            lblBarCode.AutoSize = true;
            lblBarCode.ImeMode = ImeMode.NoControl;
            lblBarCode.Location = new Point(259, 37);
            lblBarCode.Name = "lblBarCode";
            lblBarCode.Size = new Size(45, 19);
            lblBarCode.TabIndex = 19;
            lblBarCode.Text = "باركود:";
            // 
            // txtSearchBarCode
            // 
            txtSearchBarCode.Font = new Font("Calibri", 12F);
            txtSearchBarCode.Location = new Point(4, 28);
            txtSearchBarCode.Multiline = true;
            txtSearchBarCode.Name = "txtSearchBarCode";
            txtSearchBarCode.PlaceholderText = "ادخل الباركود";
            txtSearchBarCode.Size = new Size(206, 36);
            txtSearchBarCode.TabIndex = 18;
            txtSearchBarCode.TextAlign = HorizontalAlignment.Center;
            txtSearchBarCode.KeyDown += txtSearchBarCode_KeyDown;
            // 
            // btnSearchImage
            // 
            btnSearchImage.Image = (Image)resources.GetObject("btnSearchImage.Image");
            btnSearchImage.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearchImage.ImeMode = ImeMode.NoControl;
            btnSearchImage.Location = new Point(4, 70);
            btnSearchImage.Name = "btnSearchImage";
            btnSearchImage.Size = new Size(206, 40);
            btnSearchImage.TabIndex = 17;
            btnSearchImage.Text = "  ابحث في الجدول او في الصورF9";
            btnSearchImage.UseVisualStyleBackColor = true;
            btnSearchImage.Click += btnSearchImage_Click;
            // 
            // gbOperations
            // 
            gbOperations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbOperations.Controls.Add(btnPay);
            gbOperations.Controls.Add(rbAnalysis);
            gbOperations.Controls.Add(rbPrinterDirectly);
            gbOperations.Controls.Add(btnDeleteSelected);
            gbOperations.Controls.Add(btnEditSelected);
            gbOperations.Controls.Add(btnDown);
            gbOperations.Controls.Add(btnUp);
            gbOperations.Location = new Point(3, 3);
            gbOperations.Name = "gbOperations";
            gbOperations.Size = new Size(275, 137);
            gbOperations.TabIndex = 24;
            gbOperations.TabStop = false;
            gbOperations.Text = "العمليات المتاحة على الجدول";
            // 
            // btnPay
            // 
            btnPay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPay.Image = (Image)resources.GetObject("btnPay.Image");
            btnPay.ImageAlign = ContentAlignment.MiddleLeft;
            btnPay.ImeMode = ImeMode.NoControl;
            btnPay.Location = new Point(3, 91);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(152, 40);
            btnPay.TabIndex = 33;
            btnPay.Text = "اضافة النمودج F9";
            btnPay.TextAlign = ContentAlignment.MiddleRight;
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // rbAnalysis
            // 
            rbAnalysis.AutoSize = true;
            rbAnalysis.Location = new Point(3, 56);
            rbAnalysis.Name = "rbAnalysis";
            rbAnalysis.Size = new Size(114, 23);
            rbAnalysis.TabIndex = 32;
            rbAnalysis.Text = "معاينة ثم طباعة";
            rbAnalysis.UseVisualStyleBackColor = true;
            // 
            // rbPrinterDirectly
            // 
            rbPrinterDirectly.AutoSize = true;
            rbPrinterDirectly.Checked = true;
            rbPrinterDirectly.Location = new Point(18, 26);
            rbPrinterDirectly.Name = "rbPrinterDirectly";
            rbPrinterDirectly.Size = new Size(99, 23);
            rbPrinterDirectly.TabIndex = 31;
            rbPrinterDirectly.TabStop = true;
            rbPrinterDirectly.Text = "طباعة مباشرة";
            rbPrinterDirectly.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSelected
            // 
            btnDeleteSelected.Anchor = AnchorStyles.None;
            btnDeleteSelected.Image = (Image)resources.GetObject("btnDeleteSelected.Image");
            btnDeleteSelected.ImeMode = ImeMode.NoControl;
            btnDeleteSelected.Location = new Point(140, 46);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(37, 34);
            btnDeleteSelected.TabIndex = 30;
            btnDeleteSelected.Text = "       تصدير/طباعة جميع فاتورات المورد";
            btnDeleteSelected.UseVisualStyleBackColor = true;
            btnDeleteSelected.Click += btnDeleteSelected_Click;
            // 
            // btnEditSelected
            // 
            btnEditSelected.Anchor = AnchorStyles.None;
            btnEditSelected.Image = (Image)resources.GetObject("btnEditSelected.Image");
            btnEditSelected.ImeMode = ImeMode.NoControl;
            btnEditSelected.Location = new Point(228, 44);
            btnEditSelected.Name = "btnEditSelected";
            btnEditSelected.Size = new Size(37, 34);
            btnEditSelected.TabIndex = 28;
            btnEditSelected.Text = "       تصدير/طباعة جميع فاتورات المورد";
            btnEditSelected.UseVisualStyleBackColor = true;
            btnEditSelected.Click += btnEditSelected_Click;
            // 
            // btnDown
            // 
            btnDown.Anchor = AnchorStyles.None;
            btnDown.Image = (Image)resources.GetObject("btnDown.Image");
            btnDown.ImeMode = ImeMode.NoControl;
            btnDown.Location = new Point(183, 20);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(37, 34);
            btnDown.TabIndex = 26;
            btnDown.Text = "       تصدير/طباعة جميع فاتورات المورد";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // btnUp
            // 
            btnUp.Anchor = AnchorStyles.None;
            btnUp.Image = (Image)resources.GetObject("btnUp.Image");
            btnUp.ImeMode = ImeMode.NoControl;
            btnUp.Location = new Point(183, 60);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(37, 34);
            btnUp.TabIndex = 23;
            btnUp.Text = "       تصدير/طباعة جميع فاتورات المورد";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 6;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 257F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 166F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 144F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 142F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 156F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 137F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
            tableLayoutPanel.Controls.Add(txtQty, 2, 1);
            tableLayoutPanel.Controls.Add(txtProductName, 0, 1);
            tableLayoutPanel.Controls.Add(lblProductName, 0, 0);
            tableLayoutPanel.Controls.Add(lblQuentity, 2, 0);
            tableLayoutPanel.Controls.Add(lblSalePrice, 1, 0);
            tableLayoutPanel.Controls.Add(txtSalePrice, 1, 1);
            tableLayoutPanel.Controls.Add(lblBuyPrice, 3, 0);
            tableLayoutPanel.Controls.Add(txtSaleDiscount, 3, 1);
            tableLayoutPanel.Controls.Add(lblWholesaleprice, 4, 0);
            tableLayoutPanel.Controls.Add(lblTotalSale, 5, 0);
            tableLayoutPanel.Controls.Add(txtWholeSalePrice, 4, 1);
            tableLayoutPanel.Controls.Add(txtTotalSaleProduct, 5, 1);
            tableLayoutPanel.Location = new Point(5, 146);
            tableLayoutPanel.Margin = new Padding(5, 3, 5, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 44.927536F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 55.072464F));
            tableLayoutPanel.Size = new Size(1010, 69);
            tableLayoutPanel.TabIndex = 25;
            // 
            // txtQty
            // 
            txtQty.Anchor = AnchorStyles.None;
            txtQty.Font = new Font("Calibri", 12F);
            txtQty.Location = new Point(445, 34);
            txtQty.Multiline = true;
            txtQty.Name = "txtQty";
            txtQty.PlaceholderText = "9999";
            txtQty.Size = new Size(139, 32);
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
            txtProductName.Font = new Font("Calibri", 12F);
            txtProductName.Location = new Point(758, 34);
            txtProductName.Margin = new Padding(3, 3, 5, 3);
            txtProductName.Multiline = true;
            txtProductName.Name = "txtProductName";
            txtProductName.PlaceholderText = "اسم المنتج";
            txtProductName.Size = new Size(249, 32);
            txtProductName.TabIndex = 19;
            txtProductName.TextAlign = HorizontalAlignment.Center;
            // 
            // lblProductName
            // 
            lblProductName.Anchor = AnchorStyles.None;
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductName.Location = new Point(848, 6);
            lblProductName.Margin = new Padding(3);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(67, 19);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "اسم المنتج";
            // 
            // lblQuentity
            // 
            lblQuentity.Anchor = AnchorStyles.None;
            lblQuentity.AutoSize = true;
            lblQuentity.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuentity.Location = new Point(494, 6);
            lblQuentity.Margin = new Padding(3);
            lblQuentity.Name = "lblQuentity";
            lblQuentity.Size = new Size(41, 19);
            lblQuentity.TabIndex = 3;
            lblQuentity.Text = "الكمية";
            // 
            // lblSalePrice
            // 
            lblSalePrice.Anchor = AnchorStyles.None;
            lblSalePrice.AutoSize = true;
            lblSalePrice.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSalePrice.Location = new Point(640, 6);
            lblSalePrice.Margin = new Padding(3);
            lblSalePrice.Name = "lblSalePrice";
            lblSalePrice.Size = new Size(61, 19);
            lblSalePrice.TabIndex = 4;
            lblSalePrice.Text = "سعر البيع";
            // 
            // txtSalePrice
            // 
            txtSalePrice.Anchor = AnchorStyles.None;
            txtSalePrice.Enabled = false;
            txtSalePrice.Font = new Font("Calibri", 12F);
            txtSalePrice.Location = new Point(590, 34);
            txtSalePrice.Multiline = true;
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.PlaceholderText = "9999";
            txtSalePrice.Size = new Size(160, 32);
            txtSalePrice.TabIndex = 23;
            txtSalePrice.TextAlign = HorizontalAlignment.Center;
            txtSalePrice.KeyDown += txtSalePrice_KeyDown;
            txtSalePrice.KeyUp += txtSalePrice_KeyUp;
            // 
            // lblBuyPrice
            // 
            lblBuyPrice.Anchor = AnchorStyles.None;
            lblBuyPrice.AutoSize = true;
            lblBuyPrice.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuyPrice.Location = new Point(335, 6);
            lblBuyPrice.Margin = new Padding(3);
            lblBuyPrice.Name = "lblBuyPrice";
            lblBuyPrice.Size = new Size(71, 19);
            lblBuyPrice.TabIndex = 2;
            lblBuyPrice.Text = "التخفيض%";
            // 
            // txtSaleDiscount
            // 
            txtSaleDiscount.Anchor = AnchorStyles.None;
            txtSaleDiscount.Font = new Font("Calibri", 12F);
            txtSaleDiscount.Location = new Point(305, 34);
            txtSaleDiscount.Multiline = true;
            txtSaleDiscount.Name = "txtSaleDiscount";
            txtSaleDiscount.PlaceholderText = "9999";
            txtSaleDiscount.Size = new Size(131, 32);
            txtSaleDiscount.TabIndex = 20;
            txtSaleDiscount.TextAlign = HorizontalAlignment.Center;
            // 
            // lblWholesaleprice
            // 
            lblWholesaleprice.Anchor = AnchorStyles.None;
            lblWholesaleprice.AutoSize = true;
            lblWholesaleprice.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWholesaleprice.Location = new Point(181, 6);
            lblWholesaleprice.Margin = new Padding(3);
            lblWholesaleprice.Name = "lblWholesaleprice";
            lblWholesaleprice.Size = new Size(93, 19);
            lblWholesaleprice.TabIndex = 5;
            lblWholesaleprice.Text = "سعر البيع جملة";
            // 
            // lblTotalSale
            // 
            lblTotalSale.Anchor = AnchorStyles.None;
            lblTotalSale.AutoSize = true;
            lblTotalSale.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalSale.Location = new Point(42, 6);
            lblTotalSale.Margin = new Padding(3);
            lblTotalSale.Name = "lblTotalSale";
            lblTotalSale.Size = new Size(73, 19);
            lblTotalSale.TabIndex = 6;
            lblTotalSale.Text = "اجمالي البيع";
            // 
            // txtWholeSalePrice
            // 
            txtWholeSalePrice.Anchor = AnchorStyles.Right;
            txtWholeSalePrice.Font = new Font("Calibri", 12F);
            txtWholeSalePrice.Location = new Point(159, 34);
            txtWholeSalePrice.Multiline = true;
            txtWholeSalePrice.Name = "txtWholeSalePrice";
            txtWholeSalePrice.PlaceholderText = "9999";
            txtWholeSalePrice.Size = new Size(136, 32);
            txtWholeSalePrice.TabIndex = 24;
            txtWholeSalePrice.TextAlign = HorizontalAlignment.Center;
            // 
            // txtTotalSaleProduct
            // 
            txtTotalSaleProduct.Anchor = AnchorStyles.None;
            txtTotalSaleProduct.Enabled = false;
            txtTotalSaleProduct.Font = new Font("Calibri", 12F);
            txtTotalSaleProduct.Location = new Point(4, 34);
            txtTotalSaleProduct.Multiline = true;
            txtTotalSaleProduct.Name = "txtTotalSaleProduct";
            txtTotalSaleProduct.PlaceholderText = "9999999999";
            txtTotalSaleProduct.Size = new Size(149, 32);
            txtTotalSaleProduct.TabIndex = 22;
            txtTotalSaleProduct.TextAlign = HorizontalAlignment.Center;
            // 
            // ProformaReports
            // 
            ProformaReports.BackColor = Color.White;
            ProformaReports.Controls.Add(PanelPagination);
            ProformaReports.Controls.Add(label1);
            ProformaReports.Controls.Add(Dgv1);
            ProformaReports.Controls.Add(panelstatisticsandOperations);
            ProformaReports.Location = new Point(4, 28);
            ProformaReports.Name = "ProformaReports";
            ProformaReports.Padding = new Padding(3);
            ProformaReports.Size = new Size(1026, 649);
            ProformaReports.TabIndex = 1;
            ProformaReports.Text = "تقرير عن جميع النماذج";
            // 
            // PanelPagination
            // 
            PanelPagination.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelPagination.Controls.Add(cmbpagination);
            PanelPagination.Controls.Add(btnPrev);
            PanelPagination.Controls.Add(btnNext);
            PanelPagination.Location = new Point(6, 603);
            PanelPagination.Name = "PanelPagination";
            PanelPagination.Size = new Size(169, 40);
            PanelPagination.TabIndex = 41;
            // 
            // cmbpagination
            // 
            cmbpagination.Dock = DockStyle.Fill;
            cmbpagination.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbpagination.FormattingEnabled = true;
            cmbpagination.Location = new Point(50, 0);
            cmbpagination.Name = "cmbpagination";
            cmbpagination.Size = new Size(69, 37);
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
            btnPrev.Size = new Size(50, 40);
            btnPrev.TabIndex = 26;
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Dock = DockStyle.Right;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.ImeMode = ImeMode.NoControl;
            btnNext.Location = new Point(119, 0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(50, 40);
            btnNext.TabIndex = 25;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Crimson;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(451, 353);
            label1.Name = "label1";
            label1.Size = new Size(133, 19);
            label1.TabIndex = 39;
            label1.Text = "لا توجد بيانات لعرضها";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Visible = false;
            // 
            // Dgv1
            // 
            Dgv1.AllowUserToAddRows = false;
            Dgv1.AllowUserToResizeColumns = false;
            Dgv1.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            Dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            Dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Dgv1.BackgroundColor = Color.White;
            Dgv1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            Dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            Dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            Dgv1.ColumnHeadersHeight = 40;
            Dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            Dgv1.DefaultCellStyle = dataGridViewCellStyle7;
            Dgv1.Dock = DockStyle.Fill;
            Dgv1.EnableHeadersVisualStyles = false;
            Dgv1.GridColor = SystemColors.ControlDark;
            Dgv1.Location = new Point(3, 123);
            Dgv1.MultiSelect = false;
            Dgv1.Name = "Dgv1";
            Dgv1.ReadOnly = true;
            Dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Dgv1.RowHeadersVisible = false;
            Dgv1.RowHeadersWidth = 21;
            Dgv1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            Dgv1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            Dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv1.Size = new Size(1020, 523);
            Dgv1.TabIndex = 40;
            // 
            // panelstatisticsandOperations
            // 
            panelstatisticsandOperations.Controls.Add(button1);
            panelstatisticsandOperations.Controls.Add(dtpFrom);
            panelstatisticsandOperations.Controls.Add(dtpTo);
            panelstatisticsandOperations.Controls.Add(lblTo);
            panelstatisticsandOperations.Controls.Add(lblFrom);
            panelstatisticsandOperations.Controls.Add(button2);
            panelstatisticsandOperations.Controls.Add(lblTitleForm);
            panelstatisticsandOperations.Controls.Add(SearchPanel);
            panelstatisticsandOperations.Dock = DockStyle.Top;
            panelstatisticsandOperations.Location = new Point(3, 3);
            panelstatisticsandOperations.Name = "panelstatisticsandOperations";
            panelstatisticsandOperations.Size = new Size(1020, 120);
            panelstatisticsandOperations.TabIndex = 11;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.ImeMode = ImeMode.NoControl;
            button1.Location = new Point(32, 61);
            button1.Name = "button1";
            button1.Size = new Size(225, 40);
            button1.TabIndex = 38;
            button1.Text = "معاينة النموذج المحدد";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(865, 34);
            dtpFrom.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(119, 27);
            dtpFrom.TabIndex = 37;
            dtpFrom.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpTo.CustomFormat = "yyyy-MM-dd";
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(703, 34);
            dtpTo.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(119, 27);
            dtpTo.TabIndex = 36;
            dtpTo.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // lblTo
            // 
            lblTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTo.AutoSize = true;
            lblTo.ImeMode = ImeMode.NoControl;
            lblTo.Location = new Point(828, 36);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(27, 19);
            lblTo.TabIndex = 35;
            lblTo.Text = "الى:";
            // 
            // lblFrom
            // 
            lblFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFrom.AutoSize = true;
            lblFrom.ImeMode = ImeMode.NoControl;
            lblFrom.Location = new Point(985, 37);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(28, 19);
            lblFrom.TabIndex = 34;
            lblFrom.Text = "من:";
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.ImeMode = ImeMode.NoControl;
            button2.Location = new Point(32, 15);
            button2.Name = "button2";
            button2.Size = new Size(225, 40);
            button2.TabIndex = 14;
            button2.Text = "حذف جميع بيانات الجدول";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // lblTitleForm
            // 
            lblTitleForm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitleForm.AutoSize = true;
            lblTitleForm.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleForm.ForeColor = Color.Red;
            lblTitleForm.ImeMode = ImeMode.NoControl;
            lblTitleForm.Location = new Point(421, 0);
            lblTitleForm.Margin = new Padding(3);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(147, 23);
            lblTitleForm.TabIndex = 13;
            lblTitleForm.Text = "تقرير حالات الصناديق";
            // 
            // SearchPanel
            // 
            SearchPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchPanel.Controls.Add(txtSearch);
            SearchPanel.Controls.Add(btnSearch);
            SearchPanel.Location = new Point(387, 29);
            SearchPanel.Name = "SearchPanel";
            SearchPanel.Size = new Size(294, 40);
            SearchPanel.TabIndex = 8;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Calibri", 12F);
            txtSearch.Location = new Point(50, 0);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ادخل معلومة للبحث";
            txtSearch.Size = new Size(244, 40);
            txtSearch.TabIndex = 9;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSearch
            // 
            btnSearch.Dock = DockStyle.Left;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.ImeMode = ImeMode.NoControl;
            btnSearch.Location = new Point(0, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(50, 40);
            btnSearch.TabIndex = 7;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // ProformaUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(NewProforma);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProformaUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            KeyDown += ProformaUserControl_KeyDown;
            NewProforma.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِProducts).EndInit();
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            gbPayChoiches.PerformLayout();
            gpSearchAvailable.ResumeLayout(false);
            gpSearchAvailable.PerformLayout();
            gbOperations.ResumeLayout(false);
            gbOperations.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ProformaReports.ResumeLayout(false);
            ProformaReports.PerformLayout();
            PanelPagination.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Dgv1).EndInit();
            panelstatisticsandOperations.ResumeLayout(false);
            panelstatisticsandOperations.PerformLayout();
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl NewProforma;
        private TabPage tabPage1;
        private TabPage ProformaReports;
        private FlowLayoutPanel OperationsflowLayoutPanel;
        private GroupBox gbPayChoiches;
        private CheckBox cbWholsale;
        private DateTimePicker DtpDateFacture;
        private Label lblDateFacture;
        private ComboBox cmbCustomers;
        private Label lblSuppliers;
        private Label lblFacture;
        private TextBox txtFactureNumber;
        private GroupBox gpSearchAvailable;
        private Label label2;
        private Label lblBarCode;
        private TextBox txtSearchBarCode;
        private Button btnSearchImage;
        private GroupBox gbOperations;
        private RadioButton rbAnalysis;
        private RadioButton rbPrinterDirectly;
        private Button btnDeleteSelected;
        private Button btnEditSelected;
        private Button btnDown;
        private Button btnUp;
        private TableLayoutPanel tableLayoutPanel;
        private TextBox txtQty;
        private TextBox txtProductName;
        private Label lblProductName;
        private Label lblQuentity;
        private Label lblSalePrice;
        private TextBox txtSalePrice;
        private Label lblBuyPrice;
        private TextBox txtSaleDiscount;
        private Label lblWholesaleprice;
        private Label lblTotalSale;
        private TextBox txtWholeSalePrice;
        private TextBox txtTotalSaleProduct;
        private Button btnPay;
        private Label lblEmptyData;
        private DataGridView DgvِProducts;
        private Button btnRefresh;
        private Panel panelstatisticsandOperations;
        private Label lblTitleForm;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel PanelPagination;
        private ComboBox cmbpagination;
        private Button btnPrev;
        private Button btnNext;
        private Label label1;
        private DataGridView Dgv1;
        private Button button2;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label lblTo;
        private Label lblFrom;
        private Button button1;
    }
}
