namespace Store.ApplicationUI.Gui.CustomersGui
{
    partial class CustomersUserControl
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomersUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddCustomer = new Button();
            btnEditCustomer = new Button();
            btnDeleteCustomer = new Button();
            btnExportCustomer = new Button();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            lblEmptyData = new Label();
            DgvِCustomer = new DataGridView();
            toolTip1 = new ToolTip(components);
            btnRefresh = new Button();
            OperationsflowLayoutPanel.SuspendLayout();
            SearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِCustomer).BeginInit();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddCustomer);
            OperationsflowLayoutPanel.Controls.Add(btnEditCustomer);
            OperationsflowLayoutPanel.Controls.Add(btnDeleteCustomer);
            OperationsflowLayoutPanel.Controls.Add(btnExportCustomer);
            OperationsflowLayoutPanel.Controls.Add(SearchPanel);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1034, 51);
            OperationsflowLayoutPanel.TabIndex = 9;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Anchor = AnchorStyles.None;
            btnAddCustomer.Image = (Image)resources.GetObject("btnAddCustomer.Image");
            btnAddCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddCustomer.Location = new Point(931, 3);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(100, 40);
            btnAddCustomer.TabIndex = 3;
            btnAddCustomer.Text = "   اضافة";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // btnEditCustomer
            // 
            btnEditCustomer.Anchor = AnchorStyles.None;
            btnEditCustomer.Image = (Image)resources.GetObject("btnEditCustomer.Image");
            btnEditCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditCustomer.Location = new Point(825, 3);
            btnEditCustomer.Name = "btnEditCustomer";
            btnEditCustomer.Size = new Size(100, 40);
            btnEditCustomer.TabIndex = 4;
            btnEditCustomer.Text = "   تعديل";
            btnEditCustomer.UseVisualStyleBackColor = true;
            btnEditCustomer.Click += btnEditCustomer_Click;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Anchor = AnchorStyles.None;
            btnDeleteCustomer.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteCustomer.Image = (Image)resources.GetObject("btnDeleteCustomer.Image");
            btnDeleteCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteCustomer.Location = new Point(719, 3);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(100, 40);
            btnDeleteCustomer.TabIndex = 5;
            btnDeleteCustomer.Text = "   حذف";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnExportCustomer
            // 
            btnExportCustomer.Anchor = AnchorStyles.None;
            btnExportCustomer.Image = (Image)resources.GetObject("btnExportCustomer.Image");
            btnExportCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportCustomer.Location = new Point(613, 3);
            btnExportCustomer.Name = "btnExportCustomer";
            btnExportCustomer.Size = new Size(100, 40);
            btnExportCustomer.TabIndex = 6;
            btnExportCustomer.Text = "   تصدير";
            btnExportCustomer.UseVisualStyleBackColor = true;
            btnExportCustomer.Visible = false;
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
            txtSearch.PlaceholderText = "ابحث عن عميل";
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
            lblEmptyData.TabIndex = 10;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvِCustomer
            // 
            DgvِCustomer.AllowUserToAddRows = false;
            DgvِCustomer.AllowUserToResizeColumns = false;
            DgvِCustomer.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvِCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvِCustomer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvِCustomer.BackgroundColor = Color.White;
            DgvِCustomer.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvِCustomer.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvِCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvِCustomer.ColumnHeadersHeight = 40;
            DgvِCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvِCustomer.DefaultCellStyle = dataGridViewCellStyle3;
            DgvِCustomer.Dock = DockStyle.Fill;
            DgvِCustomer.EnableHeadersVisualStyles = false;
            DgvِCustomer.GridColor = SystemColors.ControlDark;
            DgvِCustomer.Location = new Point(0, 51);
            DgvِCustomer.MultiSelect = false;
            DgvِCustomer.Name = "DgvِCustomer";
            DgvِCustomer.ReadOnly = true;
            DgvِCustomer.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvِCustomer.RowHeadersVisible = false;
            DgvِCustomer.RowHeadersWidth = 21;
            DgvِCustomer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِCustomer.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvِCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvِCustomer.Size = new Size(1034, 630);
            DgvِCustomer.TabIndex = 11;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.Location = new Point(981, 638);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(50, 40);
            btnRefresh.TabIndex = 12;
            toolTip1.SetToolTip(btnRefresh, "اعادة التحميل");
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // CustomersUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnRefresh);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvِCustomer);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CustomersUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            OperationsflowLayoutPanel.ResumeLayout(false);
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِCustomer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddCustomer;
        private Button btnEditCustomer;
        private Button btnDeleteCustomer;
        private Button btnExportCustomer;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblEmptyData;
        private DataGridView DgvِCustomer;
        private ToolTip toolTip1;
        private Button btnRefresh;
    }
}
