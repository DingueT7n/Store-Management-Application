namespace Store.ApplicationUI.Gui.ProductsGui.Category
{
    partial class AddCategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCategoryForm));
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddCategory = new Button();
            btnEditCategory = new Button();
            btnDeleteCategory = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnClose = new Button();
            DgvCategory = new DataGridView();
            lblEmptyData = new Label();
            GbInfoCategory = new GroupBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            lblCategoryId = new Label();
            label13 = new Label();
            txtNameِCategory = new TextBox();
            OperationsflowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvCategory).BeginInit();
            GbInfoCategory.SuspendLayout();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddCategory);
            OperationsflowLayoutPanel.Controls.Add(btnEditCategory);
            OperationsflowLayoutPanel.Controls.Add(btnDeleteCategory);
            OperationsflowLayoutPanel.Controls.Add(txtSearch);
            OperationsflowLayoutPanel.Controls.Add(btnSearch);
            OperationsflowLayoutPanel.Controls.Add(btnClose);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(707, 51);
            OperationsflowLayoutPanel.TabIndex = 10;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Anchor = AnchorStyles.None;
            btnAddCategory.Image = (Image)resources.GetObject("btnAddCategory.Image");
            btnAddCategory.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddCategory.Location = new Point(604, 3);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(100, 40);
            btnAddCategory.TabIndex = 3;
            btnAddCategory.Text = "   اضافة";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // btnEditCategory
            // 
            btnEditCategory.Anchor = AnchorStyles.None;
            btnEditCategory.Enabled = false;
            btnEditCategory.Image = (Image)resources.GetObject("btnEditCategory.Image");
            btnEditCategory.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditCategory.Location = new Point(498, 3);
            btnEditCategory.Name = "btnEditCategory";
            btnEditCategory.Size = new Size(100, 40);
            btnEditCategory.TabIndex = 4;
            btnEditCategory.Text = "   تعديل";
            btnEditCategory.UseVisualStyleBackColor = true;
            btnEditCategory.Click += btnEditCategory_Click;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Anchor = AnchorStyles.None;
            btnDeleteCategory.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteCategory.Image = (Image)resources.GetObject("btnDeleteCategory.Image");
            btnDeleteCategory.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteCategory.Location = new Point(392, 3);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(100, 40);
            btnDeleteCategory.TabIndex = 8;
            btnDeleteCategory.Text = "   حذف";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            btnDeleteCategory.Click += btnDeleteCategory_Click;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(166, 3);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث عن الصنف";
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
            // DgvCategory
            // 
            DgvCategory.AllowUserToAddRows = false;
            DgvCategory.AllowUserToResizeColumns = false;
            DgvCategory.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvCategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            DgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvCategory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvCategory.BackgroundColor = Color.White;
            DgvCategory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvCategory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            DgvCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            DgvCategory.ColumnHeadersHeight = 40;
            DgvCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            DgvCategory.DefaultCellStyle = dataGridViewCellStyle7;
            DgvCategory.Dock = DockStyle.Fill;
            DgvCategory.EnableHeadersVisualStyles = false;
            DgvCategory.GridColor = SystemColors.ControlDark;
            DgvCategory.Location = new Point(0, 116);
            DgvCategory.MultiSelect = false;
            DgvCategory.Name = "DgvCategory";
            DgvCategory.ReadOnly = true;
            DgvCategory.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvCategory.RowHeadersVisible = false;
            DgvCategory.RowHeadersWidth = 21;
            DgvCategory.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvCategory.RowsDefaultCellStyle = dataGridViewCellStyle8;
            DgvCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvCategory.Size = new Size(707, 365);
            DgvCategory.TabIndex = 11;
            DgvCategory.CellMouseClick += CellMouseClick;
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
            lblEmptyData.TabIndex = 12;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // GbInfoCategory
            // 
            GbInfoCategory.Controls.Add(button1);
            GbInfoCategory.Controls.Add(label1);
            GbInfoCategory.Controls.Add(label2);
            GbInfoCategory.Controls.Add(lblCategoryId);
            GbInfoCategory.Controls.Add(label13);
            GbInfoCategory.Controls.Add(txtNameِCategory);
            GbInfoCategory.Dock = DockStyle.Top;
            GbInfoCategory.Location = new Point(0, 51);
            GbInfoCategory.Name = "GbInfoCategory";
            GbInfoCategory.Size = new Size(707, 65);
            GbInfoCategory.TabIndex = 13;
            GbInfoCategory.TabStop = false;
            GbInfoCategory.Text = "بيانات الصنف";
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(6, 14);
            button1.Name = "button1";
            button1.Size = new Size(35, 45);
            button1.TabIndex = 29;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            label1.Text = "اسم الصنف:";
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
            label13.Text = "معرف الصنف:";
            // 
            // txtNameِCategory
            // 
            txtNameِCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNameِCategory.Location = new Point(152, 27);
            txtNameِCategory.Name = "txtNameِCategory";
            txtNameِCategory.PlaceholderText = "ادخل اسم الصنف الجديد";
            txtNameِCategory.Size = new Size(260, 27);
            txtNameِCategory.TabIndex = 1;
            txtNameِCategory.TextAlign = HorizontalAlignment.Center;
            // 
            // AddCategoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(707, 481);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvCategory);
            Controls.Add(GbInfoCategory);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(723, 520);
            MinimizeBox = false;
            MinimumSize = new Size(723, 520);
            Name = "AddCategoryForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة/تعديل صنف ";
            OperationsflowLayoutPanel.ResumeLayout(false);
            OperationsflowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvCategory).EndInit();
            GbInfoCategory.ResumeLayout(false);
            GbInfoCategory.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddCategory;
        private Button btnEditCategory;
        private Button btnClose;
        private Button btnDeleteCategory;
        private DataGridView DgvCategory;
        private Label lblEmptyData;
        private Button btnSearch;
        private TextBox txtSearch;
        private GroupBox GbInfoCategory;
        private Label lblCategoryId;
        private Label label13;
        private TextBox txtNameِCategory;
        private Label label1;
        private Label label2;
        private Button button1;
    }
}