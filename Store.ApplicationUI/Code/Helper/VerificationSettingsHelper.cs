using Store.Infrastructure.Data;

namespace Store.ApplicationUI.Code.Helper
{
    public static class VerificationSettingsHelper
    {

        public static bool IsAllSettingsAreApplied(ApplicationDbContext context)
        {
            var caisse = context.Caisses.FirstOrDefault(x => x.Id == Properties.Settings.Default.DefaultCaisseId);
            if (caisse is null)
            {
                ToasterHelper.ShowSettingCaisse();
                return false;
            }
            var store = context.Stores.FirstOrDefault(x => x.Id == Properties.Settings.Default.StoreIdDefault);
            if (store is null)
            {
                ToasterHelper.ShowSettingCaisse();
                return false;
            }
            var storefast = context.Stores.FirstOrDefault(x => x.Id == Properties.Settings.Default.FastSaleStore);
            if (storefast is null)
            {
                ToasterHelper.ShowSettingCaisse();
                return false;
            }

            var cust = context.Customers.FirstOrDefault(x => x.Id.ToString() == Properties.Settings.Default.IdCustomerSale);
            if (cust is null)
            {
                ToasterHelper.ShowSettingCaisse();
                return false;
            }

            return true;
        }
        public static bool ValidateActivationKey()
        {
            SKGL.Validate validate = new SKGL.Validate
            {
                secretPhase = Properties.Settings.Default.Key_crypt,
                Key = Properties.Settings.Default.Key
            };

            double daysLeft = Convert.ToDouble(Properties.Settings.Default.Days_left);
            DateTime dateTimeCreate = Convert.ToDateTime(Properties.Settings.Default.Creation);
            DateTime dateTimeExp = Convert.ToDateTime(Properties.Settings.Default.Expiration);

            if (DateTime.Now.Date < dateTimeCreate.Date)
            {
                return false;
            }

            if (DateTime.Now.Date > dateTimeExp.Date)
            {
                Properties.Settings.Default.Days_left = "0";
                Properties.Settings.Default.Save();
            }

            if (daysLeft < 0)
            {
                ToasterHelper.ShowActivationCompleted();
                MessageBox.Show("يرجى الاتصال بالمطور", "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            var daysleft = (validate.ExpireDate.Date - validate.CreationDate.Date).TotalDays;
            if (daysleft < 0)
            {
                ToasterHelper.ShowActivationCompleted();
                MessageBox.Show("يرجى الاتصال بالمطور", "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            Properties.Settings.Default.Days_left = daysleft.ToString();
            Properties.Settings.Default.Save();
            return (validate.IsValid && validate.ExpireDate >= DateTime.Now.Date);
        }
    }
}
