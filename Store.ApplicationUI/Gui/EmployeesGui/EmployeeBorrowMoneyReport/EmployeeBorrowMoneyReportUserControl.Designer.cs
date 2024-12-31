namespace Store.ApplicationUI.Gui.EmployeesGui.EmployeeBorrowMoneyReport
{
    partial class EmployeeBorrowMoneyReportUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeBorrowMoneyReportUserControl));
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
            flowLayoutPanelreturnsoption = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            cmbEmployees = new ComboBox();
            rbStoresFromAll = new RadioButton();
            rbStoresFrom = new RadioButton();
            panelstatisticsandOperations = new Panel();
            lblTitleForm = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
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
            groupBox1.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
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
            OperationsflowLayoutPanel.Size = new Size(1034, 174);
            OperationsflowLayoutPanel.TabIndex = 18;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(dtpFrom);
            gbPayChoiches.Controls.Add(dtpTo);
            gbPayChoiches.Controls.Add(lblTo);
            gbPayChoiches.Controls.Add(lblFrom);
            gbPayChoiches.Controls.Add(flowLayoutPanelreturnsoption);
            gbPayChoiches.Location = new Point(574, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(457, 165);
            gbPayChoiches.TabIndex = 8;
            gbPayChoiches.TabStop = false;
            gbPayChoiches.Text = "اختيارات البحث";
            // 
            // dtpFrom
            // 
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(245, 111);
            dtpFrom.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(119, 27);
            dtpFrom.TabIndex = 33;
            dtpFrom.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // dtpTo
            // 
            dtpTo.CustomFormat = "yyyy-MM-dd";
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(83, 111);
            dtpTo.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(119, 27);
            dtpTo.TabIndex = 32;
            dtpTo.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.ImeMode = ImeMode.NoControl;
            lblTo.Location = new Point(208, 113);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(27, 19);
            lblTo.TabIndex = 31;
            lblTo.Text = "الى:";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.ImeMode = ImeMode.NoControl;
            lblFrom.Location = new Point(365, 114);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(28, 19);
            lblFrom.TabIndex = 30;
            lblFrom.Text = "من:";
            // 
            // flowLayoutPanelreturnsoption
            // 
            flowLayoutPanelreturnsoption.Controls.Add(groupBox1);
            flowLayoutPanelreturnsoption.Dock = DockStyle.Top;
            flowLayoutPanelreturnsoption.Location = new Point(3, 23);
            flowLayoutPanelreturnsoption.Name = "flowLayoutPanelreturnsoption";
            flowLayoutPanelreturnsoption.Size = new Size(451, 50);
            flowLayoutPanelreturnsoption.TabIndex = 28;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbEmployees);
            groupBox1.Controls.Add(rbStoresFromAll);
            groupBox1.Controls.Add(rbStoresFrom);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(445, 47);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "المخازن المحول منها";
            // 
            // cmbEmployees
            // 
            cmbEmployees.Enabled = false;
            cmbEmployees.FormattingEnabled = true;
            cmbEmployees.Location = new Point(6, 15);
            cmbEmployees.Margin = new Padding(3, 15, 3, 3);
            cmbEmployees.Name = "cmbEmployees";
            cmbEmployees.Size = new Size(156, 27);
            cmbEmployees.TabIndex = 9;
            cmbEmployees.SelectionChangeCommitted += cmbEmployees_SelectionChangeCommitted;
            // 
            // rbStoresFromAll
            // 
            rbStoresFromAll.AutoSize = true;
            rbStoresFromAll.Checked = true;
            rbStoresFromAll.ImeMode = ImeMode.NoControl;
            rbStoresFromAll.Location = new Point(273, 18);
            rbStoresFromAll.Margin = new Padding(15, 3, 15, 3);
            rbStoresFromAll.Name = "rbStoresFromAll";
            rbStoresFromAll.Size = new Size(160, 23);
            rbStoresFromAll.TabIndex = 6;
            rbStoresFromAll.TabStop = true;
            rbStoresFromAll.Text = "كل الموظفين والاشخاص";
            rbStoresFromAll.UseVisualStyleBackColor = true;
            rbStoresFromAll.CheckedChanged += rbStoresFromAll_CheckedChanged;
            // 
            // rbStoresFrom
            // 
            rbStoresFrom.AutoSize = true;
            rbStoresFrom.BackColor = Color.White;
            rbStoresFrom.ForeColor = Color.Green;
            rbStoresFrom.ImeMode = ImeMode.NoControl;
            rbStoresFrom.Location = new Point(168, 18);
            rbStoresFrom.Margin = new Padding(15, 3, 15, 3);
            rbStoresFrom.Name = "rbStoresFrom";
            rbStoresFrom.Size = new Size(99, 23);
            rbStoresFrom.TabIndex = 7;
            rbStoresFrom.Text = "موظف محدد";
            rbStoresFrom.UseVisualStyleBackColor = false;
            rbStoresFrom.CheckedChanged += rbStoresFrom_CheckedChanged;
            // 
            // panelstatisticsandOperations
            // 
            panelstatisticsandOperations.Controls.Add(lblTitleForm);
            panelstatisticsandOperations.Controls.Add(flowLayoutPanel1);
            panelstatisticsandOperations.Controls.Add(SearchPanel);
            panelstatisticsandOperations.Location = new Point(268, 3);
            panelstatisticsandOperations.Name = "panelstatisticsandOperations";
            panelstatisticsandOperations.Size = new Size(300, 165);
            panelstatisticsandOperations.TabIndex = 10;
            // 
            // lblTitleForm
            // 
            lblTitleForm.AutoSize = true;
            lblTitleForm.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleForm.ForeColor = Color.Red;
            lblTitleForm.ImeMode = ImeMode.NoControl;
            lblTitleForm.Location = new Point(103, 4);
            lblTitleForm.Margin = new Padding(3);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(105, 23);
            lblTitleForm.TabIndex = 13;
            lblTitleForm.Text = "تقرير السلفيات";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(25, 79);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(247, 76);
            flowLayoutPanel1.TabIndex = 12;
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
            txtSearch.PlaceholderText = "ادخل اسم الشخص";
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
            // panelButtons
            // 
            panelButtons.Controls.Add(button2);
            panelButtons.Controls.Add(btnExportCustomer);
            panelButtons.Location = new Point(11, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(251, 165);
            panelButtons.TabIndex = 9;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.ImeMode = ImeMode.NoControl;
            button2.Location = new Point(3, 4);
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
            btnExportCustomer.Location = new Point(4, 50);
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
            lblEmptyData.TabIndex = 32;
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
            DgvSales.Location = new Point(0, 174);
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
            DgvSales.Size = new Size(1034, 507);
            DgvSales.TabIndex = 33;
            // 
            // EmployeeBorrowMoneyReportUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblEmptyData);
            Controls.Add(DgvSales);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EmployeeBorrowMoneyReportUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            gbPayChoiches.PerformLayout();
            flowLayoutPanelreturnsoption.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelstatisticsandOperations.ResumeLayout(false);
            panelstatisticsandOperations.PerformLayout();
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
        private FlowLayoutPanel flowLayoutPanelreturnsoption;
        private GroupBox groupBox1;
        private ComboBox cmbEmployees;
        private RadioButton rbStoresFromAll;
        private RadioButton rbStoresFrom;
        private Panel panelstatisticsandOperations;
        private Label lblTitleForm;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel panelButtons;
        private Button button2;
        private Button btnExportCustomer;
        private Label lblEmptyData;
        private DataGridView DgvSales;
    }
}
