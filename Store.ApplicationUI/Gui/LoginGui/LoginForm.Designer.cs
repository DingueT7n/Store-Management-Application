namespace Store.ApplicationUI.Gui.LoginGui
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel1 = new Panel();
            lblActivation = new Label();
            lblCon = new Label();
            button2 = new Button();
            button1 = new Button();
            groupBox1 = new GroupBox();
            label4 = new Label();
            txtPassowrd = new TextBox();
            label3 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblActivation);
            panel1.Controls.Add(lblCon);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 360);
            panel1.TabIndex = 2;
            // 
            // lblActivation
            // 
            lblActivation.AutoSize = true;
            lblActivation.Cursor = Cursors.Hand;
            lblActivation.Font = new Font("Calibri", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblActivation.ForeColor = Color.Blue;
            lblActivation.Location = new Point(12, 332);
            lblActivation.Name = "lblActivation";
            lblActivation.Size = new Size(87, 19);
            lblActivation.TabIndex = 6;
            lblActivation.Text = "شاشة التفعيل";
            lblActivation.Visible = false;
            // 
            // lblCon
            // 
            lblCon.AutoSize = true;
            lblCon.Cursor = Cursors.Hand;
            lblCon.Font = new Font("Calibri", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblCon.ForeColor = Color.Blue;
            lblCon.Location = new Point(312, 332);
            lblCon.Name = "lblCon";
            lblCon.Size = new Size(136, 19);
            lblCon.TabIndex = 5;
            lblCon.Text = "تعديل اعدادات الاتصال";
            lblCon.Visible = false;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(12, 276);
            button2.Name = "button2";
            button2.Size = new Size(186, 42);
            button2.TabIndex = 4;
            button2.Text = "اغلاق البرنامج";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(262, 276);
            button1.Name = "button1";
            button1.Size = new Size(186, 42);
            button1.TabIndex = 3;
            button1.Text = "موافق";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtPassowrd);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 117);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(436, 153);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "معلومات الدخول";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label4.Location = new Point(375, 95);
            label4.Name = "label4";
            label4.Size = new Size(63, 19);
            label4.TabIndex = 3;
            label4.Text = "كلمة السر";
            // 
            // txtPassowrd
            // 
            txtPassowrd.Font = new Font("Calibri", 12F, FontStyle.Bold);
            txtPassowrd.Location = new Point(6, 96);
            txtPassowrd.Multiline = true;
            txtPassowrd.Name = "txtPassowrd";
            txtPassowrd.PasswordChar = '*';
            txtPassowrd.PlaceholderText = "******";
            txtPassowrd.Size = new Size(302, 35);
            txtPassowrd.TabIndex = 2;
            txtPassowrd.TextAlign = HorizontalAlignment.Center;
            txtPassowrd.WordWrap = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.Location = new Point(342, 46);
            label3.Name = "label3";
            label3.Size = new Size(96, 19);
            label3.TabIndex = 1;
            label3.Text = "اسم المستخدم ";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Calibri", 12F, FontStyle.Bold);
            txtUsername.Location = new Point(6, 46);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "ex.Admin";
            txtUsername.Size = new Size(302, 35);
            txtUsername.TabIndex = 0;
            txtUsername.TextAlign = HorizontalAlignment.Center;
            txtUsername.WordWrap = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(88, 57);
            label2.Name = "label2";
            label2.Size = new Size(285, 33);
            label2.TabIndex = 1;
            label2.Text = "بوابة تسجيل الدخول للمنصة";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(167, 9);
            label1.Name = "label1";
            label1.Size = new Size(127, 33);
            label1.TabIndex = 0;
            label1.Text = "اهلا بعودتك";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(460, 360);
            Controls.Add(panel1);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "واجهة تسجيل الدخول للبرنامج";
            Load += LoginForm_Load;
            KeyDown += LoginForm_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblActivation;
        private Label lblCon;
        private Button button2;
        private Button button1;
        private GroupBox groupBox1;
        private Label label4;
        private TextBox txtPassowrd;
        private Label label3;
        private TextBox txtUsername;
        private Label label2;
        private Label label1;
    }
}