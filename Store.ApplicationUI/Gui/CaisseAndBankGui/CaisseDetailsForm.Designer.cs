namespace Store.ApplicationUI.Gui.CaisseAndBankGui
{
    partial class CaisseDetailsForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaisseDetailsForm));
            panelMainDetails = new Panel();
            lblEmptyData = new Label();
            DgvCaisser = new DataGridView();
            GbInfoCategory = new GroupBox();
            label2 = new Label();
            btnRefresh = new Button();
            label1 = new Label();
            lblCaisseIdShow = new Label();
            lblidCaisse = new Label();
            txtNameِCategory = new TextBox();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            btnAddCaisse = new Button();
            btnEditCaisse = new Button();
            btnDeleteCaisse = new Button();
            panelSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            btnDepositToCaisse = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            panelUserControls = new Panel();
            flowLayoutPanel = new FlowLayoutPanel();
            panelMainDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvCaisser).BeginInit();
            GbInfoCategory.SuspendLayout();
            OperationsflowLayoutPanel.SuspendLayout();
            panelSearch.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainDetails
            // 
            panelMainDetails.Controls.Add(lblEmptyData);
            panelMainDetails.Controls.Add(DgvCaisser);
            panelMainDetails.Controls.Add(GbInfoCategory);
            panelMainDetails.Controls.Add(OperationsflowLayoutPanel);
            panelMainDetails.Location = new Point(3, 4);
            panelMainDetails.Margin = new Padding(3, 4, 3, 4);
            panelMainDetails.Name = "panelMainDetails";
            panelMainDetails.Size = new Size(670, 517);
            panelMainDetails.TabIndex = 0;
            // 
            // lblEmptyData
            // 
            lblEmptyData.Anchor = AnchorStyles.None;
            lblEmptyData.AutoSize = true;
            lblEmptyData.BackColor = Color.Transparent;
            lblEmptyData.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 7);
            lblEmptyData.ForeColor = Color.Crimson;
            lblEmptyData.Location = new Point(269, 321);
            lblEmptyData.Name = "lblEmptyData";
            lblEmptyData.Size = new Size(133, 19);
            lblEmptyData.TabIndex = 18;
            lblEmptyData.Text = "لا توجد بيانات لعرضها";
            lblEmptyData.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyData.Visible = false;
            // 
            // DgvCaisser
            // 
            DgvCaisser.AllowUserToAddRows = false;
            DgvCaisser.AllowUserToResizeColumns = false;
            DgvCaisser.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvCaisser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvCaisser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvCaisser.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvCaisser.BackgroundColor = Color.White;
            DgvCaisser.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvCaisser.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvCaisser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvCaisser.ColumnHeadersHeight = 40;
            DgvCaisser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvCaisser.DefaultCellStyle = dataGridViewCellStyle3;
            DgvCaisser.Dock = DockStyle.Fill;
            DgvCaisser.EnableHeadersVisualStyles = false;
            DgvCaisser.GridColor = SystemColors.ControlDark;
            DgvCaisser.Location = new Point(0, 181);
            DgvCaisser.MultiSelect = false;
            DgvCaisser.Name = "DgvCaisser";
            DgvCaisser.ReadOnly = true;
            DgvCaisser.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvCaisser.RowHeadersVisible = false;
            DgvCaisser.RowHeadersWidth = 21;
            DgvCaisser.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvCaisser.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvCaisser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvCaisser.Size = new Size(670, 336);
            DgvCaisser.TabIndex = 17;
            DgvCaisser.CellMouseClick += DgvCaisser_CellMouseClick;
            // 
            // GbInfoCategory
            // 
            GbInfoCategory.Controls.Add(label2);
            GbInfoCategory.Controls.Add(btnRefresh);
            GbInfoCategory.Controls.Add(label1);
            GbInfoCategory.Controls.Add(lblCaisseIdShow);
            GbInfoCategory.Controls.Add(lblidCaisse);
            GbInfoCategory.Controls.Add(txtNameِCategory);
            GbInfoCategory.Dock = DockStyle.Top;
            GbInfoCategory.Location = new Point(0, 116);
            GbInfoCategory.Name = "GbInfoCategory";
            GbInfoCategory.Size = new Size(670, 65);
            GbInfoCategory.TabIndex = 15;
            GbInfoCategory.TabStop = false;
            GbInfoCategory.Text = "بيانات الصندوق";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(556, 26);
            label2.Name = "label2";
            label2.Size = new Size(17, 19);
            label2.TabIndex = 28;
            label2.Text = "*";
            label2.TextAlign = ContentAlignment.MiddleCenter;
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
            label1.Location = new Point(897, 30);
            label1.Name = "label1";
            label1.Size = new Size(76, 19);
            label1.TabIndex = 0;
            label1.Text = "اسم المخزن:";
            // 
            // lblCaisseIdShow
            // 
            lblCaisseIdShow.AutoSize = true;
            lblCaisseIdShow.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCaisseIdShow.Location = new Point(570, 30);
            lblCaisseIdShow.Name = "lblCaisseIdShow";
            lblCaisseIdShow.Size = new Size(97, 19);
            lblCaisseIdShow.TabIndex = 26;
            lblCaisseIdShow.Text = "معرف الصندوق:";
            // 
            // lblidCaisse
            // 
            lblidCaisse.AutoSize = true;
            lblidCaisse.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblidCaisse.Location = new Point(498, 30);
            lblidCaisse.Name = "lblidCaisse";
            lblidCaisse.Size = new Size(49, 19);
            lblidCaisse.TabIndex = 27;
            lblidCaisse.Text = "00000";
            // 
            // txtNameِCategory
            // 
            txtNameِCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNameِCategory.Location = new Point(180, 26);
            txtNameِCategory.Name = "txtNameِCategory";
            txtNameِCategory.PlaceholderText = "ادخل اسم للصندوق";
            txtNameِCategory.Size = new Size(260, 27);
            txtNameِCategory.TabIndex = 1;
            txtNameِCategory.TextAlign = HorizontalAlignment.Center;
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(btnAddCaisse);
            OperationsflowLayoutPanel.Controls.Add(btnEditCaisse);
            OperationsflowLayoutPanel.Controls.Add(btnDeleteCaisse);
            OperationsflowLayoutPanel.Controls.Add(panelSearch);
            OperationsflowLayoutPanel.Controls.Add(btnDepositToCaisse);
            OperationsflowLayoutPanel.Controls.Add(button1);
            OperationsflowLayoutPanel.Controls.Add(button2);
            OperationsflowLayoutPanel.Controls.Add(button3);
            OperationsflowLayoutPanel.Controls.Add(button4);
            OperationsflowLayoutPanel.Controls.Add(button5);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(670, 116);
            OperationsflowLayoutPanel.TabIndex = 12;
            // 
            // btnAddCaisse
            // 
            btnAddCaisse.Anchor = AnchorStyles.None;
            btnAddCaisse.Image = (Image)resources.GetObject("btnAddCaisse.Image");
            btnAddCaisse.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddCaisse.Location = new Point(584, 5);
            btnAddCaisse.Name = "btnAddCaisse";
            btnAddCaisse.Size = new Size(83, 45);
            btnAddCaisse.TabIndex = 3;
            btnAddCaisse.Text = "   اضافة";
            btnAddCaisse.UseVisualStyleBackColor = true;
            btnAddCaisse.Click += btnAddCaisse_Click;
            // 
            // btnEditCaisse
            // 
            btnEditCaisse.Anchor = AnchorStyles.None;
            btnEditCaisse.Enabled = false;
            btnEditCaisse.Image = (Image)resources.GetObject("btnEditCaisse.Image");
            btnEditCaisse.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditCaisse.Location = new Point(495, 5);
            btnEditCaisse.Name = "btnEditCaisse";
            btnEditCaisse.Size = new Size(83, 45);
            btnEditCaisse.TabIndex = 4;
            btnEditCaisse.Text = "   تعديل";
            btnEditCaisse.UseVisualStyleBackColor = true;
            btnEditCaisse.Click += btnEditCaisse_Click;
            // 
            // btnDeleteCaisse
            // 
            btnDeleteCaisse.Anchor = AnchorStyles.None;
            btnDeleteCaisse.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteCaisse.Image = (Image)resources.GetObject("btnDeleteCaisse.Image");
            btnDeleteCaisse.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteCaisse.Location = new Point(406, 4);
            btnDeleteCaisse.Name = "btnDeleteCaisse";
            btnDeleteCaisse.Size = new Size(83, 47);
            btnDeleteCaisse.TabIndex = 8;
            btnDeleteCaisse.Text = "   حذف";
            btnDeleteCaisse.UseVisualStyleBackColor = true;
            btnDeleteCaisse.Click += btnDeleteCaisse_Click;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Location = new Point(190, 3);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(210, 50);
            panelSearch.TabIndex = 11;
            // 
            // btnSearch
            // 
            btnSearch.Dock = DockStyle.Left;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(0, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(50, 50);
            btnSearch.TabIndex = 9;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Right;
            txtSearch.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(28, 0);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث عن صندوق";
            txtSearch.Size = new Size(182, 50);
            txtSearch.TabIndex = 10;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDepositToCaisse
            // 
            btnDepositToCaisse.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            btnDepositToCaisse.FlatAppearance.BorderSize = 5;
            btnDepositToCaisse.Image = (Image)resources.GetObject("btnDepositToCaisse.Image");
            btnDepositToCaisse.ImageAlign = ContentAlignment.TopCenter;
            btnDepositToCaisse.Location = new Point(35, 3);
            btnDepositToCaisse.Name = "btnDepositToCaisse";
            btnDepositToCaisse.Size = new Size(149, 50);
            btnDepositToCaisse.TabIndex = 12;
            btnDepositToCaisse.Text = "ايداع رصيد في صندوق";
            btnDepositToCaisse.TextAlign = ContentAlignment.BottomCenter;
            btnDepositToCaisse.UseVisualStyleBackColor = true;
            btnDepositToCaisse.Click += btnDepositToCaisse_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            button1.FlatAppearance.BorderSize = 5;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.Location = new Point(547, 59);
            button1.Name = "button1";
            button1.Size = new Size(120, 50);
            button1.TabIndex = 13;
            button1.Text = "ايداع رصيد في بنك";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            button2.FlatAppearance.BorderSize = 5;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.TopCenter;
            button2.Location = new Point(424, 59);
            button2.Name = "button2";
            button2.Size = new Size(117, 50);
            button2.TabIndex = 14;
            button2.Text = "سحب من صندوق";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            button3.FlatAppearance.BorderSize = 5;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.TopCenter;
            button3.Location = new Point(321, 59);
            button3.Name = "button3";
            button3.Size = new Size(97, 50);
            button3.TabIndex = 15;
            button3.Text = "سحب من بنك";
            button3.TextAlign = ContentAlignment.BottomCenter;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            button4.FlatAppearance.BorderSize = 5;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.TopCenter;
            button4.Location = new Point(190, 59);
            button4.Name = "button4";
            button4.Size = new Size(125, 50);
            button4.TabIndex = 16;
            button4.Text = "تحويل بين الصناديق";
            button4.TextAlign = ContentAlignment.BottomCenter;
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            button5.FlatAppearance.BorderSize = 5;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.TopCenter;
            button5.Location = new Point(35, 59);
            button5.Name = "button5";
            button5.Size = new Size(149, 50);
            button5.TabIndex = 17;
            button5.Text = "تحويل بين صندوق وبنك";
            button5.TextAlign = ContentAlignment.BottomCenter;
            button5.UseVisualStyleBackColor = true;
            // 
            // panelUserControls
            // 
            panelUserControls.Location = new Point(3, 529);
            panelUserControls.Margin = new Padding(3, 4, 3, 4);
            panelUserControls.Name = "panelUserControls";
            panelUserControls.Size = new Size(437, 517);
            panelUserControls.TabIndex = 1;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Controls.Add(panelMainDetails);
            flowLayoutPanel.Controls.Add(panelUserControls);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(680, 521);
            flowLayoutPanel.TabIndex = 2;
            // 
            // CaisseDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(680, 521);
            Controls.Add(flowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(1135, 560);
            MinimumSize = new Size(696, 560);
            Name = "CaisseDetailsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            Text = "شاشة الصناديق والبنك";
            panelMainDetails.ResumeLayout(false);
            panelMainDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvCaisser).EndInit();
            GbInfoCategory.ResumeLayout(false);
            GbInfoCategory.PerformLayout();
            OperationsflowLayoutPanel.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMainDetails;
        private FlowLayoutPanel flowLayoutPanel;
        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddCaisse;
        private Button btnEditCaisse;
        private Button btnDeleteCaisse;
        private Button btnSearch;
        private Panel panelSearch;
        private TextBox txtSearch;
        private GroupBox GbInfoCategory;
        private Button btnRefresh;
        private Label label1;
        private Label label2;
        private Label lblidCaisse;
        private Label lblCaisseIdShow;
        private TextBox txtNameِCategory;
        private Label lblEmptyData;
        private DataGridView DgvCaisser;
        private Button btnDepositToCaisse;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        public Panel panelUserControls;
    }
}