namespace Store.ApplicationUI.Gui.SupplierGui
{
    partial class SuppliersUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuppliersUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddSupplier = new Button();
            btnEditSupplier = new Button();
            btnDeleteSupplier = new Button();
            btnExportSupplier = new Button();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            lblEmptyData = new Label();
            DgvِSupplier = new DataGridView();
            OperationsflowLayoutPanel.SuspendLayout();
            SearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِSupplier).BeginInit();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddSupplier);
            OperationsflowLayoutPanel.Controls.Add(btnEditSupplier);
            OperationsflowLayoutPanel.Controls.Add(btnDeleteSupplier);
            OperationsflowLayoutPanel.Controls.Add(btnExportSupplier);
            OperationsflowLayoutPanel.Controls.Add(SearchPanel);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1034, 51);
            OperationsflowLayoutPanel.TabIndex = 10;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Anchor = AnchorStyles.None;
            btnAddSupplier.Image = (Image)resources.GetObject("btnAddSupplier.Image");
            btnAddSupplier.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddSupplier.Location = new Point(931, 3);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(100, 40);
            btnAddSupplier.TabIndex = 3;
            btnAddSupplier.Text = "   اضافة";
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // btnEditSupplier
            // 
            btnEditSupplier.Anchor = AnchorStyles.None;
            btnEditSupplier.Image = (Image)resources.GetObject("btnEditSupplier.Image");
            btnEditSupplier.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditSupplier.Location = new Point(825, 3);
            btnEditSupplier.Name = "btnEditSupplier";
            btnEditSupplier.Size = new Size(100, 40);
            btnEditSupplier.TabIndex = 4;
            btnEditSupplier.Text = "   تعديل";
            btnEditSupplier.UseVisualStyleBackColor = true;
            btnEditSupplier.Click += btnEditSupplier_Click;
            // 
            // btnDeleteSupplier
            // 
            btnDeleteSupplier.Anchor = AnchorStyles.None;
            btnDeleteSupplier.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteSupplier.Image = (Image)resources.GetObject("btnDeleteSupplier.Image");
            btnDeleteSupplier.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteSupplier.Location = new Point(719, 3);
            btnDeleteSupplier.Name = "btnDeleteSupplier";
            btnDeleteSupplier.Size = new Size(100, 40);
            btnDeleteSupplier.TabIndex = 5;
            btnDeleteSupplier.Text = "   حذف";
            btnDeleteSupplier.UseVisualStyleBackColor = true;
            btnDeleteSupplier.Click += btnDeleteSupplier_Click;
            // 
            // btnExportSupplier
            // 
            btnExportSupplier.Anchor = AnchorStyles.None;
            btnExportSupplier.Image = (Image)resources.GetObject("btnExportSupplier.Image");
            btnExportSupplier.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportSupplier.Location = new Point(613, 3);
            btnExportSupplier.Name = "btnExportSupplier";
            btnExportSupplier.Size = new Size(100, 40);
            btnExportSupplier.TabIndex = 6;
            btnExportSupplier.Text = "   تصدير";
            btnExportSupplier.UseVisualStyleBackColor = true;
            btnExportSupplier.Click += btnExportSupplier_Click;
            // 
            // SearchPanel
            // 
            SearchPanel.Controls.Add(txtSearch);
            SearchPanel.Controls.Add(btnSearch);
            SearchPanel.Location = new Point(267, 3);
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
            txtSearch.PlaceholderText = "ابحث عن مورد";
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
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.Location = new Point(981, 638);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(50, 40);
            btnRefresh.TabIndex = 15;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
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
            lblEmptyData.TabIndex = 13;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvِSupplier
            // 
            DgvِSupplier.AllowUserToAddRows = false;
            DgvِSupplier.AllowUserToResizeColumns = false;
            DgvِSupplier.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِSupplier.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvِSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvِSupplier.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvِSupplier.BackgroundColor = Color.White;
            DgvِSupplier.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvِSupplier.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvِSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvِSupplier.ColumnHeadersHeight = 40;
            DgvِSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvِSupplier.DefaultCellStyle = dataGridViewCellStyle3;
            DgvِSupplier.Dock = DockStyle.Fill;
            DgvِSupplier.EnableHeadersVisualStyles = false;
            DgvِSupplier.GridColor = SystemColors.ControlDark;
            DgvِSupplier.Location = new Point(0, 51);
            DgvِSupplier.MultiSelect = false;
            DgvِSupplier.Name = "DgvِSupplier";
            DgvِSupplier.ReadOnly = true;
            DgvِSupplier.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvِSupplier.RowHeadersVisible = false;
            DgvِSupplier.RowHeadersWidth = 21;
            DgvِSupplier.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِSupplier.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvِSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvِSupplier.Size = new Size(1034, 630);
            DgvِSupplier.TabIndex = 14;
            // 
            // SuppliersUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnRefresh);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvِSupplier);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SuppliersUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            OperationsflowLayoutPanel.ResumeLayout(false);
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِSupplier).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddSupplier;
        private Button btnEditSupplier;
        private Button btnDeleteSupplier;
        private Button btnExportSupplier;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private Label lblEmptyData;
        private DataGridView DgvِSupplier;
    }
}
