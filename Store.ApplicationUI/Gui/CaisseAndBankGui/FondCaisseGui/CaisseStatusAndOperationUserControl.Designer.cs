namespace Store.ApplicationUI.Gui.CaisseAndBankGui.FondCaisseGui
{
    partial class CaisseStatusAndOperationUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaisseStatusAndOperationUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            Dgv1 = new DataGridView();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            lblTo = new Label();
            lblFrom = new Label();
            flowLayoutPanelreturnsoption = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            cmbCaisse = new ComboBox();
            rbStoresFromAll = new RadioButton();
            rbStoresFrom = new RadioButton();
            panelstatisticsandOperations = new Panel();
            lblTitleForm = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panelButtons = new Panel();
            button2 = new Button();
            tabPage2 = new TabPage();
            panel4 = new Panel();
            cmbpagination2 = new ComboBox();
            btnPrev2 = new Button();
            btnNext2 = new Button();
            lblEmptyData2 = new Label();
            Dgv2 = new DataGridView();
            flowLayoutPanel2 = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            dtpFrom2 = new DateTimePicker();
            dtpTo2 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            groupBox3 = new GroupBox();
            cmbCaisse2 = new ComboBox();
            rbStoresFromAll2 = new RadioButton();
            rbStoresFrom2 = new RadioButton();
            panel1 = new Panel();
            label3 = new Label();
            flowLayoutPanel4 = new FlowLayoutPanel();
            panel2 = new Panel();
            txtSearch2 = new TextBox();
            btnSearch2 = new Button();
            panel3 = new Panel();
            button3 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            PanelPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv1).BeginInit();
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            flowLayoutPanelreturnsoption.SuspendLayout();
            groupBox1.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
            SearchPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            tabPage2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv2).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            groupBox3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            tabPage1.Controls.Add(Dgv1);
            tabPage1.Controls.Add(OperationsflowLayoutPanel);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1026, 649);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "تقرير جميع حالات الصناديق";
            // 
            // PanelPagination
            // 
            PanelPagination.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelPagination.Controls.Add(cmbpagination);
            PanelPagination.Controls.Add(btnPrev);
            PanelPagination.Controls.Add(btnNext);
            PanelPagination.Location = new Point(6, 603);
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
            lblEmptyData.TabIndex = 36;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // Dgv1
            // 
            Dgv1.AllowUserToAddRows = false;
            Dgv1.AllowUserToResizeColumns = false;
            Dgv1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            Dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            Dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Dgv1.BackgroundColor = Color.White;
            Dgv1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            Dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            Dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            Dgv1.ColumnHeadersHeight = 40;
            Dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            Dgv1.DefaultCellStyle = dataGridViewCellStyle3;
            Dgv1.Dock = DockStyle.Fill;
            Dgv1.EnableHeadersVisualStyles = false;
            Dgv1.GridColor = SystemColors.ControlDark;
            Dgv1.Location = new Point(3, 177);
            Dgv1.MultiSelect = false;
            Dgv1.Name = "Dgv1";
            Dgv1.ReadOnly = true;
            Dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Dgv1.RowHeadersVisible = false;
            Dgv1.RowHeadersWidth = 21;
            Dgv1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            Dgv1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            Dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv1.Size = new Size(1020, 469);
            Dgv1.TabIndex = 37;
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
            OperationsflowLayoutPanel.Size = new Size(1020, 174);
            OperationsflowLayoutPanel.TabIndex = 20;
            // 
            // gbPayChoiches
            // 
            gbPayChoiches.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbPayChoiches.Controls.Add(dtpFrom);
            gbPayChoiches.Controls.Add(dtpTo);
            gbPayChoiches.Controls.Add(lblTo);
            gbPayChoiches.Controls.Add(lblFrom);
            gbPayChoiches.Controls.Add(flowLayoutPanelreturnsoption);
            gbPayChoiches.Location = new Point(560, 3);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.Size = new Size(457, 165);
            gbPayChoiches.TabIndex = 8;
            gbPayChoiches.TabStop = false;
            gbPayChoiches.Text = "اختيارات البحث";
            // 
            // dtpFrom
            // 
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(245, 111);
            dtpFrom.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(119, 27);
            dtpFrom.TabIndex = 33;
            dtpFrom.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // dtpTo
            // 
            dtpTo.CustomFormat = "yyyy-MM-dd";
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(83, 111);
            dtpTo.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(119, 27);
            dtpTo.TabIndex = 32;
            dtpTo.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.ImeMode = ImeMode.NoControl;
            lblTo.Location = new Point(208, 113);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(27, 19);
            lblTo.TabIndex = 31;
            lblTo.Text = "الى:";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.ImeMode = ImeMode.NoControl;
            lblFrom.Location = new Point(365, 114);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(28, 19);
            lblFrom.TabIndex = 30;
            lblFrom.Text = "من:";
            // 
            // flowLayoutPanelreturnsoption
            // 
            flowLayoutPanelreturnsoption.Controls.Add(groupBox1);
            flowLayoutPanelreturnsoption.Dock = DockStyle.Top;
            flowLayoutPanelreturnsoption.Location = new Point(3, 23);
            flowLayoutPanelreturnsoption.Name = "flowLayoutPanelreturnsoption";
            flowLayoutPanelreturnsoption.Size = new Size(451, 50);
            flowLayoutPanelreturnsoption.TabIndex = 28;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbCaisse);
            groupBox1.Controls.Add(rbStoresFromAll);
            groupBox1.Controls.Add(rbStoresFrom);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(445, 47);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "الصناديق التي تم الايداع فيها";
            // 
            // cmbCaisse
            // 
            cmbCaisse.Enabled = false;
            cmbCaisse.FormattingEnabled = true;
            cmbCaisse.Location = new Point(6, 15);
            cmbCaisse.Margin = new Padding(3, 15, 3, 3);
            cmbCaisse.Name = "cmbCaisse";
            cmbCaisse.Size = new Size(156, 27);
            cmbCaisse.TabIndex = 9;
            cmbCaisse.SelectionChangeCommitted += cmbCaisse_SelectionChangeCommitted;
            // 
            // rbStoresFromAll
            // 
            rbStoresFromAll.AutoSize = true;
            rbStoresFromAll.Checked = true;
            rbStoresFromAll.ImeMode = ImeMode.NoControl;
            rbStoresFromAll.Location = new Point(344, 19);
            rbStoresFromAll.Margin = new Padding(15, 3, 15, 3);
            rbStoresFromAll.Name = "rbStoresFromAll";
            rbStoresFromAll.Size = new Size(95, 23);
            rbStoresFromAll.TabIndex = 6;
            rbStoresFromAll.TabStop = true;
            rbStoresFromAll.Text = "كل الصناديق";
            rbStoresFromAll.UseVisualStyleBackColor = true;
            rbStoresFromAll.CheckedChanged += rbStoresFromAll_CheckedChanged;
            // 
            // rbStoresFrom
            // 
            rbStoresFrom.AutoSize = true;
            rbStoresFrom.BackColor = Color.White;
            rbStoresFrom.ForeColor = SystemColors.ControlText;
            rbStoresFrom.ImeMode = ImeMode.NoControl;
            rbStoresFrom.Location = new Point(168, 18);
            rbStoresFrom.Margin = new Padding(15, 3, 15, 3);
            rbStoresFrom.Name = "rbStoresFrom";
            rbStoresFrom.Size = new Size(103, 23);
            rbStoresFrom.TabIndex = 7;
            rbStoresFrom.Text = "صندوق محدد";
            rbStoresFrom.UseVisualStyleBackColor = false;
            rbStoresFrom.CheckedChanged += rbStoresFrom_CheckedChanged;
            // 
            // panelstatisticsandOperations
            // 
            panelstatisticsandOperations.Controls.Add(lblTitleForm);
            panelstatisticsandOperations.Controls.Add(flowLayoutPanel1);
            panelstatisticsandOperations.Controls.Add(SearchPanel);
            panelstatisticsandOperations.Location = new Point(254, 3);
            panelstatisticsandOperations.Name = "panelstatisticsandOperations";
            panelstatisticsandOperations.Size = new Size(300, 165);
            panelstatisticsandOperations.TabIndex = 10;
            // 
            // lblTitleForm
            // 
            lblTitleForm.AutoSize = true;
            lblTitleForm.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleForm.ForeColor = Color.Red;
            lblTitleForm.ImeMode = ImeMode.NoControl;
            lblTitleForm.Location = new Point(71, 4);
            lblTitleForm.Margin = new Padding(3);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(147, 23);
            lblTitleForm.TabIndex = 13;
            lblTitleForm.Text = "تقرير حالات الصناديق";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(25, 79);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(247, 76);
            flowLayoutPanel1.TabIndex = 12;
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
            txtSearch.PlaceholderText = "ادخل معلومة للبحث";
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
            // panelButtons
            // 
            panelButtons.Controls.Add(button2);
            panelButtons.Location = new Point(18, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(230, 165);
            panelButtons.TabIndex = 9;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.ImeMode = ImeMode.NoControl;
            button2.Location = new Point(2, 4);
            button2.Name = "button2";
            button2.Size = new Size(225, 40);
            button2.TabIndex = 8;
            button2.Text = "حذف جميع بيانات الجدول";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(panel4);
            tabPage2.Controls.Add(lblEmptyData2);
            tabPage2.Controls.Add(Dgv2);
            tabPage2.Controls.Add(flowLayoutPanel2);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1026, 649);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "تقرير جميع عمليات الحالات على الصناديق";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel4.Controls.Add(cmbpagination2);
            panel4.Controls.Add(btnPrev2);
            panel4.Controls.Add(btnNext2);
            panel4.Location = new Point(6, 603);
            panel4.Name = "panel4";
            panel4.Size = new Size(169, 40);
            panel4.TabIndex = 39;
            // 
            // cmbpagination2
            // 
            cmbpagination2.Dock = DockStyle.Fill;
            cmbpagination2.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbpagination2.FormattingEnabled = true;
            cmbpagination2.Location = new Point(50, 0);
            cmbpagination2.Name = "cmbpagination2";
            cmbpagination2.Size = new Size(69, 37);
            cmbpagination2.TabIndex = 28;
            cmbpagination2.SelectionChangeCommitted += cmbpagination2_SelectionChangeCommitted;
            // 
            // btnPrev2
            // 
            btnPrev2.Dock = DockStyle.Left;
            btnPrev2.Image = (Image)resources.GetObject("btnPrev2.Image");
            btnPrev2.ImeMode = ImeMode.NoControl;
            btnPrev2.Location = new Point(0, 0);
            btnPrev2.Name = "btnPrev2";
            btnPrev2.Size = new Size(50, 40);
            btnPrev2.TabIndex = 26;
            btnPrev2.UseVisualStyleBackColor = true;
            btnPrev2.Click += btnPrev2_Click;
            // 
            // btnNext2
            // 
            btnNext2.Dock = DockStyle.Right;
            btnNext2.Image = (Image)resources.GetObject("btnNext2.Image");
            btnNext2.ImeMode = ImeMode.NoControl;
            btnNext2.Location = new Point(119, 0);
            btnNext2.Name = "btnNext2";
            btnNext2.Size = new Size(50, 40);
            btnNext2.TabIndex = 25;
            btnNext2.UseVisualStyleBackColor = true;
            btnNext2.Click += btnNext2_Click;
            // 
            // lblEmptyData2
            // 
            lblEmptyData2.Anchor = AnchorStyles.None;
            lblEmptyData2.AutoSize = true;
            lblEmptyData2.BackColor = Color.Transparent;
            lblEmptyData2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblEmptyData2.ForeColor = Color.Crimson;
            lblEmptyData2.ImeMode = ImeMode.NoControl;
            lblEmptyData2.Location = new Point(451, 353);
            lblEmptyData2.Name = "lblEmptyData2";
            lblEmptyData2.Size = new Size(133, 19);
            lblEmptyData2.TabIndex = 38;
            lblEmptyData2.Text = "لا توجد بيانات لعرضها";
            lblEmptyData2.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData2.Visible = false;
            // 
            // Dgv2
            // 
            Dgv2.AllowUserToAddRows = false;
            Dgv2.AllowUserToResizeColumns = false;
            Dgv2.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            Dgv2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            Dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Dgv2.BackgroundColor = Color.White;
            Dgv2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            Dgv2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            Dgv2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            Dgv2.ColumnHeadersHeight = 40;
            Dgv2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            Dgv2.DefaultCellStyle = dataGridViewCellStyle7;
            Dgv2.Dock = DockStyle.Fill;
            Dgv2.EnableHeadersVisualStyles = false;
            Dgv2.GridColor = SystemColors.ControlDark;
            Dgv2.Location = new Point(3, 177);
            Dgv2.MultiSelect = false;
            Dgv2.Name = "Dgv2";
            Dgv2.ReadOnly = true;
            Dgv2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Dgv2.RowHeadersVisible = false;
            Dgv2.RowHeadersWidth = 21;
            Dgv2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            Dgv2.RowsDefaultCellStyle = dataGridViewCellStyle8;
            Dgv2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv2.Size = new Size(1020, 469);
            Dgv2.TabIndex = 39;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Add(groupBox2);
            flowLayoutPanel2.Controls.Add(panel1);
            flowLayoutPanel2.Controls.Add(panel3);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Margin = new Padding(5);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1020, 174);
            flowLayoutPanel2.TabIndex = 21;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(dtpFrom2);
            groupBox2.Controls.Add(dtpTo2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(flowLayoutPanel3);
            groupBox2.Location = new Point(560, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(457, 165);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "اختيارات البحث";
            // 
            // dtpFrom2
            // 
            dtpFrom2.CustomFormat = "yyyy-MM-dd";
            dtpFrom2.Format = DateTimePickerFormat.Short;
            dtpFrom2.Location = new Point(245, 111);
            dtpFrom2.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpFrom2.Name = "dtpFrom2";
            dtpFrom2.Size = new Size(119, 27);
            dtpFrom2.TabIndex = 33;
            dtpFrom2.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // dtpTo2
            // 
            dtpTo2.CustomFormat = "yyyy-MM-dd";
            dtpTo2.Format = DateTimePickerFormat.Short;
            dtpTo2.Location = new Point(83, 111);
            dtpTo2.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpTo2.Name = "dtpTo2";
            dtpTo2.Size = new Size(119, 27);
            dtpTo2.TabIndex = 32;
            dtpTo2.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(208, 115);
            label1.Name = "label1";
            label1.Size = new Size(27, 19);
            label1.TabIndex = 31;
            label1.Text = "الى:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(365, 114);
            label2.Name = "label2";
            label2.Size = new Size(28, 19);
            label2.TabIndex = 30;
            label2.Text = "من:";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(groupBox3);
            flowLayoutPanel3.Dock = DockStyle.Top;
            flowLayoutPanel3.Location = new Point(3, 23);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(451, 50);
            flowLayoutPanel3.TabIndex = 28;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cmbCaisse2);
            groupBox3.Controls.Add(rbStoresFromAll2);
            groupBox3.Controls.Add(rbStoresFrom2);
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(445, 47);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "الصناديق التي تم الايداع فيها";
            // 
            // cmbCaisse2
            // 
            cmbCaisse2.Enabled = false;
            cmbCaisse2.FormattingEnabled = true;
            cmbCaisse2.Location = new Point(6, 15);
            cmbCaisse2.Margin = new Padding(3, 15, 3, 3);
            cmbCaisse2.Name = "cmbCaisse2";
            cmbCaisse2.Size = new Size(156, 27);
            cmbCaisse2.TabIndex = 9;
            cmbCaisse2.SelectionChangeCommitted += cmbCaisse2_SelectionChangeCommitted;
            // 
            // rbStoresFromAll2
            // 
            rbStoresFromAll2.AutoSize = true;
            rbStoresFromAll2.Checked = true;
            rbStoresFromAll2.ImeMode = ImeMode.NoControl;
            rbStoresFromAll2.Location = new Point(344, 19);
            rbStoresFromAll2.Margin = new Padding(15, 3, 15, 3);
            rbStoresFromAll2.Name = "rbStoresFromAll2";
            rbStoresFromAll2.Size = new Size(95, 23);
            rbStoresFromAll2.TabIndex = 6;
            rbStoresFromAll2.TabStop = true;
            rbStoresFromAll2.Text = "كل الصناديق";
            rbStoresFromAll2.UseVisualStyleBackColor = true;
            rbStoresFromAll2.CheckedChanged += rbStoresFromAll2_CheckedChanged;
            // 
            // rbStoresFrom2
            // 
            rbStoresFrom2.AutoSize = true;
            rbStoresFrom2.BackColor = Color.White;
            rbStoresFrom2.ForeColor = SystemColors.ControlText;
            rbStoresFrom2.ImeMode = ImeMode.NoControl;
            rbStoresFrom2.Location = new Point(168, 18);
            rbStoresFrom2.Margin = new Padding(15, 3, 15, 3);
            rbStoresFrom2.Name = "rbStoresFrom2";
            rbStoresFrom2.Size = new Size(103, 23);
            rbStoresFrom2.TabIndex = 7;
            rbStoresFrom2.Text = "صندوق محدد";
            rbStoresFrom2.UseVisualStyleBackColor = false;
            rbStoresFrom2.CheckedChanged += rbStoresFrom2_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(flowLayoutPanel4);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(254, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 165);
            panel1.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Red;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(42, 4);
            label3.Margin = new Padding(3);
            label3.Name = "label3";
            label3.Size = new Size(234, 23);
            label3.TabIndex = 13;
            label3.Text = "تقرير عمليات الحالات على الصناديق";
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Location = new Point(25, 79);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(247, 76);
            flowLayoutPanel4.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtSearch2);
            panel2.Controls.Add(btnSearch2);
            panel2.Location = new Point(3, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(294, 40);
            panel2.TabIndex = 8;
            // 
            // txtSearch2
            // 
            txtSearch2.Dock = DockStyle.Fill;
            txtSearch2.Font = new Font("Calibri", 12F);
            txtSearch2.Location = new Point(50, 0);
            txtSearch2.Multiline = true;
            txtSearch2.Name = "txtSearch2";
            txtSearch2.PlaceholderText = "ادخل معلومة للبحث";
            txtSearch2.Size = new Size(244, 40);
            txtSearch2.TabIndex = 9;
            txtSearch2.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSearch2
            // 
            btnSearch2.Dock = DockStyle.Left;
            btnSearch2.Image = (Image)resources.GetObject("btnSearch2.Image");
            btnSearch2.ImeMode = ImeMode.NoControl;
            btnSearch2.Location = new Point(0, 0);
            btnSearch2.Name = "btnSearch2";
            btnSearch2.Size = new Size(50, 40);
            btnSearch2.TabIndex = 7;
            btnSearch2.UseVisualStyleBackColor = true;
            btnSearch2.Click += btnSearch2_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(button3);
            panel3.Location = new Point(18, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(230, 165);
            panel3.TabIndex = 9;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.ImeMode = ImeMode.NoControl;
            button3.Location = new Point(2, 4);
            button3.Name = "button3";
            button3.Size = new Size(225, 40);
            button3.TabIndex = 8;
            button3.Text = "حذف جميع بيانات الجدول";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // CaisseStatusAndOperationUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tabControl1);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CaisseStatusAndOperationUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            PanelPagination.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Dgv1).EndInit();
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            gbPayChoiches.PerformLayout();
            flowLayoutPanelreturnsoption.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelstatisticsandOperations.ResumeLayout(false);
            panelstatisticsandOperations.PerformLayout();
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Dgv2).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private FlowLayoutPanel OperationsflowLayoutPanel;
        private GroupBox gbPayChoiches;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label lblTo;
        private Label lblFrom;
        private FlowLayoutPanel flowLayoutPanelreturnsoption;
        private GroupBox groupBox1;
        private ComboBox cmbCaisse;
        private RadioButton rbStoresFromAll;
        private RadioButton rbStoresFrom;
        private Panel panelstatisticsandOperations;
        private Label lblTitleForm;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel panelButtons;
        private Button button2;
        private Label lblEmptyData;
        private DataGridView Dgv1;
        private TabPage tabPage2;
        private Panel PanelPagination;
        private ComboBox cmbpagination;
        private Button btnPrev;
        private Button btnNext;
        private FlowLayoutPanel flowLayoutPanel2;
        private GroupBox groupBox2;
        private DateTimePicker dtpFrom2;
        private DateTimePicker dtpTo2;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel3;
        private GroupBox groupBox3;
        private ComboBox cmbCaisse2;
        private RadioButton rbStoresFromAll2;
        private RadioButton rbStoresFrom2;
        private Panel panel1;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel4;
        private Panel panel2;
        private TextBox txtSearch2;
        private Button btnSearch2;
        private Panel panel3;
        private Button button3;
        private Panel panel4;
        private ComboBox cmbpagination2;
        private Button btnPrev2;
        private Button btnNext2;
        private Label lblEmptyData2;
        private DataGridView Dgv2;
    }
}
