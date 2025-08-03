namespace Store.ApplicationUI.Gui.LoginGui
{
    partial class ConnectionSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionSettingsForm));
            label1 = new Label();
            groupBox1 = new GroupBox();
            label6 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            button2 = new Button();
            label4 = new Label();
            txtUserpass = new TextBox();
            label5 = new Label();
            txtUserCon = new TextBox();
            label2 = new Label();
            txtDb = new TextBox();
            label3 = new Label();
            rbLocal = new RadioButton();
            rbWide = new RadioButton();
            txtServer = new TextBox();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(214, 23);
            label1.Name = "label1";
            label1.Size = new Size(224, 29);
            label1.TabIndex = 0;
            label1.Text = "اعدادات الاتصال بالسيرفر";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(maskedTextBox1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtUserpass);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtUserCon);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtDb);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(rbLocal);
            groupBox1.Controls.Add(rbWide);
            groupBox1.Controls.Add(txtServer);
            groupBox1.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(25, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(629, 322);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "معلومات الاتصال بالسيرفر";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlText;
            label6.Location = new Point(531, 54);
            label6.Name = "label6";
            label6.Size = new Size(63, 19);
            label6.TabIndex = 14;
            label6.Text = "كلمة السر";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.BackColor = Color.White;
            maskedTextBox1.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBox1.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            maskedTextBox1.Location = new Point(270, 49);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.PasswordChar = '*';
            maskedTextBox1.Size = new Size(234, 31);
            maskedTextBox1.TabIndex = 13;
            maskedTextBox1.KeyDown += maskedTextBox1_KeyDown;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Enabled = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(473, 274);
            button2.Name = "button2";
            button2.Size = new Size(150, 42);
            button2.TabIndex = 12;
            button2.Text = "تجربة الاتصال";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label4.Location = new Point(228, 223);
            label4.Name = "label4";
            label4.Size = new Size(63, 19);
            label4.TabIndex = 11;
            label4.Text = "كلمة السر";
            // 
            // txtUserpass
            // 
            txtUserpass.Enabled = false;
            txtUserpass.Font = new Font("Calibri", 12F, FontStyle.Bold);
            txtUserpass.Location = new Point(6, 220);
            txtUserpass.Name = "txtUserpass";
            txtUserpass.PasswordChar = '*';
            txtUserpass.PlaceholderText = "*****";
            txtUserpass.RightToLeft = RightToLeft.No;
            txtUserpass.Size = new Size(199, 27);
            txtUserpass.TabIndex = 10;
            txtUserpass.TextAlign = HorizontalAlignment.Center;
            txtUserpass.WordWrap = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label5.Location = new Point(531, 225);
            label5.Name = "label5";
            label5.Size = new Size(92, 19);
            label5.TabIndex = 9;
            label5.Text = "اسم المستخدم";
            // 
            // txtUserCon
            // 
            txtUserCon.Enabled = false;
            txtUserCon.Font = new Font("Calibri", 12F, FontStyle.Bold);
            txtUserCon.Location = new Point(331, 222);
            txtUserCon.Name = "txtUserCon";
            txtUserCon.PlaceholderText = "ex.Admin";
            txtUserCon.RightToLeft = RightToLeft.No;
            txtUserCon.Size = new Size(194, 27);
            txtUserCon.TabIndex = 8;
            txtUserCon.TextAlign = HorizontalAlignment.Center;
            txtUserCon.WordWrap = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label2.Location = new Point(228, 177);
            label2.Name = "label2";
            label2.Size = new Size(87, 19);
            label2.TabIndex = 7;
            label2.Text = "قاعدة البيانات";
            // 
            // txtDb
            // 
            txtDb.Enabled = false;
            txtDb.Font = new Font("Calibri", 12F, FontStyle.Bold);
            txtDb.Location = new Point(6, 169);
            txtDb.Name = "txtDb";
            txtDb.PlaceholderText = "MyDb";
            txtDb.RightToLeft = RightToLeft.No;
            txtDb.Size = new Size(199, 27);
            txtDb.TabIndex = 6;
            txtDb.TextAlign = HorizontalAlignment.Center;
            txtDb.WordWrap = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.Location = new Point(573, 174);
            label3.Name = "label3";
            label3.Size = new Size(50, 19);
            label3.TabIndex = 5;
            label3.Text = "السيرفر";
            // 
            // rbLocal
            // 
            rbLocal.AutoSize = true;
            rbLocal.Checked = true;
            rbLocal.Enabled = false;
            rbLocal.Font = new Font("Calibri", 12F, FontStyle.Bold);
            rbLocal.Location = new Point(510, 114);
            rbLocal.Name = "rbLocal";
            rbLocal.Size = new Size(94, 23);
            rbLocal.TabIndex = 1;
            rbLocal.TabStop = true;
            rbLocal.Text = "اتصال محلي";
            rbLocal.UseVisualStyleBackColor = true;
            rbLocal.CheckedChanged += rbLocal_CheckedChanged;
            // 
            // rbWide
            // 
            rbWide.AutoSize = true;
            rbWide.Enabled = false;
            rbWide.Font = new Font("Calibri", 12F, FontStyle.Bold);
            rbWide.Location = new Point(349, 114);
            rbWide.Name = "rbWide";
            rbWide.Size = new Size(93, 23);
            rbWide.TabIndex = 0;
            rbWide.Text = "اتصال شبكي";
            rbWide.UseVisualStyleBackColor = true;
            rbWide.CheckedChanged += rbWide_CheckedChanged;
            // 
            // txtServer
            // 
            txtServer.Enabled = false;
            txtServer.Font = new Font("Calibri", 12F, FontStyle.Bold);
            txtServer.Location = new Point(331, 174);
            txtServer.Name = "txtServer";
            txtServer.PlaceholderText = ".\\SQLEXPRESS";
            txtServer.RightToLeft = RightToLeft.No;
            txtServer.Size = new Size(194, 27);
            txtServer.TabIndex = 4;
            txtServer.TextAlign = HorizontalAlignment.Center;
            txtServer.WordWrap = false;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Enabled = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(254, 399);
            button1.Name = "button1";
            button1.Size = new Size(150, 42);
            button1.TabIndex = 6;
            button1.Text = "حفظ البيانات";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ConnectionSettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(671, 456);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(687, 495);
            MinimizeBox = false;
            MinimumSize = new Size(687, 495);
            Name = "ConnectionSettingsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private RadioButton rbLocal;
        private RadioButton rbWide;
        private Label label3;
        private TextBox txtServer;
        private Button button1;
        private Label label2;
        private TextBox txtDb;
        private Label label4;
        private TextBox txtUserpass;
        private Label label5;
        private TextBox txtUserCon;
        private Button button2;
        private Label label6;
        private MaskedTextBox maskedTextBox1;
    }
}