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
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertsUserControl));
            flowLayoutPanelRight = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            paneldgvandlbl = new Panel();
            lblEmptyData = new Label();
            DgvProducts = new DataGridView();
            gbOutDatedData = new GroupBox();
            panelProductsOutDated = new Panel();
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
            PanelPagination = new Panel();
            cmbpagination = new ComboBox();
            btnPrev = new Button();
            btnNext = new Button();
            flowLayoutPanelRight.SuspendLayout();
            paneldgvandlbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).BeginInit();
            panelProductsOutDated.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDataOutdated).BeginInit();
            panelDebtSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataDebtSuppliers).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataCustomerDebts).BeginInit();
            PanelPagination.SuspendLayout();
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
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle13.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle13.ForeColor = Color.White;
            dataGridViewCellStyle13.SelectionBackColor = Color.OrangeRed;
            dataGridViewCellStyle13.SelectionForeColor = Color.White;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            DgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            DgvProducts.ColumnHeadersHeight = 43;
            DgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = Color.White;
            dataGridViewCellStyle14.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle14.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            DgvProducts.DefaultCellStyle = dataGridViewCellStyle14;
            DgvProducts.EnableHeadersVisualStyles = false;
            DgvProducts.GridColor = Color.FromArgb(64, 64, 64);
            DgvProducts.Location = new Point(0, 0);
            DgvProducts.Name = "DgvProducts";
            DgvProducts.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = Color.White;
            dataGridViewCellStyle15.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle15.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            DgvProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
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
            panelProductsOutDated.Controls.Add(lblEmptyData1);
            panelProductsOutDated.Controls.Add(dgvDataOutdated);
            panelProductsOutDated.Location = new Point(3, 366);
            panelProductsOutDated.Name = "panelProductsOutDated";
            panelProductsOutDated.Size = new Size(526, 295);
            panelProductsOutDated.TabIndex = 16;
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
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle16.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle16.ForeColor = Color.White;
            dataGridViewCellStyle16.SelectionBackColor = Color.OrangeRed;
            dataGridViewCellStyle16.SelectionForeColor = Color.White;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
            dgvDataOutdated.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            dgvDataOutdated.ColumnHeadersHeight = 43;
            dgvDataOutdated.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = Color.White;
            dataGridViewCellStyle17.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle17.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.False;
            dgvDataOutdated.DefaultCellStyle = dataGridViewCellStyle17;
            dgvDataOutdated.EnableHeadersVisualStyles = false;
            dgvDataOutdated.GridColor = Color.FromArgb(64, 64, 64);
            dgvDataOutdated.Location = new Point(0, 0);
            dgvDataOutdated.Name = "dgvDataOutdated";
            dgvDataOutdated.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = Color.White;
            dataGridViewCellStyle18.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle18.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.True;
            dgvDataOutdated.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            dgvDataOutdated.RowHeadersVisible = false;
            dgvDataOutdated.RowTemplate.Height = 22;
            dgvDataOutdated.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDataOutdated.Size = new Size(523, 250);
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
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle19.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle19.ForeColor = Color.White;
            dataGridViewCellStyle19.SelectionBackColor = Color.OrangeRed;
            dataGridViewCellStyle19.SelectionForeColor = Color.White;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dataDebtSuppliers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dataDebtSuppliers.ColumnHeadersHeight = 43;
            dataDebtSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = Color.White;
            dataGridViewCellStyle20.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle20.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle20.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = DataGridViewTriState.False;
            dataDebtSuppliers.DefaultCellStyle = dataGridViewCellStyle20;
            dataDebtSuppliers.EnableHeadersVisualStyles = false;
            dataDebtSuppliers.GridColor = Color.FromArgb(64, 64, 64);
            dataDebtSuppliers.Location = new Point(0, 0);
            dataDebtSuppliers.Name = "dataDebtSuppliers";
            dataDebtSuppliers.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = Color.White;
            dataGridViewCellStyle21.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle21.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
            dataDebtSuppliers.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
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
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle22.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle22.ForeColor = Color.White;
            dataGridViewCellStyle22.SelectionBackColor = Color.OrangeRed;
            dataGridViewCellStyle22.SelectionForeColor = Color.White;
            dataGridViewCellStyle22.WrapMode = DataGridViewTriState.True;
            dataCustomerDebts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            dataCustomerDebts.ColumnHeadersHeight = 43;
            dataCustomerDebts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = Color.White;
            dataGridViewCellStyle23.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle23.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle23.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = DataGridViewTriState.False;
            dataCustomerDebts.DefaultCellStyle = dataGridViewCellStyle23;
            dataCustomerDebts.EnableHeadersVisualStyles = false;
            dataCustomerDebts.GridColor = Color.FromArgb(64, 64, 64);
            dataCustomerDebts.Location = new Point(0, 0);
            dataCustomerDebts.Name = "dataCustomerDebts";
            dataCustomerDebts.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = Color.White;
            dataGridViewCellStyle24.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle24.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = DataGridViewTriState.True;
            dataCustomerDebts.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
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
            flowLayoutPanelRight.ResumeLayout(false);
            paneldgvandlbl.ResumeLayout(false);
            paneldgvandlbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).EndInit();
            panelProductsOutDated.ResumeLayout(false);
            panelProductsOutDated.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDataOutdated).EndInit();
            panelDebtSupplier.ResumeLayout(false);
            panelDebtSupplier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataDebtSuppliers).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataCustomerDebts).EndInit();
            PanelPagination.ResumeLayout(false);
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
    }
}
