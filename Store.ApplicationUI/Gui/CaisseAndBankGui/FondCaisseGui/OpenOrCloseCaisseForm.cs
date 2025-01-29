using Store.ApplicationUI.Code.Helper;
using Store.ApplicationUI.Code.Models;
using Store.ApplicationUI.Gui.SalesGui.PosGui;
using Store.Core.Entities.Helpers;
using Store.Infrastructure.Data;
using Store.Infrastructure.Repositories;

namespace Store.ApplicationUI.Gui.CaisseAndBankGui.FondCaisseGui
{
    public partial class OpenOrCloseCaisseForm : Form
    {
        private static ApplicationDbContext _context;
        private static MainForm _main;
        private static PosForm _pos;
        private static CaisseStatusDetailRepository _repository;
        private static OpenOrCloseCaisseForm? _Form;

        public OpenOrCloseCaisseForm(MainForm main)
        {
            _context = new ApplicationDbContext();
            _repository = new CaisseStatusDetailRepository(_context);

            _main = main;
            InitializeComponent();
            this.Owner = main;

        }
        public OpenOrCloseCaisseForm(PosForm _pos)
        {
            _context = new ApplicationDbContext();
            _repository = new CaisseStatusDetailRepository(_context);
            _pos = _pos;
            InitializeComponent();
            this.Owner = _pos;

        }
        public static void SetPose(PosForm _poss)
        {
            _pos = _poss;
        }
        private async void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure calculations are performed before proceeding
                calculate();

                bool confirmClose = true;

                // Check if there is an error related to money and confirm action if needed
                if (lblErrorMoney.Visible)
                {
                    confirmClose = MsgHelper.ShowAreYouSureYouWantToOpenCAisseWithNegative();
                }

