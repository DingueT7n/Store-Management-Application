namespace Store.ApplicationUI.Gui.ReturnsGui
{
    partial class ReturnUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            flowLayoutPanelstatistics = new FlowLayoutPanel();
            gBPayOptions = new GroupBox();
            btnPay = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblFactureTime = new Label();
            lblOperationMaker = new Label();
            lblTotalFacture = new Label();
            lblPaidUp = new Label();
            lblRemain = new Label();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            btnSearchFactureNumber = new Button();
            label1 = new Label();
            DtpDateFacture = new DateTimePicker();
            lblDateFacture = new Label();
            cmbStores = new ComboBox();
            cmbCustomers = new ComboBox();
            lblFacture = new Label();
            txtFactureNumber = new TextBox();
            cmbSuppliers = new ComboBox();
            lblCustomer = new Label();
            lblSuppliers = new Label();
            panelstatisticsandOperations = new Panel();
            panelButtons = new Panel();
            SearchPanel = new Panel();
            lblTitleForm = new Label();
            gpSearchAvailable = new GroupBox();
            flowLayoutPaneloperations = new FlowLayoutPanel();
            rbSale = new RadioButton();
            rbBuy = new RadioButton();
            lblEmptyData = new Label();
            DgvِProducts = new DataGridView();
            flowLayoutPanelstatistics.SuspendLayout();
            gBPayOptions.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
            panelButtons.SuspendLayout();
            SearchPanel.SuspendLayout();
            gpSearchAvailable.SuspendLayout();
            flowLayoutPaneloperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِProducts).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanelstatistics
            // 
            flowLayoutPanelstatistics.AutoScroll = true;
            flowLayoutPanelstatistics.Controls.Add(gBPayOptions);
            flowLayoutPanelstatistics.Controls.Add(flowLayoutPanel1);
            flowLayoutPanelstatistics.Dock = DockStyle.Bottom;
            flowLayoutPanelstatistics.Location = new Point(0, 540);
            flowLayoutPanelstatistics.Margin = new Padding(5);
            flowLayoutPanelstatistics.Name = "flowLayoutPanelstatistics";
            flowLayoutPanelstatistics.Size = new Size(1034, 141);
            flowLayoutPanelstatistics.TabIndex = 25;
            // 
            // gBPayOptions
            // 
            gBPayOptions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gBPayOptions.Controls.Add(btnPay);
            gBPayOptions.Location = new Point(689, 3);
            gBPayOptions.Name = "gBPayOptions";
            gBPayOptions.Size = new Size(342, 125);
            gBPayOptions.TabIndex = 8;
            gBPayOptions.TabStop = false;
            gBPayOptions.Text = "عملية الدفع";
            // 
            // btnPay
            // 
            btnPay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPay.Image = (Image)resources.GetObject("btnPay.Image");
            btnPay.ImageAlign = ContentAlignment.MiddleLeft;
            btnPay.ImeMode = ImeMode.NoControl;
            btnPay.Location = new Point(48, 25);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(290, 40);
            btnPay.TabIndex = 4;
            btnPay.Text = "ارجع الفاتورة كاملة مع الاموال المحسوبة";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(lblFactureTime);
            flowLayoutPanel1.Controls.Add(lblOperationMaker);
            flowLayoutPanel1.Controls.Add(lblTotalFacture);
            flowLayoutPanel1.Controls.Add(lblPaidUp);
            flowLayoutPanel1.Controls.Add(lblRemain);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(343, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(340, 125);
            flowLayoutPanel1.TabIndex = 24;
            // 
            // lblFactureTime
            // 
            lblFactureTime.AutoSize = true;
            lblFactureTime.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblFactureTime.ImeMode = ImeMode.NoControl;
            lblFactureTime.Location = new Point(243, 3);
            lblFactureTime.Margin = new Padding(3, 3, 3, 0);
            lblFactureTime.Name = "lblFactureTime";
            lblFactureTime.Size = new Size(94, 19);
            lblFactureTime.TabIndex = 30;
            lblFactureTime.Text = "-----------------";
            // 
            // lblOperationMaker
            // 
            lblOperationMaker.AutoSize = true;
            lblOperationMaker.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblOperationMaker.ImeMode = ImeMode.NoControl;
            lblOperationMaker.Location = new Point(243, 25);
            lblOperationMaker.Margin = new Padding(3, 3, 3, 0);
            lblOperationMaker.Name = "lblOperationMaker";
            lblOperationMaker.Size = new Size(94, 19);
            lblOperationMaker.TabIndex = 31;
            lblOperationMaker.Text = "-----------------";
            // 
            // lblTotalFacture
            // 
            lblTotalFacture.AutoSize = true;
            lblTotalFacture.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblTotalFacture.ImeMode = ImeMode.NoControl;
            lblTotalFacture.Location = new Point(243, 47);
            lblTotalFacture.Margin = new Padding(3, 3, 3, 0);
            lblTotalFacture.Name = "lblTotalFacture";
            lblTotalFacture.Size = new Size(94, 19);
            lblTotalFacture.TabIndex = 32;
            lblTotalFacture.Text = "-----------------";
            // 
            // lblPaidUp
            // 
            lblPaidUp.AutoSize = true;
            lblPaidUp.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblPaidUp.ImeMode = ImeMode.NoControl;
            lblPaidUp.Location = new Point(243, 69);
            lblPaidUp.Margin = new Padding(3, 3, 3, 0);
            lblPaidUp.Name = "lblPaidUp";
            lblPaidUp.Size = new Size(94, 19);
            lblPaidUp.TabIndex = 33;
            lblPaidUp.Text = "-----------------";
            // 
            // lblRemain
            // 
            lblRemain.AutoSize = true;
            lblRemain.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblRemain.ImeMode = ImeMode.NoControl;
            lblRemain.Location = new Point(243, 91);
            lblRemain.Margin = new Padding(3, 3, 3, 0);
            lblRemain.Name = "lblRemain";
            lblRemain.Size = new Size(94, 19);
            lblRemain.TabIndex = 34;
            lblRemain.Text = "-----------------";
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(gbPayChoiches);
            OperationsflowLayoutPanel.Controls.Add(panelstatisticsandOperations);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1034, 145);
            OperationsflowLayoutPanel.TabIndex = 26;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(btnSearchFactureNumber);
            gbPayChoiches.Controls.Add(label1);
            gbPayChoiches.Controls.Add(DtpDateFacture);
            gbPayChoiches.Controls.Add(lblDateFacture);
            gbPayChoiches.Controls.Add(cmbStores);
            gbPayChoiches.Controls.Add(cmbCustomers);
            gbPayChoiches.Controls.Add(lblFacture);
            gbPayChoiches.Controls.Add(txtFactureNumber);
            gbPayChoiches.Controls.Add(cmbSuppliers);
            gbPayChoiches.Controls.Add(lblCustomer);
            gbPayChoiches.Controls.Add(lblSuppliers);
            gbPayChoiches.Location = new Point(612, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(419, 137);
            gbPayChoiches.TabIndex = 8;
            gbPayChoiches.TabStop = false;
            gbPayChoiches.Text = "معلومات حول الفاتورة:";
            // 
            // btnSearchFactureNumber
            // 
            btnSearchFactureNumber.Anchor = AnchorStyles.None;
            btnSearchFactureNumber.Image = (Image)resources.GetObject("btnSearchFactureNumber.Image");
            btnSearchFactureNumber.ImeMode = ImeMode.NoControl;
            btnSearchFactureNumber.Location = new Point(114, 25);
            btnSearchFactureNumber.Name = "btnSearchFactureNumber";
            btnSearchFactureNumber.Size = new Size(32, 28);
            btnSearchFactureNumber.TabIndex = 31;
            btnSearchFactureNumber.Text = "       تصدير/طباعة جميع فاتورات المورد";
            btnSearchFactureNumber.UseVisualStyleBackColor = true;
            btnSearchFactureNumber.Click += btnSearchFactureNumber_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(365, 106);
            label1.Name = "label1";
            label1.Size = new Size(51, 19);
            label1.TabIndex = 27;
            label1.Text = "المخزن:";
            // 
            // DtpDateFacture
            // 
            DtpDateFacture.CustomFormat = "yyyy-MM-dd";
            DtpDateFacture.Format = DateTimePickerFormat.Short;
            DtpDateFacture.Location = new Point(4, 65);
            DtpDateFacture.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            DtpDateFacture.Name = "DtpDateFacture";
            DtpDateFacture.Size = new Size(116, 27);
            DtpDateFacture.TabIndex = 26;
            DtpDateFacture.Value = new DateTime(2024, 8, 27, 0, 0, 0, 0);
            // 
            // lblDateFacture
            // 
            lblDateFacture.AutoSize = true;
            lblDateFacture.ImeMode = ImeMode.NoControl;
            lblDateFacture.Location = new Point(6, 28);
            lblDateFacture.Name = "lblDateFacture";
            lblDateFacture.Size = new Size(87, 19);
            lblDateFacture.TabIndex = 14;
            lblDateFacture.Text = "تاريخ الفاتورة:";
            // 
            // cmbStores
            // 
            cmbStores.FormattingEnabled = true;
            cmbStores.Location = new Point(152, 103);
            cmbStores.Name = "cmbStores";
            cmbStores.Size = new Size(181, 27);
            cmbStores.TabIndex = 13;
            cmbStores.Text = "اختر مخزن";
            // 
            // cmbCustomers
            // 
            cmbCustomers.Enabled = false;
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(152, 65);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(181, 27);
            cmbCustomers.TabIndex = 11;
            cmbCustomers.Text = "اختر العميل";
            // 
            // lblFacture
            // 
            lblFacture.AutoSize = true;
            lblFacture.ImeMode = ImeMode.NoControl;
            lblFacture.Location = new Point(340, 28);
            lblFacture.Name = "lblFacture";
            lblFacture.Size = new Size(76, 19);
            lblFacture.TabIndex = 9;
            lblFacture.Text = "رقم الفاتورة:";
            // 
            // txtFactureNumber
            // 
            txtFactureNumber.Location = new Point(152, 26);
            txtFactureNumber.Name = "txtFactureNumber";
            txtFactureNumber.PlaceholderText = "رقم الفاتورة";
            txtFactureNumber.Size = new Size(181, 27);
            txtFactureNumber.TabIndex = 7;
            txtFactureNumber.TextAlign = HorizontalAlignment.Center;
            txtFactureNumber.KeyDown += txtFactureNumber_KeyDown;
            // 
            // cmbSuppliers
            // 
            cmbSuppliers.Enabled = false;
            cmbSuppliers.FormattingEnabled = true;
            cmbSuppliers.Location = new Point(152, 65);
            cmbSuppliers.Name = "cmbSuppliers";
            cmbSuppliers.Size = new Size(181, 27);
            cmbSuppliers.TabIndex = 30;
            cmbSuppliers.Text = "اختر مورد";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.ImeMode = ImeMode.NoControl;
            lblCustomer.Location = new Point(363, 70);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(48, 19);
            lblCustomer.TabIndex = 10;
            lblCustomer.Text = "العميل:";
            lblCustomer.Click += lblCustomer_Click;
            // 
            // lblSuppliers
            // 
            lblSuppliers.AutoSize = true;
            lblSuppliers.ImeMode = ImeMode.NoControl;
            lblSuppliers.Location = new Point(365, 70);
            lblSuppliers.Name = "lblSuppliers";
            lblSuppliers.Size = new Size(46, 19);
            lblSuppliers.TabIndex = 29;
            lblSuppliers.Text = "المورد:";
            // 
            // panelstatisticsandOperations
            // 
            panelstatisticsandOperations.Controls.Add(panelButtons);
            panelstatisticsandOperations.Dock = DockStyle.Fill;
            panelstatisticsandOperations.Location = new Point(5, 3);
            panelstatisticsandOperations.Name = "panelstatisticsandOperations";
            panelstatisticsandOperations.Size = new Size(601, 137);
            panelstatisticsandOperations.TabIndex = 10;
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelButtons.Controls.Add(SearchPanel);
            panelButtons.Location = new Point(3, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1026, 134);
            panelButtons.TabIndex = 9;
            // 
            // SearchPanel
            // 
            SearchPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchPanel.Controls.Add(lblTitleForm);
            SearchPanel.Controls.Add(gpSearchAvailable);
            SearchPanel.Location = new Point(335, 6);
            SearchPanel.Name = "SearchPanel";
            SearchPanel.Size = new Size(260, 134);
            SearchPanel.TabIndex = 8;
            // 
            // lblTitleForm
            // 
            lblTitleForm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitleForm.AutoSize = true;
            lblTitleForm.Font = new Font("Calibri", 14.25F);
            lblTitleForm.ForeColor = Color.Red;
            lblTitleForm.ImeMode = ImeMode.NoControl;
            lblTitleForm.Location = new Point(68, -3);
            lblTitleForm.Margin = new Padding(3);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(98, 23);
            lblTitleForm.TabIndex = 14;
            lblTitleForm.Text = "ارجاع منتجات";
            // 
            // gpSearchAvailable
            // 
            gpSearchAvailable.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            gpSearchAvailable.Controls.Add(flowLayoutPaneloperations);
            gpSearchAvailable.Location = new Point(1, 19);
            gpSearchAvailable.Name = "gpSearchAvailable";
            gpSearchAvailable.Size = new Size(256, 112);
            gpSearchAvailable.TabIndex = 17;
            gpSearchAvailable.TabStop = false;
            gpSearchAvailable.Text = "عمليات البحث المتاحة";
            // 
            // flowLayoutPaneloperations
            // 
            flowLayoutPaneloperations.AutoScroll = true;
            flowLayoutPaneloperations.Controls.Add(rbSale);
            flowLayoutPaneloperations.Controls.Add(rbBuy);
            flowLayoutPaneloperations.Dock = DockStyle.Fill;
            flowLayoutPaneloperations.Location = new Point(3, 23);
            flowLayoutPaneloperations.Name = "flowLayoutPaneloperations";
            flowLayoutPaneloperations.Size = new Size(250, 86);
            flowLayoutPaneloperations.TabIndex = 9;
            // 
            // rbSale
            // 
            rbSale.AutoSize = true;
            rbSale.Checked = true;
            rbSale.Location = new Point(107, 3);
            rbSale.Name = "rbSale";
            rbSale.Size = new Size(140, 23);
            rbSale.TabIndex = 0;
            rbSale.TabStop = true;
            rbSale.Text = "ارجاع فاتورة مبيعات ";
            rbSale.UseVisualStyleBackColor = true;
            // 
            // rbBuy
            // 
            rbBuy.AutoSize = true;
            rbBuy.Location = new Point(124, 32);
            rbBuy.Name = "rbBuy";
            rbBuy.Size = new Size(123, 23);
            rbBuy.TabIndex = 1;
            rbBuy.Text = "ارجاع فاتورة شراء ";
            rbBuy.UseVisualStyleBackColor = true;
            rbBuy.CheckedChanged += rbBuy_CheckedChanged;
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
            lblEmptyData.TabIndex = 28;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvِProducts
            // 
            DgvِProducts.AllowUserToAddRows = false;
            DgvِProducts.AllowUserToResizeColumns = false;
            DgvِProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvِProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvِProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvِProducts.BackgroundColor = Color.White;
            DgvِProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvِProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvِProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvِProducts.ColumnHeadersHeight = 40;
            DgvِProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvِProducts.DefaultCellStyle = dataGridViewCellStyle3;
            DgvِProducts.Dock = DockStyle.Fill;
            DgvِProducts.EnableHeadersVisualStyles = false;
            DgvِProducts.GridColor = SystemColors.ControlDark;
            DgvِProducts.Location = new Point(0, 145);
            DgvِProducts.MultiSelect = false;
            DgvِProducts.Name = "DgvِProducts";
            DgvِProducts.ReadOnly = true;
            DgvِProducts.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvِProducts.RowHeadersVisible = false;
            DgvِProducts.RowHeadersWidth = 21;
            DgvِProducts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِProducts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvِProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvِProducts.Size = new Size(1034, 395);
            DgvِProducts.TabIndex = 29;
            // 
            // ReturnUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblEmptyData);
            Controls.Add(DgvِProducts);
            Controls.Add(OperationsflowLayoutPanel);
            Controls.Add(flowLayoutPanelstatistics);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReturnUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            flowLayoutPanelstatistics.ResumeLayout(false);
            gBPayOptions.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            gbPayChoiches.PerformLayout();
            panelstatisticsandOperations.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            gpSearchAvailable.ResumeLayout(false);
            flowLayoutPaneloperations.ResumeLayout(false);
            flowLayoutPaneloperations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelstatistics;
        private GroupBox gBPayOptions;
        private Button btnPay;
        private FlowLayoutPanel OperationsflowLayoutPanel;
        private GroupBox gbPayChoiches;
        private Label label1;
        private DateTimePicker DtpDateFacture;
        private Label lblDateFacture;
        private ComboBox cmbStores;
        private ComboBox cmbCustomers;
        private Label lblCustomer;
        private Label lblFacture;
        private TextBox txtFactureNumber;
        private Panel panelstatisticsandOperations;
        private Panel SearchPanel;
        private Label lblTitleForm;
        private GroupBox gpSearchAvailable;
        private Panel panelButtons;
        private Label lblEmptyData;
        private DataGridView DgvِProducts;
        private RadioButton rbBuy;
        private RadioButton rbSale;
        private Label lblSuppliers;
        private ComboBox cmbSuppliers;
        private Button btnSearchFactureNumber;
        private FlowLayoutPanel flowLayoutPaneloperations;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblFactureTime;
        private Label lblOperationMaker;
        private Label lblTotalFacture;
        private Label lblPaidUp;
        private Label lblRemain;
    }
}
