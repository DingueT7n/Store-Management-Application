namespace Store.ApplicationUI.Gui.BuysGui
{
    partial class BuysUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuysUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            label1 = new Label();
            DtpDateFacture = new DateTimePicker();
            lblDateFacture = new Label();
            cmbStores = new ComboBox();
            cmbSuppliers = new ComboBox();
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
            btnPay = new Button();
            flowLayoutPanelstatistics = new FlowLayoutPanel();
            gBPayOptions = new GroupBox();
            dtpReminderDate = new DateTimePicker();
            lblReminderDate = new Label();
            rBPayDebt = new RadioButton();
            rBPayPartial = new RadioButton();
            rBPayCash = new RadioButton();
            panelStatistics = new Panel();
            ErrorsflowLayoutPanel = new FlowLayoutPanel();
            labelError1 = new Label();
            StatisticsflowLayoutPanel = new FlowLayoutPanel();
            lblTotalProductsInTable = new Label();
            lblTotalQuentity = new Label();
            lblTotalPriceinFacture = new Label();
            btnRefresh = new Button();
            lblEmptyData = new Label();
            DgvِProducts = new DataGridView();
            tableLayoutPanel = new TableLayoutPanel();
            dtpDateExpiration = new DateTimePicker();
            txtPriceWithTax = new TextBox();
            txtWholeSalePrice = new TextBox();
            txtTotalBuyProduct = new TextBox();
            txtQty = new TextBox();
            txtBuyPrice = new TextBox();
            txtProductName = new TextBox();
            lblDateExpiration = new Label();
            lblPriceWithTax = new Label();
            lblTotalBuy = new Label();
            lblProductName = new Label();
            lblQuentity = new Label();
            lblWholesaleprice = new Label();
            lblSalePrice = new Label();
            lblBuyPrice = new Label();
            txtSalePrice = new TextBox();
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
            SearchPanel.SuspendLayout();
            gpSearchAvailable.SuspendLayout();
            panelButtons.SuspendLayout();
            gbOperations.SuspendLayout();
            flowLayoutPanelstatistics.SuspendLayout();
            gBPayOptions.SuspendLayout();
            panelStatistics.SuspendLayout();
            ErrorsflowLayoutPanel.SuspendLayout();
            StatisticsflowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِProducts).BeginInit();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(gbPayChoiches);
            OperationsflowLayoutPanel.Controls.Add(panelstatisticsandOperations);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1034, 147);
            OperationsflowLayoutPanel.TabIndex = 12;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(label1);
            gbPayChoiches.Controls.Add(DtpDateFacture);
            gbPayChoiches.Controls.Add(lblDateFacture);
            gbPayChoiches.Controls.Add(cmbStores);
            gbPayChoiches.Controls.Add(cmbSuppliers);
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
            DtpDateFacture.Location = new Point(8, 65);
            DtpDateFacture.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            DtpDateFacture.Name = "DtpDateFacture";
            DtpDateFacture.Size = new Size(114, 27);
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
            // cmbSuppliers
            // 
            cmbSuppliers.FormattingEnabled = true;
            cmbSuppliers.Location = new Point(152, 65);
            cmbSuppliers.Name = "cmbSuppliers";
            cmbSuppliers.Size = new Size(181, 27);
            cmbSuppliers.TabIndex = 11;
            cmbSuppliers.Text = "اختر مورد";
            // 
            // lblSuppliers
            // 
            lblSuppliers.AutoSize = true;
            lblSuppliers.ImeMode = ImeMode.NoControl;
            lblSuppliers.Location = new Point(370, 68);
            lblSuppliers.Name = "lblSuppliers";
            lblSuppliers.Size = new Size(46, 19);
            lblSuppliers.TabIndex = 10;
            lblSuppliers.Text = "المورد:";
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
            SearchPanel.Size = new Size(309, 134);
            SearchPanel.TabIndex = 8;
            // 
            // lblTitleForm
            // 
            lblTitleForm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitleForm.AutoSize = true;
            lblTitleForm.Font = new Font("Calibri", 14.25F);
            lblTitleForm.ForeColor = Color.Red;
            lblTitleForm.ImeMode = ImeMode.NoControl;
            lblTitleForm.Location = new Point(136, 0);
            lblTitleForm.Margin = new Padding(3);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(100, 23);
            lblTitleForm.TabIndex = 14;
            lblTitleForm.Text = "شراء المنتجات";
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
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelButtons.Controls.Add(gbOperations);
            panelButtons.Location = new Point(8, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(278, 134);
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
            flowLayoutPanelstatistics.TabIndex = 13;
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
            labelError1.Location = new Point(32, 5);
            labelError1.Margin = new Padding(5);
            labelError1.Name = "labelError1";
            labelError1.Size = new Size(207, 38);
            labelError1.TabIndex = 10;
            labelError1.Text = "هل انت متأكد ان سعر الجملة اكبر من سعر التجزئة؟";
            labelError1.Visible = false;
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
            btnRefresh.TabIndex = 21;
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
            lblEmptyData.TabIndex = 19;
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
            DgvِProducts.Location = new Point(0, 216);
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
            DgvِProducts.Size = new Size(1034, 322);
            DgvِProducts.TabIndex = 20;
            DgvِProducts.CellDoubleClick += DgvِProducts_CellDoubleClick;
            DgvِProducts.RowsAdded += DgvِProducts_RowsAdded;
            DgvِProducts.RowsRemoved += DgvِProducts_RowsRemoved;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 9;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 191F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 106F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 137F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 164F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            tableLayoutPanel.Controls.Add(dtpDateExpiration, 7, 1);
            tableLayoutPanel.Controls.Add(txtPriceWithTax, 6, 1);
            tableLayoutPanel.Controls.Add(txtWholeSalePrice, 5, 1);
            tableLayoutPanel.Controls.Add(txtTotalBuyProduct, 3, 1);
            tableLayoutPanel.Controls.Add(txtQty, 2, 1);
            tableLayoutPanel.Controls.Add(txtBuyPrice, 1, 1);
            tableLayoutPanel.Controls.Add(txtProductName, 0, 1);
            tableLayoutPanel.Controls.Add(lblDateExpiration, 7, 0);
            tableLayoutPanel.Controls.Add(lblPriceWithTax, 6, 0);
            tableLayoutPanel.Controls.Add(lblTotalBuy, 3, 0);
            tableLayoutPanel.Controls.Add(lblProductName, 0, 0);
            tableLayoutPanel.Controls.Add(lblQuentity, 2, 0);
            tableLayoutPanel.Controls.Add(lblWholesaleprice, 5, 0);
            tableLayoutPanel.Controls.Add(lblSalePrice, 4, 0);
            tableLayoutPanel.Controls.Add(lblBuyPrice, 1, 0);
            tableLayoutPanel.Controls.Add(txtSalePrice, 4, 1);
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.Location = new Point(0, 147);
            tableLayoutPanel.Margin = new Padding(5, 3, 5, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 44.927536F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 55.072464F));
            tableLayoutPanel.Size = new Size(1034, 69);
            tableLayoutPanel.TabIndex = 22;
            tableLayoutPanel.Paint += tableLayoutPanel_Paint;
            // 
            // dtpDateExpiration
            // 
            dtpDateExpiration.Anchor = AnchorStyles.None;
            dtpDateExpiration.CustomFormat = "yyyy-MM-dd";
            dtpDateExpiration.Format = DateTimePickerFormat.Short;
            dtpDateExpiration.Location = new Point(26, 36);
            dtpDateExpiration.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpDateExpiration.Name = "dtpDateExpiration";
            dtpDateExpiration.Size = new Size(128, 27);
            dtpDateExpiration.TabIndex = 27;
            dtpDateExpiration.Value = new DateTime(2024, 8, 27, 0, 0, 0, 0);
            // 
            // txtPriceWithTax
            // 
            txtPriceWithTax.Anchor = AnchorStyles.None;
            txtPriceWithTax.Enabled = false;
            txtPriceWithTax.Font = new Font("Calibri", 12F);
            txtPriceWithTax.Location = new Point(175, 34);
            txtPriceWithTax.Multiline = true;
            txtPriceWithTax.Name = "txtPriceWithTax";
            txtPriceWithTax.PlaceholderText = "9999";
            txtPriceWithTax.Size = new Size(131, 32);
            txtPriceWithTax.TabIndex = 25;
            txtPriceWithTax.TextAlign = HorizontalAlignment.Center;
            // 
            // txtWholeSalePrice
            // 
            txtWholeSalePrice.Anchor = AnchorStyles.None;
            txtWholeSalePrice.Font = new Font("Calibri", 12F);
            txtWholeSalePrice.Location = new Point(315, 34);
            txtWholeSalePrice.Multiline = true;
            txtWholeSalePrice.Name = "txtWholeSalePrice";
            txtWholeSalePrice.PlaceholderText = "9999";
            txtWholeSalePrice.Size = new Size(99, 32);
            txtWholeSalePrice.TabIndex = 24;
            txtWholeSalePrice.TextAlign = HorizontalAlignment.Center;
            txtWholeSalePrice.TextChanged += txtWholeSalePrice_TextChanged;
            txtWholeSalePrice.KeyPress += txtWholeSalePrice_KeyPress;
            txtWholeSalePrice.KeyUp += txtWholeSalePrice_KeyUp;
            // 
            // txtTotalBuyProduct
            // 
            txtTotalBuyProduct.Anchor = AnchorStyles.None;
            txtTotalBuyProduct.Enabled = false;
            txtTotalBuyProduct.Font = new Font("Calibri", 12F);
            txtTotalBuyProduct.Location = new Point(527, 34);
            txtTotalBuyProduct.Multiline = true;
            txtTotalBuyProduct.Name = "txtTotalBuyProduct";
            txtTotalBuyProduct.PlaceholderText = "9999";
            txtTotalBuyProduct.Size = new Size(100, 32);
            txtTotalBuyProduct.TabIndex = 22;
            txtTotalBuyProduct.TextAlign = HorizontalAlignment.Center;
            // 
            // txtQty
            // 
            txtQty.Anchor = AnchorStyles.None;
            txtQty.Font = new Font("Calibri", 12F);
            txtQty.Location = new Point(633, 34);
            txtQty.Multiline = true;
            txtQty.Name = "txtQty";
            txtQty.PlaceholderText = "9999";
            txtQty.Size = new Size(99, 32);
            txtQty.TabIndex = 21;
            txtQty.TextAlign = HorizontalAlignment.Center;
            txtQty.KeyDown += txtQty_KeyDown;
            txtQty.KeyPress += txtQty_KeyPress;
            txtQty.KeyUp += txtQty_KeyUp;
            // 
            // txtBuyPrice
            // 
            txtBuyPrice.Anchor = AnchorStyles.None;
            txtBuyPrice.Font = new Font("Calibri", 12F);
            txtBuyPrice.Location = new Point(738, 34);
            txtBuyPrice.Multiline = true;
            txtBuyPrice.Name = "txtBuyPrice";
            txtBuyPrice.PlaceholderText = "9999";
            txtBuyPrice.Size = new Size(102, 32);
            txtBuyPrice.TabIndex = 20;
            txtBuyPrice.TextAlign = HorizontalAlignment.Center;
            txtBuyPrice.KeyDown += txtBuyPrice_KeyDown;
            txtBuyPrice.KeyPress += txtBuyPrice_KeyPress;
            txtBuyPrice.KeyUp += txtBuyPrice_KeyUp;
            // 
            // txtProductName
            // 
            txtProductName.Anchor = AnchorStyles.None;
            txtProductName.Enabled = false;
            txtProductName.Font = new Font("Calibri", 12F);
            txtProductName.Location = new Point(846, 34);
            txtProductName.Multiline = true;
            txtProductName.Name = "txtProductName";
            txtProductName.PlaceholderText = "اسم المنتج";
            txtProductName.Size = new Size(185, 32);
            txtProductName.TabIndex = 19;
            txtProductName.TextAlign = HorizontalAlignment.Center;
            // 
            // lblDateExpiration
            // 
            lblDateExpiration.Anchor = AnchorStyles.None;
            lblDateExpiration.AutoSize = true;
            lblDateExpiration.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateExpiration.Location = new Point(33, 5);
            lblDateExpiration.Margin = new Padding(3, 5, 5, 3);
            lblDateExpiration.Name = "lblDateExpiration";
            lblDateExpiration.Size = new Size(117, 23);
            lblDateExpiration.TabIndex = 8;
            lblDateExpiration.Text = "تاريخ انتهاء صلاحية المنتوج";
            // 
            // lblPriceWithTax
            // 
            lblPriceWithTax.Anchor = AnchorStyles.None;
            lblPriceWithTax.AutoSize = true;
            lblPriceWithTax.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPriceWithTax.Location = new Point(175, 6);
            lblPriceWithTax.Margin = new Padding(3);
            lblPriceWithTax.Name = "lblPriceWithTax";
            lblPriceWithTax.Size = new Size(131, 19);
            lblPriceWithTax.TabIndex = 7;
            lblPriceWithTax.Text = "البيع باحتساب الضريبة";
            // 
            // lblTotalBuy
            // 
            lblTotalBuy.Anchor = AnchorStyles.None;
            lblTotalBuy.AutoSize = true;
            lblTotalBuy.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalBuy.Location = new Point(538, 6);
            lblTotalBuy.Margin = new Padding(3);
            lblTotalBuy.Name = "lblTotalBuy";
            lblTotalBuy.Size = new Size(79, 19);
            lblTotalBuy.TabIndex = 6;
            lblTotalBuy.Text = "اجمالي الشراء";
            // 
            // lblProductName
            // 
            lblProductName.Anchor = AnchorStyles.None;
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductName.Location = new Point(905, 6);
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
            lblQuentity.Location = new Point(662, 6);
            lblQuentity.Margin = new Padding(3);
            lblQuentity.Name = "lblQuentity";
            lblQuentity.Size = new Size(41, 19);
            lblQuentity.TabIndex = 3;
            lblQuentity.Text = "الكمية";
            // 
            // lblWholesaleprice
            // 
            lblWholesaleprice.Anchor = AnchorStyles.None;
            lblWholesaleprice.AutoSize = true;
            lblWholesaleprice.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWholesaleprice.Location = new Point(318, 6);
            lblWholesaleprice.Margin = new Padding(3);
            lblWholesaleprice.Name = "lblWholesaleprice";
            lblWholesaleprice.Size = new Size(93, 19);
            lblWholesaleprice.TabIndex = 5;
            lblWholesaleprice.Text = "سعر البيع جملة";
            // 
            // lblSalePrice
            // 
            lblSalePrice.Anchor = AnchorStyles.None;
            lblSalePrice.AutoSize = true;
            lblSalePrice.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSalePrice.Location = new Point(441, 6);
            lblSalePrice.Margin = new Padding(3);
            lblSalePrice.Name = "lblSalePrice";
            lblSalePrice.Size = new Size(61, 19);
            lblSalePrice.TabIndex = 4;
            lblSalePrice.Text = "سعر البيع";
            // 
            // lblBuyPrice
            // 
            lblBuyPrice.Anchor = AnchorStyles.None;
            lblBuyPrice.AutoSize = true;
            lblBuyPrice.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuyPrice.Location = new Point(756, 6);
            lblBuyPrice.Margin = new Padding(3);
            lblBuyPrice.Name = "lblBuyPrice";
            lblBuyPrice.Size = new Size(67, 19);
            lblBuyPrice.TabIndex = 2;
            lblBuyPrice.Text = "سعر الشراء";
            // 
            // txtSalePrice
            // 
            txtSalePrice.Anchor = AnchorStyles.None;
            txtSalePrice.Font = new Font("Calibri", 12F);
            txtSalePrice.Location = new Point(422, 34);
            txtSalePrice.Multiline = true;
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.PlaceholderText = "9999";
            txtSalePrice.Size = new Size(99, 32);
            txtSalePrice.TabIndex = 23;
            txtSalePrice.TextAlign = HorizontalAlignment.Center;
            txtSalePrice.TextChanged += txtSalePrice_TextChanged;
            txtSalePrice.KeyDown += txtSalePrice_KeyDown;
            txtSalePrice.KeyPress += txtSalePrice_KeyPress;
            txtSalePrice.KeyUp += txtSalePrice_KeyUp;
            // 
            // BuysUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnRefresh);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvِProducts);
            Controls.Add(tableLayoutPanel);
            Controls.Add(OperationsflowLayoutPanel);
            Controls.Add(flowLayoutPanelstatistics);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BuysUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
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
            flowLayoutPanelstatistics.ResumeLayout(false);
            gBPayOptions.ResumeLayout(false);
            gBPayOptions.PerformLayout();
            panelStatistics.ResumeLayout(false);
            ErrorsflowLayoutPanel.ResumeLayout(false);
            ErrorsflowLayoutPanel.PerformLayout();
            StatisticsflowLayoutPanel.ResumeLayout(false);
            StatisticsflowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِProducts).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private GroupBox gbPayChoiches;
        private Label lblSuppliers;
        private Label lblFacture;
        private TextBox txtFactureNumber;
        private Button btnPay;
        private Panel panelstatisticsandOperations;
        private Label lblTitleForm;
        private Panel SearchPanel;
        private Panel panelButtons;
        private FlowLayoutPanel flowLayoutPanelstatistics;
        private GroupBox gBPayOptions;
        private RadioButton rBPayDebt;
        private RadioButton rBPayPartial;
        private RadioButton rBPayCash;
        private Button button3;
        private Panel panelStatistics;
        private FlowLayoutPanel StatisticsflowLayoutPanel;
        private Label lblTotalProductsInTable;
        private Label lblTotalQuentity;
        private Label lblTotalPriceinFacture;
        private Button btnRefresh;
        private Label lblEmptyData;
        private DataGridView DgvِProducts;
        private ComboBox cmbStores;
        private Label label7;
        private ComboBox cmbSuppliers;
        private Label lblDateFacture;
        private DateTimePicker DtpDateFacture;
        private GroupBox gpSearchAvailable;
        private Label label9;
        private Label lblBarCode;
        private TextBox txtSearchBarCode;
        private Button btnSearchImage;
        private GroupBox gbOperations;
        private Button btnDeleteSelected;
        private Label lblDelete;
        private Button btnEditSelected;
        private Label lblEdit;
        private Button btnDown;
        private Label lblDown;
        private Label lblUp;
        private Button btnUp;
        private DateTimePicker dtpReminderDate;
        private Label lblReminderDate;
        private TableLayoutPanel tableLayoutPanel;
        private Label lblProductName;
        private Label lblSalePrice;
        private Label lblBuyPrice;
        private Label lblQuentity;
        private Label lblPriceWithTax;
        private Label lblTotalBuy;
        private Label lblWholesaleprice;
        private TextBox txtPriceWithTax;
        private TextBox txtWholeSalePrice;
        private TextBox txtSalePrice;
        private TextBox txtTotalBuyProduct;
        private TextBox txtQty;
        private TextBox txtBuyPrice;
        private TextBox txtProductName;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel ErrorsflowLayoutPanel;
        private Label labelError1;
        private DateTimePicker dtpDateExpiration;
        private Label lblDateExpiration;
    }
}
