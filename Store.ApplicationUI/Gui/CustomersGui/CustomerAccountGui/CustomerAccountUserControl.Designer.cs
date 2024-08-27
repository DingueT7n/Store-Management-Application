namespace Store.ApplicationUI.Gui.CustomersGui.CustomerAccountGui
{
    partial class CustomerAccountUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerAccountUserControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            gbPayChoiches = new GroupBox();
            lblPayAllDebts = new Label();
            lblPayFacture = new Label();
            rbPayAllFactures = new RadioButton();
            txtPayAmout = new TextBox();
            rbPayPartialFacture = new RadioButton();
            rbPayFacture = new RadioButton();
            btnPay = new Button();
            panelstatisticsandOperations = new Panel();
            lblTitleForm = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblTotalDebt = new Label();
            lblTotalCustomers = new Label();
            lblTotalFactures = new Label();
            SearchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panelButtons = new Panel();
            button2 = new Button();
            button1 = new Button();
            btnExportCustomer = new Button();
            toolTip1 = new ToolTip(components);
            btnRefresh = new Button();
            lblEmptyData = new Label();
            DgvِCustomer = new DataGridView();
            OperationsflowLayoutPanel.SuspendLayout();
            gbPayChoiches.SuspendLayout();
            panelstatisticsandOperations.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SearchPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvِCustomer).BeginInit();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            resources.ApplyResources(OperationsflowLayoutPanel, "OperationsflowLayoutPanel");
            OperationsflowLayoutPanel.Controls.Add(gbPayChoiches);
            OperationsflowLayoutPanel.Controls.Add(panelstatisticsandOperations);
            OperationsflowLayoutPanel.Controls.Add(panelButtons);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            // 
            // gbPayChoiches
            // 
            resources.ApplyResources(gbPayChoiches, "gbPayChoiches");
            gbPayChoiches.Controls.Add(lblPayAllDebts);
            gbPayChoiches.Controls.Add(lblPayFacture);
            gbPayChoiches.Controls.Add(rbPayAllFactures);
            gbPayChoiches.Controls.Add(txtPayAmout);
            gbPayChoiches.Controls.Add(rbPayPartialFacture);
            gbPayChoiches.Controls.Add(rbPayFacture);
            gbPayChoiches.Controls.Add(btnPay);
            gbPayChoiches.Name = "gbPayChoiches";
            gbPayChoiches.TabStop = false;
            // 
            // lblPayAllDebts
            // 
            resources.ApplyResources(lblPayAllDebts, "lblPayAllDebts");
            lblPayAllDebts.Name = "lblPayAllDebts";
            // 
            // lblPayFacture
            // 
            resources.ApplyResources(lblPayFacture, "lblPayFacture");
            lblPayFacture.Name = "lblPayFacture";
            // 
            // rbPayAllFactures
            // 
            resources.ApplyResources(rbPayAllFactures, "rbPayAllFactures");
            rbPayAllFactures.Name = "rbPayAllFactures";
            rbPayAllFactures.UseVisualStyleBackColor = true;
            // 
            // txtPayAmout
            // 
            resources.ApplyResources(txtPayAmout, "txtPayAmout");
            txtPayAmout.Name = "txtPayAmout";
            // 
            // rbPayPartialFacture
            // 
            resources.ApplyResources(rbPayPartialFacture, "rbPayPartialFacture");
            rbPayPartialFacture.Name = "rbPayPartialFacture";
            rbPayPartialFacture.UseVisualStyleBackColor = true;
            // 
            // rbPayFacture
            // 
            resources.ApplyResources(rbPayFacture, "rbPayFacture");
            rbPayFacture.Checked = true;
            rbPayFacture.Name = "rbPayFacture";
            rbPayFacture.TabStop = true;
            rbPayFacture.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            resources.ApplyResources(btnPay, "btnPay");
            btnPay.Name = "btnPay";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // panelstatisticsandOperations
            // 
            panelstatisticsandOperations.Controls.Add(lblTitleForm);
            panelstatisticsandOperations.Controls.Add(flowLayoutPanel1);
            panelstatisticsandOperations.Controls.Add(SearchPanel);
            resources.ApplyResources(panelstatisticsandOperations, "panelstatisticsandOperations");
            panelstatisticsandOperations.Name = "panelstatisticsandOperations";
            // 
            // lblTitleForm
            // 
            resources.ApplyResources(lblTitleForm, "lblTitleForm");
            lblTitleForm.ForeColor = Color.Red;
            lblTitleForm.Name = "lblTitleForm";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lblTotalDebt);
            flowLayoutPanel1.Controls.Add(lblTotalCustomers);
            flowLayoutPanel1.Controls.Add(lblTotalFactures);
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // lblTotalDebt
            // 
            resources.ApplyResources(lblTotalDebt, "lblTotalDebt");
            lblTotalDebt.Name = "lblTotalDebt";
            // 
            // lblTotalCustomers
            // 
            resources.ApplyResources(lblTotalCustomers, "lblTotalCustomers");
            lblTotalCustomers.Name = "lblTotalCustomers";
            // 
            // lblTotalFactures
            // 
            resources.ApplyResources(lblTotalFactures, "lblTotalFactures");
            lblTotalFactures.Name = "lblTotalFactures";
            // 
            // SearchPanel
            // 
            SearchPanel.Controls.Add(txtSearch);
            SearchPanel.Controls.Add(btnSearch);
            resources.ApplyResources(SearchPanel, "SearchPanel");
            SearchPanel.Name = "SearchPanel";
            // 
            // txtSearch
            // 
            resources.ApplyResources(txtSearch, "txtSearch");
            txtSearch.Name = "txtSearch";
            // 
            // btnSearch
            // 
            resources.ApplyResources(btnSearch, "btnSearch");
            btnSearch.Name = "btnSearch";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(button2);
            panelButtons.Controls.Add(button1);
            panelButtons.Controls.Add(btnExportCustomer);
            resources.ApplyResources(panelButtons, "panelButtons");
            panelButtons.Name = "panelButtons";
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnExportCustomer
            // 
            resources.ApplyResources(btnExportCustomer, "btnExportCustomer");
            btnExportCustomer.Name = "btnExportCustomer";
            btnExportCustomer.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            resources.ApplyResources(btnRefresh, "btnRefresh");
            btnRefresh.Name = "btnRefresh";
            toolTip1.SetToolTip(btnRefresh, resources.GetString("btnRefresh.ToolTip"));
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click_1;
            // 
            // lblEmptyData
            // 
            resources.ApplyResources(lblEmptyData, "lblEmptyData");
            lblEmptyData.BackColor = Color.Transparent;
            lblEmptyData.ForeColor = Color.Crimson;
            lblEmptyData.Name = "lblEmptyData";
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
            resources.ApplyResources(DgvِCustomer, "DgvِCustomer");
            DgvِCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvِCustomer.DefaultCellStyle = dataGridViewCellStyle3;
            DgvِCustomer.EnableHeadersVisualStyles = false;
            DgvِCustomer.GridColor = SystemColors.ControlDark;
            DgvِCustomer.MultiSelect = false;
            DgvِCustomer.Name = "DgvِCustomer";
            DgvِCustomer.ReadOnly = true;
            DgvِCustomer.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvِCustomer.RowHeadersVisible = false;
            DgvِCustomer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new Font("Sakkal Majalla", 14.25F, FontStyle.Bold);
            DgvِCustomer.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DgvِCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // CustomerAccountUserControl
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnRefresh);
            Controls.Add(lblEmptyData);
            Controls.Add(DgvِCustomer);
            Controls.Add(OperationsflowLayoutPanel);
            Name = "CustomerAccountUserControl";
            OperationsflowLayoutPanel.ResumeLayout(false);
            gbPayChoiches.ResumeLayout(false);
            gbPayChoiches.PerformLayout();
            panelstatisticsandOperations.ResumeLayout(false);
            panelstatisticsandOperations.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvِCustomer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private Button btnAddCustomer;
        private Button btnPay;
        private Button btnExportCustomer;
        private ToolTip toolTip1;
        private Button btnRefresh;
        private Label lblEmptyData;
        private DataGridView DgvِCustomer;
        private GroupBox gbPayChoiches;
        private TextBox txtPayAmout;
        private RadioButton rbPayPartialFacture;
        private RadioButton rbPayFacture;
        private RadioButton rbPayAllFactures;
        private Label lblPayFacture;
        private Label lblPayAllDebts;
        private Panel panelButtons;
        private Button button1;
        private Button button2;
        private Panel panelstatisticsandOperations;
        private Panel SearchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblTotalDebt;
        private Label lblTotalFactures;
        private Label lblTotalCustomers;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblTitleForm;
    }
}
