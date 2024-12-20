namespace Store.ApplicationUI.Reports.ProductsReports
{
    partial class ProductBarCode
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.lblPrice = new DevExpress.XtraReports.UI.XRLabel();
            this.lblProductName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblProductLineBar = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCodeBar = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine8 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine7 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 2.691481E-05F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Detail.Dpi = 254F;
            this.Detail.DrillDownExpanded = false;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 254F;
            this.Detail.KeepTogether = true;
            this.Detail.KeepTogetherWithDetailReports = true;
            this.Detail.LockedInUserDesigner = true;
            this.Detail.Name = "Detail";
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry;
            this.Detail.StylePriority.UseBorders = false;
            this.Detail.Visible = false;
            // 
            // lblPrice
            // 
            this.lblPrice.Dpi = 254F;
            this.lblPrice.Font = new DevExpress.Drawing.DXFont("Calibri", 8F);
            this.lblPrice.LocationFloat = new DevExpress.Utils.PointFloat(4.999969F, 202.624F);
            this.lblPrice.Multiline = true;
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblPrice.SizeF = new System.Drawing.SizeF(370F, 41.96625F);
            this.lblPrice.StylePriority.UseFont = false;
            this.lblPrice.Text = "سعر المنتج 8940030539803";
            // 
            // lblProductName
            // 
            this.lblProductName.Dpi = 254F;
            this.lblProductName.Font = new DevExpress.Drawing.DXFont("Calibri", 8F);
            this.lblProductName.LocationFloat = new DevExpress.Utils.PointFloat(4.999969F, 5F);
            this.lblProductName.Multiline = true;
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblProductName.SizeF = new System.Drawing.SizeF(370F, 61.8256F);
            this.lblProductName.StylePriority.UseFont = false;
            this.lblProductName.Text = "lblProductName";
            // 
            // lblProductLineBar
            // 
            this.lblProductLineBar.Dpi = 254F;
            this.lblProductLineBar.Font = new DevExpress.Drawing.DXFont("Aatrix3of9Reg", 9F);
            this.lblProductLineBar.LocationFloat = new DevExpress.Utils.PointFloat(4.999969F, 66.82555F);
            this.lblProductLineBar.Multiline = true;
            this.lblProductLineBar.Name = "lblProductLineBar";
            this.lblProductLineBar.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblProductLineBar.SizeF = new System.Drawing.SizeF(370F, 57.48073F);
            this.lblProductLineBar.StylePriority.UseFont = false;
            this.lblProductLineBar.StylePriority.UseTextAlignment = false;
            this.lblProductLineBar.Text = "lblProductName";
            this.lblProductLineBar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblCodeBar
            // 
            this.lblCodeBar.Dpi = 254F;
            this.lblCodeBar.Font = new DevExpress.Drawing.DXFont("Calibri", 9F);
            this.lblCodeBar.LocationFloat = new DevExpress.Utils.PointFloat(4.999969F, 124.3063F);
            this.lblCodeBar.Multiline = true;
            this.lblCodeBar.Name = "lblCodeBar";
            this.lblCodeBar.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblCodeBar.SizeF = new System.Drawing.SizeF(370F, 56.84904F);
            this.lblCodeBar.StylePriority.UseFont = false;
            this.lblCodeBar.StylePriority.UseTextAlignment = false;
            this.lblCodeBar.Text = "6745754745745745";
            this.lblCodeBar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine7,
            this.xrLine6,
            this.lblCodeBar,
            this.xrLine5,
            this.lblProductLineBar,
            this.lblPrice,
            this.xrLine8,
            this.lblProductName});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 249.5903F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLine5
            // 
            this.xrLine5.Dpi = 254F;
            this.xrLine5.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(375F, 0F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(5F, 247F);
            // 
            // xrLine8
            // 
            this.xrLine8.Dpi = 254F;
            this.xrLine8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine8.Name = "xrLine8";
            this.xrLine8.SizeF = new System.Drawing.SizeF(380F, 5F);
            // 
            // xrLine6
            // 
            this.xrLine6.Dpi = 254F;
            this.xrLine6.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.SizeF = new System.Drawing.SizeF(5F, 247F);
            // 
            // xrLine7
            // 
            this.xrLine7.Dpi = 254F;
            this.xrLine7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 244.5903F);
            this.xrLine7.Name = "xrLine7";
            this.xrLine7.SizeF = new System.Drawing.SizeF(380F, 5F);
            // 
            // ProductBarCode
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader});
            this.Dpi = 254F;
            this.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(0F, 0F, 0F, 2.691481E-05F);
            this.PageHeight = 250;
            this.PageWidth = 380;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.SnapGridSize = 25F;
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.Version = "24.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        public DevExpress.XtraReports.UI.XRLabel lblPrice;
        public DevExpress.XtraReports.UI.XRLabel lblProductName;
        public DevExpress.XtraReports.UI.XRLabel lblProductLineBar;
        public DevExpress.XtraReports.UI.XRLabel lblCodeBar;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLine xrLine7;
        private DevExpress.XtraReports.UI.XRLine xrLine6;
        private DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.UI.XRLine xrLine8;
    }
}
