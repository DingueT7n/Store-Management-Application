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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            button1 = new Button();
            button2 = new Button();
            btnExportCustomer = new Button();
            lblEmptyData = new Label();
            DgvSales = new DataGridView();
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
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            flowLayoutPanelreturnsoption.SuspendLayout();
            SearchPanel.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvSales).BeginInit();
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
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(lblBuys);
            flowLayoutPanel1.Controls.Add(lblSales);
            flowLayoutPanel1.Controls.Add(lblProfitExpected);
            flowLayoutPanel1.Controls.Add(lblQtyInTable);
            flowLayoutPanel1.Controls.Add(lblProductInTables);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 46);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(294, 109);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // lblBuys
            // 
            lblBuys.AutoSize = true;
            lblBuys.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuys.Location = new Point(200, 10);
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
            lblSales.Location = new Point(207, 49);
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
            lblProfitExpected.Location = new Point(85, 10);
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
            lblQtyInTable.Location = new Point(86, 49);
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
            lblProductInTables.Location = new Point(17, 10);
            lblProductInTables.Margin = new Padding(10);
            lblProductInTables.Name = "lblProductInTables";
            lblProductInTables.Size = new Size(48, 57);
            lblProductInTables.TabIndex = 5;
            lblProductInTables.Text = "عدد المنتجات";
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
            DgvSales.Size = new Size(1034, 437);
            DgvSales.TabIndex = 27;
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
            flowLayoutPanelStats.Location = new Point(0, 601);
            flowLayoutPanelStats.Name = "flowLayoutPanelStats";
            flowLayoutPanelStats.Size = new Size(1034, 80);
            flowLayoutPanelStats.TabIndex = 32;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtAllProducts);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(863, 5);
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
            panel7.Location = new Point(725, 5);
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
            panel2.Location = new Point(587, 5);
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
            panel4.Location = new Point(444, 5);
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
            panel5.Location = new Point(301, 5);
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
            panel6.Location = new Point(158, 5);
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
            panel3.Location = new Point(15, 5);
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
            // StoreInventoryUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblEmptyData);
            Controls.Add(DgvSales);
            Controls.Add(OperationsflowLayoutPanel);
            Controls.Add(flowLayoutPanelStats);
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
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvSales).EndInit();
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
        private Label lblBuys;
        private Label lblSales;
        private Label lblProfitExpected;
        private Label lblQtyInTable;
        private Label lblProductInTables;
        private Panel panel3;
        private TextBox txtCapital;
        private Label label3;
    }
}