                // Proceed only if the user confirms
                if (confirmClose)
                {
                    // Validate repository and settings before making the call
                    if (_repository == null)
                    {
                        throw new InvalidOperationException("Repository is not initialized.");
                    }

                    if (Properties.Settings.Default.DefaultCaisseId <= 0)
                    {
                        throw new ArgumentException("Invalid Caisse ID in settings.");
                    }


                    await _repository.OpenCaisse(Properties.Settings.Default.DefaultCaisseId
                         , LocalUser.User.UserName,
                         numericUpDown12.Value,
                         (numericUpDown1.Value),
                         (numericUpDown2.Value),
                         (numericUpDown3.Value),
                         (numericUpDown4.Value),
                         (numericUpDown5.Value),
                         (numericUpDown6.Value),
                         (numericUpDown7.Value),
                         (numericUpDown8.Value),
                         (numericUpDown9.Value), (numericUpDown11.Value));
                    ToasterHelper.ShowOpenedCaisse();

                    if (lblErrorMoney.Visible)
                    {
                        string caissename = _context.Caisses.FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId).CaisseName;
                        string alerttype = "فتح الصندوق بالسالب";
                        string Message = $"لقد تم فتح الصندوق {caissename} عن طريق {LocalUser.User.UserName} بنقص يقدر ب {amoutmis} يرجى مراجعة معلومات البرنامج والقيمة الحقيقة للصندوق";
                        var alert = _context.AlertsTable.FirstOrDefault(x => x.AlertType == alerttype && x.Message == Message && !x.IsResolved);
                        if (alert == null)
                        {
                            AlertTable alertTable = new AlertTable();
                            alertTable.AlertType = alerttype;
                            alertTable.Message = Message;
                            alertTable.Priority = PriorityAlert.Low;
                            alertTable.CreatedDate = DateTime.Now;
                            alertTable.IsResolved = false;
                            alertTable.Category = LocalUser.User.UserName;
                            _context.Add(alertTable);
                            _context.SaveChanges();
                        }
                    }
                    this.Hide();
                    _main.Hide();
                    PosForm posForm = new PosForm(_main);
                    posForm.ShowDialog();
                    _main.Show();
                }
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
        }
        decimal amoutmis = 0.00m;
        void calculate()
        {
            try
            {

                ValidateNumericUpDownValues();

                numericUpDown12.Value =
                    (numericUpDown11.Value) +
                    (numericUpDown9.Value * 5) +
                    (numericUpDown8.Value * 10) +
                    (numericUpDown7.Value * 20) +
                    (numericUpDown6.Value * 50) +
                    (numericUpDown5.Value * 100) +
                    (numericUpDown4.Value * 200) +
                    (numericUpDown3.Value * 500) +
                    (numericUpDown2.Value * 1000) +
                    (numericUpDown1.Value * 2000);
                if (btnClose.Visible)
                {
                    var amountmissing = _repository.BeforeClosing(Properties.Settings.Default.DefaultCaisseId, numericUpDown12.Value);
                    if (amountmissing > 0)
                    {
                        amoutmis = amountmissing;
                        lblErrorMoney.Visible = true;
                        lblErrorMoney.Text = $"يجب اعادة الحسبة لأنها تنقص {amountmissing} دج";


                    }
                    else
                    {
                        amoutmis = amountmissing;
                        lblErrorMoney.Visible = false;

                    }

                }
                else if (btnOpen.Visible)
                {
                    var amountmissing = _repository.BeforeOpening(Properties.Settings.Default.DefaultCaisseId, numericUpDown12.Value);
                    if (amountmissing > 0)
                    {
                        amoutmis = amountmissing;
                        lblErrorMoney.Visible = true;
                        lblErrorMoney.Text = $"يجب اعادة الحسبة لأنها تنقص {amountmissing} دج";
                    }
                    else
                    {
                        amoutmis = amountmissing;
                        lblErrorMoney.Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                ToasterHelper.ShowErrorHappened(ex.Message);
                throw;
            }
        }
        private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
        {
            calculate();
        }

        private async void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure calculations are performed before proceeding
                calculate();

                bool confirmClose = true;

                // Check if there is an error related to money and confirm action if needed
                if (lblErrorMoney.Visible)
                {
                    confirmClose = MsgHelper.ShowAreYouSureYouWantToCloseCAisseWithNegative();
                }

                // Proceed only if the user confirms
                if (confirmClose)
                {
                    // Validate repository and settings before making the call
                    if (_repository == null)
                    {
                        throw new InvalidOperationException("Repository is not initialized.");
                    }

                    if (Properties.Settings.Default.DefaultCaisseId <= 0)
                    {
                        throw new ArgumentException("Invalid Caisse ID in settings.");
                    }

                    // Close the caisse
                    await _repository.CloseCaisse(
                        Properties.Settings.Default.DefaultCaisseId,
                        LocalUser.User?.UserName ?? "Unknown User", // Ensure username is not null
                        numericUpDown12.Value,
                        numericUpDown1.Value,
                        numericUpDown2.Value,
                        numericUpDown3.Value,
                        numericUpDown4.Value,
                        numericUpDown5.Value,
                        numericUpDown6.Value,
                        numericUpDown7.Value,
                        numericUpDown8.Value,
                        numericUpDown9.Value,
                        numericUpDown11.Value
                    );

                    // Show success notification
                    ToasterHelper.ShowCloseCaisse();

                    if (lblErrorMoney.Visible)
                    {
                        string caissename = _context.Caisses.FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId).CaisseName;
                        string alerttype = "اغلاق الصندوق بالسالب";
                        string Message = $"لقد تم اغلاق الصندوق {caissename} عن طريق {LocalUser.User.UserName} بنقص يقدر ب {amoutmis} يرجى مراجعة معلومات البرنامج والقيمة الحقيقة للصندوق";
                        var alert = _context.AlertsTable.FirstOrDefault(x => x.AlertType == alerttype && x.Message == Message && !x.IsResolved);
                        if (alert == null)
                        {
                            AlertTable alertTable = new AlertTable();
                            alertTable.AlertType = alerttype;
                            alertTable.Message = Message;
                            alertTable.Priority = PriorityAlert.Low;
                            alertTable.CreatedDate = DateTime.Now;
                            alertTable.IsResolved = false;
                            alertTable.Category = LocalUser.User.UserName;
                            _context.Add(alertTable);
                            _context.SaveChanges();
                        }
                    }
                    // Hide current form and close the POS
                    this.Hide();
                    _pos?.Close();
                }
            }
            catch (Exception ex)
            {
                // Show user-friendly error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ValidateNumericUpDownValues()
        {
            var numericControls = new[]
            {
        numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5,
        numericUpDown6, numericUpDown7, numericUpDown8, numericUpDown9, numericUpDown11, numericUpDown12
    };

            foreach (var control in numericControls)
            {
                if (control.Value > control.Maximum || control.Value < control.Minimum)
                {
                    throw new OverflowException($"The value for {control.Name} exceeds the allowed range ({control.Minimum} to {control.Maximum}).");
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown)
            {
                if (numericUpDown.Value > numericUpDown.Maximum)
                {
                    MessageBox.Show(
                        $"The value for {numericUpDown.Name} exceeds the allowed maximum!",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    numericUpDown.Value = numericUpDown.Maximum; // Reset to maximum
                }
                else if (numericUpDown.Value < numericUpDown.Minimum)
                {
                    MessageBox.Show(
                        $"The value for {numericUpDown.Name} is below the allowed minimum!",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    numericUpDown.Value = numericUpDown.Minimum;
                }
            }
        }
    }
}
