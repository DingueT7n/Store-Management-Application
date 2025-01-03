namespace Store.ApplicationUI.Gui.LoginGui
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            labelCopyright = new DevExpress.XtraEditors.LabelControl();
            labelStatus = new DevExpress.XtraEditors.LabelControl();
            peImage = new DevExpress.XtraEditors.PictureEdit();
            progressBarControl = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)peImage.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)progressBarControl.Properties).BeginInit();
            SuspendLayout();
            // 
            // labelCopyright
            // 
            labelCopyright.Appearance.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCopyright.Appearance.Options.UseFont = true;
            labelCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            labelCopyright.Location = new Point(327, 360);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(90, 15);
            labelCopyright.TabIndex = 6;
            labelCopyright.Text = "Copyright ALG-D";
            // 
            // labelStatus
            // 
            labelStatus.Appearance.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatus.Appearance.Options.UseFont = true;
            labelStatus.Location = new Point(454, 252);
            labelStatus.Margin = new Padding(3, 3, 3, 1);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(94, 18);
            labelStatus.TabIndex = 7;
            labelStatus.Text = ".......بداية البرنامج";
            // 
            // peImage
            // 
            peImage.Dock = DockStyle.Top;
            peImage.EditValue = resources.GetObject("peImage.EditValue");
            peImage.Location = new Point(1, 1);
            peImage.Name = "peImage";
            peImage.Properties.AllowFocused = false;
            peImage.Properties.Appearance.BackColor = Color.White;
            peImage.Properties.Appearance.Options.UseBackColor = true;
            peImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            peImage.Properties.InitialImageOptions.Image = (Image)resources.GetObject("peImage.Properties.InitialImageOptions.Image");
            peImage.Properties.ShowMenu = false;
            peImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            peImage.Properties.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            peImage.Size = new Size(563, 238);
            peImage.TabIndex = 9;
            // 
            // progressBarControl
            // 
            progressBarControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBarControl.EditValue = 0;
            progressBarControl.Location = new Point(22, 274);
            progressBarControl.Name = "progressBarControl";
            progressBarControl.Properties.Appearance.BackColor = Color.Fuchsia;
            progressBarControl.Properties.Appearance.BorderColor = Color.Fuchsia;
            progressBarControl.Properties.AppearanceFocused.BackColor = Color.Fuchsia;
            progressBarControl.Properties.AppearanceFocused.BorderColor = Color.Fuchsia;
            progressBarControl.Properties.MarqueeAnimationSpeed = 105;
            progressBarControl.Properties.TextOrientation = DevExpress.Utils.Drawing.TextOrientation.Horizontal;
            progressBarControl.Size = new Size(526, 24);
            progressBarControl.TabIndex = 5;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 392);
            Controls.Add(peImage);
            Controls.Add(labelStatus);
            Controls.Add(labelCopyright);
            Controls.Add(progressBarControl);
            Name = "SplashScreen";
            Padding = new Padding(1);
            ((System.ComponentModel.ISupportInitialize)peImage.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)progressBarControl.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelCopyright;
        private DevExpress.XtraEditors.LabelControl labelStatus;
        private DevExpress.XtraEditors.PictureEdit peImage;
        private DevExpress.XtraEditors.MarqueeProgressBarControl progressBarControl;
    }
}
