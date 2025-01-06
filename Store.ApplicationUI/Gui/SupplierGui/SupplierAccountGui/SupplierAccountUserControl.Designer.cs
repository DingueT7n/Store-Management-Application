namespace Store.ApplicationUI.Gui.SupplierGui.SupplierAccountGui
{
    partial class SupplierAccountUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierAccountUserControl));
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            lblPayAllDebts = new Label();
            lblPayFacture = new Label();
            rbPayAllFactures = new RadioButton();
            txtPayAmout = new TextBox();
            rbPayPartialFacture = new RadioButton();
            rbPayFacture = new RadioButton();
            btnPay = new Button();
            panelstatisticsandOperations = new Panel();
            lblTitleForm = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblTotalDebt = new Label();
            lblTotalCustomers = new Label();
            lblTotalFactures = new Label();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panelButtons = new Panel();
            button2 = new Button();
            button1 = new Button();
            btnExportCustomer = new Button();
            btnRefresh = new Button();
            lblEmptyData = new Label();
            DgvِCustomer = new DataGridView();
            toolTip1 = new ToolTip(components);
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SearchPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِCustomer).BeginInit();
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
            OperationsflowLayoutPanel.Size = new Size(1034, 168);
            OperationsflowLayoutPanel.TabIndex = 11;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(lblPayAllDebts);
            gbPayChoiches.Controls.Add(lblPayFacture);
            gbPayChoiches.Controls.Add(rbPayAllFactures);
            gbPayChoiches.Controls.Add(txtPayAmout);
            gbPayChoiches.Controls.Add(rbPayPartialFacture);
            gbPayChoiches.Controls.Add(rbPayFacture);
            gbPayChoiches.Controls.Add(btnPay);
            gbPayChoiches.Location = new Point(574, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(457, 158);
            gbPayChoiches.TabIndex = 8;
            gbPayChoiches.TabStop = false;
            gbPayChoiches.Text = "اختيارات الدفع";
            // 
            // lblPayAllDebts
            // 
            lblPayAllDebts.AutoSize = true;
            lblPayAllDebts.ImeMode = ImeMode.NoControl;
            lblPayAllDebts.Location = new Point(112, 106);
            lblPayAllDebts.Name = "lblPayAllDebts";
            lblPayAllDebts.Size = new Size(81, 19);
            lblPayAllDebts.TabIndex = 10;
            lblPayAllDebts.Text = "000000000";
            // 
            // lblPayFacture
            // 
            lblPayFacture.AutoSize = true;
            lblPayFacture.ImeMode = ImeMode.NoControl;
            lblPayFacture.Location = new Point(106, 30);
            lblPayFacture.Name = "lblPayFacture";
            lblPayFacture.Size = new Size(144, 19);
            lblPayFacture.TabIndex = 9;
            lblPayFacture.Text = "فاتورة رقم 0 الدين : 000";
            // 
            // rbPayAllFactures
            // 
            rbPayAllFactures.AutoSize = true;
            rbPayAllFactures.ImeMode = ImeMode.NoControl;
            rbPayAllFactures.Location = new Point(196, 104);
            rbPayAllFactures.Name = "rbPayAllFactures";
            rbPayAllFactures.Size = new Size(248, 23);
            rbPayAllFactures.TabIndex = 8;
            rbPayAllFactures.Text = "دفع جميع الديون في الجدول المقدرة ب :";
            rbPayAllFactures.UseVisualStyleBackColor = true;
            // 
            // txtPayAmout
            // 
            txtPayAmout.Enabled = false;
            txtPayAmout.Location = new Point(106, 65);
            txtPayAmout.Name = "txtPayAmout";
            txtPayAmout.Size = new Size(181, 27);
            txtPayAmout.TabIndex = 7;
            txtPayAmout.KeyPress += txtPayAmout_KeyPress;
            // 
            // rbPayPartialFacture
            // 
            rbPayPartialFacture.AutoSize = true;
            rbPayPartialFacture.ImeMode = ImeMode.NoControl;
            rbPayPartialFacture.Location = new Point(304, 66);
            rbPayPartialFacture.Name = "rbPayPartialFacture";
            rbPayPartialFacture.Size = new Size(140, 23);
            rbPayPartialFacture.TabIndex = 6;
            rbPayPartialFacture.Text = "دفع جزء من الفاتورة:";
            rbPayPartialFacture.UseVisualStyleBackColor = true;
            rbPayPartialFacture.CheckedChanged += rbPayPartialFacture_CheckedChanged;
            // 
            // rbPayFacture
            // 
            rbPayFacture.AutoSize = true;
            rbPayFacture.Checked = true;
            rbPayFacture.ImeMode = ImeMode.NoControl;
            rbPayFacture.Location = new Point(319, 26);
            rbPayFacture.Name = "rbPayFacture";
            rbPayFacture.Size = new Size(125, 23);
            rbPayFacture.TabIndex = 5;
            rbPayFacture.TabStop = true;
            rbPayFacture.Text = "دفع الفاتورة كاملة:";
            rbPayFacture.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            btnPay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPay.Image = (Image)resources.GetObject("btnPay.Image");
            btnPay.ImageAlign = ContentAlignment.MiddleLeft;
            btnPay.ImeMode = ImeMode.NoControl;
            btnPay.Location = new Point(6, 112);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(100, 40);
            btnPay.TabIndex = 4;
            btnPay.Text = "       دفع الآن ";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
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
            lblTitleForm.Font = new Font("Calibri", 14.25F);
            lblTitleForm.ForeColor = Color.Red;
            lblTitleForm.ImeMode = ImeMode.NoControl;
            lblTitleForm.Location = new Point(53, 5);
            lblTitleForm.Margin = new Padding(3);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(194, 23);
            lblTitleForm.TabIndex = 14;
            lblTitleForm.Text = "حسابات الموردين والدين لهم:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lblTotalDebt);
            flowLayoutPanel1.Controls.Add(lblTotalCustomers);
            flowLayoutPanel1.Controls.Add(lblTotalFactures);
            flowLayoutPanel1.Location = new Point(27, 79);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(247, 76);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // lblTotalDebt
            // 
            lblTotalDebt.AutoSize = true;
            lblTotalDebt.ImeMode = ImeMode.NoControl;
            lblTotalDebt.Location = new Point(82, 3);
            lblTotalDebt.Margin = new Padding(3);
            lblTotalDebt.Name = "lblTotalDebt";
            lblTotalDebt.Size = new Size(162, 19);
            lblTotalDebt.TabIndex = 9;
            lblTotalDebt.Text = "مجموع الديون على الموردين:";
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.ImeMode = ImeMode.NoControl;
            lblTotalCustomers.Location = new Point(121, 28);
            lblTotalCustomers.Margin = new Padding(3);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(123, 19);
            lblTotalCustomers.TabIndex = 10;
            lblTotalCustomers.Text = "مجموع الموردين:000";
            // 
            // lblTotalFactures
            // 
            lblTotalFactures.AutoSize = true;
            lblTotalFactures.ImeMode = ImeMode.NoControl;
            lblTotalFactures.Location = new Point(72, 53);
            lblTotalFactures.Margin = new Padding(3);
            lblTotalFactures.Name = "lblTotalFactures";
            lblTotalFactures.Size = new Size(172, 19);
            lblTotalFactures.TabIndex = 11;
            lblTotalFactures.Text = "مجموع الفواتير في الجدول:000";
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
            txtSearch.PlaceholderText = "ابحث عن مورد او رقم فاتورة";
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
            button2.Location = new Point(4, 110);
            button2.Name = "button2";
            button2.Size = new Size(244, 40);
            button2.TabIndex = 8;
            button2.Text = "طباعة فاتورة المورد A4";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.ImeMode = ImeMode.NoControl;
            button1.Location = new Point(4, 61);
            button1.Name = "button1";
            button1.Size = new Size(244, 40);
            button1.TabIndex = 7;
            button1.Text = "طباعة الفاتورة المحددة 8cm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnExportCustomer
            // 
            btnExportCustomer.Anchor = AnchorStyles.None;
            btnExportCustomer.Image = (Image)resources.GetObject("btnExportCustomer.Image");
            btnExportCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportCustomer.ImeMode = ImeMode.NoControl;
            btnExportCustomer.Location = new Point(4, 11);
            btnExportCustomer.Name = "btnExportCustomer";
            btnExportCustomer.Size = new Size(244, 40);
            btnExportCustomer.TabIndex = 6;
            btnExportCustomer.Text = "طباعة فاتورة حسابات الموردين";
            btnExportCustomer.UseVisualStyleBackColor = true;
            btnExportCustomer.Click += btnExportCustomer_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImeMode = ImeMode.NoControl;
            btnRefresh.Location = new Point(981, 638);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(50, 40);
            btnRefresh.TabIndex = 18;
            toolTip1.SetToolTip(btnRefresh, "اعادة التحميل");
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
            lblEmptyData.TabIndex = 16;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvِCustomer
            // 
            DgvِCustomer.AllowUserToAddRows = false;
            DgvِCustomer.AllowUserToResizeColumns = false;
            DgvِCustomer.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            DgvِCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvِCustomer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvِCustomer.BackgroundColor = Color.White;
            DgvِCustomer.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvِCustomer.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            DgvِCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            DgvِCustomer.ColumnHeadersHeight = 40;
            DgvِCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            DgvِCustomer.DefaultCellStyle = dataGridViewCellStyle7;
            DgvِCustomer.Dock = DockStyle.Fill;
            DgvِCustomer.EnableHeadersVisualStyles = false;
            DgvِCustomer.GridColor = SystemColors.ControlDark;
            DgvِCustomer.Location = new Point(0, 168);
            DgvِCustomer.MultiSelect = false;
            DgvِCustomer.Name = "DgvِCustomer";
            DgvِCustomer.ReadOnly = true;
            DgvِCustomer.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvِCustomer.RowHeadersVisible = false;
            DgvِCustomer.RowHeadersWidth = 21;
            DgvِCustomer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِCustomer.RowsDefaultCellStyle = dataGridViewCellStyle8;
            DgvِCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvِCustomer.Size = new Size(1034, 513);
            DgvِCustomer.TabIndex = 17;
            // 
            // SupplierAccountUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnRefresh);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvِCustomer);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SupplierAccountUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            gbPayChoiches.PerformLayout();
            panelstatisticsandOperations.ResumeLayout(false);
            panelstatisticsandOperations.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvِCustomer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private GroupBox gbPayChoiches;
        private Label lblPayAllDebts;
        private Label lblPayFacture;
        private RadioButton rbPayAllFactures;
        private TextBox txtPayAmout;
        private RadioButton rbPayPartialFacture;
        private RadioButton rbPayFacture;
        private Button btnPay;
        private Panel panelstatisticsandOperations;
        private Label lblTitleForm;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblTotalDebt;
        private Label lblTotalCustomers;
        private Label lblTotalFactures;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel panelButtons;
        private Button button2;
        private Button button1;
        private Button btnExportCustomer;
        private Button btnRefresh;
        private Label lblEmptyData;
        private DataGridView DgvِCustomer;
        private ToolTip toolTip1;
    }
}
