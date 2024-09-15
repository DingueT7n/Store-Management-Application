namespace Store.ApplicationUI.Reports
{
    public partial class sale8cm : DevExpress.XtraReports.UI.XtraReport
    {
        public sale8cm()
        {
            InitializeComponent();

            InitialElements();


        }
        void InitialElements()
        {
            xrLabel20.Text = MainForm.Context.Caisses
                    .FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId)?.CaisseName
                    ?? "الصندوق الافتراضي";
            lblPhoneNumber.Text = "999-999-999"; // add the phone number
            lblStoreName.Text = "محل ALG-D"; // add the Store Name
        }
        private void sale8cm_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
