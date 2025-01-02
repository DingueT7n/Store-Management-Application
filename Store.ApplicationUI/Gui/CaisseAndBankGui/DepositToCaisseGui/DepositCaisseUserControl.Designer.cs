namespace Store.ApplicationUI.Gui.CaisseAndBankGui.DepositToCaisseGui
{
    partial class DepositCaisseUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepositCaisseUserControl));
            flowLayoutPaneltitle = new FlowLayoutPanel();
            label1 = new Label();
            panel1 = new Panel();
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
            cmbCaisse = new ComboBox();
            flowLayoutPaneltitle.SuspendLayout();
            panel1.SuspendLayout();
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
            flowLayoutPaneltitle.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(169, 20);
            label1.Margin = new Padding(150, 20, 150, 20);
            label1.Name = "label1";
            label1.Size = new Size(118, 23);
            label1.TabIndex = 0;
            label1.Text = "ايداع الى صندوق";
            // 
            // panel1
            // 
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
            panel1.Controls.Add(cmbCaisse);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(437, 444);
            panel1.TabIndex = 1;
            // 
            // btnDepositToCaisse
            // 
            btnDepositToCaisse.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            btnDepositToCaisse.FlatAppearance.BorderSize = 5;
            btnDepositToCaisse.Image = (Image)resources.GetObject("btnDepositToCaisse.Image");
            btnDepositToCaisse.ImageAlign = ContentAlignment.MiddleLeft;
            btnDepositToCaisse.Location = new Point(43, 367);
            btnDepositToCaisse.Name = "btnDepositToCaisse";
            btnDepositToCaisse.Size = new Size(287, 53);
            btnDepositToCaisse.TabIndex = 13;
            btnDepositToCaisse.Text = "تأكيد الايداع";
            btnDepositToCaisse.UseVisualStyleBackColor = true;
            btnDepositToCaisse.Click += btnDepositToCaisse_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(352, 308);
            label7.Name = "label7";
            label7.Size = new Size(68, 19);
            label7.TabIndex = 11;
            label7.Text = "ملاحظات :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(43, 300);
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
            label6.Location = new Point(352, 253);
            label6.Name = "label6";
            label6.Size = new Size(76, 19);
            label6.TabIndex = 9;
            label6.Text = "اسم المودع :";
            // 
            // txtDepositorName
            // 
            txtDepositorName.Location = new Point(127, 245);
            txtDepositorName.Name = "txtDepositorName";
            txtDepositorName.Size = new Size(200, 27);
            txtDepositorName.TabIndex = 8;
            txtDepositorName.TextAlign = HorizontalAlignment.Center;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Location = new Point(197, 189);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(130, 27);
            dateTimePicker.TabIndex = 7;
            dateTimePicker.Value = new DateTime(2024, 9, 8, 23, 45, 8, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(347, 197);
            label5.Name = "label5";
            label5.Size = new Size(84, 19);
            label5.TabIndex = 6;
            label5.Text = "تاريخ الايداع :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(352, 144);
            label4.Name = "label4";
            label4.Size = new Size(79, 19);
            label4.TabIndex = 5;
            label4.Text = "قيمة الايداع :";
            // 
            // txtValue
            // 
            txtValue.Location = new Point(127, 136);
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
            flowLayoutPanel1.Location = new Point(3, 68);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(431, 62);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(264, 20);
            label3.Margin = new Padding(3, 20, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(164, 21);
            label3.TabIndex = 2;
            label3.Text = "الرصيد الحالي في الصندوق :";
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblValue.Location = new Point(194, 20);
            lblValue.Margin = new Padding(3, 20, 3, 0);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(64, 21);
            lblValue.TabIndex = 3;
            lblValue.Text = "903443";
            // 
            // lblCurrency
            // 
            lblCurrency.AutoSize = true;
            lblCurrency.Font = new Font("Calibri", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrency.Location = new Point(162, 20);
            lblCurrency.Margin = new Padding(3, 20, 3, 0);
            lblCurrency.Name = "lblCurrency";
            lblCurrency.Size = new Size(26, 21);
            lblCurrency.TabIndex = 4;
            lblCurrency.Text = "دج";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(340, 28);
            label2.Name = "label2";
            label2.Size = new Size(91, 19);
            label2.TabIndex = 1;
            label2.Text = "اختر الصندوق :";
            // 
            // cmbCaisse
            // 
            cmbCaisse.FormattingEnabled = true;
            cmbCaisse.Location = new Point(127, 25);
            cmbCaisse.Name = "cmbCaisse";
            cmbCaisse.Size = new Size(207, 27);
            cmbCaisse.TabIndex = 0;
            cmbCaisse.Text = "اختر صندوق";
            cmbCaisse.SelectionChangeCommitted += cmbCaisse_SelectionChangeCommitted;
            // 
            // DepositCaisseUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(flowLayoutPaneltitle);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DepositCaisseUserControl";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(437, 517);
            flowLayoutPaneltitle.ResumeLayout(false);
            flowLayoutPaneltitle.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPaneltitle;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private ComboBox cmbCaisse;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;
        private Label lblValue;
        private Label lblCurrency;
        private Label label4;
        private TextBox txtValue;
        private Label label5;
        private DateTimePicker dateTimePicker;
        private Label label6;
        private TextBox txtDepositorName;
        private Label label7;
        private TextBox textBox1;
        private Button btnDepositToCaisse;
    }
}
