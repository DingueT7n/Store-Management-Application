namespace Store.ApplicationUI.Gui.ProductsGui
{
    partial class ProductsUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddProduct = new Button();
            btnEditProduct = new Button();
            btnDeleteProduct = new Button();
            btnAddCategory = new Button();
            btnAddStore = new Button();
            btnAddSimilareProduct = new Button();
            button1 = new Button();
            btnExportProduct = new Button();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            DgvProducts = new DataGridView();
            lblEmptyData = new Label();
            btnRefresh = new Button();
            toolTip1 = new ToolTip(components);
            PanelPagination = new Panel();
            cmbpagination = new ComboBox();
            btnPrev = new Button();
            btnNext = new Button();
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
            panel3 = new Panel();
            txtAllCategories = new TextBox();
            label3 = new Label();
            panel4 = new Panel();
            txttotalBuy = new TextBox();
            label4 = new Label();
            panel5 = new Panel();
            txttotalSell = new TextBox();
            label5 = new Label();
            panel6 = new Panel();
            txtTotalProfitExpected = new TextBox();
            label6 = new Label();
            OperationsflowLayoutPanel.SuspendLayout();
            SearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).BeginInit();
            PanelPagination.SuspendLayout();
            flowLayoutPanelStats.SuspendLayout();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddProduct);
            OperationsflowLayoutPanel.Controls.Add(btnEditProduct);
            OperationsflowLayoutPanel.Controls.Add(btnDeleteProduct);
            OperationsflowLayoutPanel.Controls.Add(btnAddCategory);
            OperationsflowLayoutPanel.Controls.Add(btnAddStore);
            OperationsflowLayoutPanel.Controls.Add(btnAddSimilareProduct);
            OperationsflowLayoutPanel.Controls.Add(button1);
            OperationsflowLayoutPanel.Controls.Add(btnExportProduct);
            OperationsflowLayoutPanel.Controls.Add(SearchPanel);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1034, 48);
            OperationsflowLayoutPanel.TabIndex = 8;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Anchor = AnchorStyles.None;
            btnAddProduct.Image = (Image)resources.GetObject("btnAddProduct.Image");
            btnAddProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddProduct.Location = new Point(914, 3);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(100, 40);
            btnAddProduct.TabIndex = 3;
            btnAddProduct.Text = "   اضافة";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnEditProduct
            // 
            btnEditProduct.Anchor = AnchorStyles.None;
            btnEditProduct.Image = (Image)resources.GetObject("btnEditProduct.Image");
            btnEditProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditProduct.Location = new Point(808, 3);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(100, 40);
            btnEditProduct.TabIndex = 4;
            btnEditProduct.Text = "   تعديل";
            btnEditProduct.UseVisualStyleBackColor = true;
            btnEditProduct.Click += btnEditProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Anchor = AnchorStyles.None;
            btnDeleteProduct.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteProduct.Image = (Image)resources.GetObject("btnDeleteProduct.Image");
            btnDeleteProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteProduct.Location = new Point(702, 3);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(100, 40);
            btnDeleteProduct.TabIndex = 5;
            btnDeleteProduct.Text = "   حذف";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Anchor = AnchorStyles.None;
            btnAddCategory.Image = (Image)resources.GetObject("btnAddCategory.Image");
            btnAddCategory.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddCategory.Location = new Point(575, 3);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(121, 40);
            btnAddCategory.TabIndex = 8;
            btnAddCategory.Text = "      اضافة صنف";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // btnAddStore
            // 
            btnAddStore.Anchor = AnchorStyles.None;
            btnAddStore.Image = (Image)resources.GetObject("btnAddStore.Image");
            btnAddStore.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddStore.Location = new Point(450, 3);
            btnAddStore.Name = "btnAddStore";
            btnAddStore.Size = new Size(119, 40);
            btnAddStore.TabIndex = 9;
            btnAddStore.Text = "    اضافة مخزن";
            btnAddStore.UseVisualStyleBackColor = true;
            btnAddStore.Click += btnAddStore_Click;
            // 
            // btnAddSimilareProduct
            // 
            btnAddSimilareProduct.Anchor = AnchorStyles.None;
            btnAddSimilareProduct.Image = (Image)resources.GetObject("btnAddSimilareProduct.Image");
            btnAddSimilareProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddSimilareProduct.Location = new Point(306, 3);
            btnAddSimilareProduct.Name = "btnAddSimilareProduct";
            btnAddSimilareProduct.Size = new Size(138, 40);
            btnAddSimilareProduct.TabIndex = 10;
            btnAddSimilareProduct.Text = "اضافة منتج مماثل";
            btnAddSimilareProduct.TextAlign = ContentAlignment.MiddleRight;
            btnAddSimilareProduct.UseVisualStyleBackColor = true;
            btnAddSimilareProduct.Click += btnAddSimilareProduct_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(163, 3);
            button1.Name = "button1";
            button1.Size = new Size(137, 40);
            button1.TabIndex = 11;
            button1.Text = "طباعة المنتجات";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // btnExportProduct
            // 
            btnExportProduct.Anchor = AnchorStyles.None;
            btnExportProduct.Image = (Image)resources.GetObject("btnExportProduct.Image");
            btnExportProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportProduct.Location = new Point(64, 3);
            btnExportProduct.Name = "btnExportProduct";
            btnExportProduct.Size = new Size(93, 40);
            btnExportProduct.TabIndex = 6;
            btnExportProduct.Text = "   تصدير";
            btnExportProduct.UseVisualStyleBackColor = true;
            btnExportProduct.Click += btnExportProduct_Click;
            // 
            // SearchPanel
            // 
            SearchPanel.Controls.Add(txtSearch);
            SearchPanel.Controls.Add(btnSearch);
            SearchPanel.Location = new Point(762, 49);
            SearchPanel.Name = "SearchPanel";
            SearchPanel.Size = new Size(252, 40);
            SearchPanel.TabIndex = 7;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(50, 0);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث عن منتج";
            txtSearch.Size = new Size(202, 40);
            txtSearch.TabIndex = 9;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            txtSearch.KeyDown += txtSearch_KeyDown;
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
            DgvProducts.Location = new Point(0, 48);
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
            DgvProducts.Size = new Size(1034, 553);
            DgvProducts.TabIndex = 9;
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
            lblEmptyData.TabIndex = 8;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.Location = new Point(981, 555);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(50, 40);
            btnRefresh.TabIndex = 10;
            toolTip1.SetToolTip(btnRefresh, "اعادة التحميل");
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // PanelPagination
            // 
            PanelPagination.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelPagination.Controls.Add(cmbpagination);
            PanelPagination.Controls.Add(btnPrev);
            PanelPagination.Controls.Add(btnNext);
            PanelPagination.Location = new Point(3, 555);
            PanelPagination.Name = "PanelPagination";
            PanelPagination.Size = new Size(169, 40);
            PanelPagination.TabIndex = 30;
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
            // flowLayoutPanelStats
            // 
            flowLayoutPanelStats.Controls.Add(panel1);
            flowLayoutPanelStats.Controls.Add(panel7);
            flowLayoutPanelStats.Controls.Add(panel2);
            flowLayoutPanelStats.Controls.Add(panel3);
            flowLayoutPanelStats.Controls.Add(panel4);
            flowLayoutPanelStats.Controls.Add(panel5);
            flowLayoutPanelStats.Controls.Add(panel6);
            flowLayoutPanelStats.Dock = DockStyle.Bottom;
            flowLayoutPanelStats.Location = new Point(0, 601);
            flowLayoutPanelStats.Name = "flowLayoutPanelStats";
            flowLayoutPanelStats.Size = new Size(1034, 80);
            flowLayoutPanelStats.TabIndex = 31;
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
            // panel3
            // 
            panel3.Controls.Add(txtAllCategories);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(449, 5);
            panel3.Margin = new Padding(5);
            panel3.Name = "panel3";
            panel3.Size = new Size(128, 74);
            panel3.TabIndex = 2;
            // 
            // txtAllCategories
            // 
            txtAllCategories.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAllCategories.Location = new Point(12, 32);
            txtAllCategories.Multiline = true;
            txtAllCategories.Name = "txtAllCategories";
            txtAllCategories.PlaceholderText = "0";
            txtAllCategories.ReadOnly = true;
            txtAllCategories.Size = new Size(97, 39);
            txtAllCategories.TabIndex = 10;
            txtAllCategories.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 10);
            label3.Name = "label3";
            label3.Size = new Size(83, 19);
            label3.TabIndex = 0;
            label3.Text = "عدد الاصناف";
            // 
            // panel4
            // 
            panel4.Controls.Add(txttotalBuy);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(306, 5);
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
            panel5.Location = new Point(163, 5);
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
            panel6.Location = new Point(20, 5);
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
            // ProductsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(PanelPagination);
            Controls.Add(btnRefresh);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvProducts);
            Controls.Add(OperationsflowLayoutPanel);
            Controls.Add(flowLayoutPanelStats);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductsUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            OperationsflowLayoutPanel.ResumeLayout(false);
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).EndInit();
            PanelPagination.ResumeLayout(false);
            flowLayoutPanelStats.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddProduct;
        private Button btnEditProduct;
        private Button btnDeleteProduct;
        private Button btnExportProduct;
        private Panel SearchPanel;
        private Button btnSearch;
        private TextBox txtSearch;
        private DataGridView DgvProducts;
        private Label lblEmptyData;
        private Button btnRefresh;
        private ToolTip toolTip1;
        private Button btnAddCategory;
        private Button btnAddStore;
        private Button btnAddSimilareProduct;
        private Button button1;
        private Panel PanelPagination;
        private ComboBox cmbpagination;
        private Button btnPrev;
        private Button btnNext;
        private FlowLayoutPanel flowLayoutPanelStats;
        private Panel panel1;
        private Label label1;
        private TextBox txtAllProducts;
        private Panel panel2;
        private TextBox txtAllQty;
        private Label label2;
        private Panel panel3;
        private TextBox txtAllCategories;
        private Label label3;
        private Panel panel4;
        private TextBox txttotalBuy;
        private Label label4;
        private Panel panel5;
        private TextBox txttotalSell;
        private Label label5;
        private Panel panel6;
        private TextBox txtTotalProfitExpected;
        private Label label6;
        private Panel panel7;
        private TextBox txtProductSum;
        private Label label7;
    }
}
