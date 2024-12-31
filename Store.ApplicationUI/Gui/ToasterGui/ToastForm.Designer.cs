namespace Store.ApplicationUI.Gui.ToasterGui
{
    partial class ToastForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToastForm));
            pictureBoxNotify = new PictureBox();
            lblTitle = new Label();
            lblDescription = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBoxNotify).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxNotify
            // 
            pictureBoxNotify.Dock = DockStyle.Right;
            pictureBoxNotify.Image = (Image)resources.GetObject("pictureBoxNotify.Image");
            pictureBoxNotify.Location = new Point(270, 0);
            pictureBoxNotify.Name = "pictureBoxNotify";
            pictureBoxNotify.Size = new Size(75, 73);
            pictureBoxNotify.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxNotify.TabIndex = 0;
            pictureBoxNotify.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(270, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "اضافة البيانات";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            lblDescription.Dock = DockStyle.Top;
            lblDescription.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(0, 32);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(270, 41);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "تم اضافة البيانات بنجاح";
            lblDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 2000;
            timer1.Tick += timer1_Tick;
            // 
            // ToastForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(345, 73);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(pictureBoxNotify);
            Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ToastForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Toast";
            TopMost = true;
            Shown += ToastForm_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBoxNotify).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxNotify;
        private Label lblTitle;
        private Label lblDescription;
        private System.Windows.Forms.Timer timer1;
    }
}