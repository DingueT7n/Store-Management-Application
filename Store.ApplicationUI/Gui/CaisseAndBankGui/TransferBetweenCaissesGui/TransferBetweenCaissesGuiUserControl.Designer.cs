namespace Store.ApplicationUI.Gui.CaisseAndBankGui.TransferBetweenCaissesGui
{
    partial class TransferBetweenCaissesGuiUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferBetweenCaissesGuiUserControl));
            flowLayoutPaneltitle = new FlowLayoutPanel();
            label1 = new Label();
            panel1 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblto = new Label();
            lblValueTo = new Label();
            label10 = new Label();
            label11 = new Label();
            cmbCaisseTo = new ComboBox();
            btnDepositToCaisse = new Button();
            label7 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            txtDepositorName = new TextBox();
            dateTimePicker = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            txtValue = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label3 = new Label();
            lblValue = new Label();
            lblCurrency = new Label();
            label2 = new Label();
            cmbCaisseFrom = new ComboBox();
            flowLayoutPaneltitle.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPaneltitle
            // 
            flowLayoutPaneltitle.Controls.Add(label1);
            flowLayoutPaneltitle.Dock = DockStyle.Top;
            flowLayoutPaneltitle.FlowDirection = FlowDirection.TopDown;
            flowLayoutPaneltitle.Location = new Point(0, 0);
            flowLayoutPaneltitle.Name = "flowLayoutPaneltitle";
            flowLayoutPaneltitle.Size = new Size(437, 73);
            flowLayoutPaneltitle.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(157, 20);
            label1.Margin = new Padding(130, 20, 130, 20);
            label1.Name = "label1";
            label1.Size = new Size(150, 23);
            label1.TabIndex = 0;
            label1.Text = "التحويل بين الصناديق";
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(cmbCaisseTo);
            panel1.Controls.Add(btnDepositToCaisse);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtDepositorName);
            panel1.Controls.Add(dateTimePicker);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtValue);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbCaisseFrom);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(437, 444);
            panel1.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(lblto);
            flowLayoutPanel2.Controls.Add(lblValueTo);
            flowLayoutPanel2.Controls.Add(label10);
            flowLayoutPanel2.Location = new Point(3, 124);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(431, 43);
            flowLayoutPanel2.TabIndex = 16;
            // 
            // lblto
            // 
            lblto.AutoSize = true;
            lblto.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblto.Location = new Point(203, 10);
            lblto.Margin = new Padding(3, 10, 3, 0);
            lblto.Name = "lblto";
            lblto.Size = new Size(225, 21);
            lblto.TabIndex = 2;
            lblto.Text = "الرصيد الحالي في الصندوق المستقبل  :";
            // 
            // lblValueTo
            // 
            lblValueTo.AutoSize = true;
            lblValueTo.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblValueTo.Location = new Point(133, 10);
            lblValueTo.Margin = new Padding(3, 10, 3, 0);
            lblValueTo.Name = "lblValueTo";
            lblValueTo.Size = new Size(64, 21);
            lblValueTo.TabIndex = 3;
            lblValueTo.Text = "903443";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(101, 10);
            label10.Margin = new Padding(3, 10, 3, 0);
            label10.Name = "label10";
            label10.Size = new Size(26, 21);
            label10.TabIndex = 4;
            label10.Text = "دج";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(341, 94);
            label11.Name = "label11";
            label11.Size = new Size(83, 19);
            label11.TabIndex = 15;
            label11.Text = "الى الصندوق :";
            // 
            // cmbCaisseTo
            // 
            cmbCaisseTo.FormattingEnabled = true;
            cmbCaisseTo.Location = new Point(127, 91);
            cmbCaisseTo.Name = "cmbCaisseTo";
            cmbCaisseTo.Size = new Size(207, 27);
            cmbCaisseTo.TabIndex = 14;
            cmbCaisseTo.Text = "اختر صندوق";
            cmbCaisseTo.SelectionChangeCommitted += cmbCaisseTo_SelectionChangeCommitted;
            // 
            // btnDepositToCaisse
            // 
            btnDepositToCaisse.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            btnDepositToCaisse.FlatAppearance.BorderSize = 5;
            btnDepositToCaisse.Image = (Image)resources.GetObject("btnDepositToCaisse.Image");
            btnDepositToCaisse.ImageAlign = ContentAlignment.MiddleLeft;
            btnDepositToCaisse.Location = new Point(43, 374);
            btnDepositToCaisse.Name = "btnDepositToCaisse";
            btnDepositToCaisse.Size = new Size(287, 53);
            btnDepositToCaisse.TabIndex = 13;
            btnDepositToCaisse.Text = "تأكيد التحويل";
            btnDepositToCaisse.UseVisualStyleBackColor = true;
            btnDepositToCaisse.Click += btnDepositToCaisse_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(356, 307);
            label7.Name = "label7";
            label7.Size = new Size(68, 19);
            label7.TabIndex = 11;
            label7.Text = "ملاحظات :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(47, 307);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "ادخل اي ملاحظة";
            textBox1.Size = new Size(287, 51);
            textBox1.TabIndex = 10;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(346, 262);
            label6.Name = "label6";
            label6.Size = new Size(85, 19);
            label6.TabIndex = 9;
            label6.Text = "ااسم المحول :";
            // 
            // txtDepositorName
            // 
            txtDepositorName.Location = new Point(130, 259);
            txtDepositorName.Name = "txtDepositorName";
            txtDepositorName.PlaceholderText = "اسم";
            txtDepositorName.Size = new Size(200, 27);
            txtDepositorName.TabIndex = 8;
            txtDepositorName.TextAlign = HorizontalAlignment.Center;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Location = new Point(197, 215);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(130, 27);
            dateTimePicker.TabIndex = 7;
            dateTimePicker.Value = new DateTime(2024, 9, 8, 23, 45, 8, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(339, 221);
            label5.Name = "label5";
            label5.Size = new Size(92, 19);
            label5.TabIndex = 6;
            label5.Text = "تاريخ التحويل :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(344, 173);
            label4.Name = "label4";
            label4.Size = new Size(87, 19);
            label4.TabIndex = 5;
            label4.Text = "قيمة التحويل :";
            // 
            // txtValue
            // 
            txtValue.Location = new Point(127, 170);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(200, 27);
            txtValue.TabIndex = 4;
            txtValue.Text = "0";
            txtValue.TextAlign = HorizontalAlignment.Center;
            txtValue.KeyPress += txtValue_KeyPress;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(lblValue);
            flowLayoutPanel1.Controls.Add(lblCurrency);
            flowLayoutPanel1.Location = new Point(3, 42);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(431, 43);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(218, 10);
            label3.Margin = new Padding(3, 10, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(210, 21);
            label3.TabIndex = 2;
            label3.Text = "الرصيد الحالي في الصندوق المرسل :";
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblValue.Location = new Point(148, 10);
            lblValue.Margin = new Padding(3, 10, 3, 0);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(64, 21);
            lblValue.TabIndex = 3;
            lblValue.Text = "903443";
            // 
            // lblCurrency
            // 
            lblCurrency.AutoSize = true;
            lblCurrency.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrency.Location = new Point(116, 10);
            lblCurrency.Margin = new Padding(3, 10, 3, 0);
            lblCurrency.Name = "lblCurrency";
            lblCurrency.Size = new Size(26, 21);
            lblCurrency.TabIndex = 4;
            lblCurrency.Text = "دج";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(340, 12);
            label2.Name = "label2";
            label2.Size = new Size(84, 19);
            label2.TabIndex = 1;
            label2.Text = "من الصندوق :";
            // 
            // cmbCaisseFrom
            // 
            cmbCaisseFrom.FormattingEnabled = true;
            cmbCaisseFrom.Location = new Point(127, 9);
            cmbCaisseFrom.Name = "cmbCaisseFrom";
            cmbCaisseFrom.Size = new Size(207, 27);
            cmbCaisseFrom.TabIndex = 0;
            cmbCaisseFrom.Text = "اختر صندوق";
            cmbCaisseFrom.SelectionChangeCommitted += cmbCaisseFrom_SelectionChangeCommitted;
            // 
            // TransferBetweenCaissesGuiUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(flowLayoutPaneltitle);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TransferBetweenCaissesGuiUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(437, 517);
            flowLayoutPaneltitle.ResumeLayout(false);
            flowLayoutPaneltitle.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPaneltitle;
        private Label label1;
        private Panel panel1;
        private Button btnDepositToCaisse;
        private Label label7;
        private TextBox textBox1;
        private Label label6;
        private TextBox txtDepositorName;
        private DateTimePicker dateTimePicker;
        private Label label5;
        private Label label4;
        private TextBox txtValue;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;
        private Label lblValue;
        private Label lblCurrency;
        private Label label2;
        private ComboBox cmbCaisseFrom;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label lblto;
        private Label lblValueTo;
        private Label label10;
        private Label label11;
        private ComboBox cmbCaisseTo;
    }
}
