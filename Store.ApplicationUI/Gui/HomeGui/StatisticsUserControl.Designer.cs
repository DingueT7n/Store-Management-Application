namespace Store.ApplicationUI.Gui.HomeGui
{
    partial class StatisticsUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsUserControl));
            OperationsflowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            lblTo = new Label();
            lblFrom = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label1 = new Label();
            cmbCaisse = new ComboBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label2 = new Label();
            cmbUser = new ComboBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            label3 = new Label();
            cmbCustomers = new ComboBox();
            btnSearch = new Button();
            flowLayoutPanel6 = new FlowLayoutPanel();
            flowLayoutPanel7 = new FlowLayoutPanel();
            label4 = new Label();
            txtTotalSales = new TextBox();
            flowLayoutPanel8 = new FlowLayoutPanel();
            label5 = new Label();
            txtTotalBuys = new TextBox();
            flowLayoutPanel9 = new FlowLayoutPanel();
            label6 = new Label();
            txtTotalDeserved = new TextBox();
            OperationsflowLayoutPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            flowLayoutPanel9.SuspendLayout();
            SuspendLayout();
            // 
            // OperationsflowLayoutPanel
            // 
            OperationsflowLayoutPanel.AutoScroll = true;
            OperationsflowLayoutPanel.Controls.Add(flowLayoutPanel1);
            OperationsflowLayoutPanel.Controls.Add(flowLayoutPanel2);
            OperationsflowLayoutPanel.Controls.Add(flowLayoutPanel3);
            OperationsflowLayoutPanel.Controls.Add(flowLayoutPanel4);
            OperationsflowLayoutPanel.Controls.Add(flowLayoutPanel5);
            OperationsflowLayoutPanel.Controls.Add(btnSearch);
            OperationsflowLayoutPanel.Dock = DockStyle.Top;
            OperationsflowLayoutPanel.Location = new Point(0, 0);
            OperationsflowLayoutPanel.Margin = new Padding(5);
            OperationsflowLayoutPanel.Name = "OperationsflowLayoutPanel";
            OperationsflowLayoutPanel.Size = new Size(1034, 51);
            OperationsflowLayoutPanel.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(lblFrom);
            flowLayoutPanel1.Controls.Add(dtpFrom);
            flowLayoutPanel1.Location = new Point(860, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(171, 40);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // dtpFrom
            // 
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(13, 7);
            dtpFrom.Margin = new Padding(5, 7, 5, 7);
            dtpFrom.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(113, 27);
            dtpFrom.TabIndex = 31;
            dtpFrom.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // dtpTo
            // 
            dtpTo.CustomFormat = "yyyy-MM-dd";
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(12, 7);
            dtpTo.Margin = new Padding(5, 7, 5, 7);
            dtpTo.MaxDate = new DateTime(2101, 1, 1, 0, 0, 0, 0);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(113, 27);
            dtpTo.TabIndex = 30;
            dtpTo.Value = new DateTime(2024, 8, 23, 21, 42, 30, 0);
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.ImeMode = ImeMode.NoControl;
            lblTo.Location = new Point(135, 10);
            lblTo.Margin = new Padding(5, 10, 5, 10);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(27, 19);
            lblTo.TabIndex = 29;
            lblTo.Text = "الى:";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.ImeMode = ImeMode.NoControl;
            lblFrom.Location = new Point(136, 10);
            lblFrom.Margin = new Padding(5, 10, 5, 10);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(28, 19);
            lblFrom.TabIndex = 28;
            lblFrom.Text = "من:";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel2.Controls.Add(lblTo);
            flowLayoutPanel2.Controls.Add(dtpTo);
            flowLayoutPanel2.Location = new Point(685, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(169, 40);
            flowLayoutPanel2.TabIndex = 31;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel3.Controls.Add(label1);
            flowLayoutPanel3.Controls.Add(cmbCaisse);
            flowLayoutPanel3.Location = new Point(476, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(203, 40);
            flowLayoutPanel3.TabIndex = 32;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(135, 10);
            label1.Margin = new Padding(5, 10, 5, 10);
            label1.Name = "label1";
            label1.Size = new Size(61, 19);
            label1.TabIndex = 30;
            label1.Text = "الصندوق:";
            // 
            // cmbCaisse
            // 
            cmbCaisse.Enabled = false;
            cmbCaisse.FormattingEnabled = true;
            cmbCaisse.Location = new Point(5, 7);
            cmbCaisse.Margin = new Padding(5, 7, 5, 7);
            cmbCaisse.Name = "cmbCaisse";
            cmbCaisse.Size = new Size(120, 27);
            cmbCaisse.TabIndex = 31;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel4.Controls.Add(label2);
            flowLayoutPanel4.Controls.Add(cmbUser);
            flowLayoutPanel4.Location = new Point(260, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(210, 40);
            flowLayoutPanel4.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(135, 10);
            label2.Margin = new Padding(5, 10, 5, 10);
            label2.Name = "label2";
            label2.Size = new Size(68, 19);
            label2.TabIndex = 30;
            label2.Text = "المستخدم:";
            // 
            // cmbUser
            // 
            cmbUser.Enabled = false;
            cmbUser.FormattingEnabled = true;
            cmbUser.Location = new Point(5, 7);
            cmbUser.Margin = new Padding(5, 7, 5, 7);
            cmbUser.Name = "cmbUser";
            cmbUser.Size = new Size(120, 27);
            cmbUser.TabIndex = 31;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel5.Controls.Add(label3);
            flowLayoutPanel5.Controls.Add(cmbCustomers);
            flowLayoutPanel5.Location = new Point(64, 3);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(190, 40);
            flowLayoutPanel5.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(135, 10);
            label3.Margin = new Padding(5, 10, 5, 10);
            label3.Name = "label3";
            label3.Size = new Size(48, 19);
            label3.TabIndex = 30;
            label3.Text = "العميل:";
            // 
            // cmbCustomers
            // 
            cmbCustomers.Enabled = false;
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(5, 7);
            cmbCustomers.Margin = new Padding(5, 7, 5, 7);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(120, 27);
            cmbCustomers.TabIndex = 31;
            // 
            // btnSearch
            // 
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.ImeMode = ImeMode.NoControl;
            btnSearch.Location = new Point(18, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(40, 40);
            btnSearch.TabIndex = 10;
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.AutoScroll = true;
            flowLayoutPanel6.Controls.Add(flowLayoutPanel8);
            flowLayoutPanel6.Controls.Add(flowLayoutPanel7);
            flowLayoutPanel6.Controls.Add(flowLayoutPanel9);
            flowLayoutPanel6.Dock = DockStyle.Top;
            flowLayoutPanel6.Location = new Point(0, 51);
            flowLayoutPanel6.Margin = new Padding(5, 20, 5, 20);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(1034, 95);
            flowLayoutPanel6.TabIndex = 10;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel7.Controls.Add(label4);
            flowLayoutPanel7.Controls.Add(txtTotalSales);
            flowLayoutPanel7.Location = new Point(671, 3);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(177, 67);
            flowLayoutPanel7.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(69, 5);
            label4.Margin = new Padding(5);
            label4.Name = "label4";
            label4.Size = new Size(101, 19);
            label4.TabIndex = 28;
            label4.Text = "مجموع المبيعات:";
            // 
            // txtTotalSales
            // 
            txtTotalSales.Location = new Point(12, 32);
            txtTotalSales.Name = "txtTotalSales";
            txtTotalSales.Size = new Size(160, 27);
            txtTotalSales.TabIndex = 29;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel8.Controls.Add(label5);
            flowLayoutPanel8.Controls.Add(txtTotalBuys);
            flowLayoutPanel8.Location = new Point(854, 3);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(177, 67);
            flowLayoutPanel8.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(63, 5);
            label5.Margin = new Padding(5);
            label5.Name = "label5";
            label5.Size = new Size(107, 19);
            label5.TabIndex = 28;
            label5.Text = "مجموع المشتريات:";
            // 
            // txtTotalBuys
            // 
            txtTotalBuys.Location = new Point(12, 32);
            txtTotalBuys.Name = "txtTotalBuys";
            txtTotalBuys.Size = new Size(160, 27);
            txtTotalBuys.TabIndex = 29;
            // 
            // flowLayoutPanel9
            // 
            flowLayoutPanel9.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel9.Controls.Add(label6);
            flowLayoutPanel9.Controls.Add(txtTotalDeserved);
            flowLayoutPanel9.Location = new Point(488, 3);
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            flowLayoutPanel9.Size = new Size(177, 67);
            flowLayoutPanel9.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ImeMode = ImeMode.NoControl;
            label6.Location = new Point(64, 5);
            label6.Margin = new Padding(5);
            label6.Name = "label6";
            label6.Size = new Size(106, 19);
            label6.TabIndex = 28;
            label6.Text = "مجموع المصاريف:";
            // 
            // txtTotalDeserved
            // 
            txtTotalDeserved.Location = new Point(12, 32);
            txtTotalDeserved.Name = "txtTotalDeserved";
            txtTotalDeserved.Size = new Size(160, 27);
            txtTotalDeserved.TabIndex = 29;
            // 
            // StatisticsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flowLayoutPanel6);
            Controls.Add(OperationsflowLayoutPanel);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StatisticsUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1034, 681);
            OperationsflowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            flowLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel9.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel OperationsflowLayoutPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblFrom;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label lblTo;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label1;
        private ComboBox cmbCaisse;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label2;
        private ComboBox cmbUser;
        private FlowLayoutPanel flowLayoutPanel5;
        private Label label3;
        private ComboBox cmbCustomers;
        private Button btnSearch;
        private FlowLayoutPanel flowLayoutPanel6;
        private FlowLayoutPanel flowLayoutPanel7;
        private Label label4;
        private TextBox txtTotalSales;
        private FlowLayoutPanel flowLayoutPanel8;
        private Label label5;
        private TextBox txtTotalBuys;
        private FlowLayoutPanel flowLayoutPanel9;
        private Label label6;
        private TextBox txtTotalDeserved;
    }
}
