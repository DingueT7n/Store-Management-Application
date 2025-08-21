namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui.StoreInventoryGui
{
    partial class InverntoryOperationsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InverntoryOperationsForm));
            lblEmptyData = new Label();
            DgvStore = new DataGridView();
            GbInfoCategory = new GroupBox();
            groupBox1 = new GroupBox();
            cmbStoresFrom = new ComboBox();
            rbStoresFromAll = new RadioButton();
            rbStoresFrom = new RadioButton();
            label3 = new Label();
            txtNotes = new TextBox();
            dtpFrom = new DateTimePicker();
            lblFrom = new Label();
            btnRefresh = new Button();
            label1 = new Label();
            label2 = new Label();
            lblCategoryId = new Label();
            label13 = new Label();
            txtPerformedBy = new TextBox();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddStore = new Button();
            btnEditStore = new Button();
            btnDeleteStore = new Button();
            button1 = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvStore).BeginInit();
            GbInfoCategory.SuspendLayout();
            groupBox1.SuspendLayout();
            OperationsflowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblEmptyData
            // 
            lblEmptyData.Anchor = AnchorStyles.None;
            lblEmptyData.AutoSize = true;
            lblEmptyData.BackColor = Color.Transparent;
            lblEmptyData.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 7);
            lblEmptyData.ForeColor = Color.Crimson;
            lblEmptyData.Location = new Point(428, 280);
            lblEmptyData.Name = "lblEmptyData";
            lblEmptyData.Size = new Size(133, 19);
            lblEmptyData.TabIndex = 20;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvStore
            // 
            DgvStore.AllowUserToAddRows = false;
            DgvStore.AllowUserToResizeColumns = false;
            DgvStore.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvStore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            DgvStore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvStore.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvStore.BackgroundColor = Color.White;
            DgvStore.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvStore.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            DgvStore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            DgvStore.ColumnHeadersHeight = 40;
            DgvStore.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            DgvStore.DefaultCellStyle = dataGridViewCellStyle7;
            DgvStore.Dock = DockStyle.Fill;
            DgvStore.EnableHeadersVisualStyles = false;
            DgvStore.GridColor = SystemColors.ControlDark;
            DgvStore.Location = new Point(0, 202);
            DgvStore.MultiSelect = false;
            DgvStore.Name = "DgvStore";
            DgvStore.ReadOnly = true;
            DgvStore.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvStore.RowHeadersVisible = false;
            DgvStore.RowHeadersWidth = 21;
            DgvStore.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvStore.RowsDefaultCellStyle = dataGridViewCellStyle8;
            DgvStore.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvStore.Size = new Size(989, 305);
            DgvStore.TabIndex = 19;
            DgvStore.CellMouseClick += DgvStore_CellMouseClick;
            // 
            // GbInfoCategory
            // 
            GbInfoCategory.Controls.Add(groupBox1);
            GbInfoCategory.Controls.Add(label3);
            GbInfoCategory.Controls.Add(txtNotes);
            GbInfoCategory.Controls.Add(dtpFrom);
            GbInfoCategory.Controls.Add(lblFrom);
            GbInfoCategory.Controls.Add(btnRefresh);
            GbInfoCategory.Controls.Add(label1);
            GbInfoCategory.Controls.Add(label2);
            GbInfoCategory.Controls.Add(lblCategoryId);
            GbInfoCategory.Controls.Add(label13);
            GbInfoCategory.Controls.Add(txtPerformedBy);
            GbInfoCategory.Dock = DockStyle.Top;
            GbInfoCategory.Location = new Point(0, 51);
            GbInfoCategory.Name = "GbInfoCategory";
            GbInfoCategory.Size = new Size(989, 151);
            GbInfoCategory.TabIndex = 18;
            GbInfoCategory.TabStop = false;
            GbInfoCategory.Text = "بيانات المخزن";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbStoresFrom);
            groupBox1.Controls.Add(rbStoresFromAll);
            groupBox1.Controls.Add(rbStoresFrom);
            groupBox1.Location = new Point(532, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(445, 47);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "المخزن المراد الجرد فيه :";
            // 
            // cmbStoresFrom
            // 
            cmbStoresFrom.Enabled = false;
            cmbStoresFrom.FormattingEnabled = true;
            cmbStoresFrom.Location = new Point(6, 15);
            cmbStoresFrom.Margin = new Padding(3, 15, 3, 3);
            cmbStoresFrom.Name = "cmbStoresFrom";
            cmbStoresFrom.Size = new Size(168, 27);
            cmbStoresFrom.TabIndex = 9;
            // 
            // rbStoresFromAll
            // 
            rbStoresFromAll.AutoSize = true;
            rbStoresFromAll.Checked = true;
            rbStoresFromAll.ImeMode = ImeMode.NoControl;
            rbStoresFromAll.Location = new Point(339, 18);
            rbStoresFromAll.Margin = new Padding(15, 3, 15, 3);
            rbStoresFromAll.Name = "rbStoresFromAll";
            rbStoresFromAll.Size = new Size(88, 23);
            rbStoresFromAll.TabIndex = 6;
            rbStoresFromAll.TabStop = true;
            rbStoresFromAll.Text = "كل المخازن";
            rbStoresFromAll.UseVisualStyleBackColor = true;
            rbStoresFromAll.CheckedChanged += rbStoresFromAll_CheckedChanged;
            // 
            // rbStoresFrom
            // 
            rbStoresFrom.AutoSize = true;
            rbStoresFrom.BackColor = Color.White;
            rbStoresFrom.ForeColor = Color.Green;
            rbStoresFrom.ImeMode = ImeMode.NoControl;
            rbStoresFrom.Location = new Point(202, 18);
            rbStoresFrom.Margin = new Padding(15, 3, 15, 3);
            rbStoresFrom.Name = "rbStoresFrom";
            rbStoresFrom.Size = new Size(92, 23);
            rbStoresFrom.TabIndex = 7;
            rbStoresFrom.Text = "مخزن محدد";
            rbStoresFrom.UseVisualStyleBackColor = false;
            rbStoresFrom.CheckedChanged += rbStoresFrom_CheckedChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(403, 83);
            label3.Name = "label3";
            label3.Size = new Size(58, 19);
            label3.TabIndex = 36;
            label3.Text = "ملاحظة :";
            // 
            // txtNotes
            // 
            txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNotes.Location = new Point(89, 80);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.PlaceholderText = "Admin...";
            txtNotes.Size = new Size(308, 67);
            txtNotes.TabIndex = 37;
            txtNotes.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpFrom
            // 
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(250, 27);
            dtpFrom.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(119, 27);
            dtpFrom.TabIndex = 35;
            dtpFrom.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.ImeMode = ImeMode.NoControl;
            lblFrom.Location = new Point(384, 32);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(77, 19);
            lblFrom.TabIndex = 34;
            lblFrom.Text = "تاريخ البدء :";
            // 
            // btnRefresh
            // 
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.Location = new Point(6, 14);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(35, 45);
            btnRefresh.TabIndex = 29;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(674, 27);
            label1.Name = "label1";
            label1.Size = new Size(122, 19);
            label1.TabIndex = 0;
            label1.Text = "المسؤول عن العملية:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(886, 24);
            label2.Name = "label2";
            label2.Size = new Size(17, 19);
            label2.TabIndex = 28;
            label2.Text = "*";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCategoryId
            // 
            lblCategoryId.AutoSize = true;
            lblCategoryId.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategoryId.Location = new Point(831, 27);
            lblCategoryId.Name = "lblCategoryId";
            lblCategoryId.Size = new Size(49, 19);
            lblCategoryId.TabIndex = 27;
            lblCategoryId.Text = "00000";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(899, 27);
            label13.Name = "label13";
            label13.Size = new Size(78, 19);
            label13.TabIndex = 26;
            label13.Text = "معرف الجرد:";
            // 
            // txtPerformedBy
            // 
            txtPerformedBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPerformedBy.Location = new Point(488, 24);
            txtPerformedBy.Name = "txtPerformedBy";
            txtPerformedBy.PlaceholderText = "Admin...";
            txtPerformedBy.Size = new Size(180, 27);
            txtPerformedBy.TabIndex = 1;
            txtPerformedBy.TextAlign = HorizontalAlignment.Center;
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddStore);
            OperationsflowLayoutPanel.Controls.Add(btnEditStore);
            OperationsflowLayoutPanel.Controls.Add(btnDeleteStore);
            OperationsflowLayoutPanel.Controls.Add(button1);
            OperationsflowLayoutPanel.Controls.Add(txtSearch);
            OperationsflowLayoutPanel.Controls.Add(btnSearch);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(989, 51);
            OperationsflowLayoutPanel.TabIndex = 17;
            // 
            // btnAddStore
            // 
            btnAddStore.Anchor = AnchorStyles.None;
            btnAddStore.Image = (Image)resources.GetObject("btnAddStore.Image");
            btnAddStore.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddStore.Location = new Point(886, 3);
            btnAddStore.Name = "btnAddStore";
            btnAddStore.Size = new Size(100, 40);
            btnAddStore.TabIndex = 3;
            btnAddStore.Text = "   اضافة";
            btnAddStore.UseVisualStyleBackColor = true;
            btnAddStore.Click += btnAddStore_Click;
            // 
            // btnEditStore
            // 
            btnEditStore.Anchor = AnchorStyles.None;
            btnEditStore.Enabled = false;
            btnEditStore.Image = (Image)resources.GetObject("btnEditStore.Image");
            btnEditStore.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditStore.Location = new Point(780, 3);
            btnEditStore.Name = "btnEditStore";
            btnEditStore.Size = new Size(100, 40);
            btnEditStore.TabIndex = 4;
            btnEditStore.Text = "   تعديل";
            btnEditStore.UseVisualStyleBackColor = true;
            btnEditStore.Click += btnEditStore_Click;
            // 
            // btnDeleteStore
            // 
            btnDeleteStore.Anchor = AnchorStyles.None;
            btnDeleteStore.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteStore.Image = (Image)resources.GetObject("btnDeleteStore.Image");
            btnDeleteStore.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteStore.Location = new Point(674, 3);
            btnDeleteStore.Name = "btnDeleteStore";
            btnDeleteStore.Size = new Size(100, 40);
            btnDeleteStore.TabIndex = 8;
            btnDeleteStore.Text = "   حذف";
            btnDeleteStore.UseVisualStyleBackColor = true;
            btnDeleteStore.Click += btnDeleteStore_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(488, 3);
            button1.Name = "button1";
            button1.Size = new Size(180, 40);
            button1.TabIndex = 11;
            button1.Text = "ابدء/استكمال الجرد";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(262, 3);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث عن مخزن";
            txtSearch.Size = new Size(220, 40);
            txtSearch.TabIndex = 10;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSearch
            // 
            btnSearch.Dock = DockStyle.Left;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(206, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(50, 40);
            btnSearch.TabIndex = 9;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // InverntoryOperationsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(989, 507);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvStore);
            Controls.Add(GbInfoCategory);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "InverntoryOperationsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "عملية جرد السلع اضافة/تعديل/اطلاع";
            ((System.ComponentModel.ISupportInitialize)DgvStore).EndInit();
            GbInfoCategory.ResumeLayout(false);
            GbInfoCategory.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            OperationsflowLayoutPanel.ResumeLayout(false);
            OperationsflowLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmptyData;
        private DataGridView DgvStore;
        private GroupBox GbInfoCategory;
        private Button btnRefresh;
        private Label label1;
        private Label label2;
        private Label lblCategoryId;
        private Label label13;
        private TextBox txtPerformedBy;
        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddStore;
        private Button btnDeleteStore;
        private TextBox txtSearch;
        private Button btnSearch;
        private DateTimePicker dtpFrom;
        private Label lblFrom;
        private Label label3;
        private TextBox txtNotes;
        private GroupBox groupBox1;
        private ComboBox cmbStoresFrom;
        private RadioButton rbStoresFromAll;
        private RadioButton rbStoresFrom;
        private Button btnEditStore;
        private Button button1;
    }
}