namespace Store.ApplicationUI.Gui.DeservedGui
{
    partial class AddDeservedTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDeservedTypeForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddTypes = new Button();
            btnEditTypes = new Button();
            btnDeleteTypes = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnClose = new Button();
            GbInfoTypes = new GroupBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            lblCategoryId = new Label();
            label13 = new Label();
            txtNameِCategory = new TextBox();
            lblEmptyData = new Label();
            DgvTypes = new DataGridView();
            OperationsflowLayoutPanel.SuspendLayout();
            GbInfoTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvTypes).BeginInit();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddTypes);
            OperationsflowLayoutPanel.Controls.Add(btnEditTypes);
            OperationsflowLayoutPanel.Controls.Add(btnDeleteTypes);
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
            // btnAddTypes
            // 
            btnAddTypes.Anchor = AnchorStyles.None;
            btnAddTypes.Image = (Image)resources.GetObject("btnAddTypes.Image");
            btnAddTypes.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddTypes.Location = new Point(604, 3);
            btnAddTypes.Name = "btnAddTypes";
            btnAddTypes.Size = new Size(100, 40);
            btnAddTypes.TabIndex = 3;
            btnAddTypes.Text = "   اضافة";
            btnAddTypes.UseVisualStyleBackColor = true;
            btnAddTypes.Click += btnAddTypes_Click;
            // 
            // btnEditTypes
            // 
            btnEditTypes.Anchor = AnchorStyles.None;
            btnEditTypes.Enabled = false;
            btnEditTypes.Image = (Image)resources.GetObject("btnEditTypes.Image");
            btnEditTypes.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditTypes.Location = new Point(498, 3);
            btnEditTypes.Name = "btnEditTypes";
            btnEditTypes.Size = new Size(100, 40);
            btnEditTypes.TabIndex = 4;
            btnEditTypes.Text = "   تعديل";
            btnEditTypes.UseVisualStyleBackColor = true;
            btnEditTypes.Click += btnEditTypes_Click;
            // 
            // btnDeleteTypes
            // 
            btnDeleteTypes.Anchor = AnchorStyles.None;
            btnDeleteTypes.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteTypes.Image = (Image)resources.GetObject("btnDeleteTypes.Image");
            btnDeleteTypes.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteTypes.Location = new Point(392, 3);
            btnDeleteTypes.Name = "btnDeleteTypes";
            btnDeleteTypes.Size = new Size(100, 40);
            btnDeleteTypes.TabIndex = 8;
            btnDeleteTypes.Text = "   حذف";
            btnDeleteTypes.UseVisualStyleBackColor = true;
            btnDeleteTypes.Click += btnDeleteTypes_Click;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(166, 3);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث عن نوع";
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
            // GbInfoTypes
            // 
            GbInfoTypes.Controls.Add(button1);
            GbInfoTypes.Controls.Add(label1);
            GbInfoTypes.Controls.Add(label2);
            GbInfoTypes.Controls.Add(lblCategoryId);
            GbInfoTypes.Controls.Add(label13);
            GbInfoTypes.Controls.Add(txtNameِCategory);
            GbInfoTypes.Dock = DockStyle.Top;
            GbInfoTypes.Location = new Point(0, 51);
            GbInfoTypes.Name = "GbInfoTypes";
            GbInfoTypes.Size = new Size(707, 65);
            GbInfoTypes.TabIndex = 14;
            GbInfoTypes.TabStop = false;
            GbInfoTypes.Text = "بيانات النوع الجديد";
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
            label1.Location = new Point(416, 30);
            label1.Name = "label1";
            label1.Size = new Size(67, 19);
            label1.TabIndex = 0;
            label1.Text = "اسم النوع :";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(402, 27);
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
            label13.Size = new Size(78, 19);
            label13.TabIndex = 26;
            label13.Text = "معرف النوع :";
            // 
            // txtNameِCategory
            // 
            txtNameِCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNameِCategory.Location = new Point(126, 27);
            txtNameِCategory.Name = "txtNameِCategory";
            txtNameِCategory.PlaceholderText = "ادخل نوع الجديد";
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
            // DgvTypes
            // 
            DgvTypes.AllowUserToAddRows = false;
            DgvTypes.AllowUserToResizeColumns = false;
            DgvTypes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvTypes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvTypes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvTypes.BackgroundColor = Color.White;
            DgvTypes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvTypes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvTypes.ColumnHeadersHeight = 40;
            DgvTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvTypes.DefaultCellStyle = dataGridViewCellStyle3;
            DgvTypes.Dock = DockStyle.Fill;
            DgvTypes.EnableHeadersVisualStyles = false;
            DgvTypes.GridColor = SystemColors.ControlDark;
            DgvTypes.Location = new Point(0, 116);
            DgvTypes.MultiSelect = false;
            DgvTypes.Name = "DgvTypes";
            DgvTypes.ReadOnly = true;
            DgvTypes.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvTypes.RowHeadersVisible = false;
            DgvTypes.RowHeadersWidth = 21;
            DgvTypes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvTypes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvTypes.Size = new Size(707, 365);
            DgvTypes.TabIndex = 15;
            DgvTypes.CellMouseClick += DgvTypes_CellMouseClick;
            // 
            // AddDeservedTypeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(707, 481);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvTypes);
            Controls.Add(GbInfoTypes);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddDeservedTypeForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة نوع مصروفة";
            OperationsflowLayoutPanel.ResumeLayout(false);
            OperationsflowLayoutPanel.PerformLayout();
            GbInfoTypes.ResumeLayout(false);
            GbInfoTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvTypes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddTypes;
        private Button btnEditTypes;
        private Button btnDeleteTypes;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClose;
        private GroupBox GbInfoTypes;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label lblCategoryId;
        private Label label13;
        private TextBox txtNameِCategory;
        private Label lblEmptyData;
        private DataGridView DgvTypes;
    }
}