namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreInventoryGui
{
    partial class StoreInventoryUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreInventoryUserControl));
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            flowLayoutPanelreturnsoption = new FlowLayoutPanel();
            rbStoreAll = new RadioButton();
            rbSelectedStore = new RadioButton();
            cmbStores = new ComboBox();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panelstatisticsandOperations = new Panel();
            lblTitleForm = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panelButtons = new Panel();
            button1 = new Button();
            button2 = new Button();
            btnExportCustomer = new Button();
            lblEmptyData = new Label();
            DgvSales = new DataGridView();
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            flowLayoutPanelreturnsoption.SuspendLayout();
            SearchPanel.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
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
            OperationsflowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1034, 164);
            OperationsflowLayoutPanel.TabIndex = 15;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(flowLayoutPanelreturnsoption);
            gbPayChoiches.Location = new Point(574, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(457, 158);
            gbPayChoiches.TabIndex = 8;
            gbPayChoiches.TabStop = false;
            gbPayChoiches.Text = "اختيارات البحث";
            // 
            // flowLayoutPanelreturnsoption
            // 
            flowLayoutPanelreturnsoption.Controls.Add(rbStoreAll);
            flowLayoutPanelreturnsoption.Controls.Add(rbSelectedStore);
            flowLayoutPanelreturnsoption.Controls.Add(cmbStores);
            flowLayoutPanelreturnsoption.Controls.Add(SearchPanel);
            flowLayoutPanelreturnsoption.Dock = DockStyle.Top;
            flowLayoutPanelreturnsoption.Location = new Point(3, 23);
            flowLayoutPanelreturnsoption.Name = "flowLayoutPanelreturnsoption";
            flowLayoutPanelreturnsoption.Size = new Size(451, 129);
            flowLayoutPanelreturnsoption.TabIndex = 28;
            // 
            // rbStoreAll
            // 
            rbStoreAll.AutoSize = true;
            rbStoreAll.Checked = true;
            rbStoreAll.ImeMode = ImeMode.NoControl;
            rbStoreAll.Location = new Point(348, 15);
            rbStoreAll.Margin = new Padding(15, 15, 15, 3);
            rbStoreAll.Name = "rbStoreAll";
            rbStoreAll.Size = new Size(88, 23);
            rbStoreAll.TabIndex = 6;
            rbStoreAll.TabStop = true;
            rbStoreAll.Text = "كل المخازن";
            rbStoreAll.UseVisualStyleBackColor = true;
            rbStoreAll.CheckedChanged += rbStoreAll_CheckedChanged;
            // 
            // rbSelectedStore
            // 
            rbSelectedStore.AutoSize = true;
            rbSelectedStore.BackColor = Color.White;
            rbSelectedStore.ForeColor = Color.Green;
            rbSelectedStore.ImeMode = ImeMode.NoControl;
            rbSelectedStore.Location = new Point(226, 15);
            rbSelectedStore.Margin = new Padding(15, 15, 15, 3);
            rbSelectedStore.Name = "rbSelectedStore";
            rbSelectedStore.Size = new Size(92, 23);
            rbSelectedStore.TabIndex = 7;
            rbSelectedStore.Text = "مخزن محدد";
            rbSelectedStore.UseVisualStyleBackColor = false;
            rbSelectedStore.CheckedChanged += rbSelectedStore_CheckedChanged;
            // 
            // cmbStores
            // 
            cmbStores.Enabled = false;
            cmbStores.FormattingEnabled = true;
            cmbStores.Location = new Point(16, 15);
            cmbStores.Margin = new Padding(3, 15, 3, 3);
            cmbStores.Name = "cmbStores";
            cmbStores.Size = new Size(192, 27);
            cmbStores.TabIndex = 8;
            cmbStores.SelectionChangeCommitted += cmbStores_SelectionChangeCommitted;
            // 
            // SearchPanel
            // 
            SearchPanel.Controls.Add(txtSearch);
            SearchPanel.Controls.Add(btnSearch);
            SearchPanel.Location = new Point(97, 60);
            SearchPanel.Margin = new Padding(60, 15, 3, 3);
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
            txtSearch.PlaceholderText = "البحث عن طريق الباركود";
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
            // panelstatisticsandOperations
            // 
            panelstatisticsandOperations.Controls.Add(lblTitleForm);
            panelstatisticsandOperations.Controls.Add(flowLayoutPanel1);
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
            lblTitleForm.Size = new Size(127, 23);
            lblTitleForm.TabIndex = 13;
            lblTitleForm.Text = "شاشة جرد المخازن";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(3, 46);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(294, 109);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(button1);
            panelButtons.Controls.Add(button2);
            panelButtons.Controls.Add(btnExportCustomer);
            panelButtons.Location = new Point(3, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(259, 158);
            panelButtons.TabIndex = 9;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.ImeMode = ImeMode.NoControl;
            button1.Location = new Point(3, 50);
            button1.Name = "button1";
            button1.Size = new Size(249, 40);
            button1.TabIndex = 9;
            button1.Text = "اخراج المنتجات التالفة من مخزن";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.ImeMode = ImeMode.NoControl;
            button2.Location = new Point(3, 0);
            button2.Name = "button2";
            button2.Size = new Size(249, 40);
            button2.TabIndex = 8;
            button2.Text = "تحويل المنتجات بين المخازن";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnExportCustomer
            // 
            btnExportCustomer.Anchor = AnchorStyles.None;
            btnExportCustomer.Image = (Image)resources.GetObject("btnExportCustomer.Image");
            btnExportCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportCustomer.ImeMode = ImeMode.NoControl;
            btnExportCustomer.Location = new Point(3, 99);
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
            dataGridViewCellStyle9.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            DgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvSales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvSales.BackgroundColor = Color.White;
            DgvSales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvSales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle10.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            DgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            DgvSales.ColumnHeadersHeight = 40;
            DgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            DgvSales.DefaultCellStyle = dataGridViewCellStyle11;
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
            dataGridViewCellStyle12.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvSales.RowsDefaultCellStyle = dataGridViewCellStyle12;
            DgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvSales.Size = new Size(1034, 517);
            DgvSales.TabIndex = 27;
            // 
            // StoreInventoryUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblEmptyData);
            Controls.Add(DgvSales);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StoreInventoryUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            flowLayoutPanelreturnsoption.ResumeLayout(false);
            flowLayoutPanelreturnsoption.PerformLayout();
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            panelstatisticsandOperations.ResumeLayout(false);
            panelstatisticsandOperations.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private GroupBox gbPayChoiches;
        private FlowLayoutPanel flowLayoutPanelreturnsoption;
        private RadioButton rbStoreAll;
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
        private RadioButton rbSelectedStore;
        private ComboBox cmbStores;
        private Button button1;
    }
}
