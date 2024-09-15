namespace Store.ApplicationUI.Gui.DeservedGui
{
    partial class DeservedUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeservedUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddDeserved = new Button();
            btnEditDeserved = new Button();
            btnDeleteDeserved = new Button();
            btnAddDeservedType = new Button();
            btnExportProduct = new Button();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            lblEmptyData = new Label();
            DgvProducts = new DataGridView();
            OperationsflowLayoutPanel.SuspendLayout();
            SearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).BeginInit();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddDeserved);
            OperationsflowLayoutPanel.Controls.Add(btnEditDeserved);
            OperationsflowLayoutPanel.Controls.Add(btnDeleteDeserved);
            OperationsflowLayoutPanel.Controls.Add(btnAddDeservedType);
            OperationsflowLayoutPanel.Controls.Add(btnExportProduct);
            OperationsflowLayoutPanel.Controls.Add(SearchPanel);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1034, 51);
            OperationsflowLayoutPanel.TabIndex = 9;
            // 
            // btnAddDeserved
            // 
            btnAddDeserved.Anchor = AnchorStyles.None;
            btnAddDeserved.Image = (Image)resources.GetObject("btnAddDeserved.Image");
            btnAddDeserved.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddDeserved.Location = new Point(931, 3);
            btnAddDeserved.Name = "btnAddDeserved";
            btnAddDeserved.Size = new Size(100, 40);
            btnAddDeserved.TabIndex = 3;
            btnAddDeserved.Text = "   اضافة";
            btnAddDeserved.UseVisualStyleBackColor = true;
            btnAddDeserved.Click += btnAddDeserved_Click;
            // 
            // btnEditDeserved
            // 
            btnEditDeserved.Anchor = AnchorStyles.None;
            btnEditDeserved.Image = (Image)resources.GetObject("btnEditDeserved.Image");
            btnEditDeserved.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditDeserved.Location = new Point(825, 3);
            btnEditDeserved.Name = "btnEditDeserved";
            btnEditDeserved.Size = new Size(100, 40);
            btnEditDeserved.TabIndex = 4;
            btnEditDeserved.Text = "   تعديل";
            btnEditDeserved.UseVisualStyleBackColor = true;
            btnEditDeserved.Click += btnEditDeserved_Click;
            // 
            // btnDeleteDeserved
            // 
            btnDeleteDeserved.Anchor = AnchorStyles.None;
            btnDeleteDeserved.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteDeserved.Image = (Image)resources.GetObject("btnDeleteDeserved.Image");
            btnDeleteDeserved.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteDeserved.Location = new Point(719, 3);
            btnDeleteDeserved.Name = "btnDeleteDeserved";
            btnDeleteDeserved.Size = new Size(100, 40);
            btnDeleteDeserved.TabIndex = 5;
            btnDeleteDeserved.Text = "   حذف";
            btnDeleteDeserved.UseVisualStyleBackColor = true;
            // 
            // btnAddDeservedType
            // 
            btnAddDeservedType.Anchor = AnchorStyles.None;
            btnAddDeservedType.Image = (Image)resources.GetObject("btnAddDeservedType.Image");
            btnAddDeservedType.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddDeservedType.Location = new Point(573, 3);
            btnAddDeservedType.Name = "btnAddDeservedType";
            btnAddDeservedType.Size = new Size(140, 40);
            btnAddDeservedType.TabIndex = 8;
            btnAddDeservedType.Text = "انواع المصروفات";
            btnAddDeservedType.TextAlign = ContentAlignment.MiddleRight;
            btnAddDeservedType.UseVisualStyleBackColor = true;
            btnAddDeservedType.Click += btnAddDeservedType_Click;
            // 
            // btnExportProduct
            // 
            btnExportProduct.Anchor = AnchorStyles.None;
            btnExportProduct.Image = (Image)resources.GetObject("btnExportProduct.Image");
            btnExportProduct.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportProduct.Location = new Point(467, 3);
            btnExportProduct.Name = "btnExportProduct";
            btnExportProduct.Size = new Size(100, 40);
            btnExportProduct.TabIndex = 6;
            btnExportProduct.Text = "   تصدير";
            btnExportProduct.UseVisualStyleBackColor = true;
            // 
            // SearchPanel
            // 
            SearchPanel.Controls.Add(txtSearch);
            SearchPanel.Controls.Add(btnSearch);
            SearchPanel.Location = new Point(121, 3);
            SearchPanel.Name = "SearchPanel";
            SearchPanel.Size = new Size(340, 40);
            SearchPanel.TabIndex = 7;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(50, 0);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث عن رقم مصروفة";
            txtSearch.Size = new Size(290, 40);
            txtSearch.TabIndex = 9;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSearch
            // 
            btnSearch.Dock = DockStyle.Left;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(0, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(50, 40);
            btnSearch.TabIndex = 7;
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.Location = new Point(981, 638);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(50, 40);
            btnRefresh.TabIndex = 13;
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lblEmptyData
            // 
            lblEmptyData.Anchor = AnchorStyles.None;
            lblEmptyData.AutoSize = true;
            lblEmptyData.BackColor = Color.Transparent;
            lblEmptyData.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 7);
            lblEmptyData.ForeColor = Color.Crimson;
            lblEmptyData.Location = new Point(451, 331);
            lblEmptyData.Name = "lblEmptyData";
            lblEmptyData.Size = new Size(133, 19);
            lblEmptyData.TabIndex = 11;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvProducts
            // 
            DgvProducts.AllowUserToAddRows = false;
            DgvProducts.AllowUserToResizeColumns = false;
            DgvProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvProducts.BackgroundColor = Color.White;
            DgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvProducts.ColumnHeadersHeight = 40;
            DgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvProducts.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvProducts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvProducts.Size = new Size(1034, 630);
            DgvProducts.TabIndex = 12;
            // 
            // DeservedUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnRefresh);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvProducts);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DeservedUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            OperationsflowLayoutPanel.ResumeLayout(false);
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddDeserved;
        private Button btnEditDeserved;
        private Button btnDeleteDeserved;
        private Button btnAddDeservedType;
        private Button btnExportProduct;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private Label lblEmptyData;
        private DataGridView DgvProducts;
    }
}
