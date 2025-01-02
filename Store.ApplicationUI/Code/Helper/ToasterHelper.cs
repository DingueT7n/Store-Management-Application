using System.IO;
using System.Windows.Media;
using Store.ApplicationUI.Gui.ToasterGui;

namespace Store.ApplicationUI.Code.Helper
{
    public static class ToasterHelper
    {
        private static MediaPlayer _player = new(); // Field to keep MediaPlayer alive
        static string soundFilePath = Path.Combine(Application.StartupPath, "ClickMouse.wav");

        public static void PlayNotificationSound()
        {
            try
            {
                if (!File.Exists(soundFilePath))
                {
                    //MessageBox.Show($"Sound file not found: {soundFilePath}");
                    return;
                }
                _player.Open(new Uri(soundFilePath));
                _player.MediaEnded += (s, e) => _player.Close(); // Cleanup after playback
                _player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}");
            }
        }
        public static void ShowAddToast()
        {
            ToastForm.Instance("اضافة البيانات", "تم اضافة البيانات بنجاح", null).Show();
        }
        public static void ShowEditToast()
        {
            ToastForm.Instance("تعديل البيانات", "تم تعديل البيانات بنجاح", null).Show();
        }
        public static void ShowDeletedToast()
        {
            ToastForm.Instance("حذف البيانات", "تم حذف البيانات بنجاح", null).Show();
        }
        public static void ShowTransfertProduct()
        {
            ToastForm.Instance("تحويل المنتجات", "تم تحويل المنتجات بنجاح", null).Show();
        }
        public static void ShowOutStockProduct()
        {
            ToastForm.Instance(" تحويل المنتجات الفاسدة", "تم تحويل المنتجات الفاسدة بنجاح", null).Show();
        }
        public static void ShowProductDiscountAdded()
        {
            ToastForm.Instance("اضافة التخفيض", "تم اضافة التخفيض على المنتجات بنجاح", null).Show();
        }
        public static void ShowNewBuyAdd()
        {
            ToastForm.Instance("اضافة شراء", "تم اضافة الشراء بنجاح", null).Show();
        }
        public static void ShowNewSaleAdd()
        {
            ToastForm.Instance("اضافة مبيعات", "تم اضافة المبيعة بنجاح", null).Show();
        }
        public static void ShowWithdraw()
        {
            ToastForm.Instance("سحب اموال", "تم سحب المال بنجاح", null).Show();
        }
        public static void ShowDeposit()
        {
            ToastForm.Instance("ايداع اموال", "تم ايداع المال بنجاح", null).Show();
        }

        public static void ShowTransfert()
        {
            ToastForm.Instance("تحويل اموال", "تم تحويل المال بنجاح", null).Show();
        }
        public static void ShowDebtAdded()
        {
            ToastForm.Instance("دفع الدين", "تم دفع الدين بنجاح", null).Show();
        }
        public static void ShowSalarie()
        {
            ToastForm.Instance("دفع الرواتب", "تم دفع الراتب بنجاح", null).Show();
        }
        public static void ShowBorrowMoney()
        {
            ToastForm.Instance("اضافة الدين", "تم اضافة الدين بنجاح", null).Show();
        }
        public static void ShowBorrowItem()
        {
            ToastForm.Instance("اضافة بيانات", "تم سحب المنتج بنجاح", null).Show();
        }
        public static void ShowAddedRefund()
        {
            ToastForm.Instance("اضافة المرتجعات", "تم اضافة المرتجعات بنجاح", null).Show();
        }

        public static void ShowConnectionIsEstablished()
        {
            ToastForm.Instance("اتصال بالسيريفر", "تم الاتصال بالسيرفر بنجاح", null).Show();
        }
        public static void ShowConnectionIsNotEstablished()
        {
            ToastForm.Instance("اتصال بالسيريفر", "لم يتم الاتصال بالسيرفر ", System.Drawing.Color.Red).Show();
        }
    }
}
