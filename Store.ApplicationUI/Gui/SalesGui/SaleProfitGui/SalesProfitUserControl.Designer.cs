namespace Store.ApplicationUI.Gui.SalesGui.SaleProfitGui
{
    partial class SalesProfitUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesProfitUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            lblTo = new Label();
            lblFrom = new Label();
            rbBoth = new RadioButton();
            rbCustomerAndOrder = new RadioButton();
            rbDateSearch = new RadioButton();
            panelstatisticsandOperations = new Panel();
            lblTitleForm = new Label();
            flowLayoutPanel = new FlowLayoutPanel();
            lblTotalIncome = new Label();
            lblTotalBuys = new Label();
            lblTotalProfit = new Label();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panelButtons = new Panel();
            button2 = new Button();
            button1 = new Button();
            btnExportCustomer = new Button();
            panelDeletes = new Panel();
            GbDeletes = new GroupBox();
            btnDeleteCurrentPage = new Button();
            btnDeleteAllReports = new Button();
            btnDeleteReportsInPeriod = new Button();
            btnRefresh = new Button();
            lblEmptyData = new Label();
            DgvSalesProfit = new DataGridView();
            PanelPagination = new Panel();
            cmbpagination = new ComboBox();
            btnPrev = new Button();
            btnNext = new Button();
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            SearchPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            panelDeletes.SuspendLayout();
            GbDeletes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvSalesProfit).BeginInit();
            PanelPagination.SuspendLayout();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(gbPayChoiches);
            OperationsflowLayoutPanel.Controls.Add(panelstatisticsandOperations);
            OperationsflowLayoutPanel.Controls.Add(panelButtons);
            OperationsflowLayoutPanel.Controls.Add(panelDeletes);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1034, 164);
            OperationsflowLayoutPanel.TabIndex = 14;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(dtpFrom);
            gbPayChoiches.Controls.Add(dtpTo);
            gbPayChoiches.Controls.Add(lblTo);
            gbPayChoiches.Controls.Add(lblFrom);
            gbPayChoiches.Controls.Add(rbBoth);
            gbPayChoiches.Controls.Add(rbCustomerAndOrder);
            gbPayChoiches.Controls.Add(rbDateSearch);
            gbPayChoiches.Location = new Point(557, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(457, 158);
            gbPayChoiches.TabIndex = 8;
            gbPayChoiches.TabStop = false;
            gbPayChoiches.Text = "اختيارات البحث";
            // 
            // dtpFrom
            // 
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(181, 27);
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
            dtpTo.Location = new Point(19, 27);
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
            lblTo.Location = new Point(144, 29);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(27, 19);
            lblTo.TabIndex = 11;
            lblTo.Text = "الى:";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.ImeMode = ImeMode.NoControl;
            lblFrom.Location = new Point(301, 30);
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
            rbBoth.Location = new Point(169, 110);
            rbBoth.Name = "rbBoth";
            rbBoth.Size = new Size(269, 23);
            rbBoth.TabIndex = 8;
            rbBoth.TabStop = true;
            rbBoth.Text = "البحث عن عميل او منتج او رقم فاتورة في فترة";
            rbBoth.UseVisualStyleBackColor = true;
            // 
            // rbCustomerAndOrder
            // 
            rbCustomerAndOrder.AutoSize = true;
            rbCustomerAndOrder.ImeMode = ImeMode.NoControl;
            rbCustomerAndOrder.Location = new Point(182, 70);
            rbCustomerAndOrder.Name = "rbCustomerAndOrder";
            rbCustomerAndOrder.Size = new Size(256, 23);
            rbCustomerAndOrder.TabIndex = 6;
            rbCustomerAndOrder.Text = "البحث عن عميل او اسم منتج او رقم فاتورة";
            rbCustomerAndOrder.UseVisualStyleBackColor = true;
            // 
            // rbDateSearch
            // 
            rbDateSearch.AutoSize = true;
            rbDateSearch.ImeMode = ImeMode.NoControl;
            rbDateSearch.Location = new Point(333, 28);
            rbDateSearch.Name = "rbDateSearch";
            rbDateSearch.Size = new Size(105, 23);
            rbDateSearch.TabIndex = 5;
            rbDateSearch.Text = "البحث في فترة:";
            rbDateSearch.UseVisualStyleBackColor = true;
            // 
            // panelstatisticsandOperations
            // 
            panelstatisticsandOperations.Controls.Add(lblTitleForm);
            panelstatisticsandOperations.Controls.Add(flowLayoutPanel);
            panelstatisticsandOperations.Controls.Add(SearchPanel);
            panelstatisticsandOperations.Location = new Point(251, 3);
            panelstatisticsandOperations.Name = "panelstatisticsandOperations";
            panelstatisticsandOperations.Size = new Size(300, 158);
            panelstatisticsandOperations.TabIndex = 10;
            // 
            // lblTitleForm
            // 
            lblTitleForm.AutoSize = true;
            lblTitleForm.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleForm.ForeColor = Color.Red;
            lblTitleForm.ImeMode = ImeMode.NoControl;
            lblTitleForm.Location = new Point(85, 5);
            lblTitleForm.Margin = new Padding(3);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(126, 23);
            lblTitleForm.TabIndex = 13;
            lblTitleForm.Text = "تقارير جميع الارباح";
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Controls.Add(lblTotalIncome);
            flowLayoutPanel.Controls.Add(lblTotalBuys);
            flowLayoutPanel.Controls.Add(lblTotalProfit);
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Location = new Point(25, 79);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(247, 76);
            flowLayoutPanel.TabIndex = 12;
            // 
            // lblTotalIncome
            // 
            lblTotalIncome.AutoSize = true;
            lblTotalIncome.ImeMode = ImeMode.NoControl;
            lblTotalIncome.Location = new Point(138, 3);
            lblTotalIncome.Margin = new Padding(3);
            lblTotalIncome.Name = "lblTotalIncome";
            lblTotalIncome.Size = new Size(106, 19);
            lblTotalIncome.TabIndex = 9;
            lblTotalIncome.Text = "مجموع المداخيل :";
            // 
            // lblTotalBuys
            // 
            lblTotalBuys.AutoSize = true;
            lblTotalBuys.ImeMode = ImeMode.NoControl;
            lblTotalBuys.Location = new Point(156, 28);
            lblTotalBuys.Margin = new Padding(3);
            lblTotalBuys.Name = "lblTotalBuys";
            lblTotalBuys.Size = new Size(88, 19);
            lblTotalBuys.TabIndex = 10;
            lblTotalBuys.Text = "مجموع الشراء :";
            // 
            // lblTotalProfit
            // 
            lblTotalProfit.AutoSize = true;
            lblTotalProfit.ImeMode = ImeMode.NoControl;
            lblTotalProfit.Location = new Point(160, 53);
            lblTotalProfit.Margin = new Padding(3);
            lblTotalProfit.Name = "lblTotalProfit";
            lblTotalProfit.Size = new Size(84, 19);
            lblTotalProfit.TabIndex = 11;
            lblTotalProfit.Text = "مجموع الربح :";
            // 
            // SearchPanel
            // 
            SearchPanel.Controls.Add(txtSearch);
            SearchPanel.Controls.Add(btnSearch);
            SearchPanel.Location = new Point(3, 33);
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
            txtSearch.PlaceholderText = "اختر طريقة البحث (على اليمين)";
            txtSearch.Size = new Size(244, 40);
            txtSearch.TabIndex = 9;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            txtSearch.KeyDown += txtSearch_KeyDown;
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
            // panelButtons
            // 
            panelButtons.Controls.Add(button2);
            panelButtons.Controls.Add(button1);
            panelButtons.Controls.Add(btnExportCustomer);
            panelButtons.Location = new Point(4, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(241, 158);
            panelButtons.TabIndex = 9;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.ImeMode = ImeMode.NoControl;
            button2.Location = new Point(0, 108);
            button2.Name = "button2";
            button2.Size = new Size(235, 40);
            button2.TabIndex = 8;
            button2.Text = "طباعة الفاتورة المحدد (A4)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.ImeMode = ImeMode.NoControl;
            button1.Location = new Point(0, 59);
            button1.Name = "button1";
            button1.Size = new Size(235, 40);
            button1.TabIndex = 7;
            button1.Text = "تصدير جميع المعلومات Excel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnExportCustomer
            // 
            btnExportCustomer.Anchor = AnchorStyles.None;
            btnExportCustomer.Image = (Image)resources.GetObject("btnExportCustomer.Image");
            btnExportCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportCustomer.ImeMode = ImeMode.NoControl;
            btnExportCustomer.Location = new Point(0, 9);
            btnExportCustomer.Name = "btnExportCustomer";
            btnExportCustomer.Size = new Size(235, 40);
            btnExportCustomer.TabIndex = 6;
            btnExportCustomer.Text = "طباعة تقرير الفترة المحددة (A4)";
            btnExportCustomer.UseVisualStyleBackColor = true;
            btnExportCustomer.Click += btnExportCustomer_Click;
            // 
            // panelDeletes
            // 
            panelDeletes.Controls.Add(GbDeletes);
            panelDeletes.Location = new Point(773, 167);
            panelDeletes.Name = "panelDeletes";
            panelDeletes.Size = new Size(241, 159);
            panelDeletes.TabIndex = 12;
            // 
            // GbDeletes
            // 
            GbDeletes.Controls.Add(btnDeleteCurrentPage);
            GbDeletes.Controls.Add(btnDeleteAllReports);
            GbDeletes.Controls.Add(btnDeleteReportsInPeriod);
            GbDeletes.Dock = DockStyle.Fill;
            GbDeletes.Location = new Point(0, 0);
            GbDeletes.Name = "GbDeletes";
            GbDeletes.Size = new Size(241, 159);
            GbDeletes.TabIndex = 28;
            GbDeletes.TabStop = false;
            GbDeletes.Text = "خيارات المسح";
            // 
            // btnDeleteCurrentPage
            // 
            btnDeleteCurrentPage.Anchor = AnchorStyles.None;
            btnDeleteCurrentPage.Image = (Image)resources.GetObject("btnDeleteCurrentPage.Image");
            btnDeleteCurrentPage.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteCurrentPage.ImeMode = ImeMode.NoControl;
            btnDeleteCurrentPage.Location = new Point(6, 19);
            btnDeleteCurrentPage.Name = "btnDeleteCurrentPage";
            btnDeleteCurrentPage.Size = new Size(210, 40);
            btnDeleteCurrentPage.TabIndex = 8;
            btnDeleteCurrentPage.Text = "مسح الصفحة الحالية";
            btnDeleteCurrentPage.UseVisualStyleBackColor = true;
            btnDeleteCurrentPage.Click += btnDeleteCurrentPage_Click;
            // 
            // btnDeleteAllReports
            // 
            btnDeleteAllReports.Anchor = AnchorStyles.None;
            btnDeleteAllReports.Image = (Image)resources.GetObject("btnDeleteAllReports.Image");
            btnDeleteAllReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteAllReports.ImeMode = ImeMode.NoControl;
            btnDeleteAllReports.Location = new Point(6, 110);
            btnDeleteAllReports.Name = "btnDeleteAllReports";
            btnDeleteAllReports.Size = new Size(210, 40);
            btnDeleteAllReports.TabIndex = 6;
            btnDeleteAllReports.Text = "مسح جميع التقارير";
            btnDeleteAllReports.UseVisualStyleBackColor = true;
            btnDeleteAllReports.Click += btnDeleteAllReports_Click;
            // 
            // btnDeleteReportsInPeriod
            // 
            btnDeleteReportsInPeriod.Anchor = AnchorStyles.None;
            btnDeleteReportsInPeriod.Image = (Image)resources.GetObject("btnDeleteReportsInPeriod.Image");
            btnDeleteReportsInPeriod.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteReportsInPeriod.ImeMode = ImeMode.NoControl;
            btnDeleteReportsInPeriod.Location = new Point(6, 67);
            btnDeleteReportsInPeriod.Name = "btnDeleteReportsInPeriod";
            btnDeleteReportsInPeriod.Size = new Size(210, 40);
            btnDeleteReportsInPeriod.TabIndex = 7;
            btnDeleteReportsInPeriod.Text = "مسح تقارير في فترة زمنية";
            btnDeleteReportsInPeriod.UseVisualStyleBackColor = true;
            btnDeleteReportsInPeriod.Click += btnDeleteReportsInPeriod_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImeMode = ImeMode.NoControl;
            btnRefresh.Location = new Point(981, 638);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(50, 40);
            btnRefresh.TabIndex = 27;
            btnRefresh.UseVisualStyleBackColor = true;
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
            // DgvSalesProfit
            // 
            DgvSalesProfit.AllowUserToAddRows = false;
            DgvSalesProfit.AllowUserToResizeColumns = false;
            DgvSalesProfit.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvSalesProfit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvSalesProfit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvSalesProfit.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvSalesProfit.BackgroundColor = Color.White;
            DgvSalesProfit.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvSalesProfit.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvSalesProfit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvSalesProfit.ColumnHeadersHeight = 40;
            DgvSalesProfit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvSalesProfit.DefaultCellStyle = dataGridViewCellStyle3;
            DgvSalesProfit.Dock = DockStyle.Fill;
            DgvSalesProfit.EnableHeadersVisualStyles = false;
            DgvSalesProfit.GridColor = SystemColors.ControlDark;
            DgvSalesProfit.Location = new Point(0, 164);
            DgvSalesProfit.MultiSelect = false;
            DgvSalesProfit.Name = "DgvSalesProfit";
            DgvSalesProfit.ReadOnly = true;
            DgvSalesProfit.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvSalesProfit.RowHeadersVisible = false;
            DgvSalesProfit.RowHeadersWidth = 21;
            DgvSalesProfit.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvSalesProfit.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvSalesProfit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvSalesProfit.Size = new Size(1034, 517);
            DgvSalesProfit.TabIndex = 26;
            DgvSalesProfit.RowsAdded += DgvSalesProfit_RowsAdded;
            DgvSalesProfit.RowsRemoved += DgvSalesProfit_RowsRemoved;
            // 
            // PanelPagination
            // 
            PanelPagination.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelPagination.Controls.Add(cmbpagination);
            PanelPagination.Controls.Add(btnPrev);
            PanelPagination.Controls.Add(btnNext);
            PanelPagination.Location = new Point(3, 638);
            PanelPagination.Name = "PanelPagination";
            PanelPagination.Size = new Size(169, 40);
            PanelPagination.TabIndex = 29;
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
            // SalesProfitUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(PanelPagination);
            Controls.Add(btnRefresh);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvSalesProfit);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SalesProfitUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            gbPayChoiches.PerformLayout();
            panelstatisticsandOperations.ResumeLayout(false);
            panelstatisticsandOperations.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelDeletes.ResumeLayout(false);
            GbDeletes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvSalesProfit).EndInit();
            PanelPagination.ResumeLayout(false);
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
        private RadioButton rbCustomerAndOrder;
        private RadioButton rbDateSearch;
        private Panel panelstatisticsandOperations;
        private Label lblTitleForm;
        private FlowLayoutPanel flowLayoutPanel;
        private Label lblTotalIncome;
        private Label lblTotalBuys;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel panelButtons;
        private Button button2;
        private Button button1;
        private Button btnExportCustomer;
        private Button btnRefresh;
        private Label lblEmptyData;
        private DataGridView DgvSalesProfit;
        private Label lblTotalProfit;
        private Panel PanelPagination;
        private ComboBox cmbpagination;
        private Button btnPrev;
        private Button btnNext;
        private Panel panelDeletes;
        private GroupBox GbDeletes;
        private Button btnDeleteCurrentPage;
        private Button btnDeleteAllReports;
        private Button btnDeleteReportsInPeriod;
    }
}
