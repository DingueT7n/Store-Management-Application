namespace Store.ApplicationUI.Gui.ProductsGui.StoreGui
{
    partial class AddStoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStoreForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddStore = new Button();
            btnEditStore = new Button();
            btnDeleteStore = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnClose = new Button();
            GbInfoCategory = new GroupBox();
            btnRefresh = new Button();
            label1 = new Label();
            label2 = new Label();
            lblCategoryId = new Label();
            label13 = new Label();
            txtNameِCategory = new TextBox();
            lblEmptyData = new Label();
            DgvStore = new DataGridView();
            OperationsflowLayoutPanel.SuspendLayout();
            GbInfoCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvStore).BeginInit();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddStore);
            OperationsflowLayoutPanel.Controls.Add(btnEditStore);
            OperationsflowLayoutPanel.Controls.Add(btnDeleteStore);
            OperationsflowLayoutPanel.Controls.Add(txtSearch);
            OperationsflowLayoutPanel.Controls.Add(btnSearch);
            OperationsflowLayoutPanel.Controls.Add(btnClose);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(707, 51);
            OperationsflowLayoutPanel.TabIndex = 11;
            // 
            // btnAddStore
            // 
            btnAddStore.Anchor = AnchorStyles.None;
            btnAddStore.Image = (Image)resources.GetObject("btnAddStore.Image");
            btnAddStore.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddStore.Location = new Point(604, 3);
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
            btnEditStore.Location = new Point(498, 3);
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
            btnDeleteStore.Location = new Point(392, 3);
            btnDeleteStore.Name = "btnDeleteStore";
            btnDeleteStore.Size = new Size(100, 40);
            btnDeleteStore.TabIndex = 8;
            btnDeleteStore.Text = "   حذف";
            btnDeleteStore.UseVisualStyleBackColor = true;
            btnDeleteStore.Click += btnDeleteStore_Click;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(166, 3);
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
            btnSearch.Location = new Point(110, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(50, 40);
            btnSearch.TabIndex = 9;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            btnClose.FlatAppearance.BorderSize = 5;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 7;
            btnClose.Text = "      الخروج";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // GbInfoCategory
            // 
            GbInfoCategory.Controls.Add(btnRefresh);
            GbInfoCategory.Controls.Add(label1);
            GbInfoCategory.Controls.Add(label2);
            GbInfoCategory.Controls.Add(lblCategoryId);
            GbInfoCategory.Controls.Add(label13);
            GbInfoCategory.Controls.Add(txtNameِCategory);
            GbInfoCategory.Dock = DockStyle.Top;
            GbInfoCategory.Location = new Point(0, 51);
            GbInfoCategory.Name = "GbInfoCategory";
            GbInfoCategory.Size = new Size(707, 65);
            GbInfoCategory.TabIndex = 14;
            GbInfoCategory.TabStop = false;
            GbInfoCategory.Text = "بيانات المخزن";
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
            label1.Location = new Point(427, 30);
            label1.Name = "label1";
            label1.Size = new Size(76, 19);
            label1.TabIndex = 0;
            label1.Text = "اسم المخزن:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(418, 23);
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
            lblCategoryId.Location = new Point(530, 30);
            lblCategoryId.Name = "lblCategoryId";
            lblCategoryId.Size = new Size(49, 19);
            lblCategoryId.TabIndex = 27;
            lblCategoryId.Text = "00000";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(604, 30);
            label13.Name = "label13";
            label13.Size = new Size(87, 19);
            label13.TabIndex = 26;
            label13.Text = "معرف المخزن:";
            // 
            // txtNameِCategory
            // 
            txtNameِCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNameِCategory.Location = new Point(152, 27);
            txtNameِCategory.Name = "txtNameِCategory";
            txtNameِCategory.PlaceholderText = "ادخل اسم المخزن الجديد";
            txtNameِCategory.Size = new Size(260, 27);
            txtNameِCategory.TabIndex = 1;
            txtNameِCategory.TextAlign = HorizontalAlignment.Center;
            // 
            // lblEmptyData
            // 
            lblEmptyData.Anchor = AnchorStyles.None;
            lblEmptyData.AutoSize = true;
            lblEmptyData.BackColor = Color.Transparent;
            lblEmptyData.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 7);
            lblEmptyData.ForeColor = Color.Crimson;
            lblEmptyData.Location = new Point(288, 280);
            lblEmptyData.Name = "lblEmptyData";
            lblEmptyData.Size = new Size(133, 19);
            lblEmptyData.TabIndex = 16;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvStore
            // 
            DgvStore.AllowUserToAddRows = false;
            DgvStore.AllowUserToResizeColumns = false;
            DgvStore.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvStore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvStore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvStore.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvStore.BackgroundColor = Color.White;
            DgvStore.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvStore.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvStore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvStore.ColumnHeadersHeight = 40;
            DgvStore.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvStore.DefaultCellStyle = dataGridViewCellStyle3;
            DgvStore.Dock = DockStyle.Fill;
            DgvStore.EnableHeadersVisualStyles = false;
            DgvStore.GridColor = SystemColors.ControlDark;
            DgvStore.Location = new Point(0, 116);
            DgvStore.MultiSelect = false;
            DgvStore.Name = "DgvStore";
            DgvStore.ReadOnly = true;
            DgvStore.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvStore.RowHeadersVisible = false;
            DgvStore.RowHeadersWidth = 21;
            DgvStore.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvStore.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvStore.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvStore.Size = new Size(707, 365);
            DgvStore.TabIndex = 15;
            DgvStore.CellMouseClick += DgvStore_CellMouseClick;
            // 
            // AddStoreForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(707, 481);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvStore);
            Controls.Add(GbInfoCategory);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(723, 520);
            MinimizeBox = false;
            MinimumSize = new Size(723, 520);
            Name = "AddStoreForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة/تعديل مخزن ";
            OperationsflowLayoutPanel.ResumeLayout(false);
            OperationsflowLayoutPanel.PerformLayout();
            GbInfoCategory.ResumeLayout(false);
            GbInfoCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvStore).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddStore;
        private Button btnEditStore;
        private Button btnDeleteStore;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClose;
        private GroupBox GbInfoCategory;
        private Button btnRefresh;
        private Label label1;
        private Label label2;
        private Label lblCategoryId;
        private Label label13;
        private TextBox txtNameِCategory;
        private Label lblEmptyData;
        private DataGridView DgvStore;
    }
}