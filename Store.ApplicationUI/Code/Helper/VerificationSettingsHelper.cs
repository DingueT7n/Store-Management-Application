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
    }
}
