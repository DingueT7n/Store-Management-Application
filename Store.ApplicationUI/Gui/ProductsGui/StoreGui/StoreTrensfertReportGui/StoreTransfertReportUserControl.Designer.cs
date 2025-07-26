namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreTrensfertReportGui
{
    partial class StoreTransfertReportUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreTransfertReportUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            cmbStoresTo = new ComboBox();
            rbAllStoresTo = new RadioButton();
            rbStoresTo = new RadioButton();
            flowLayoutPanelreturnsoption = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            cmbStoresFrom = new ComboBox();
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
            flowLayoutPanel2.SuspendLayout();
            groupBox2.SuspendLayout();
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
            OperationsflowLayoutPanel.TabIndex = 15;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(flowLayoutPanel2);
            gbPayChoiches.Controls.Add(flowLayoutPanelreturnsoption);
            gbPayChoiches.Location = new Point(574, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(457, 165);
            gbPayChoiches.TabIndex = 8;
            gbPayChoiches.TabStop = false;
            gbPayChoiches.Text = "اختيارات البحث";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(groupBox2);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(3, 73);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(451, 50);
            flowLayoutPanel2.TabIndex = 29;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbStoresTo);
            groupBox2.Controls.Add(rbAllStoresTo);
            groupBox2.Controls.Add(rbStoresTo);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(445, 47);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "المخازن المحول لها";
            // 
            // cmbStoresTo
            // 
            cmbStoresTo.Enabled = false;
            cmbStoresTo.FormattingEnabled = true;
            cmbStoresTo.Location = new Point(18, 15);
            cmbStoresTo.Margin = new Padding(3, 15, 3, 3);
            cmbStoresTo.Name = "cmbStoresTo";
            cmbStoresTo.Size = new Size(156, 27);
            cmbStoresTo.TabIndex = 9;
            // 
            // rbAllStoresTo
            // 
            rbAllStoresTo.AutoSize = true;
            rbAllStoresTo.Checked = true;
            rbAllStoresTo.ImeMode = ImeMode.NoControl;
            rbAllStoresTo.Location = new Point(339, 18);
            rbAllStoresTo.Margin = new Padding(15, 3, 15, 3);
            rbAllStoresTo.Name = "rbAllStoresTo";
            rbAllStoresTo.Size = new Size(88, 23);
            rbAllStoresTo.TabIndex = 6;
            rbAllStoresTo.TabStop = true;
            rbAllStoresTo.Text = "كل المخازن";
            rbAllStoresTo.UseVisualStyleBackColor = true;
            rbAllStoresTo.CheckedChanged += rbAllStoresTo_CheckedChanged;
            // 
            // rbStoresTo
            // 
            rbStoresTo.AutoSize = true;
            rbStoresTo.BackColor = Color.White;
            rbStoresTo.ForeColor = Color.Green;
            rbStoresTo.ImeMode = ImeMode.NoControl;
            rbStoresTo.Location = new Point(202, 18);
            rbStoresTo.Margin = new Padding(15, 3, 15, 3);
            rbStoresTo.Name = "rbStoresTo";
            rbStoresTo.Size = new Size(92, 23);
            rbStoresTo.TabIndex = 7;
            rbStoresTo.Text = "مخزن محدد";
            rbStoresTo.UseVisualStyleBackColor = false;
            rbStoresTo.CheckedChanged += rbStoresTo_CheckedChanged;
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
            groupBox1.Controls.Add(cmbStoresFrom);
            groupBox1.Controls.Add(rbStoresFromAll);
            groupBox1.Controls.Add(rbStoresFrom);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(445, 47);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "المخازن المحول منها";
            // 
            // cmbStoresFrom
            // 
            cmbStoresFrom.Enabled = false;
            cmbStoresFrom.FormattingEnabled = true;
            cmbStoresFrom.Location = new Point(18, 15);
            cmbStoresFrom.Margin = new Padding(3, 15, 3, 3);
            cmbStoresFrom.Name = "cmbStoresFrom";
            cmbStoresFrom.Size = new Size(156, 27);
            cmbStoresFrom.TabIndex = 9;
            // 
            // rbStoresFromAll
            // 
            rbStoresFromAll.AutoSize = true;
            rbStoresFromAll.Checked = true;
            rbStoresFromAll.ImeMode = ImeMode.NoControl;
            rbStoresFromAll.Location = new Point(339, 18);
            rbStoresFromAll.Margin = new Padding(15, 3, 15, 3);
            rbStoresFromAll.Name = "rbStoresFromAll";
            rbStoresFromAll.Size = new Size(88, 23);
            rbStoresFromAll.TabIndex = 6;
            rbStoresFromAll.TabStop = true;
            rbStoresFromAll.Text = "كل المخازن";
            rbStoresFromAll.UseVisualStyleBackColor = true;
            rbStoresFromAll.CheckedChanged += rbStoresFromAll_CheckedChanged;
            // 
            // rbStoresFrom
            // 
            rbStoresFrom.AutoSize = true;
            rbStoresFrom.BackColor = Color.White;
            rbStoresFrom.ForeColor = Color.Green;
            rbStoresFrom.ImeMode = ImeMode.NoControl;
            rbStoresFrom.Location = new Point(202, 18);
            rbStoresFrom.Margin = new Padding(15, 3, 15, 3);
            rbStoresFrom.Name = "rbStoresFrom";
            rbStoresFrom.Size = new Size(92, 23);
            rbStoresFrom.TabIndex = 7;
            rbStoresFrom.Text = "مخزن محدد";
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
            lblTitleForm.Location = new Point(13, 4);
            lblTitleForm.Margin = new Padding(3);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(272, 23);
            lblTitleForm.TabIndex = 13;
            lblTitleForm.Text = "تقرير جميع المنتجات المحولة بين المخازن";
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
            txtSearch.PlaceholderText = "ادخل معلومة للبحث مثال الباركود";
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
            panelButtons.Size = new Size(251, 165);
            panelButtons.TabIndex = 9;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.ImeMode = ImeMode.NoControl;
            button2.Location = new Point(0, 12);
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
            btnExportCustomer.Location = new Point(3, 58);
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
            lblEmptyData.TabIndex = 26;
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
            DgvSales.TabIndex = 27;
            // 
            // StoreTransfertReportUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblEmptyData);
            Controls.Add(DgvSales);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StoreTransfertReportUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            Load += StoreTransfertReportUserControl_Load;
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private FlowLayoutPanel flowLayoutPanelreturnsoption;
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
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel2;
        private GroupBox groupBox2;
        private ComboBox cmbStoresTo;
        private RadioButton rbAllStoresTo;
        private RadioButton rbStoresTo;
        private ComboBox cmbStoresFrom;
    }
}
