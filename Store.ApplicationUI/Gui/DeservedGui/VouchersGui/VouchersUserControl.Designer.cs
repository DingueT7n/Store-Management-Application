namespace Store.ApplicationUI.Gui.DeservedGui.VouchersGui
{
    partial class VouchersUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VouchersUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            groupBox1 = new GroupBox();
            rbReciptVoucher = new RadioButton();
            rbSendVoucher = new RadioButton();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            lblTo = new Label();
            lblFrom = new Label();
            rbBoth = new RadioButton();
            rbSupplierAndOrder = new RadioButton();
            rbDateSearch = new RadioButton();
            panelstatisticsandOperations = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblTotalDebt = new Label();
            lblTotalCustomers = new Label();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            btnAddDeserved = new Button();
            btnEditDeserved = new Button();
            btnExportProduct = new Button();
            btnAddDeservedType = new Button();
            btnDeleteDeserved = new Button();
            btnRefresh = new Button();
            lblEmptyData = new Label();
            DgvProducts = new DataGridView();
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            groupBox1.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SearchPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).BeginInit();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(gbPayChoiches);
            OperationsflowLayoutPanel.Controls.Add(panelstatisticsandOperations);
            OperationsflowLayoutPanel.Controls.Add(panel1);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1034, 168);
            OperationsflowLayoutPanel.TabIndex = 10;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(groupBox1);
            gbPayChoiches.Controls.Add(dtpFrom);
            gbPayChoiches.Controls.Add(dtpTo);
            gbPayChoiches.Controls.Add(lblTo);
            gbPayChoiches.Controls.Add(lblFrom);
            gbPayChoiches.Controls.Add(rbBoth);
            gbPayChoiches.Controls.Add(rbSupplierAndOrder);
            gbPayChoiches.Controls.Add(rbDateSearch);
            gbPayChoiches.Location = new Point(597, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(434, 159);
            gbPayChoiches.TabIndex = 9;
            gbPayChoiches.TabStop = false;
            gbPayChoiches.Text = "اختيارات البحث";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbReciptVoucher);
            groupBox1.Controls.Add(rbSendVoucher);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(3, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(428, 48);
            groupBox1.TabIndex = 31;
            groupBox1.TabStop = false;
            groupBox1.Text = "نوع السند";
            // 
            // rbReciptVoucher
            // 
            rbReciptVoucher.AutoSize = true;
            rbReciptVoucher.Checked = true;
            rbReciptVoucher.ImeMode = ImeMode.NoControl;
            rbReciptVoucher.Location = new Point(273, 20);
            rbReciptVoucher.Name = "rbReciptVoucher";
            rbReciptVoucher.Size = new Size(90, 23);
            rbReciptVoucher.TabIndex = 29;
            rbReciptVoucher.TabStop = true;
            rbReciptVoucher.Text = "سند القبض";
            rbReciptVoucher.UseVisualStyleBackColor = true;
            rbReciptVoucher.CheckedChanged += rbReciptVoucher_CheckedChanged;
            // 
            // rbSendVoucher
            // 
            rbSendVoucher.AutoSize = true;
            rbSendVoucher.ImeMode = ImeMode.NoControl;
            rbSendVoucher.Location = new Point(109, 19);
            rbSendVoucher.Name = "rbSendVoucher";
            rbSendVoucher.Size = new Size(91, 23);
            rbSendVoucher.TabIndex = 30;
            rbSendVoucher.Text = "سند الصرف";
            rbSendVoucher.UseVisualStyleBackColor = true;
            rbSendVoucher.CheckedChanged += rbSendVoucher_CheckedChanged;
            // 
            // dtpFrom
            // 
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(172, 72);
            dtpFrom.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(119, 27);
            dtpFrom.TabIndex = 27;
            dtpFrom.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // dtpTo
            // 
            dtpTo.CustomFormat = "yyyy-MM-dd";
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(10, 72);
            dtpTo.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(119, 27);
            dtpTo.TabIndex = 26;
            dtpTo.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.ImeMode = ImeMode.NoControl;
            lblTo.Location = new Point(135, 74);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(27, 19);
            lblTo.TabIndex = 11;
            lblTo.Text = "الى:";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.ImeMode = ImeMode.NoControl;
            lblFrom.Location = new Point(292, 75);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(28, 19);
            lblFrom.TabIndex = 9;
            lblFrom.Text = "من:";
            // 
            // rbBoth
            // 
            rbBoth.AutoSize = true;
            rbBoth.Checked = true;
            rbBoth.ImeMode = ImeMode.NoControl;
            rbBoth.Location = new Point(276, 130);
            rbBoth.Name = "rbBoth";
            rbBoth.Size = new Size(149, 23);
            rbBoth.TabIndex = 8;
            rbBoth.TabStop = true;
            rbBoth.Text = "البحث عن سند في فترة";
            rbBoth.UseVisualStyleBackColor = true;
            // 
            // rbSupplierAndOrder
            // 
            rbSupplierAndOrder.AutoSize = true;
            rbSupplierAndOrder.ImeMode = ImeMode.NoControl;
            rbSupplierAndOrder.Location = new Point(291, 101);
            rbSupplierAndOrder.Name = "rbSupplierAndOrder";
            rbSupplierAndOrder.Size = new Size(134, 23);
            rbSupplierAndOrder.TabIndex = 6;
            rbSupplierAndOrder.Text = "البحث عن رقم سند";
            rbSupplierAndOrder.UseVisualStyleBackColor = true;
            // 
            // rbDateSearch
            // 
            rbDateSearch.AutoSize = true;
            rbDateSearch.ImeMode = ImeMode.NoControl;
            rbDateSearch.Location = new Point(323, 72);
            rbDateSearch.Name = "rbDateSearch";
            rbDateSearch.Size = new Size(105, 23);
            rbDateSearch.TabIndex = 5;
            rbDateSearch.Text = "البحث في فترة:";
            rbDateSearch.UseVisualStyleBackColor = true;
            // 
            // panelstatisticsandOperations
            // 
            panelstatisticsandOperations.Controls.Add(flowLayoutPanel1);
            panelstatisticsandOperations.Controls.Add(SearchPanel);
            panelstatisticsandOperations.Location = new Point(321, 3);
            panelstatisticsandOperations.Name = "panelstatisticsandOperations";
            panelstatisticsandOperations.Size = new Size(270, 137);
            panelstatisticsandOperations.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lblTotalDebt);
            flowLayoutPanel1.Controls.Add(lblTotalCustomers);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 59);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(267, 76);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // lblTotalDebt
            // 
            lblTotalDebt.AutoSize = true;
            lblTotalDebt.ImeMode = ImeMode.NoControl;
            lblTotalDebt.Location = new Point(150, 3);
            lblTotalDebt.Margin = new Padding(3);
            lblTotalDebt.Name = "lblTotalDebt";
            lblTotalDebt.Size = new Size(114, 19);
            lblTotalDebt.TabIndex = 9;
            lblTotalDebt.Text = "مجموع المصروفات:";
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.ImeMode = ImeMode.NoControl;
            lblTotalCustomers.Location = new Point(159, 28);
            lblTotalCustomers.Margin = new Padding(3);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(105, 19);
            lblTotalCustomers.TabIndex = 10;
            lblTotalCustomers.Text = "عدد المصروفات :";
            // 
            // SearchPanel
            // 
            SearchPanel.Controls.Add(txtSearch);
            SearchPanel.Controls.Add(btnSearch);
            SearchPanel.Location = new Point(3, 13);
            SearchPanel.Name = "SearchPanel";
            SearchPanel.Size = new Size(260, 40);
            SearchPanel.TabIndex = 7;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(50, 0);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث عن رقم مصروفة";
            txtSearch.Size = new Size(210, 40);
            txtSearch.TabIndex = 9;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSearch
            // 
            btnSearch.Dock = DockStyle.Left;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(0, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(50, 40);
            btnSearch.TabIndex = 7;
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnAddDeserved);
            panel1.Controls.Add(btnEditDeserved);
            panel1.Controls.Add(btnExportProduct);
            panel1.Controls.Add(btnAddDeservedType);
            panel1.Controls.Add(btnDeleteDeserved);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 159);
            panel1.TabIndex = 15;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(3, 113);
            button2.Name = "button2";
            button2.Size = new Size(158, 40);
            button2.TabIndex = 10;
            button2.Text = "طباعة كل المصروفات";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(163, 113);
            button1.Name = "button1";
            button1.Size = new Size(146, 40);
            button1.TabIndex = 9;
            button1.Text = "حذف كل المعلومات";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnAddDeserved
            // 
            btnAddDeserved.Anchor = AnchorStyles.None;
            btnAddDeserved.Image = (Image)resources.GetObject("btnAddDeserved.Image");
            btnAddDeserved.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddDeserved.Location = new Point(219, 12);
            btnAddDeserved.Name = "btnAddDeserved";
            btnAddDeserved.Size = new Size(90, 40);
            btnAddDeserved.TabIndex = 3;
            btnAddDeserved.Text = "اضافة";
            btnAddDeserved.TextAlign = ContentAlignment.MiddleRight;
            btnAddDeserved.UseVisualStyleBackColor = true;
            btnAddDeserved.Click += btnAddDeserved_Click;
            // 
            // btnEditDeserved
            // 
            btnEditDeserved.Anchor = AnchorStyles.None;
            btnEditDeserved.Image = (Image)resources.GetObject("btnEditDeserved.Image");
            btnEditDeserved.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditDeserved.Location = new Point(111, 12);
            btnEditDeserved.Name = "btnEditDeserved";
            btnEditDeserved.Size = new Size(90, 40);
            btnEditDeserved.TabIndex = 4;
            btnEditDeserved.Text = "تعديل";
            btnEditDeserved.TextAlign = ContentAlignment.MiddleRight;
            btnEditDeserved.UseVisualStyleBackColor = true;
            btnEditDeserved.Click += btnEditDeserved_Click;
            // 
            // btnExportProduct
            // 
            btnExportProduct.Anchor = AnchorStyles.None;
            btnExportProduct.Image = (Image)resources.GetObject("btnExportProduct.Image");
            btnExportProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportProduct.Location = new Point(3, 66);
            btnExportProduct.Name = "btnExportProduct";
            btnExportProduct.Size = new Size(158, 40);
            btnExportProduct.TabIndex = 6;
            btnExportProduct.Text = "تصدير اكسال";
            btnExportProduct.UseVisualStyleBackColor = true;
            // 
            // btnAddDeservedType
            // 
            btnAddDeservedType.Anchor = AnchorStyles.None;
            btnAddDeservedType.Image = (Image)resources.GetObject("btnAddDeservedType.Image");
            btnAddDeservedType.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddDeservedType.Location = new Point(166, 67);
            btnAddDeservedType.Name = "btnAddDeservedType";
            btnAddDeservedType.Size = new Size(146, 40);
            btnAddDeservedType.TabIndex = 8;
            btnAddDeservedType.Text = "انواع المصروفات";
            btnAddDeservedType.TextAlign = ContentAlignment.MiddleRight;
            btnAddDeservedType.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDeserved
            // 
            btnDeleteDeserved.Anchor = AnchorStyles.None;
            btnDeleteDeserved.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteDeserved.Image = (Image)resources.GetObject("btnDeleteDeserved.Image");
            btnDeleteDeserved.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteDeserved.Location = new Point(15, 12);
            btnDeleteDeserved.Name = "btnDeleteDeserved";
            btnDeleteDeserved.Size = new Size(90, 40);
            btnDeleteDeserved.TabIndex = 5;
            btnDeleteDeserved.Text = "حذف";
            btnDeleteDeserved.TextAlign = ContentAlignment.MiddleRight;
            btnDeleteDeserved.UseVisualStyleBackColor = true;
            btnDeleteDeserved.Click += btnDeleteDeserved_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.Location = new Point(981, 638);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(50, 40);
            btnRefresh.TabIndex = 16;
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lblEmptyData
            // 
            lblEmptyData.Anchor = AnchorStyles.None;
            lblEmptyData.AutoSize = true;
            lblEmptyData.BackColor = Color.Transparent;
            lblEmptyData.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 7);
            lblEmptyData.ForeColor = Color.Crimson;
            lblEmptyData.Location = new Point(451, 331);
            lblEmptyData.Name = "lblEmptyData";
            lblEmptyData.Size = new Size(133, 19);
            lblEmptyData.TabIndex = 14;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvProducts
            // 
            DgvProducts.AllowUserToAddRows = false;
            DgvProducts.AllowUserToResizeColumns = false;
            DgvProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvProducts.BackgroundColor = Color.White;
            DgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvProducts.ColumnHeadersHeight = 40;
            DgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvProducts.DefaultCellStyle = dataGridViewCellStyle3;
            DgvProducts.Dock = DockStyle.Fill;
            DgvProducts.EnableHeadersVisualStyles = false;
            DgvProducts.GridColor = SystemColors.ControlDark;
            DgvProducts.Location = new Point(0, 168);
            DgvProducts.MultiSelect = false;
            DgvProducts.Name = "DgvProducts";
            DgvProducts.ReadOnly = true;
            DgvProducts.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvProducts.RowHeadersVisible = false;
            DgvProducts.RowHeadersWidth = 21;
            DgvProducts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvProducts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvProducts.Size = new Size(1034, 513);
            DgvProducts.TabIndex = 15;
            // 
            // VouchersUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnRefresh);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvProducts);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "VouchersUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            gbPayChoiches.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelstatisticsandOperations.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private GroupBox gbPayChoiches;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label lblTo;
        private Label lblFrom;
        private RadioButton rbBoth;
        private RadioButton rbSupplierAndOrder;
        private RadioButton rbDateSearch;
        private Panel panelstatisticsandOperations;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel panel1;
        private Button button2;
        private Button button1;
        private Button btnAddDeserved;
        private Button btnEditDeserved;
        private Button btnExportProduct;
        private Button btnAddDeservedType;
        private Button btnDeleteDeserved;
        private Button btnRefresh;
        private Label lblEmptyData;
        private DataGridView DgvProducts;
        private RadioButton rbSendVoucher;
        private RadioButton rbReciptVoucher;
        private GroupBox groupBox1;
        private Label lblTotalDebt;
        private Label lblTotalCustomers;
    }
}
