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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
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
            flowLayoutPanelRight.SuspendLayout();
            paneldgvandlbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).BeginInit();
            panelProductsOutDated.SuspendLayout();
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
            paneldgvandlbl.Controls.Add(lblEmptyData);
            paneldgvandlbl.Controls.Add(DgvProducts);
            paneldgvandlbl.Location = new Point(3, 30);
            paneldgvandlbl.Name = "paneldgvandlbl";
            paneldgvandlbl.Size = new Size(526, 253);
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
            lblEmptyData.Location = new Point(196, 101);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.OrangeRed;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DgvProducts.ColumnHeadersHeight = 43;
            DgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            DgvProducts.EnableHeadersVisualStyles = false;
            DgvProducts.GridColor = Color.FromArgb(64, 64, 64);
            DgvProducts.Location = new Point(0, 0);
            DgvProducts.Name = "DgvProducts";
            DgvProducts.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DgvProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DgvProducts.RowHeadersVisible = false;
            DgvProducts.RowTemplate.Height = 22;
            DgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvProducts.Size = new Size(530, 250);
            DgvProducts.TabIndex = 9;
            // 
            // gbOutDatedData
            // 
            gbOutDatedData.Font = new Font("Calibri", 12F, FontStyle.Bold);
            gbOutDatedData.ForeColor = Color.Red;
            gbOutDatedData.Location = new Point(3, 289);
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
            panelProductsOutDated.Location = new Point(3, 316);
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.OrangeRed;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvDataOutdated.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvDataOutdated.ColumnHeadersHeight = 43;
            dgvDataOutdated.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvDataOutdated.DefaultCellStyle = dataGridViewCellStyle5;
            dgvDataOutdated.EnableHeadersVisualStyles = false;
            dgvDataOutdated.GridColor = Color.FromArgb(64, 64, 64);
            dgvDataOutdated.Location = new Point(0, 0);
            dgvDataOutdated.Name = "dgvDataOutdated";
            dgvDataOutdated.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvDataOutdated.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
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
            gbDebtToSuppliers.Location = new Point(3, 617);
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
            panelDebtSupplier.Location = new Point(3, 644);
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
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.OrangeRed;
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataDebtSuppliers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataDebtSuppliers.ColumnHeadersHeight = 43;
            dataDebtSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dataDebtSuppliers.DefaultCellStyle = dataGridViewCellStyle8;
            dataDebtSuppliers.EnableHeadersVisualStyles = false;
            dataDebtSuppliers.GridColor = Color.FromArgb(64, 64, 64);
            dataDebtSuppliers.Location = new Point(0, 0);
            dataDebtSuppliers.Name = "dataDebtSuppliers";
            dataDebtSuppliers.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dataDebtSuppliers.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
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
            gbCustomers.Location = new Point(3, 904);
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
            panel1.Location = new Point(3, 931);
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
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle10.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.SelectionBackColor = Color.OrangeRed;
            dataGridViewCellStyle10.SelectionForeColor = Color.White;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dataCustomerDebts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dataCustomerDebts.ColumnHeadersHeight = 43;
            dataCustomerDebts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.White;
            dataGridViewCellStyle11.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dataCustomerDebts.DefaultCellStyle = dataGridViewCellStyle11;
            dataCustomerDebts.EnableHeadersVisualStyles = false;
            dataCustomerDebts.GridColor = Color.FromArgb(64, 64, 64);
            dataCustomerDebts.Location = new Point(0, 0);
            dataCustomerDebts.Name = "dataCustomerDebts";
            dataCustomerDebts.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dataCustomerDebts.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
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
    }
}
