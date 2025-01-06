namespace Store.ApplicationUI.Gui.ReturnsGui.ReturnsReportsGui
{
    partial class ReturnsReportsUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnsReportsUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            flowLayoutPanelreturnsoption = new FlowLayoutPanel();
            rbRefundAll = new RadioButton();
            rbRefundSales = new RadioButton();
            rbRefundBuys = new RadioButton();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            lblTo = new Label();
            lblFrom = new Label();
            rbBoth = new RadioButton();
            rbDateSearch = new RadioButton();
            panelstatisticsandOperations = new Panel();
            lblTitleForm = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblTotalDebt = new Label();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panelButtons = new Panel();
            button2 = new Button();
            btnExportCustomer = new Button();
            lblEmptyData = new Label();
            DgvSales = new DataGridView();
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            flowLayoutPanelreturnsoption.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SearchPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvSales).BeginInit();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(gbPayChoiches);
            OperationsflowLayoutPanel.Controls.Add(panelstatisticsandOperations);
            OperationsflowLayoutPanel.Controls.Add(panelButtons);
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
            gbPayChoiches.Controls.Add(flowLayoutPanelreturnsoption);
            gbPayChoiches.Controls.Add(dtpFrom);
            gbPayChoiches.Controls.Add(dtpTo);
            gbPayChoiches.Controls.Add(lblTo);
            gbPayChoiches.Controls.Add(lblFrom);
            gbPayChoiches.Controls.Add(rbBoth);
            gbPayChoiches.Controls.Add(rbDateSearch);
            gbPayChoiches.Location = new Point(574, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(457, 158);
            gbPayChoiches.TabIndex = 8;
            gbPayChoiches.TabStop = false;
            gbPayChoiches.Text = "اختيارات البحث";
            // 
            // flowLayoutPanelreturnsoption
            // 
            flowLayoutPanelreturnsoption.Controls.Add(rbRefundAll);
            flowLayoutPanelreturnsoption.Controls.Add(rbRefundSales);
            flowLayoutPanelreturnsoption.Controls.Add(rbRefundBuys);
            flowLayoutPanelreturnsoption.Dock = DockStyle.Top;
            flowLayoutPanelreturnsoption.Location = new Point(3, 23);
            flowLayoutPanelreturnsoption.Name = "flowLayoutPanelreturnsoption";
            flowLayoutPanelreturnsoption.Size = new Size(451, 39);
            flowLayoutPanelreturnsoption.TabIndex = 28;
            // 
            // rbRefundAll
            // 
            rbRefundAll.AutoSize = true;
            rbRefundAll.Checked = true;
            rbRefundAll.ImeMode = ImeMode.NoControl;
            rbRefundAll.Location = new Point(333, 3);
            rbRefundAll.Margin = new Padding(15, 3, 15, 3);
            rbRefundAll.Name = "rbRefundAll";
            rbRefundAll.Size = new Size(103, 23);
            rbRefundAll.TabIndex = 6;
            rbRefundAll.TabStop = true;
            rbRefundAll.Text = "كل المرتجعات";
            rbRefundAll.UseVisualStyleBackColor = true;
            rbRefundAll.CheckedChanged += rbRefundAll_CheckedChanged;
            // 
            // rbRefundSales
            // 
            rbRefundSales.AutoSize = true;
            rbRefundSales.BackColor = Color.White;
            rbRefundSales.ForeColor = Color.Green;
            rbRefundSales.ImeMode = ImeMode.NoControl;
            rbRefundSales.Location = new Point(183, 3);
            rbRefundSales.Margin = new Padding(15, 3, 15, 3);
            rbRefundSales.Name = "rbRefundSales";
            rbRefundSales.Size = new Size(120, 23);
            rbRefundSales.TabIndex = 7;
            rbRefundSales.Text = "مرتجعات مبيعات";
            rbRefundSales.UseVisualStyleBackColor = false;
            rbRefundSales.CheckedChanged += rbRefundSales_CheckedChanged;
            // 
            // rbRefundBuys
            // 
            rbRefundBuys.AutoSize = true;
            rbRefundBuys.ForeColor = Color.Red;
            rbRefundBuys.ImeMode = ImeMode.NoControl;
            rbRefundBuys.Location = new Point(27, 3);
            rbRefundBuys.Margin = new Padding(15, 3, 15, 3);
            rbRefundBuys.Name = "rbRefundBuys";
            rbRefundBuys.Size = new Size(126, 23);
            rbRefundBuys.TabIndex = 8;
            rbRefundBuys.Text = "مرتجعات مشتريات";
            rbRefundBuys.UseVisualStyleBackColor = true;
            rbRefundBuys.CheckedChanged += rbRefundBuys_CheckedChanged;
            // 
            // dtpFrom
            // 
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(181, 81);
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
            dtpTo.Location = new Point(19, 81);
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
            lblTo.Location = new Point(144, 83);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(27, 19);
            lblTo.TabIndex = 11;
            lblTo.Text = "الى:";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.ImeMode = ImeMode.NoControl;
            lblFrom.Location = new Point(301, 84);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(28, 19);
            lblFrom.TabIndex = 9;
            lblFrom.Text = "من:";
            // 
            // rbBoth
            // 
            rbBoth.AutoSize = true;
            rbBoth.ImeMode = ImeMode.NoControl;
            rbBoth.Location = new Point(241, 129);
            rbBoth.Name = "rbBoth";
            rbBoth.Size = new Size(197, 23);
            rbBoth.TabIndex = 8;
            rbBoth.Text = "البحث عن عميل او مورد في فترة";
            rbBoth.UseVisualStyleBackColor = true;
            // 
            // rbDateSearch
            // 
            rbDateSearch.AutoSize = true;
            rbDateSearch.ImeMode = ImeMode.NoControl;
            rbDateSearch.Location = new Point(333, 82);
            rbDateSearch.Name = "rbDateSearch";
            rbDateSearch.Size = new Size(105, 23);
            rbDateSearch.TabIndex = 5;
            rbDateSearch.Text = "البحث في فترة:";
            rbDateSearch.UseVisualStyleBackColor = true;
            // 
            // panelstatisticsandOperations
            // 
            panelstatisticsandOperations.Controls.Add(lblTitleForm);
            panelstatisticsandOperations.Controls.Add(flowLayoutPanel1);
            panelstatisticsandOperations.Controls.Add(SearchPanel);
            panelstatisticsandOperations.Location = new Point(268, 3);
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
            lblTitleForm.Location = new Point(79, 5);
            lblTitleForm.Margin = new Padding(3);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(154, 23);
            lblTitleForm.TabIndex = 13;
            lblTitleForm.Text = "تقارير جميع المرتجعات";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lblTotalDebt);
            flowLayoutPanel1.Location = new Point(25, 79);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(247, 76);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // lblTotalDebt
            // 
            lblTotalDebt.AutoSize = true;
            lblTotalDebt.ImeMode = ImeMode.NoControl;
            lblTotalDebt.Location = new Point(134, 3);
            lblTotalDebt.Margin = new Padding(3);
            lblTotalDebt.Name = "lblTotalDebt";
            lblTotalDebt.Size = new Size(110, 19);
            lblTotalDebt.TabIndex = 9;
            lblTotalDebt.Text = "مجموع المرتجعات:";
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
            panelButtons.Controls.Add(btnExportCustomer);
            panelButtons.Location = new Point(11, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(251, 158);
            panelButtons.TabIndex = 9;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.ImeMode = ImeMode.NoControl;
            button2.Location = new Point(4, 9);
            button2.Name = "button2";
            button2.Size = new Size(244, 40);
            button2.TabIndex = 8;
            button2.Text = "حذف جميع بيانات الجدول";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnExportCustomer
            // 
            btnExportCustomer.Anchor = AnchorStyles.None;
            btnExportCustomer.Image = (Image)resources.GetObject("btnExportCustomer.Image");
            btnExportCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportCustomer.ImeMode = ImeMode.NoControl;
            btnExportCustomer.Location = new Point(4, 61);
            btnExportCustomer.Name = "btnExportCustomer";
            btnExportCustomer.Size = new Size(244, 40);
            btnExportCustomer.TabIndex = 6;
            btnExportCustomer.Text = "   تصدير/طباعة الفاتورة";
            btnExportCustomer.UseVisualStyleBackColor = true;
            btnExportCustomer.Visible = false;
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
            lblEmptyData.TabIndex = 24;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvSales
            // 
            DgvSales.AllowUserToAddRows = false;
            DgvSales.AllowUserToResizeColumns = false;
            DgvSales.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvSales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvSales.BackgroundColor = Color.White;
            DgvSales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvSales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvSales.ColumnHeadersHeight = 40;
            DgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvSales.DefaultCellStyle = dataGridViewCellStyle3;
            DgvSales.Dock = DockStyle.Fill;
            DgvSales.EnableHeadersVisualStyles = false;
            DgvSales.GridColor = SystemColors.ControlDark;
            DgvSales.Location = new Point(0, 164);
            DgvSales.MultiSelect = false;
            DgvSales.Name = "DgvSales";
            DgvSales.ReadOnly = true;
            DgvSales.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvSales.RowHeadersVisible = false;
            DgvSales.RowHeadersWidth = 21;
            DgvSales.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvSales.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvSales.Size = new Size(1034, 517);
            DgvSales.TabIndex = 25;
            // 
            // ReturnsReportsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblEmptyData);
            Controls.Add(DgvSales);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReturnsReportsUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            gbPayChoiches.PerformLayout();
            flowLayoutPanelreturnsoption.ResumeLayout(false);
            flowLayoutPanelreturnsoption.PerformLayout();
            panelstatisticsandOperations.ResumeLayout(false);
            panelstatisticsandOperations.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvSales).EndInit();
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
        private RadioButton rbDateSearch;
        private Panel panelstatisticsandOperations;
        private Label lblTitleForm;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblTotalDebt;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel panelButtons;
        private Button button2;
        private Button btnExportCustomer;
        private Label lblEmptyData;
        private DataGridView DgvSales;
        private FlowLayoutPanel flowLayoutPanelreturnsoption;
        private RadioButton rbRefundAll;
        private RadioButton rbRefundSales;
        private RadioButton rbBoth;
        private RadioButton rbRefundBuys;
    }
}
