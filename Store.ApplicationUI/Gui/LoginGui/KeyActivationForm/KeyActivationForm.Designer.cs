namespace Store.ApplicationUI.Gui.LoginGui.KeyActivationForm
{
    partial class KeyActivationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyActivationForm));
            label1 = new Label();
            txtProductId = new TextBox();
            txtKeycrypt = new TextBox();
            label2 = new Label();
            txtKey = new TextBox();
            label3 = new Label();
            rbFull = new RadioButton();
            rbtrial = new RadioButton();
            txtDuration = new TextBox();
            txtDatecreated = new TextBox();
            label4 = new Label();
            txtDateExp = new TextBox();
            label5 = new Label();
            txtDaysLeft = new TextBox();
            label6 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 23);
            label1.Name = "label1";
            label1.Size = new Size(98, 23);
            label1.TabIndex = 0;
            label1.Text = "تعريف المنتج";
            // 
            // txtProductId
            // 
            txtProductId.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtProductId.Location = new Point(214, 20);
            txtProductId.Multiline = true;
            txtProductId.Name = "txtProductId";
            txtProductId.ReadOnly = true;
            txtProductId.Size = new Size(389, 35);
            txtProductId.TabIndex = 1;
            txtProductId.TextAlign = HorizontalAlignment.Center;
            txtProductId.WordWrap = false;
            // 
            // txtKeycrypt
            // 
            txtKeycrypt.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtKeycrypt.Location = new Point(214, 147);
            txtKeycrypt.Multiline = true;
            txtKeycrypt.Name = "txtKeycrypt";
            txtKeycrypt.Size = new Size(389, 35);
            txtKeycrypt.TabIndex = 3;
            txtKeycrypt.TextAlign = HorizontalAlignment.Center;
            txtKeycrypt.Visible = false;
            txtKeycrypt.WordWrap = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 150);
            label2.Name = "label2";
            label2.Size = new Size(101, 23);
            label2.TabIndex = 2;
            label2.Text = "مفتاح التشفير";
            label2.Visible = false;
            // 
            // txtKey
            // 
            txtKey.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtKey.Location = new Point(214, 202);
            txtKey.Multiline = true;
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(389, 35);
            txtKey.TabIndex = 5;
            txtKey.TextAlign = HorizontalAlignment.Center;
            txtKey.WordWrap = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(125, 208);
            label3.Name = "label3";
            label3.Size = new Size(58, 23);
            label3.TabIndex = 4;
            label3.Text = "المفتاح";
            // 
            // rbFull
            // 
            rbFull.AutoSize = true;
            rbFull.Location = new Point(71, 91);
            rbFull.Name = "rbFull";
            rbFull.Size = new Size(91, 27);
            rbFull.TabIndex = 6;
            rbFull.Text = "تفعيل كلي";
            rbFull.UseVisualStyleBackColor = true;
            rbFull.CheckedChanged += rbFull_CheckedChanged;
            // 
            // rbtrial
            // 
            rbtrial.AutoSize = true;
            rbtrial.Checked = true;
            rbtrial.Location = new Point(211, 91);
            rbtrial.Name = "rbtrial";
            rbtrial.Size = new Size(171, 27);
            rbtrial.TabIndex = 7;
            rbtrial.TabStop = true;
            rbtrial.Text = "نسخة تجريبية مجانية";
            rbtrial.UseVisualStyleBackColor = true;
            rbtrial.CheckedChanged += rbtrial_CheckedChanged;
            // 
            // txtDuration
            // 
            txtDuration.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDuration.Location = new Point(413, 83);
            txtDuration.Multiline = true;
            txtDuration.Name = "txtDuration";
            txtDuration.ReadOnly = true;
            txtDuration.Size = new Size(190, 35);
            txtDuration.TabIndex = 8;
            txtDuration.Text = "15";
            txtDuration.TextAlign = HorizontalAlignment.Center;
            txtDuration.WordWrap = false;
            // 
            // txtDatecreated
            // 
            txtDatecreated.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDatecreated.Location = new Point(214, 262);
            txtDatecreated.Multiline = true;
            txtDatecreated.Name = "txtDatecreated";
            txtDatecreated.ReadOnly = true;
            txtDatecreated.Size = new Size(389, 35);
            txtDatecreated.TabIndex = 10;
            txtDatecreated.TextAlign = HorizontalAlignment.Center;
            txtDatecreated.WordWrap = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 268);
            label4.Name = "label4";
            label4.Size = new Size(136, 23);
            label4.TabIndex = 9;
            label4.Text = "تاريخ انشاء المفتاح";
            // 
            // txtDateExp
            // 
            txtDateExp.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDateExp.Location = new Point(214, 317);
            txtDateExp.Multiline = true;
            txtDateExp.Name = "txtDateExp";
            txtDateExp.ReadOnly = true;
            txtDateExp.Size = new Size(389, 35);
            txtDateExp.TabIndex = 12;
            txtDateExp.TextAlign = HorizontalAlignment.Center;
            txtDateExp.WordWrap = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 321);
            label5.Name = "label5";
            label5.Size = new Size(193, 23);
            label5.TabIndex = 11;
            label5.Text = "تاريخ انتهاء صلاحية المفتاح";
            // 
            // txtDaysLeft
            // 
            txtDaysLeft.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDaysLeft.Location = new Point(214, 380);
            txtDaysLeft.Multiline = true;
            txtDaysLeft.Name = "txtDaysLeft";
            txtDaysLeft.ReadOnly = true;
            txtDaysLeft.Size = new Size(389, 35);
            txtDaysLeft.TabIndex = 14;
            txtDaysLeft.TextAlign = HorizontalAlignment.Center;
            txtDaysLeft.WordWrap = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(91, 386);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 13;
            label6.Text = "الايام المتبقية";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(214, 442);
            button1.Name = "button1";
            button1.Size = new Size(203, 42);
            button1.TabIndex = 15;
            button1.Text = "تفعيل البرنامج";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // KeyActivationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(619, 496);
            Controls.Add(button1);
            Controls.Add(txtDaysLeft);
            Controls.Add(label6);
            Controls.Add(txtDateExp);
            Controls.Add(label5);
            Controls.Add(txtDatecreated);
            Controls.Add(label4);
            Controls.Add(txtDuration);
            Controls.Add(rbtrial);
            Controls.Add(rbFull);
            Controls.Add(txtKey);
            Controls.Add(label3);
            Controls.Add(txtKeycrypt);
            Controls.Add(label2);
            Controls.Add(txtProductId);
            Controls.Add(label1);
            Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "KeyActivationForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "شاشة تفعيل البرنامج";
            Load += KeyActivationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtProductId;
        private TextBox txtKeycrypt;
        private Label label2;
        private TextBox txtKey;
        private Label label3;
        private RadioButton rbFull;
        private RadioButton rbtrial;
        private TextBox txtDuration;
        private TextBox txtDatecreated;
        private Label label4;
        private TextBox txtDateExp;
        private Label label5;
        private TextBox txtDaysLeft;
        private Label label6;
        private Button button1;
    }
}