namespace Store.ApplicationUI.Gui.PaymentGui
{
    partial class LockUnlockForm
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockUnlockForm));
            tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            tileItem1 = new DevExpress.XtraEditors.TileItem();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            maskedTextBox2 = new MaskedTextBox();
            button1 = new Button();
            maskedTextBox1 = new MaskedTextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tileGroup2
            // 
            tileGroup2.Name = "tileGroup2";
            // 
            // tileItem1
            // 
            tileItem1.AppearanceItem.Disabled.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tileItem1.AppearanceItem.Disabled.Options.UseFont = true;
            tileItem1.AppearanceItem.Disabled.Options.UseTextOptions = true;
            tileItem1.AppearanceItem.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            tileItem1.AppearanceItem.Hovered.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tileItem1.AppearanceItem.Hovered.Options.UseFont = true;
            tileItem1.AppearanceItem.Normal.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tileItem1.AppearanceItem.Normal.Options.UseFont = true;
            tileItem1.AppearanceItem.Normal.Options.UseTextOptions = true;
            tileItem1.AppearanceItem.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            tileItem1.AppearanceItem.Pressed.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tileItem1.AppearanceItem.Pressed.Options.UseFont = true;
            tileItem1.AppearanceItem.Pressed.Options.UseTextOptions = true;
            tileItem1.AppearanceItem.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            tileItem1.AppearanceItem.Selected.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tileItem1.AppearanceItem.Selected.Options.UseFont = true;
            tileItem1.AppearanceItem.Selected.Options.UseTextOptions = true;
            tileItem1.AppearanceItem.Selected.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            tileItemElement1.Text = "فك قفل الشاشة";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileItem1.Elements.Add(tileItemElement1);
            tileItem1.Id = 0;
            tileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Large;
            tileItem1.Name = "tileItem1";
            tileItem1.Padding = new Padding(0, 35, 0, 0);
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(maskedTextBox2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(maskedTextBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(722, 460);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Calibri", 18F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(505, 360);
            label3.Name = "label3";
            label3.Size = new Size(93, 29);
            label3.TabIndex = 5;
            label3.Text = "كلمة السر";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Calibri", 18F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(505, 294);
            label2.Name = "label2";
            label2.Size = new Size(138, 29);
            label2.TabIndex = 4;
            label2.Text = "اسم المستخدم";
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.BackColor = Color.Aqua;
            maskedTextBox2.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBox2.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            maskedTextBox2.Location = new Point(187, 292);
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(312, 37);
            maskedTextBox2.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.Cyan;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Calibri", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(261, 409);
            button1.Name = "button1";
            button1.Size = new Size(161, 39);
            button1.TabIndex = 5;
            button1.Text = "موافق";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.BackColor = Color.Aqua;
            maskedTextBox1.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBox1.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            maskedTextBox1.Location = new Point(187, 360);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.PasswordChar = '*';
            maskedTextBox1.Size = new Size(312, 37);
            maskedTextBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(261, 19);
            label1.Name = "label1";
            label1.Size = new Size(200, 39);
            label1.TabIndex = 0;
            label1.Text = "فك قفل الشاشة ";
            // 
            // LockUnlockForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(722, 460);
            Controls.Add(panel1);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "LockUnlockForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "شاشة غلق التطبيق";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem tileItem1;
        private Panel panel1;
        private Label label1;
        private MaskedTextBox maskedTextBox1;
        private Button button1;
        private Label label3;
        private Label label2;
        private MaskedTextBox maskedTextBox2;
    }
}