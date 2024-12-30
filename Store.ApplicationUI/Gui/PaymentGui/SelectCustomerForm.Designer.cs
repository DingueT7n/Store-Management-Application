namespace Store.ApplicationUI.Gui.PaymentGui
{
    partial class SelectCustomerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCustomerForm));
            panelTitle = new Panel();
            lblTitleForm = new Label();
            tableLayoutPanel = new TableLayoutPanel();
            panelDgv = new Panel();
            lblEmptyData = new Label();
            DgvProducts = new DataGridView();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnChooseCustomer = new Button();
            panelTitle.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).BeginInit();
            SearchPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitle
            // 
            panelTitle.Controls.Add(lblTitleForm);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(773, 54);
            panelTitle.TabIndex = 2;
            // 
            // lblTitleForm
            // 
            lblTitleForm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitleForm.AutoSize = true;
            lblTitleForm.Font = new Font("Calibri", 14.25F);
            lblTitleForm.ForeColor = Color.Red;
            lblTitleForm.ImeMode = ImeMode.NoControl;
            lblTitleForm.Location = new Point(260, 16);
            lblTitleForm.Margin = new Padding(3);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(299, 23);
            lblTitleForm.TabIndex = 15;
            lblTitleForm.Text = "اختر العميل ( انقر مرتين في الجدول او على الزر)";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.04166663F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 98.9583359F));
            tableLayoutPanel.Controls.Add(panelDgv, 1, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 54);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(773, 581);
            tableLayoutPanel.TabIndex = 3;
            // 
            // panelDgv
            // 
            panelDgv.Controls.Add(lblEmptyData);
            panelDgv.Controls.Add(DgvProducts);
            panelDgv.Controls.Add(SearchPanel);
            panelDgv.Dock = DockStyle.Fill;
            panelDgv.Location = new Point(3, 3);
            panelDgv.Name = "panelDgv";
            panelDgv.Size = new Size(759, 575);
            panelDgv.TabIndex = 1;
            // 
            // lblEmptyData
            // 
            lblEmptyData.Anchor = AnchorStyles.None;
            lblEmptyData.AutoSize = true;
            lblEmptyData.BackColor = Color.Transparent;
            lblEmptyData.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 7);
            lblEmptyData.ForeColor = Color.Crimson;
            lblEmptyData.Location = new Point(313, 278);
            lblEmptyData.Name = "lblEmptyData";
            lblEmptyData.Size = new Size(133, 19);
            lblEmptyData.TabIndex = 12;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvProducts
            // 
            DgvProducts.AllowUserToAddRows = false;
            DgvProducts.AllowUserToResizeColumns = false;
            DgvProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            DgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvProducts.BackgroundColor = Color.White;
            DgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle6.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            DgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            DgvProducts.ColumnHeadersHeight = 40;
            DgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            DgvProducts.DefaultCellStyle = dataGridViewCellStyle7;
            DgvProducts.Dock = DockStyle.Fill;
            DgvProducts.EnableHeadersVisualStyles = false;
            DgvProducts.GridColor = SystemColors.ControlDark;
            DgvProducts.Location = new Point(0, 51);
            DgvProducts.MultiSelect = false;
            DgvProducts.Name = "DgvProducts";
            DgvProducts.ReadOnly = true;
            DgvProducts.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvProducts.RowHeadersVisible = false;
            DgvProducts.RowHeadersWidth = 21;
            DgvProducts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvProducts.RowsDefaultCellStyle = dataGridViewCellStyle8;
            DgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvProducts.Size = new Size(759, 524);
            DgvProducts.TabIndex = 10;
            DgvProducts.CellContentDoubleClick += DgvProducts_CellContentDoubleClick;
            // 
            // SearchPanel
            // 
            SearchPanel.Controls.Add(txtSearch);
            SearchPanel.Controls.Add(btnSearch);
            SearchPanel.Controls.Add(btnChooseCustomer);
            SearchPanel.Dock = DockStyle.Top;
            SearchPanel.Location = new Point(0, 0);
            SearchPanel.Name = "SearchPanel";
            SearchPanel.Size = new Size(759, 51);
            SearchPanel.TabIndex = 11;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(217, 0);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث عن عميل";
            txtSearch.Size = new Size(542, 51);
            txtSearch.TabIndex = 9;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSearch
            // 
            btnSearch.Dock = DockStyle.Left;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(173, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(44, 51);
            btnSearch.TabIndex = 7;
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnChooseCustomer
            // 
            btnChooseCustomer.Dock = DockStyle.Left;
            btnChooseCustomer.Image = (Image)resources.GetObject("btnChooseCustomer.Image");
            btnChooseCustomer.ImageAlign = ContentAlignment.TopCenter;
            btnChooseCustomer.Location = new Point(0, 0);
            btnChooseCustomer.Name = "btnChooseCustomer";
            btnChooseCustomer.Size = new Size(173, 51);
            btnChooseCustomer.TabIndex = 10;
            btnChooseCustomer.Text = "اختر العميل المحدد (F3)";
            btnChooseCustomer.TextAlign = ContentAlignment.BottomCenter;
            btnChooseCustomer.UseVisualStyleBackColor = true;
            btnChooseCustomer.Click += btnChooseCustomer_Click;
            // 
            // SelectCustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(773, 635);
            Controls.Add(tableLayoutPanel);
            Controls.Add(panelTitle);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(789, 674);
            MinimizeBox = false;
            MinimumSize = new Size(789, 674);
            Name = "SelectCustomerForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اختر العميل";
            KeyDown += SelectCustomerForm_KeyDown;
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            panelDgv.ResumeLayout(false);
            panelDgv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).EndInit();
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTitle;
        private Label lblTitleForm;
        private TableLayoutPanel tableLayoutPanel;
        private Panel panelDgv;
        private Label lblEmptyData;
        private DataGridView DgvProducts;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnChooseCustomer;
    }
}