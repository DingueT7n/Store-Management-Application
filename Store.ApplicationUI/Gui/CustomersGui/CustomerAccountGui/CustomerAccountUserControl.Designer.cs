namespace Store.ApplicationUI.Gui.CustomersGui.CustomerAccountGui
{
    partial class CustomerAccountUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerAccountUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            lblPayAllDebts = new Label();
            lblPayFacture = new Label();
            radioButton3 = new RadioButton();
            txtPayAmout = new TextBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            btnPay = new Button();
            panelstatisticsandOperations = new Panel();
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
            toolTip1 = new ToolTip(components);
            btnRefresh = new Button();
            lblEmptyData = new Label();
            DgvِCustomer = new DataGridView();
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
            OperationsflowLayoutPanel.Size = new Size(1034, 164);
            OperationsflowLayoutPanel.TabIndex = 10;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(lblPayAllDebts);
            gbPayChoiches.Controls.Add(lblPayFacture);
            gbPayChoiches.Controls.Add(radioButton3);
            gbPayChoiches.Controls.Add(txtPayAmout);
            gbPayChoiches.Controls.Add(radioButton2);
            gbPayChoiches.Controls.Add(radioButton1);
            gbPayChoiches.Controls.Add(btnPay);
            gbPayChoiches.Location = new Point(584, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(447, 155);
            gbPayChoiches.TabIndex = 8;
            gbPayChoiches.TabStop = false;
            gbPayChoiches.Text = "اختيارات الدفع";
            // 
            // lblPayAllDebts
            // 
            lblPayAllDebts.AutoSize = true;
            lblPayAllDebts.Location = new Point(151, 105);
            lblPayAllDebts.Name = "lblPayAllDebts";
            lblPayAllDebts.Size = new Size(41, 19);
            lblPayAllDebts.TabIndex = 10;
            lblPayAllDebts.Text = "0000";
            // 
            // lblPayFacture
            // 
            lblPayFacture.AutoSize = true;
            lblPayFacture.Location = new Point(106, 30);
            lblPayFacture.Name = "lblPayFacture";
            lblPayFacture.Size = new Size(144, 19);
            lblPayFacture.TabIndex = 9;
            lblPayFacture.Text = "فاتورة رقم 0 الدين : 000";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(243, 105);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(190, 23);
            radioButton3.TabIndex = 8;
            radioButton3.TabStop = true;
            radioButton3.Text = "دفع جميع الديون المقدرة ب :";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // txtPayAmout
            // 
            txtPayAmout.Location = new Point(106, 65);
            txtPayAmout.Name = "txtPayAmout";
            txtPayAmout.Size = new Size(181, 27);
            txtPayAmout.TabIndex = 7;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(293, 66);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(140, 23);
            radioButton2.TabIndex = 6;
            radioButton2.TabStop = true;
            radioButton2.Text = "دفع جزء من الفاتورة:";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(308, 26);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(125, 23);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "دفع الفاتورة كاملة:";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            btnPay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPay.Image = (Image)resources.GetObject("btnPay.Image");
            btnPay.ImageAlign = ContentAlignment.MiddleLeft;
            btnPay.Location = new Point(6, 109);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(100, 40);
            btnPay.TabIndex = 4;
            btnPay.Text = "       دفع الآن ";
            btnPay.UseVisualStyleBackColor = true;
            // 
            // panelstatisticsandOperations
            // 
            panelstatisticsandOperations.Controls.Add(flowLayoutPanel1);
            panelstatisticsandOperations.Controls.Add(SearchPanel);
            panelstatisticsandOperations.Location = new Point(278, 3);
            panelstatisticsandOperations.Name = "panelstatisticsandOperations";
            panelstatisticsandOperations.Size = new Size(300, 155);
            panelstatisticsandOperations.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lblTotalDebt);
            flowLayoutPanel1.Controls.Add(lblTotalCustomers);
            flowLayoutPanel1.Controls.Add(lblTotalFactures);
            flowLayoutPanel1.Location = new Point(20, 55);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(247, 94);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // lblTotalDebt
            // 
            lblTotalDebt.AutoSize = true;
            lblTotalDebt.Location = new Point(92, 3);
            lblTotalDebt.Margin = new Padding(3);
            lblTotalDebt.Name = "lblTotalDebt";
            lblTotalDebt.Size = new Size(152, 19);
            lblTotalDebt.TabIndex = 9;
            lblTotalDebt.Text = "مجموع الديون على العملاء:";
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Location = new Point(131, 28);
            lblTotalCustomers.Margin = new Padding(3);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(113, 19);
            lblTotalCustomers.TabIndex = 10;
            lblTotalCustomers.Text = "مجموع العملاء:000";
            // 
            // lblTotalFactures
            // 
            lblTotalFactures.AutoSize = true;
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
            SearchPanel.Location = new Point(3, 9);
            SearchPanel.Name = "SearchPanel";
            SearchPanel.Size = new Size(294, 40);
            SearchPanel.TabIndex = 8;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(50, 0);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث عن عميل او رقم فاتورة";
            txtSearch.Size = new Size(244, 40);
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
            btnSearch.Click += btnSearch_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(button2);
            panelButtons.Controls.Add(button1);
            panelButtons.Controls.Add(btnExportCustomer);
            panelButtons.Location = new Point(21, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(251, 155);
            panelButtons.TabIndex = 9;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(4, 108);
            button2.Name = "button2";
            button2.Size = new Size(244, 40);
            button2.TabIndex = 8;
            button2.Text = "      تصدير/طباعة جميع الفاتورات";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(4, 59);
            button1.Name = "button1";
            button1.Size = new Size(244, 40);
            button1.TabIndex = 7;
            button1.Text = "       تصدير/طباعة جميع فاتورات العميل";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnExportCustomer
            // 
            btnExportCustomer.Anchor = AnchorStyles.None;
            btnExportCustomer.Image = (Image)resources.GetObject("btnExportCustomer.Image");
            btnExportCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportCustomer.Location = new Point(4, 9);
            btnExportCustomer.Name = "btnExportCustomer";
            btnExportCustomer.Size = new Size(244, 40);
            btnExportCustomer.TabIndex = 6;
            btnExportCustomer.Text = "   تصدير/طباعة الفاتورة";
            btnExportCustomer.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.Location = new Point(981, 638);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(50, 40);
            btnRefresh.TabIndex = 15;
            toolTip1.SetToolTip(btnRefresh, "اعادة التحميل");
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lblEmptyData
            // 
            lblEmptyData.Anchor = AnchorStyles.None;
            lblEmptyData.AutoSize = true;
            lblEmptyData.BackColor = Color.Transparent;
            lblEmptyData.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 7);
            lblEmptyData.ForeColor = Color.Crimson;
            lblEmptyData.Location = new Point(451, 353);
            lblEmptyData.Name = "lblEmptyData";
            lblEmptyData.Size = new Size(133, 19);
            lblEmptyData.TabIndex = 13;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvِCustomer
            // 
            DgvِCustomer.AllowUserToAddRows = false;
            DgvِCustomer.AllowUserToResizeColumns = false;
            DgvِCustomer.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvِCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvِCustomer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvِCustomer.BackgroundColor = Color.White;
            DgvِCustomer.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvِCustomer.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvِCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvِCustomer.ColumnHeadersHeight = 40;
            DgvِCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvِCustomer.DefaultCellStyle = dataGridViewCellStyle3;
            DgvِCustomer.Dock = DockStyle.Fill;
            DgvِCustomer.EnableHeadersVisualStyles = false;
            DgvِCustomer.GridColor = SystemColors.ControlDark;
            DgvِCustomer.Location = new Point(0, 164);
            DgvِCustomer.MultiSelect = false;
            DgvِCustomer.Name = "DgvِCustomer";
            DgvِCustomer.ReadOnly = true;
            DgvِCustomer.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvِCustomer.RowHeadersVisible = false;
            DgvِCustomer.RowHeadersWidth = 21;
            DgvِCustomer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِCustomer.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvِCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvِCustomer.Size = new Size(1034, 517);
            DgvِCustomer.TabIndex = 14;
            // 
            // CustomerAccountUserControl
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
            Name = "CustomerAccountUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            gbPayChoiches.PerformLayout();
            panelstatisticsandOperations.ResumeLayout(false);
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
        private Button btnAddCustomer;
        private Button btnPay;
        private Button btnExportCustomer;
        private ToolTip toolTip1;
        private Button btnRefresh;
        private Label lblEmptyData;
        private DataGridView DgvِCustomer;
        private GroupBox gbPayChoiches;
        private TextBox txtPayAmout;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RadioButton radioButton3;
        private Label lblPayFacture;
        private Label lblPayAllDebts;
        private Panel panelButtons;
        private Button button1;
        private Button button2;
        private Panel panelstatisticsandOperations;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblTotalDebt;
        private Label lblTotalFactures;
        private Label lblTotalCustomers;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
