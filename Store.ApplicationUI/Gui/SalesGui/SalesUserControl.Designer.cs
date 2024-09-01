namespace Store.ApplicationUI.Gui.SalesGui
{
    partial class SalesUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            cbWholsale = new CheckBox();
            label1 = new Label();
            DtpDateFacture = new DateTimePicker();
            lblDateFacture = new Label();
            cmbStores = new ComboBox();
            cmbCustomers = new ComboBox();
            lblSuppliers = new Label();
            lblFacture = new Label();
            txtFactureNumber = new TextBox();
            panelstatisticsandOperations = new Panel();
            SearchPanel = new Panel();
            lblTitleForm = new Label();
            gpSearchAvailable = new GroupBox();
            label2 = new Label();
            lblBarCode = new Label();
            txtSearchBarCode = new TextBox();
            btnSearchImage = new Button();
            panelButtons = new Panel();
            gbOperations = new GroupBox();
            btnDeleteSelected = new Button();
            lblDelete = new Label();
            btnEditSelected = new Button();
            lblEdit = new Label();
            btnDown = new Button();
            lblDown = new Label();
            lblUp = new Label();
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
            flowLayoutPanelstatistics = new FlowLayoutPanel();
            gBPayOptions = new GroupBox();
            dtpReminderDate = new DateTimePicker();
            btnPay = new Button();
            lblReminderDate = new Label();
            rBPayDebt = new RadioButton();
            rBPayPartial = new RadioButton();
            rBPayCash = new RadioButton();
            panelStatistics = new Panel();
            ErrorsflowLayoutPanel = new FlowLayoutPanel();
            labelError1 = new Label();
            lblError2 = new Label();
            StatisticsflowLayoutPanel = new FlowLayoutPanel();
            lblTotalProductsInTable = new Label();
            lblTotalQuentity = new Label();
            lblTotalPriceinFacture = new Label();
            btnRefresh = new Button();
            lblEmptyData = new Label();
            DgvِProducts = new DataGridView();
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
            SearchPanel.SuspendLayout();
            gpSearchAvailable.SuspendLayout();
            panelButtons.SuspendLayout();
            gbOperations.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            flowLayoutPanelstatistics.SuspendLayout();
            gBPayOptions.SuspendLayout();
            panelStatistics.SuspendLayout();
            ErrorsflowLayoutPanel.SuspendLayout();
            StatisticsflowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِProducts).BeginInit();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(gbPayChoiches);
            OperationsflowLayoutPanel.Controls.Add(panelstatisticsandOperations);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1034, 146);
            OperationsflowLayoutPanel.TabIndex = 13;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(cbWholsale);
            gbPayChoiches.Controls.Add(label1);
            gbPayChoiches.Controls.Add(DtpDateFacture);
            gbPayChoiches.Controls.Add(lblDateFacture);
            gbPayChoiches.Controls.Add(cmbStores);
            gbPayChoiches.Controls.Add(cmbCustomers);
            gbPayChoiches.Controls.Add(lblSuppliers);
            gbPayChoiches.Controls.Add(lblFacture);
            gbPayChoiches.Controls.Add(txtFactureNumber);
            gbPayChoiches.Location = new Point(612, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(419, 137);
            gbPayChoiches.TabIndex = 8;
            gbPayChoiches.TabStop = false;
            gbPayChoiches.Text = "معلومات حول الفاتورة:";
            // 
            // cbWholsale
            // 
            cbWholsale.AutoSize = true;
            cbWholsale.Location = new Point(8, 102);
            cbWholsale.Name = "cbWholsale";
            cbWholsale.Size = new Size(116, 23);
            cbWholsale.TabIndex = 28;
            cbWholsale.Text = "بيع بسعر الجملة";
            cbWholsale.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(365, 106);
            label1.Name = "label1";
            label1.Size = new Size(51, 19);
            label1.TabIndex = 27;
            label1.Text = "المخزن:";
            // 
            // DtpDateFacture
            // 
            DtpDateFacture.CustomFormat = "yyyy-MM-dd";
            DtpDateFacture.Format = DateTimePickerFormat.Short;
            DtpDateFacture.Location = new Point(4, 65);
            DtpDateFacture.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            DtpDateFacture.Name = "DtpDateFacture";
            DtpDateFacture.Size = new Size(122, 27);
            DtpDateFacture.TabIndex = 26;
            DtpDateFacture.Value = new DateTime(2024, 8, 27, 0, 0, 0, 0);
            // 
            // lblDateFacture
            // 
            lblDateFacture.AutoSize = true;
            lblDateFacture.ImeMode = ImeMode.NoControl;
            lblDateFacture.Location = new Point(20, 28);
            lblDateFacture.Name = "lblDateFacture";
            lblDateFacture.Size = new Size(87, 19);
            lblDateFacture.TabIndex = 14;
            lblDateFacture.Text = "تاريخ الفاتورة:";
            // 
            // cmbStores
            // 
            cmbStores.FormattingEnabled = true;
            cmbStores.Location = new Point(152, 103);
            cmbStores.Name = "cmbStores";
            cmbStores.Size = new Size(181, 27);
            cmbStores.TabIndex = 13;
            cmbStores.Text = "اختر مخزن";
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
            txtFactureNumber.Enabled = false;
            txtFactureNumber.Location = new Point(152, 26);
            txtFactureNumber.Name = "txtFactureNumber";
            txtFactureNumber.PlaceholderText = "رقم الفاتورة";
            txtFactureNumber.Size = new Size(181, 27);
            txtFactureNumber.TabIndex = 7;
            txtFactureNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // panelstatisticsandOperations
            // 
            panelstatisticsandOperations.Controls.Add(SearchPanel);
            panelstatisticsandOperations.Controls.Add(panelButtons);
            panelstatisticsandOperations.Dock = DockStyle.Fill;
            panelstatisticsandOperations.Location = new Point(5, 3);
            panelstatisticsandOperations.Name = "panelstatisticsandOperations";
            panelstatisticsandOperations.Size = new Size(601, 137);
            panelstatisticsandOperations.TabIndex = 10;
            // 
            // SearchPanel
            // 
            SearchPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchPanel.Controls.Add(lblTitleForm);
            SearchPanel.Controls.Add(gpSearchAvailable);
            SearchPanel.Location = new Point(292, 3);
            SearchPanel.Name = "SearchPanel";
            SearchPanel.Size = new Size(710, 134);
            SearchPanel.TabIndex = 8;
            // 
            // lblTitleForm
            // 
            lblTitleForm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitleForm.AutoSize = true;
            lblTitleForm.Font = new Font("Calibri", 14.25F);
            lblTitleForm.ForeColor = Color.Red;
            lblTitleForm.ImeMode = ImeMode.NoControl;
            lblTitleForm.Location = new Point(131, 0);
            lblTitleForm.Margin = new Padding(3);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(94, 23);
            lblTitleForm.TabIndex = 14;
            lblTitleForm.Text = "بيع المنتجات";
            // 
            // gpSearchAvailable
            // 
            gpSearchAvailable.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            gpSearchAvailable.Controls.Add(label2);
            gpSearchAvailable.Controls.Add(lblBarCode);
            gpSearchAvailable.Controls.Add(txtSearchBarCode);
            gpSearchAvailable.Controls.Add(btnSearchImage);
            gpSearchAvailable.Location = new Point(3, 19);
            gpSearchAvailable.Name = "gpSearchAvailable";
            gpSearchAvailable.Size = new Size(306, 115);
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
            txtSearchBarCode.KeyPress += txtSearchBarCode_KeyPress;
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
            btnSearchImage.Text = "  ابحث في الجدول او في الصور";
            btnSearchImage.UseVisualStyleBackColor = true;
            btnSearchImage.Click += btnSearchImage_Click;
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelButtons.Controls.Add(gbOperations);
            panelButtons.Location = new Point(8, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(679, 134);
            panelButtons.TabIndex = 9;
            // 
            // gbOperations
            // 
            gbOperations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbOperations.Controls.Add(btnDeleteSelected);
            gbOperations.Controls.Add(lblDelete);
            gbOperations.Controls.Add(btnEditSelected);
            gbOperations.Controls.Add(lblEdit);
            gbOperations.Controls.Add(btnDown);
            gbOperations.Controls.Add(lblDown);
            gbOperations.Controls.Add(lblUp);
            gbOperations.Controls.Add(btnUp);
            gbOperations.Location = new Point(3, 3);
            gbOperations.Name = "gbOperations";
            gbOperations.Size = new Size(275, 131);
            gbOperations.TabIndex = 23;
            gbOperations.TabStop = false;
            gbOperations.Text = "العمليات المتاحة على الجدول";
            // 
            // btnDeleteSelected
            // 
            btnDeleteSelected.Anchor = AnchorStyles.None;
            btnDeleteSelected.Image = (Image)resources.GetObject("btnDeleteSelected.Image");
            btnDeleteSelected.ImeMode = ImeMode.NoControl;
            btnDeleteSelected.Location = new Point(125, 83);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(37, 34);
            btnDeleteSelected.TabIndex = 30;
            btnDeleteSelected.Text = "       تصدير/طباعة جميع فاتورات المورد";
            btnDeleteSelected.UseVisualStyleBackColor = true;
            btnDeleteSelected.Click += btnDeleteSelected_Click;
            // 
            // lblDelete
            // 
            lblDelete.AutoSize = true;
            lblDelete.ImeMode = ImeMode.NoControl;
            lblDelete.Location = new Point(164, 97);
            lblDelete.Name = "lblDelete";
            lblDelete.Size = new Size(108, 19);
            lblDelete.TabIndex = 29;
            lblDelete.Text = "حذف من الجدول:";
            // 
            // btnEditSelected
            // 
            btnEditSelected.Anchor = AnchorStyles.None;
            btnEditSelected.Image = (Image)resources.GetObject("btnEditSelected.Image");
            btnEditSelected.ImeMode = ImeMode.NoControl;
            btnEditSelected.Location = new Point(125, 24);
            btnEditSelected.Name = "btnEditSelected";
            btnEditSelected.Size = new Size(37, 34);
            btnEditSelected.TabIndex = 28;
            btnEditSelected.Text = "       تصدير/طباعة جميع فاتورات المورد";
            btnEditSelected.UseVisualStyleBackColor = true;
            btnEditSelected.Click += btnEditSelected_Click;
            // 
            // lblEdit
            // 
            lblEdit.AutoSize = true;
            lblEdit.ImeMode = ImeMode.NoControl;
            lblEdit.Location = new Point(184, 38);
            lblEdit.Name = "lblEdit";
            lblEdit.Size = new Size(88, 19);
            lblEdit.TabIndex = 27;
            lblEdit.Text = "تعديل المحدد:";
            // 
            // btnDown
            // 
            btnDown.Anchor = AnchorStyles.None;
            btnDown.Image = (Image)resources.GetObject("btnDown.Image");
            btnDown.ImeMode = ImeMode.NoControl;
            btnDown.Location = new Point(10, 24);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(37, 34);
            btnDown.TabIndex = 26;
            btnDown.Text = "       تصدير/طباعة جميع فاتورات المورد";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // lblDown
            // 
            lblDown.AutoSize = true;
            lblDown.ImeMode = ImeMode.NoControl;
            lblDown.Location = new Point(50, 38);
            lblDown.Name = "lblDown";
            lblDown.Size = new Size(69, 19);
            lblDown.TabIndex = 25;
            lblDown.Text = "الى الاسفل:";
            // 
            // lblUp
            // 
            lblUp.AutoSize = true;
            lblUp.ImeMode = ImeMode.NoControl;
            lblUp.Location = new Point(57, 97);
            lblUp.Name = "lblUp";
            lblUp.Size = new Size(62, 19);
            lblUp.TabIndex = 24;
            lblUp.Text = "الى الفوق:";
            // 
            // btnUp
            // 
            btnUp.Anchor = AnchorStyles.None;
            btnUp.Image = (Image)resources.GetObject("btnUp.Image");
            btnUp.ImeMode = ImeMode.NoControl;
            btnUp.Location = new Point(10, 83);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(37, 34);
            btnUp.TabIndex = 23;
            btnUp.Text = "       تصدير/طباعة جميع فاتورات المورد";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 7;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 257F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 166F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 144F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 158F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
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
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.Location = new Point(0, 146);
            tableLayoutPanel.Margin = new Padding(5, 3, 5, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 44.927536F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 55.072464F));
            tableLayoutPanel.Size = new Size(1034, 69);
            tableLayoutPanel.TabIndex = 23;
            // 
            // txtQty
            // 
            txtQty.Anchor = AnchorStyles.None;
            txtQty.Font = new Font("Calibri", 12F);
            txtQty.Location = new Point(469, 34);
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
            txtProductName.Location = new Point(782, 34);
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
            lblProductName.Location = new Point(872, 6);
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
            lblQuentity.Location = new Point(518, 6);
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
            lblSalePrice.Location = new Point(664, 6);
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
            txtSalePrice.Location = new Point(614, 34);
            txtSalePrice.Multiline = true;
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.PlaceholderText = "9999";
            txtSalePrice.Size = new Size(160, 32);
            txtSalePrice.TabIndex = 23;
            txtSalePrice.TextAlign = HorizontalAlignment.Center;
            txtSalePrice.KeyDown += txtSalePrice_KeyDown;
            txtSalePrice.KeyPress += txtSalePrice_KeyPress;
            txtSalePrice.KeyUp += txtSalePrice_KeyUp;
            // 
            // lblBuyPrice
            // 
            lblBuyPrice.Anchor = AnchorStyles.None;
            lblBuyPrice.AutoSize = true;
            lblBuyPrice.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuyPrice.Location = new Point(359, 6);
            lblBuyPrice.Margin = new Padding(3);
            lblBuyPrice.Name = "lblBuyPrice";
            lblBuyPrice.Size = new Size(71, 19);
            lblBuyPrice.TabIndex = 2;
            lblBuyPrice.Text = "التخفيض%";
            // 
            // txtSaleDiscount
            // 
            txtSaleDiscount.Anchor = AnchorStyles.None;
            txtSaleDiscount.Enabled = false;
            txtSaleDiscount.Font = new Font("Calibri", 12F);
            txtSaleDiscount.Location = new Point(329, 34);
            txtSaleDiscount.Multiline = true;
            txtSaleDiscount.Name = "txtSaleDiscount";
            txtSaleDiscount.PlaceholderText = "9999";
            txtSaleDiscount.Size = new Size(131, 32);
            txtSaleDiscount.TabIndex = 20;
            txtSaleDiscount.TextAlign = HorizontalAlignment.Center;
            txtSaleDiscount.KeyDown += txtBuyPrice_KeyDown;
            txtSaleDiscount.KeyPress += txtBuyPrice_KeyPress;
            txtSaleDiscount.KeyUp += txtBuyPrice_KeyUp;
            // 
            // lblWholesaleprice
            // 
            lblWholesaleprice.Anchor = AnchorStyles.None;
            lblWholesaleprice.AutoSize = true;
            lblWholesaleprice.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWholesaleprice.Location = new Point(197, 6);
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
            lblTotalSale.Location = new Point(50, 6);
            lblTotalSale.Margin = new Padding(3);
            lblTotalSale.Name = "lblTotalSale";
            lblTotalSale.Size = new Size(73, 19);
            lblTotalSale.TabIndex = 6;
            lblTotalSale.Text = "اجمالي البيع";
            // 
            // txtWholeSalePrice
            // 
            txtWholeSalePrice.Anchor = AnchorStyles.Right;
            txtWholeSalePrice.Enabled = false;
            txtWholeSalePrice.Font = new Font("Calibri", 12F);
            txtWholeSalePrice.Location = new Point(167, 34);
            txtWholeSalePrice.Multiline = true;
            txtWholeSalePrice.Name = "txtWholeSalePrice";
            txtWholeSalePrice.PlaceholderText = "9999";
            txtWholeSalePrice.Size = new Size(152, 32);
            txtWholeSalePrice.TabIndex = 24;
            txtWholeSalePrice.TextAlign = HorizontalAlignment.Center;
            txtWholeSalePrice.KeyPress += txtWholeSalePrice_KeyPress;
            // 
            // txtTotalSaleProduct
            // 
            txtTotalSaleProduct.Anchor = AnchorStyles.None;
            txtTotalSaleProduct.Enabled = false;
            txtTotalSaleProduct.Font = new Font("Calibri", 12F);
            txtTotalSaleProduct.Location = new Point(12, 34);
            txtTotalSaleProduct.Multiline = true;
            txtTotalSaleProduct.Name = "txtTotalSaleProduct";
            txtTotalSaleProduct.PlaceholderText = "9999999999";
            txtTotalSaleProduct.Size = new Size(149, 32);
            txtTotalSaleProduct.TabIndex = 22;
            txtTotalSaleProduct.TextAlign = HorizontalAlignment.Center;
            txtTotalSaleProduct.KeyPress += txtTotalBuyProduct_KeyPress;
            // 
            // flowLayoutPanelstatistics
            // 
            flowLayoutPanelstatistics.AutoScroll = true;
            flowLayoutPanelstatistics.Controls.Add(gBPayOptions);
            flowLayoutPanelstatistics.Controls.Add(panelStatistics);
            flowLayoutPanelstatistics.Dock = DockStyle.Bottom;
            flowLayoutPanelstatistics.Location = new Point(0, 538);
            flowLayoutPanelstatistics.Margin = new Padding(5);
            flowLayoutPanelstatistics.Name = "flowLayoutPanelstatistics";
            flowLayoutPanelstatistics.Size = new Size(1034, 143);
            flowLayoutPanelstatistics.TabIndex = 24;
            // 
            // gBPayOptions
            // 
            gBPayOptions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gBPayOptions.Controls.Add(dtpReminderDate);
            gBPayOptions.Controls.Add(btnPay);
            gBPayOptions.Controls.Add(lblReminderDate);
            gBPayOptions.Controls.Add(rBPayDebt);
            gBPayOptions.Controls.Add(rBPayPartial);
            gBPayOptions.Controls.Add(rBPayCash);
            gBPayOptions.Location = new Point(512, 3);
            gBPayOptions.Name = "gBPayOptions";
            gBPayOptions.Size = new Size(519, 135);
            gBPayOptions.TabIndex = 8;
            gBPayOptions.TabStop = false;
            gBPayOptions.Text = "عملية الدفع";
            // 
            // dtpReminderDate
            // 
            dtpReminderDate.CustomFormat = "yyyy-MM-dd";
            dtpReminderDate.Format = DateTimePickerFormat.Short;
            dtpReminderDate.Location = new Point(6, 24);
            dtpReminderDate.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpReminderDate.Name = "dtpReminderDate";
            dtpReminderDate.Size = new Size(114, 27);
            dtpReminderDate.TabIndex = 28;
            dtpReminderDate.Value = new DateTime(2024, 8, 27, 0, 0, 0, 0);
            // 
            // btnPay
            // 
            btnPay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPay.Image = (Image)resources.GetObject("btnPay.Image");
            btnPay.ImageAlign = ContentAlignment.MiddleLeft;
            btnPay.ImeMode = ImeMode.NoControl;
            btnPay.Location = new Point(6, 89);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(100, 40);
            btnPay.TabIndex = 4;
            btnPay.Text = "       دفع الآن ";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // lblReminderDate
            // 
            lblReminderDate.AutoSize = true;
            lblReminderDate.ImeMode = ImeMode.NoControl;
            lblReminderDate.Location = new Point(126, 28);
            lblReminderDate.Name = "lblReminderDate";
            lblReminderDate.Size = new Size(114, 19);
            lblReminderDate.TabIndex = 27;
            lblReminderDate.Text = "تاريخ تسديد الدين:";
            // 
            // rBPayDebt
            // 
            rBPayDebt.AutoSize = true;
            rBPayDebt.ImeMode = ImeMode.NoControl;
            rBPayDebt.Location = new Point(375, 102);
            rBPayDebt.Name = "rBPayDebt";
            rBPayDebt.Size = new Size(137, 23);
            rBPayDebt.TabIndex = 8;
            rBPayDebt.Text = "اضافة الفاتورة كدين:";
            rBPayDebt.UseVisualStyleBackColor = true;
            // 
            // rBPayPartial
            // 
            rBPayPartial.AutoSize = true;
            rBPayPartial.ImeMode = ImeMode.NoControl;
            rBPayPartial.Location = new Point(302, 65);
            rBPayPartial.Name = "rBPayPartial";
            rBPayPartial.Size = new Size(210, 23);
            rBPayPartial.TabIndex = 6;
            rBPayPartial.Text = "دفع جزء من الفاتورة  (دين جزئي):";
            rBPayPartial.UseVisualStyleBackColor = true;
            // 
            // rBPayCash
            // 
            rBPayCash.AutoSize = true;
            rBPayCash.Checked = true;
            rBPayCash.ImeMode = ImeMode.NoControl;
            rBPayCash.Location = new Point(351, 28);
            rBPayCash.Name = "rBPayCash";
            rBPayCash.Size = new Size(161, 23);
            rBPayCash.TabIndex = 5;
            rBPayCash.TabStop = true;
            rBPayCash.Text = "دفع الفاتورة كامل (كاش):";
            rBPayCash.UseVisualStyleBackColor = true;
            // 
            // panelStatistics
            // 
            panelStatistics.Controls.Add(ErrorsflowLayoutPanel);
            panelStatistics.Controls.Add(StatisticsflowLayoutPanel);
            panelStatistics.Location = new Point(3, 3);
            panelStatistics.Name = "panelStatistics";
            panelStatistics.Size = new Size(503, 134);
            panelStatistics.TabIndex = 10;
            // 
            // ErrorsflowLayoutPanel
            // 
            ErrorsflowLayoutPanel.Controls.Add(labelError1);
            ErrorsflowLayoutPanel.Controls.Add(lblError2);
            ErrorsflowLayoutPanel.Dock = DockStyle.Fill;
            ErrorsflowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            ErrorsflowLayoutPanel.Location = new Point(0, 0);
            ErrorsflowLayoutPanel.Name = "ErrorsflowLayoutPanel";
            ErrorsflowLayoutPanel.Size = new Size(244, 134);
            ErrorsflowLayoutPanel.TabIndex = 13;
            // 
            // labelError1
            // 
            labelError1.AutoSize = true;
            labelError1.ForeColor = Color.Red;
            labelError1.ImeMode = ImeMode.NoControl;
            labelError1.Location = new Point(22, 5);
            labelError1.Margin = new Padding(5);
            labelError1.Name = "labelError1";
            labelError1.Size = new Size(217, 19);
            labelError1.TabIndex = 10;
            labelError1.Text = "من المفترض ان الكمية انتهت! حذاري.!";
            labelError1.Visible = false;
            // 
            // lblError2
            // 
            lblError2.AutoSize = true;
            lblError2.ForeColor = Color.Red;
            lblError2.ImeMode = ImeMode.NoControl;
            lblError2.Location = new Point(42, 34);
            lblError2.Margin = new Padding(5);
            lblError2.Name = "lblError2";
            lblError2.Size = new Size(197, 38);
            lblError2.TabIndex = 11;
            lblError2.Text = "من المفترض هاته الكمية لا توجد في المخزن المحدد يرجى نقل المنتج!.";
            lblError2.Visible = false;
            // 
            // StatisticsflowLayoutPanel
            // 
            StatisticsflowLayoutPanel.Controls.Add(lblTotalProductsInTable);
            StatisticsflowLayoutPanel.Controls.Add(lblTotalQuentity);
            StatisticsflowLayoutPanel.Controls.Add(lblTotalPriceinFacture);
            StatisticsflowLayoutPanel.Dock = DockStyle.Right;
            StatisticsflowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            StatisticsflowLayoutPanel.Location = new Point(244, 0);
            StatisticsflowLayoutPanel.Name = "StatisticsflowLayoutPanel";
            StatisticsflowLayoutPanel.Size = new Size(259, 134);
            StatisticsflowLayoutPanel.TabIndex = 12;
            // 
            // lblTotalProductsInTable
            // 
            lblTotalProductsInTable.AutoSize = true;
            lblTotalProductsInTable.ImeMode = ImeMode.NoControl;
            lblTotalProductsInTable.Location = new Point(92, 5);
            lblTotalProductsInTable.Margin = new Padding(5);
            lblTotalProductsInTable.Name = "lblTotalProductsInTable";
            lblTotalProductsInTable.Size = new Size(162, 19);
            lblTotalProductsInTable.TabIndex = 9;
            lblTotalProductsInTable.Text = "مجموع المنتجات في الجدول:";
            // 
            // lblTotalQuentity
            // 
            lblTotalQuentity.AutoSize = true;
            lblTotalQuentity.ImeMode = ImeMode.NoControl;
            lblTotalQuentity.Location = new Point(102, 34);
            lblTotalQuentity.Margin = new Padding(5);
            lblTotalQuentity.Name = "lblTotalQuentity";
            lblTotalQuentity.Size = new Size(152, 19);
            lblTotalQuentity.TabIndex = 10;
            lblTotalQuentity.Text = "اجمالي الكميات في الجدول:";
            // 
            // lblTotalPriceinFacture
            // 
            lblTotalPriceinFacture.AutoSize = true;
            lblTotalPriceinFacture.ImeMode = ImeMode.NoControl;
            lblTotalPriceinFacture.Location = new Point(105, 63);
            lblTotalPriceinFacture.Margin = new Padding(5);
            lblTotalPriceinFacture.Name = "lblTotalPriceinFacture";
            lblTotalPriceinFacture.Size = new Size(149, 19);
            lblTotalPriceinFacture.TabIndex = 11;
            lblTotalPriceinFacture.Text = "المبلغ الاجمالي في الفاتورة:";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImeMode = ImeMode.NoControl;
            btnRefresh.Location = new Point(3, 490);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(50, 40);
            btnRefresh.TabIndex = 27;
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
            lblEmptyData.TabIndex = 25;
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
            DgvِProducts.Location = new Point(0, 215);
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
            DgvِProducts.Size = new Size(1034, 323);
            DgvِProducts.TabIndex = 26;
            DgvِProducts.CellContentDoubleClick += DgvِProducts_CellContentDoubleClick;
            DgvِProducts.RowsAdded += DgvِProducts_RowsAdded;
            DgvِProducts.RowsRemoved += DgvِProducts_RowsRemoved;
            DgvِProducts.KeyDown += DgvِProducts_KeyDown;
            // 
            // SalesUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnRefresh);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvِProducts);
            Controls.Add(flowLayoutPanelstatistics);
            Controls.Add(tableLayoutPanel);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "SalesUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            KeyDown += SalesUserControl_KeyDown;
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            gbPayChoiches.PerformLayout();
            panelstatisticsandOperations.ResumeLayout(false);
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            gpSearchAvailable.ResumeLayout(false);
            gpSearchAvailable.PerformLayout();
            panelButtons.ResumeLayout(false);
            gbOperations.ResumeLayout(false);
            gbOperations.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanelstatistics.ResumeLayout(false);
            gBPayOptions.ResumeLayout(false);
            gBPayOptions.PerformLayout();
            panelStatistics.ResumeLayout(false);
            ErrorsflowLayoutPanel.ResumeLayout(false);
            ErrorsflowLayoutPanel.PerformLayout();
            StatisticsflowLayoutPanel.ResumeLayout(false);
            StatisticsflowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private GroupBox gbPayChoiches;
        private Label label1;
        private DateTimePicker DtpDateFacture;
        private Label lblDateFacture;
        private ComboBox cmbStores;
        private ComboBox cmbCustomers;
        private Label lblSuppliers;
        private Label lblFacture;
        private TextBox txtFactureNumber;
        private Panel panelstatisticsandOperations;
        private Panel SearchPanel;
        private Label lblTitleForm;
        private GroupBox gpSearchAvailable;
        private Label label2;
        private Label lblBarCode;
        private TextBox txtSearchBarCode;
        private Button btnSearchImage;
        private Panel panelButtons;
        private GroupBox gbOperations;
        private Button btnDeleteSelected;
        private Label lblDelete;
        private Button btnEditSelected;
        private Label lblEdit;
        private Button btnDown;
        private Label lblDown;
        private Label lblUp;
        private Button btnUp;
        private TableLayoutPanel tableLayoutPanel;
        private TextBox txtWholeSalePrice;
        private TextBox txtTotalSaleProduct;
        private TextBox txtQty;
        private TextBox txtSaleDiscount;
        private TextBox txtProductName;
        private Label lblTotalSale;
        private Label lblProductName;
        private Label lblQuentity;
        private Label lblWholesaleprice;
        private Label lblSalePrice;
        private Label lblBuyPrice;
        private TextBox txtSalePrice;
        private FlowLayoutPanel flowLayoutPanelstatistics;
        private GroupBox gBPayOptions;
        private DateTimePicker dtpReminderDate;
        private Button btnPay;
        private Label lblReminderDate;
        private RadioButton rBPayDebt;
        private RadioButton rBPayPartial;
        private RadioButton rBPayCash;
        private Panel panelStatistics;
        private FlowLayoutPanel ErrorsflowLayoutPanel;
        private Label labelError1;
        private FlowLayoutPanel StatisticsflowLayoutPanel;
        private Label lblTotalProductsInTable;
        private Label lblTotalQuentity;
        private Label lblTotalPriceinFacture;
        private Button btnRefresh;
        private Label lblEmptyData;
        private DataGridView DgvِProducts;
        private CheckBox cbWholsale;
        private Label lblError2;
    }
}
