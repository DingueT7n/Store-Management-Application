namespace Store.ApplicationUI.Gui.HomeGui
{
    partial class AlertsUserControl
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
            DataGridViewCellStyle dataGridViewCellStyle40 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle41 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle42 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertsUserControl));
            DataGridViewCellStyle dataGridViewCellStyle37 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle38 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle39 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle43 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle44 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle45 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle46 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle47 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle48 = new DataGridViewCellStyle();
            flowLayoutPanelRight = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            paneldgvandlbl = new Panel();
            PanelPagination = new Panel();
            cmbpagination = new ComboBox();
            btnPrev = new Button();
            btnNext = new Button();
            lblEmptyData = new Label();
            DgvProducts = new DataGridView();
            gbOutDatedData = new GroupBox();
            panelProductsOutDated = new Panel();
            panel2 = new Panel();
            cmbpagination1 = new ComboBox();
            btnPrev2 = new Button();
            btnNext2 = new Button();
            lblEmptyData1 = new Label();
            dgvDataOutdated = new DataGridView();
            gbDebtToSuppliers = new GroupBox();
            panelDebtSupplier = new Panel();
            lblEmptyData2 = new Label();
            dataDebtSuppliers = new DataGridView();
            gbCustomers = new GroupBox();
            panel1 = new Panel();
            lblEmptyData3 = new Label();
            dataCustomerDebts = new DataGridView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblEmptyAlerts = new Label();
            flowLayoutPanelRight.SuspendLayout();
            paneldgvandlbl.SuspendLayout();
            PanelPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).BeginInit();
            panelProductsOutDated.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDataOutdated).BeginInit();
            panelDebtSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataDebtSuppliers).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataCustomerDebts).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanelRight
            // 
            flowLayoutPanelRight.AutoScroll = true;
            flowLayoutPanelRight.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelRight.Controls.Add(groupBox2);
            flowLayoutPanelRight.Controls.Add(paneldgvandlbl);
            flowLayoutPanelRight.Controls.Add(gbOutDatedData);
            flowLayoutPanelRight.Controls.Add(panelProductsOutDated);
            flowLayoutPanelRight.Controls.Add(gbDebtToSuppliers);
            flowLayoutPanelRight.Controls.Add(panelDebtSupplier);
            flowLayoutPanelRight.Controls.Add(gbCustomers);
            flowLayoutPanelRight.Controls.Add(panel1);
            flowLayoutPanelRight.Dock = DockStyle.Right;
            flowLayoutPanelRight.Location = new Point(483, 0);
            flowLayoutPanelRight.Name = "flowLayoutPanelRight";
            flowLayoutPanelRight.Size = new Size(551, 681);
            flowLayoutPanelRight.TabIndex = 14;
            // 
            // groupBox2
            // 
            groupBox2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            groupBox2.ForeColor = Color.Red;
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(526, 21);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "تحذير للمنتوجات التي سوف تنتهي من المخزون :";
            // 
            // paneldgvandlbl
            // 
            paneldgvandlbl.Controls.Add(PanelPagination);
            paneldgvandlbl.Controls.Add(lblEmptyData);
            paneldgvandlbl.Controls.Add(DgvProducts);
            paneldgvandlbl.Location = new Point(3, 30);
            paneldgvandlbl.Name = "paneldgvandlbl";
            paneldgvandlbl.Size = new Size(526, 303);
            paneldgvandlbl.TabIndex = 12;
            // 
            // PanelPagination
            // 
            PanelPagination.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelPagination.Controls.Add(cmbpagination);
            PanelPagination.Controls.Add(btnPrev);
            PanelPagination.Controls.Add(btnNext);
            PanelPagination.Location = new Point(3, 268);
            PanelPagination.Name = "PanelPagination";
            PanelPagination.Size = new Size(169, 32);
            PanelPagination.TabIndex = 31;
            // 
            // cmbpagination
            // 
            cmbpagination.Dock = DockStyle.Top;
            cmbpagination.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbpagination.FormattingEnabled = true;
            cmbpagination.Location = new Point(50, 0);
            cmbpagination.Name = "cmbpagination";
            cmbpagination.Size = new Size(69, 31);
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
            btnPrev.Size = new Size(50, 32);
            btnPrev.TabIndex = 26;
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Dock = DockStyle.Right;
            btnNext.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.ImeMode = ImeMode.NoControl;
            btnNext.Location = new Point(119, 0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(50, 32);
            btnNext.TabIndex = 25;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblEmptyData
            // 
            lblEmptyData.Anchor = AnchorStyles.None;
            lblEmptyData.AutoSize = true;
            lblEmptyData.BackColor = Color.Transparent;
            lblEmptyData.BorderStyle = BorderStyle.FixedSingle;
            lblEmptyData.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblEmptyData.ForeColor = Color.Crimson;
            lblEmptyData.ImeMode = ImeMode.NoControl;
            lblEmptyData.Location = new Point(196, 141);
            lblEmptyData.Name = "lblEmptyData";
            lblEmptyData.Size = new Size(135, 21);
            lblEmptyData.TabIndex = 20;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvProducts
            // 
            DgvProducts.AllowUserToAddRows = false;
            DgvProducts.AllowUserToDeleteRows = false;
            DgvProducts.AllowUserToResizeColumns = false;
            DgvProducts.AllowUserToResizeRows = false;
            DgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvProducts.BackgroundColor = Color.White;
            DgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle40.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle40.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle40.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle40.ForeColor = Color.White;
            dataGridViewCellStyle40.SelectionBackColor = Color.OrangeRed;
            dataGridViewCellStyle40.SelectionForeColor = Color.White;
            dataGridViewCellStyle40.WrapMode = DataGridViewTriState.True;
            DgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle40;
            DgvProducts.ColumnHeadersHeight = 43;
            DgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle41.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle41.BackColor = Color.White;
            dataGridViewCellStyle41.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle41.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle41.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle41.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle41.WrapMode = DataGridViewTriState.False;
            DgvProducts.DefaultCellStyle = dataGridViewCellStyle41;
            DgvProducts.EnableHeadersVisualStyles = false;
            DgvProducts.GridColor = Color.FromArgb(64, 64, 64);
            DgvProducts.Location = new Point(0, 0);
            DgvProducts.Name = "DgvProducts";
            DgvProducts.ReadOnly = true;
            dataGridViewCellStyle42.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = Color.White;
            dataGridViewCellStyle42.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle42.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle42.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle42.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = DataGridViewTriState.True;
            DgvProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle42;
            DgvProducts.RowHeadersVisible = false;
            DgvProducts.RowTemplate.Height = 22;
            DgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvProducts.Size = new Size(530, 300);
            DgvProducts.TabIndex = 9;
            // 
            // gbOutDatedData
            // 
            gbOutDatedData.Font = new Font("Calibri", 12F, FontStyle.Bold);
            gbOutDatedData.ForeColor = Color.Red;
            gbOutDatedData.Location = new Point(3, 339);
            gbOutDatedData.Name = "gbOutDatedData";
            gbOutDatedData.Size = new Size(526, 21);
            gbOutDatedData.TabIndex = 15;
            gbOutDatedData.TabStop = false;
            gbOutDatedData.Text = "تحذير المنتجات التي سوف تنتهي صلاحيتها";
            // 
            // panelProductsOutDated
            // 
            panelProductsOutDated.Controls.Add(panel2);
            panelProductsOutDated.Controls.Add(lblEmptyData1);
            panelProductsOutDated.Controls.Add(dgvDataOutdated);
            panelProductsOutDated.Location = new Point(3, 366);
            panelProductsOutDated.Name = "panelProductsOutDated";
            panelProductsOutDated.Size = new Size(526, 295);
            panelProductsOutDated.TabIndex = 16;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.Controls.Add(cmbpagination1);
            panel2.Controls.Add(btnPrev2);
            panel2.Controls.Add(btnNext2);
            panel2.Location = new Point(3, 260);
            panel2.Name = "panel2";
            panel2.Size = new Size(169, 32);
            panel2.TabIndex = 32;
            // 
            // cmbpagination1
            // 
            cmbpagination1.Dock = DockStyle.Top;
            cmbpagination1.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbpagination1.FormattingEnabled = true;
            cmbpagination1.Location = new Point(50, 0);
            cmbpagination1.Name = "cmbpagination1";
            cmbpagination1.Size = new Size(69, 31);
            cmbpagination1.TabIndex = 28;
            cmbpagination1.SelectionChangeCommitted += cmbpagination1_SelectionChangeCommitted;
            // 
            // btnPrev2
            // 
            btnPrev2.Dock = DockStyle.Left;
            btnPrev2.Image = (Image)resources.GetObject("btnPrev2.Image");
            btnPrev2.ImeMode = ImeMode.NoControl;
            btnPrev2.Location = new Point(0, 0);
            btnPrev2.Name = "btnPrev2";
            btnPrev2.Size = new Size(50, 32);
            btnPrev2.TabIndex = 26;
            btnPrev2.UseVisualStyleBackColor = true;
            btnPrev2.Click += btnPrev2_Click;
            // 
            // btnNext2
            // 
            btnNext2.Dock = DockStyle.Right;
            btnNext2.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext2.Image = (Image)resources.GetObject("btnNext2.Image");
            btnNext2.ImeMode = ImeMode.NoControl;
            btnNext2.Location = new Point(119, 0);
            btnNext2.Name = "btnNext2";
            btnNext2.Size = new Size(50, 32);
            btnNext2.TabIndex = 25;
            btnNext2.UseVisualStyleBackColor = true;
            btnNext2.Click += btnNext2_Click;
            // 
            // lblEmptyData1
            // 
            lblEmptyData1.Anchor = AnchorStyles.None;
            lblEmptyData1.AutoSize = true;
            lblEmptyData1.BackColor = Color.Transparent;
            lblEmptyData1.BorderStyle = BorderStyle.FixedSingle;
            lblEmptyData1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblEmptyData1.ForeColor = Color.Crimson;
            lblEmptyData1.ImeMode = ImeMode.NoControl;
            lblEmptyData1.Location = new Point(196, 130);
            lblEmptyData1.Name = "lblEmptyData1";
            lblEmptyData1.Size = new Size(135, 21);
            lblEmptyData1.TabIndex = 20;
            lblEmptyData1.Text = "لا توجد بيانات لعرضها";
            lblEmptyData1.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData1.Visible = false;
            // 
            // dgvDataOutdated
            // 
            dgvDataOutdated.AllowUserToAddRows = false;
            dgvDataOutdated.AllowUserToDeleteRows = false;
            dgvDataOutdated.AllowUserToResizeColumns = false;
            dgvDataOutdated.AllowUserToResizeRows = false;
            dgvDataOutdated.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDataOutdated.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDataOutdated.BackgroundColor = Color.White;
            dgvDataOutdated.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvDataOutdated.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle37.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle37.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle37.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle37.ForeColor = Color.White;
            dataGridViewCellStyle37.SelectionBackColor = Color.OrangeRed;
            dataGridViewCellStyle37.SelectionForeColor = Color.White;
            dataGridViewCellStyle37.WrapMode = DataGridViewTriState.True;
            dgvDataOutdated.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
            dgvDataOutdated.ColumnHeadersHeight = 43;
            dgvDataOutdated.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle38.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle38.BackColor = Color.White;
            dataGridViewCellStyle38.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle38.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle38.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle38.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle38.WrapMode = DataGridViewTriState.False;
            dgvDataOutdated.DefaultCellStyle = dataGridViewCellStyle38;
            dgvDataOutdated.EnableHeadersVisualStyles = false;
            dgvDataOutdated.GridColor = Color.FromArgb(64, 64, 64);
            dgvDataOutdated.Location = new Point(0, 0);
            dgvDataOutdated.Name = "dgvDataOutdated";
            dgvDataOutdated.ReadOnly = true;
            dataGridViewCellStyle39.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = Color.White;
            dataGridViewCellStyle39.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle39.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle39.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = DataGridViewTriState.True;
            dgvDataOutdated.RowHeadersDefaultCellStyle = dataGridViewCellStyle39;
            dgvDataOutdated.RowHeadersVisible = false;
            dgvDataOutdated.RowTemplate.Height = 22;
            dgvDataOutdated.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDataOutdated.Size = new Size(523, 292);
            dgvDataOutdated.TabIndex = 9;
            // 
            // gbDebtToSuppliers
            // 
            gbDebtToSuppliers.Font = new Font("Calibri", 12F, FontStyle.Bold);
            gbDebtToSuppliers.ForeColor = Color.Red;
            gbDebtToSuppliers.Location = new Point(3, 667);
            gbDebtToSuppliers.Name = "gbDebtToSuppliers";
            gbDebtToSuppliers.Size = new Size(526, 21);
            gbDebtToSuppliers.TabIndex = 17;
            gbDebtToSuppliers.TabStop = false;
            gbDebtToSuppliers.Text = "الديون التي حان وقت استحقاقها للموردين";
            // 
            // panelDebtSupplier
            // 
            panelDebtSupplier.Controls.Add(lblEmptyData2);
            panelDebtSupplier.Controls.Add(dataDebtSuppliers);
            panelDebtSupplier.Location = new Point(3, 694);
            panelDebtSupplier.Name = "panelDebtSupplier";
            panelDebtSupplier.Size = new Size(526, 254);
            panelDebtSupplier.TabIndex = 18;
            // 
            // lblEmptyData2
            // 
            lblEmptyData2.Anchor = AnchorStyles.None;
            lblEmptyData2.AutoSize = true;
            lblEmptyData2.BackColor = Color.Transparent;
            lblEmptyData2.BorderStyle = BorderStyle.FixedSingle;
            lblEmptyData2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblEmptyData2.ForeColor = Color.Crimson;
            lblEmptyData2.ImeMode = ImeMode.NoControl;
            lblEmptyData2.Location = new Point(196, 103);
            lblEmptyData2.Name = "lblEmptyData2";
            lblEmptyData2.Size = new Size(135, 21);
            lblEmptyData2.TabIndex = 20;
            lblEmptyData2.Text = "لا توجد بيانات لعرضها";
            lblEmptyData2.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData2.Visible = false;
            // 
            // dataDebtSuppliers
            // 
            dataDebtSuppliers.AllowUserToAddRows = false;
            dataDebtSuppliers.AllowUserToDeleteRows = false;
            dataDebtSuppliers.AllowUserToResizeColumns = false;
            dataDebtSuppliers.AllowUserToResizeRows = false;
            dataDebtSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataDebtSuppliers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataDebtSuppliers.BackgroundColor = Color.White;
            dataDebtSuppliers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataDebtSuppliers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle43.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle43.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle43.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle43.ForeColor = Color.White;
            dataGridViewCellStyle43.SelectionBackColor = Color.OrangeRed;
            dataGridViewCellStyle43.SelectionForeColor = Color.White;
            dataGridViewCellStyle43.WrapMode = DataGridViewTriState.True;
            dataDebtSuppliers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle43;
            dataDebtSuppliers.ColumnHeadersHeight = 43;
            dataDebtSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle44.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = Color.White;
            dataGridViewCellStyle44.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle44.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle44.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle44.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle44.WrapMode = DataGridViewTriState.False;
            dataDebtSuppliers.DefaultCellStyle = dataGridViewCellStyle44;
            dataDebtSuppliers.EnableHeadersVisualStyles = false;
            dataDebtSuppliers.GridColor = Color.FromArgb(64, 64, 64);
            dataDebtSuppliers.Location = new Point(0, 0);
            dataDebtSuppliers.Name = "dataDebtSuppliers";
            dataDebtSuppliers.ReadOnly = true;
            dataGridViewCellStyle45.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle45.BackColor = Color.White;
            dataGridViewCellStyle45.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle45.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle45.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle45.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle45.WrapMode = DataGridViewTriState.True;
            dataDebtSuppliers.RowHeadersDefaultCellStyle = dataGridViewCellStyle45;
            dataDebtSuppliers.RowHeadersVisible = false;
            dataDebtSuppliers.RowTemplate.Height = 22;
            dataDebtSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataDebtSuppliers.Size = new Size(523, 250);
            dataDebtSuppliers.TabIndex = 9;
            // 
            // gbCustomers
            // 
            gbCustomers.Font = new Font("Calibri", 12F, FontStyle.Bold);
            gbCustomers.ForeColor = Color.Red;
            gbCustomers.Location = new Point(3, 954);
            gbCustomers.Name = "gbCustomers";
            gbCustomers.Size = new Size(526, 21);
            gbCustomers.TabIndex = 19;
            gbCustomers.TabStop = false;
            gbCustomers.Text = "الديون التي حان وقت استعادتها من العملاء";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblEmptyData3);
            panel1.Controls.Add(dataCustomerDebts);
            panel1.Location = new Point(3, 981);
            panel1.Name = "panel1";
            panel1.Size = new Size(526, 254);
            panel1.TabIndex = 20;
            // 
            // lblEmptyData3
            // 
            lblEmptyData3.Anchor = AnchorStyles.None;
            lblEmptyData3.AutoSize = true;
            lblEmptyData3.BackColor = Color.Transparent;
            lblEmptyData3.BorderStyle = BorderStyle.FixedSingle;
            lblEmptyData3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblEmptyData3.ForeColor = Color.Crimson;
            lblEmptyData3.ImeMode = ImeMode.NoControl;
            lblEmptyData3.Location = new Point(196, 117);
            lblEmptyData3.Name = "lblEmptyData3";
            lblEmptyData3.Size = new Size(135, 21);
            lblEmptyData3.TabIndex = 20;
            lblEmptyData3.Text = "لا توجد بيانات لعرضها";
            lblEmptyData3.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData3.Visible = false;
            // 
            // dataCustomerDebts
            // 
            dataCustomerDebts.AllowUserToAddRows = false;
            dataCustomerDebts.AllowUserToDeleteRows = false;
            dataCustomerDebts.AllowUserToResizeColumns = false;
            dataCustomerDebts.AllowUserToResizeRows = false;
            dataCustomerDebts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataCustomerDebts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataCustomerDebts.BackgroundColor = Color.White;
            dataCustomerDebts.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataCustomerDebts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle46.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle46.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle46.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle46.ForeColor = Color.White;
            dataGridViewCellStyle46.SelectionBackColor = Color.OrangeRed;
            dataGridViewCellStyle46.SelectionForeColor = Color.White;
            dataGridViewCellStyle46.WrapMode = DataGridViewTriState.True;
            dataCustomerDebts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle46;
            dataCustomerDebts.ColumnHeadersHeight = 43;
            dataCustomerDebts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle47.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = Color.White;
            dataGridViewCellStyle47.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle47.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle47.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle47.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = DataGridViewTriState.False;
            dataCustomerDebts.DefaultCellStyle = dataGridViewCellStyle47;
            dataCustomerDebts.EnableHeadersVisualStyles = false;
            dataCustomerDebts.GridColor = Color.FromArgb(64, 64, 64);
            dataCustomerDebts.Location = new Point(0, 0);
            dataCustomerDebts.Name = "dataCustomerDebts";
            dataCustomerDebts.ReadOnly = true;
            dataGridViewCellStyle48.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle48.BackColor = Color.White;
            dataGridViewCellStyle48.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle48.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle48.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle48.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle48.WrapMode = DataGridViewTriState.True;
            dataCustomerDebts.RowHeadersDefaultCellStyle = dataGridViewCellStyle48;
            dataCustomerDebts.RowHeadersVisible = false;
            dataCustomerDebts.RowTemplate.Height = 22;
            dataCustomerDebts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataCustomerDebts.Size = new Size(523, 250);
            dataCustomerDebts.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(483, 681);
            flowLayoutPanel1.TabIndex = 15;
            // 
            // lblEmptyAlerts
            // 
            lblEmptyAlerts.Anchor = AnchorStyles.None;
            lblEmptyAlerts.AutoSize = true;
            lblEmptyAlerts.BackColor = Color.Transparent;
            lblEmptyAlerts.BorderStyle = BorderStyle.FixedSingle;
            lblEmptyAlerts.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblEmptyAlerts.ForeColor = Color.Crimson;
            lblEmptyAlerts.ImeMode = ImeMode.NoControl;
            lblEmptyAlerts.Location = new Point(129, 330);
            lblEmptyAlerts.Name = "lblEmptyAlerts";
            lblEmptyAlerts.Size = new Size(190, 21);
            lblEmptyAlerts.TabIndex = 21;
            lblEmptyAlerts.Text = "لا توجد تنبيهات في الوقت الحالي";
            lblEmptyAlerts.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyAlerts.Visible = false;
            // 
            // AlertsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblEmptyAlerts);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanelRight);
            Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AlertsUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            Load += AlertsUserControl_Load;
            flowLayoutPanelRight.ResumeLayout(false);
            paneldgvandlbl.ResumeLayout(false);
            paneldgvandlbl.PerformLayout();
            PanelPagination.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvProducts).EndInit();
            panelProductsOutDated.ResumeLayout(false);
            panelProductsOutDated.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDataOutdated).EndInit();
            panelDebtSupplier.ResumeLayout(false);
            panelDebtSupplier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataDebtSuppliers).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataCustomerDebts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelRight;
        private GroupBox groupBox2;
        private Panel paneldgvandlbl;
        private Label lblEmptyData;
        private DataGridView DgvProducts;
        private GroupBox gbOutDatedData;
        private Panel panelProductsOutDated;
        private Label lblEmptyData1;
        private DataGridView dgvDataOutdated;
        private GroupBox gbDebtToSuppliers;
        private Panel panelDebtSupplier;
        private Label lblEmptyData2;
        private DataGridView dataDebtSuppliers;
        private GroupBox gbCustomers;
        private Panel panel1;
        private Label lblEmptyData3;
        private DataGridView dataCustomerDebts;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblEmptyAlerts;
        private Panel PanelPagination;
        private ComboBox cmbpagination;
        private Button btnPrev;
        private Button btnNext;
        private Panel panel2;
        private ComboBox cmbpagination1;
        private Button btnPrev2;
        private Button btnNext2;
    }
}
