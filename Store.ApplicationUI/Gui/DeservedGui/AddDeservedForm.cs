using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Gui.LoadingGui;
using Store.Core.Entities.AllDeserved;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.DeservedGui
{
    public partial class AddDeservedForm : Form
    {
        private static MainForm _main;
        private ApplicationDbContext _context;
        private DeservedsRepository? deservedsRepository;
        private static AddDeservedForm _adddeservedForm;

        public AddDeservedForm(MainForm main)
        {
            InitializeComponent();
            _main = main;
            this.Owner = _main;
            _context = new ApplicationDbContext();

            deservedsRepository = new DeservedsRepository(_context);
            LoadData();
            ConfigDate();
        }


        public static AddDeservedForm Instance(MainForm main)
        {
            _main = main;
            // If the instance is null, create a new one and assign it to the static field


            _adddeservedForm = new AddDeservedForm(_main);



            // Return the singleton instance

            return _adddeservedForm;
        }
        private void ConfigDate()
        {
            DtpExperation.Value = DateTime.Now;

            DtpExperation.CustomFormat = DtpExperation.CustomFormat = "yyyy-MM-dd";
        }
        public void LoadData()
        {


            //ShowLoading


            LoadingForm.Instance(_main).Show();
            if (/*await Task.Run(() =>*/ _context.Database.CanConnect())/*)*/
            {
                //Start Load Data

                // if its an admin or Normal user 

                CMBType.DataSource = _context.DeservedsTypes.ToList();



                CMBType.DisplayMember = "Description"; // Set the property to display
                CMBType.ValueMember = "Id"; // Set the property to use as the value
                CMBType.Text = "اختر نوع";

                // Optionally select the first item if needed
            }
            else
            {

                LoadingForm.Instance(_main).Hide();
                //No Connection
                MsgHelper.ShowServerError();
            }
            //Hideloading
            LoadingForm.Instance(_main).Hide();
            // Show EmptyDAta

        }
        void vider()
        {
            txtValueDeserved.Text = "";
            txtUserName.Text = Properties.Settings.Default.UserName;
            txtNotes.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtValueDeserved_KeyPress(object sender, KeyPressEventArgs e)
        {
            string currentText = (sender as TextBox)?.Text ?? string.Empty;


            char decimalSeparator = Properties.Settings.Default.DecimalSEP[0];


            if (!char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            else if (e.KeyChar == decimalSeparator && currentText.Contains(decimalSeparator))
            {
                e.Handled = true;
            }
        }
        public void SetDataToEdit(string username, string value, string notes, string typesId,
             string deservedId, DateTime DateExpiration)
        {
            LoadData();
            txtUserName.Text = username;
            txtValueDeserved.Text = value;
            CMBType.SelectedValue = Convert.ToInt32(typesId);
            txtNotes.Text = notes;
            DtpExperation.Value = DateExpiration;
            lblDeservedID.Text = deservedId;
            btnAddDeserved.Visible = false;
            btnEditDeserved.Visible = true;
            lblDeservedID.Visible = true;
            label13.Visible = true;
        }

        private void btnAddDeserved_Click(object sender, EventArgs e)
        {
            try
            {


                if (CMBType.Text != "اختر نوع")
                {
                    _context.Deserveds.Add(new Deserved
                    {
                        TypeId = (int)CMBType.SelectedValue,
                        UserName = txtUserName.Text,
                        Price = Convert.ToDecimal(txtValueDeserved.Text),
                        Date = DtpExperation.Value,
                        Notes = txtNotes.Text,
                        Time = DateTime.Now.ToString("HH:mm:ss"),
                    });
                    _context.SaveChanges();
                    Code.Helper.ToasterHelper.ShowAddToast();

                    if (!DeservedUserControl.CheckInstance())
                    {
                        DeservedUserControl.RefreshDgv();
                    }
                }
                else
                    MsgHelper.ShowRequiredFields();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnEditDeserved_Click(object sender, EventArgs e)
        {
            try
            {


                Deserved deserved = _context.Deserveds.FirstOrDefault(x => x.Id.ToString() == lblDeservedID.Text);
                if (deserved != null)
                {
                    deserved.TypeId = Convert.ToInt32(CMBType.SelectedValue);
                    deserved.UserName = txtUserName.Text;
                    deserved.Price = Convert.ToDecimal(txtValueDeserved.Text);
                    deserved.Date = DtpExperation.Value;
                    deserved.Notes = txtNotes.Text;
                    _context.Update(deserved);
                    await _context.SaveChangesAsync();
                    Code.Helper.ToasterHelper.ShowEditToast();

                    if (!DeservedUserControl.CheckInstance())
                    {
                        DeservedUserControl.RefreshDgv();
                    }
                    deserved = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAddTypes_Click(object sender, EventArgs e)
        {
            AddDeservedTypeForm addDeservedType = AddDeservedTypeForm.Instance(_main);
            this.Hide();
            addDeservedType.ShowDialog();
            this.Show();
        }
    }
}
