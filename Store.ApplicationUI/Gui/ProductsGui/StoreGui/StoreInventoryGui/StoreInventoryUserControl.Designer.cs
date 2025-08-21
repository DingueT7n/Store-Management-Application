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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            PanelPagination = new Panel();
            cmbpagination = new ComboBox();
            btnPrev = new Button();
            btnNext = new Button();
            lblEmptyData = new Label();
            DgvSales = new DataGridView();
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
            lblBuys = new Label();
            lblSales = new Label();
            lblProfitExpected = new Label();
            lblQtyInTable = new Label();
            lblProductInTables = new Label();
            panelButtons = new Panel();
            menuStrip1 = new MenuStrip();
            عملياتالجردالمتاحةToolStripMenuItem = new ToolStripMenuItem();
            تحويلالمنتجاتبينالمخازنToolStripMenuItem = new ToolStripMenuItem();
            اخراجالمنتجاتالتالفةمنالمخزنToolStripMenuItem = new ToolStripMenuItem();
            جردالسلعاضافةتعديلاطلاعToolStripMenuItem = new ToolStripMenuItem();
            تصديرالىملفExcelToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanelStats = new FlowLayoutPanel();
            panel1 = new Panel();
            txtAllProducts = new TextBox();
            label1 = new Label();
            panel7 = new Panel();
            txtProductSum = new TextBox();
            label7 = new Label();
            panel2 = new Panel();
            txtAllQty = new TextBox();
            label2 = new Label();
            panel4 = new Panel();
            txttotalBuy = new TextBox();
            label4 = new Label();
            panel5 = new Panel();
            txttotalSell = new TextBox();
            label5 = new Label();
            panel6 = new Panel();
            txtTotalProfitExpected = new TextBox();
            label6 = new Label();
            panel3 = new Panel();
            txtCapital = new TextBox();
            label3 = new Label();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            PanelPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvSales).BeginInit();
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            flowLayoutPanelreturnsoption.SuspendLayout();
            SearchPanel.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelButtons.SuspendLayout();
            menuStrip1.SuspendLayout();
            flowLayoutPanelStats.SuspendLayout();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1034, 681);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(PanelPagination);
            tabPage1.Controls.Add(lblEmptyData);
            tabPage1.Controls.Add(DgvSales);
            tabPage1.Controls.Add(OperationsflowLayoutPanel);
            tabPage1.Controls.Add(flowLayoutPanelStats);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1026, 649);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "شاشة تفاصيل المخازن";
            // 
            // PanelPagination
            // 
            PanelPagination.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelPagination.Controls.Add(cmbpagination);
            PanelPagination.Controls.Add(btnPrev);
            PanelPagination.Controls.Add(btnNext);
            PanelPagination.Location = new Point(6, 520);
            PanelPagination.Name = "PanelPagination";
            PanelPagination.Size = new Size(169, 40);
            PanelPagination.TabIndex = 38;
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
            lblEmptyData.TabIndex = 35;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvSales
            // 
            DgvSales.AllowUserToAddRows = false;
            DgvSales.AllowUserToResizeColumns = false;
            DgvSales.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            DgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvSales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvSales.BackgroundColor = Color.White;
            DgvSales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvSales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            DgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            DgvSales.ColumnHeadersHeight = 40;
            DgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            DgvSales.DefaultCellStyle = dataGridViewCellStyle7;
            DgvSales.Dock = DockStyle.Fill;
            DgvSales.EnableHeadersVisualStyles = false;
            DgvSales.GridColor = SystemColors.ControlDark;
            DgvSales.Location = new Point(3, 196);
            DgvSales.MultiSelect = false;
            DgvSales.Name = "DgvSales";
            DgvSales.ReadOnly = true;
            DgvSales.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvSales.RowHeadersVisible = false;
            DgvSales.RowHeadersWidth = 21;
            DgvSales.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvSales.RowsDefaultCellStyle = dataGridViewCellStyle8;
            DgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvSales.Size = new Size(1020, 370);
            DgvSales.TabIndex = 36;
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(gbPayChoiches);
            OperationsflowLayoutPanel.Controls.Add(panelstatisticsandOperations);
            OperationsflowLayoutPanel.Controls.Add(panelButtons);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(3, 3);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1020, 193);
            OperationsflowLayoutPanel.TabIndex = 34;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(flowLayoutPanelreturnsoption);
            gbPayChoiches.Location = new Point(594, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(423, 176);
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
            flowLayoutPanelreturnsoption.Size = new Size(417, 147);
            flowLayoutPanelreturnsoption.TabIndex = 28;
            // 
            // rbStoreAll
            // 
            rbStoreAll.AutoSize = true;
            rbStoreAll.Checked = true;
            rbStoreAll.ImeMode = ImeMode.NoControl;
            rbStoreAll.Location = new Point(314, 15);
            rbStoreAll.Margin = new Padding(15, 15, 15, 3);
            rbStoreAll.Name = "rbStoreAll";
            rbStoreAll.Size = new Size(88, 23);
            rbStoreAll.TabIndex = 6;
            rbStoreAll.TabStop = true;
            rbStoreAll.Text = "كل المخازن";
            rbStoreAll.UseVisualStyleBackColor = true;
            // 
            // rbSelectedStore
            // 
            rbSelectedStore.AutoSize = true;
            rbSelectedStore.BackColor = Color.White;
            rbSelectedStore.ForeColor = Color.Green;
            rbSelectedStore.ImeMode = ImeMode.NoControl;
            rbSelectedStore.Location = new Point(192, 15);
            rbSelectedStore.Margin = new Padding(15, 15, 15, 3);
            rbSelectedStore.Name = "rbSelectedStore";
            rbSelectedStore.Size = new Size(92, 23);
            rbSelectedStore.TabIndex = 7;
            rbSelectedStore.Text = "مخزن محدد";
            rbSelectedStore.UseVisualStyleBackColor = false;
            // 
            // cmbStores
            // 
            cmbStores.Enabled = false;
            cmbStores.FormattingEnabled = true;
            cmbStores.Location = new Point(10, 15);
            cmbStores.Margin = new Padding(3, 15, 3, 3);
            cmbStores.Name = "cmbStores";
            cmbStores.Size = new Size(164, 27);
            cmbStores.TabIndex = 8;
            // 
            // SearchPanel
            // 
            SearchPanel.Controls.Add(txtSearch);
            SearchPanel.Controls.Add(btnSearch);
            SearchPanel.Location = new Point(63, 60);
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
            txtSearch.PlaceholderText = "ادخل معلومة للبحث مثال الباركود";
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
            // 
            // panelstatisticsandOperations
            // 
            panelstatisticsandOperations.Controls.Add(lblTitleForm);
            panelstatisticsandOperations.Controls.Add(flowLayoutPanel1);
            panelstatisticsandOperations.Location = new Point(252, 3);
            panelstatisticsandOperations.Name = "panelstatisticsandOperations";
            panelstatisticsandOperations.Size = new Size(336, 179);
            panelstatisticsandOperations.TabIndex = 10;
            // 
            // lblTitleForm
            // 
            lblTitleForm.AutoSize = true;
            lblTitleForm.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleForm.ForeColor = Color.Red;
            lblTitleForm.ImeMode = ImeMode.NoControl;
            lblTitleForm.Location = new Point(75, 5);
            lblTitleForm.Margin = new Padding(3);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(0, 23);
            lblTitleForm.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(lblBuys);
            flowLayoutPanel1.Controls.Add(lblSales);
            flowLayoutPanel1.Controls.Add(lblProfitExpected);
            flowLayoutPanel1.Controls.Add(lblQtyInTable);
            flowLayoutPanel1.Controls.Add(lblProductInTables);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(326, 171);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // lblBuys
            // 
            lblBuys.AutoSize = true;
            lblBuys.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuys.Location = new Point(232, 10);
            lblBuys.Margin = new Padding(10);
            lblBuys.Name = "lblBuys";
            lblBuys.Size = new Size(84, 19);
            lblBuys.TabIndex = 1;
            lblBuys.Text = "مجموع الشراء";
            // 
            // lblSales
            // 
            lblSales.AutoSize = true;
            lblSales.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSales.Location = new Point(239, 49);
            lblSales.Margin = new Padding(10);
            lblSales.Name = "lblSales";
            lblSales.Size = new Size(77, 19);
            lblSales.TabIndex = 2;
            lblSales.Text = "مجموع البيع";
            // 
            // lblProfitExpected
            // 
            lblProfitExpected.AutoSize = true;
            lblProfitExpected.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfitExpected.Location = new Point(221, 88);
            lblProfitExpected.Margin = new Padding(10);
            lblProfitExpected.Name = "lblProfitExpected";
            lblProfitExpected.Size = new Size(95, 19);
            lblProfitExpected.TabIndex = 3;
            lblProfitExpected.Text = "الارباح المتوقعة";
            // 
            // lblQtyInTable
            // 
            lblQtyInTable.AutoSize = true;
            lblQtyInTable.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQtyInTable.Location = new Point(222, 127);
            lblQtyInTable.Margin = new Padding(10);
            lblQtyInTable.Name = "lblQtyInTable";
            lblQtyInTable.Size = new Size(94, 19);
            lblQtyInTable.TabIndex = 4;
            lblQtyInTable.Text = "مجموع الكميات";
            // 
            // lblProductInTables
            // 
            lblProductInTables.AutoSize = true;
            lblProductInTables.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductInTables.Location = new Point(113, 10);
            lblProductInTables.Margin = new Padding(10);
            lblProductInTables.Name = "lblProductInTables";
            lblProductInTables.Size = new Size(88, 19);
            lblProductInTables.TabIndex = 5;
            lblProductInTables.Text = "عدد المنتجات";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(menuStrip1);
            panelButtons.Location = new Point(23, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(25);
            panelButtons.Size = new Size(223, 179);
            panelButtons.TabIndex = 9;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { عملياتالجردالمتاحةToolStripMenuItem });
            menuStrip1.Location = new Point(25, 25);
            menuStrip1.Margin = new Padding(25);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5);
            menuStrip1.Size = new Size(173, 33);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "العمليات المتاحة";
            // 
            // عملياتالجردالمتاحةToolStripMenuItem
            // 
            عملياتالجردالمتاحةToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { تحويلالمنتجاتبينالمخازنToolStripMenuItem, اخراجالمنتجاتالتالفةمنالمخزنToolStripMenuItem, جردالسلعاضافةتعديلاطلاعToolStripMenuItem, تصديرالىملفExcelToolStripMenuItem });
            عملياتالجردالمتاحةToolStripMenuItem.Name = "عملياتالجردالمتاحةToolStripMenuItem";
            عملياتالجردالمتاحةToolStripMenuItem.Size = new Size(139, 23);
            عملياتالجردالمتاحةToolStripMenuItem.Text = "عمليات الجرد المتاحة";
            // 
            // تحويلالمنتجاتبينالمخازنToolStripMenuItem
            // 
            تحويلالمنتجاتبينالمخازنToolStripMenuItem.Name = "تحويلالمنتجاتبينالمخازنToolStripMenuItem";
            تحويلالمنتجاتبينالمخازنToolStripMenuItem.Size = new Size(262, 24);
            تحويلالمنتجاتبينالمخازنToolStripMenuItem.Text = "تحويل المنتجات بين المخازن";
            تحويلالمنتجاتبينالمخازنToolStripMenuItem.Click += تحويلالمنتجاتبينالمخازنToolStripMenuItem_Click;
            // 
            // اخراجالمنتجاتالتالفةمنالمخزنToolStripMenuItem
            // 
            اخراجالمنتجاتالتالفةمنالمخزنToolStripMenuItem.Name = "اخراجالمنتجاتالتالفةمنالمخزنToolStripMenuItem";
            اخراجالمنتجاتالتالفةمنالمخزنToolStripMenuItem.Size = new Size(262, 24);
            اخراجالمنتجاتالتالفةمنالمخزنToolStripMenuItem.Text = "اخراج المنتجات التالفة من المخزن";
            اخراجالمنتجاتالتالفةمنالمخزنToolStripMenuItem.Click += اخراجالمنتجاتالتالفةمنالمخزنToolStripMenuItem_Click;
            // 
            // جردالسلعاضافةتعديلاطلاعToolStripMenuItem
            // 
            جردالسلعاضافةتعديلاطلاعToolStripMenuItem.Name = "جردالسلعاضافةتعديلاطلاعToolStripMenuItem";
            جردالسلعاضافةتعديلاطلاعToolStripMenuItem.Size = new Size(262, 24);
            جردالسلعاضافةتعديلاطلاعToolStripMenuItem.Text = "جرد السلع اضافة/تعديل/اطلاع";
            جردالسلعاضافةتعديلاطلاعToolStripMenuItem.Click += جردالسلعاضافةتعديلاطلاعToolStripMenuItem_Click;
            // 
            // تصديرالىملفExcelToolStripMenuItem
            // 
            تصديرالىملفExcelToolStripMenuItem.Name = "تصديرالىملفExcelToolStripMenuItem";
            تصديرالىملفExcelToolStripMenuItem.Size = new Size(262, 24);
            تصديرالىملفExcelToolStripMenuItem.Text = "تصدير الى ملف Excel";
            تصديرالىملفExcelToolStripMenuItem.Click += تصديرالىملفExcelToolStripMenuItem_Click;
            // 
            // flowLayoutPanelStats
            // 
            flowLayoutPanelStats.Controls.Add(panel1);
            flowLayoutPanelStats.Controls.Add(panel7);
            flowLayoutPanelStats.Controls.Add(panel2);
            flowLayoutPanelStats.Controls.Add(panel4);
            flowLayoutPanelStats.Controls.Add(panel5);
            flowLayoutPanelStats.Controls.Add(panel6);
            flowLayoutPanelStats.Controls.Add(panel3);
            flowLayoutPanelStats.Dock = DockStyle.Bottom;
            flowLayoutPanelStats.Location = new Point(3, 566);
            flowLayoutPanelStats.Name = "flowLayoutPanelStats";
            flowLayoutPanelStats.Size = new Size(1020, 80);
            flowLayoutPanelStats.TabIndex = 37;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtAllProducts);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(849, 5);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(166, 74);
            panel1.TabIndex = 0;
            // 
            // txtAllProducts
            // 
            txtAllProducts.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAllProducts.Location = new Point(36, 32);
            txtAllProducts.Multiline = true;
            txtAllProducts.Name = "txtAllProducts";
            txtAllProducts.PlaceholderText = "0";
            txtAllProducts.ReadOnly = true;
            txtAllProducts.Size = new Size(95, 39);
            txtAllProducts.TabIndex = 10;
            txtAllProducts.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(7, 11);
            label1.Name = "label1";
            label1.Size = new Size(150, 19);
            label1.TabIndex = 0;
            label1.Text = "عدد المنتجات في المخازن";
            // 
            // panel7
            // 
            panel7.Controls.Add(txtProductSum);
            panel7.Controls.Add(label7);
            panel7.Location = new Point(711, 5);
            panel7.Margin = new Padding(5);
            panel7.Name = "panel7";
            panel7.Size = new Size(128, 74);
            panel7.TabIndex = 6;
            // 
            // txtProductSum
            // 
            txtProductSum.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductSum.Location = new Point(3, 32);
            txtProductSum.Multiline = true;
            txtProductSum.Name = "txtProductSum";
            txtProductSum.PlaceholderText = "0";
            txtProductSum.ReadOnly = true;
            txtProductSum.Size = new Size(113, 39);
            txtProductSum.TabIndex = 10;
            txtProductSum.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(21, 10);
            label7.Name = "label7";
            label7.Size = new Size(88, 19);
            label7.TabIndex = 0;
            label7.Text = "عدد المنتجات";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtAllQty);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(573, 5);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            panel2.Size = new Size(128, 74);
            panel2.TabIndex = 1;
            // 
            // txtAllQty
            // 
            txtAllQty.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAllQty.Location = new Point(12, 32);
            txtAllQty.Multiline = true;
            txtAllQty.Name = "txtAllQty";
            txtAllQty.PlaceholderText = "0";
            txtAllQty.ReadOnly = true;
            txtAllQty.Size = new Size(113, 39);
            txtAllQty.TabIndex = 10;
            txtAllQty.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 10);
            label2.Name = "label2";
            label2.Size = new Size(94, 19);
            label2.TabIndex = 0;
            label2.Text = "مجموع الكميات";
            // 
            // panel4
            // 
            panel4.Controls.Add(txttotalBuy);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(430, 5);
            panel4.Margin = new Padding(5);
            panel4.Name = "panel4";
            panel4.Size = new Size(133, 74);
            panel4.TabIndex = 3;
            // 
            // txttotalBuy
            // 
            txttotalBuy.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txttotalBuy.Location = new Point(3, 32);
            txttotalBuy.Multiline = true;
            txttotalBuy.Name = "txttotalBuy";
            txttotalBuy.PlaceholderText = "0";
            txttotalBuy.ReadOnly = true;
            txttotalBuy.Size = new Size(127, 39);
            txttotalBuy.TabIndex = 10;
            txttotalBuy.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 10);
            label4.Name = "label4";
            label4.Size = new Size(84, 19);
            label4.TabIndex = 0;
            label4.Text = "مجموع الشراء";
            // 
            // panel5
            // 
            panel5.Controls.Add(txttotalSell);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(287, 5);
            panel5.Margin = new Padding(5);
            panel5.Name = "panel5";
            panel5.Size = new Size(133, 74);
            panel5.TabIndex = 4;
            // 
            // txttotalSell
            // 
            txttotalSell.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txttotalSell.Location = new Point(3, 32);
            txttotalSell.Multiline = true;
            txttotalSell.Name = "txttotalSell";
            txttotalSell.PlaceholderText = "0";
            txttotalSell.ReadOnly = true;
            txttotalSell.Size = new Size(127, 39);
            txttotalSell.TabIndex = 10;
            txttotalSell.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(28, 10);
            label5.Name = "label5";
            label5.Size = new Size(77, 19);
            label5.TabIndex = 0;
            label5.Text = "مجموع البيع";
            // 
            // panel6
            // 
            panel6.Controls.Add(txtTotalProfitExpected);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(144, 5);
            panel6.Margin = new Padding(5);
            panel6.Name = "panel6";
            panel6.Size = new Size(133, 74);
            panel6.TabIndex = 5;
            // 
            // txtTotalProfitExpected
            // 
            txtTotalProfitExpected.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalProfitExpected.Location = new Point(3, 32);
            txtTotalProfitExpected.Multiline = true;
            txtTotalProfitExpected.Name = "txtTotalProfitExpected";
            txtTotalProfitExpected.PlaceholderText = "0";
            txtTotalProfitExpected.ReadOnly = true;
            txtTotalProfitExpected.Size = new Size(127, 39);
            txtTotalProfitExpected.TabIndex = 10;
            txtTotalProfitExpected.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(17, 10);
            label6.Name = "label6";
            label6.Size = new Size(95, 19);
            label6.TabIndex = 0;
            label6.Text = "الارباح المتوقعة";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtCapital);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(882, 89);
            panel3.Margin = new Padding(5);
            panel3.Name = "panel3";
            panel3.Size = new Size(133, 74);
            panel3.TabIndex = 7;
            // 
            // txtCapital
            // 
            txtCapital.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCapital.Location = new Point(3, 32);
            txtCapital.Multiline = true;
            txtCapital.Name = "txtCapital";
            txtCapital.PlaceholderText = "0";
            txtCapital.ReadOnly = true;
            txtCapital.Size = new Size(127, 39);
            txtCapital.TabIndex = 10;
            txtCapital.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(37, 6);
            label3.Name = "label3";
            label3.Size = new Size(63, 19);
            label3.TabIndex = 0;
            label3.Text = "رأس المال";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1026, 649);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // StoreInventoryUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tabControl1);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StoreInventoryUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            Load += StoreInventoryUserControl_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            PanelPagination.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvSales).EndInit();
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            flowLayoutPanelreturnsoption.ResumeLayout(false);
            flowLayoutPanelreturnsoption.PerformLayout();
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            panelstatisticsandOperations.ResumeLayout(false);
            panelstatisticsandOperations.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            flowLayoutPanelStats.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel PanelPagination;
        private ComboBox cmbpagination;
        private Button btnPrev;
        private Button btnNext;
        private Label lblEmptyData;
        private DataGridView DgvSales;
        private FlowLayoutPanel OperationsflowLayoutPanel;
        private GroupBox gbPayChoiches;
        private FlowLayoutPanel flowLayoutPanelreturnsoption;
        private RadioButton rbStoreAll;
        private RadioButton rbSelectedStore;
        private ComboBox cmbStores;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel panelstatisticsandOperations;
        private Label lblTitleForm;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblBuys;
        private Label lblSales;
        private Label lblProfitExpected;
        private Label lblQtyInTable;
        private Label lblProductInTables;
        private Panel panelButtons;
        private FlowLayoutPanel flowLayoutPanelStats;
        private Panel panel1;
        private TextBox txtAllProducts;
        private Label label1;
        private Panel panel7;
        private TextBox txtProductSum;
        private Label label7;
        private Panel panel2;
        private TextBox txtAllQty;
        private Label label2;
        private Panel panel4;
        private TextBox txttotalBuy;
        private Label label4;
        private Panel panel5;
        private TextBox txttotalSell;
        private Label label5;
        private Panel panel6;
        private TextBox txtTotalProfitExpected;
        private Label label6;
        private Panel panel3;
        private TextBox txtCapital;
        private Label label3;
        private TabPage tabPage2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem عملياتالجردالمتاحةToolStripMenuItem;
        private ToolStripMenuItem تحويلالمنتجاتبينالمخازنToolStripMenuItem;
        private ToolStripMenuItem اخراجالمنتجاتالتالفةمنالمخزنToolStripMenuItem;
        private ToolStripMenuItem جردالسلعاضافةتعديلاطلاعToolStripMenuItem;
        private ToolStripMenuItem تصديرالىملفExcelToolStripMenuItem;
    }
}
