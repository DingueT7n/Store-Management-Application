using System.IO;
using System.Windows.Media;
using Store.ApplicationUI.Gui.ToasterGui;

namespace Store.ApplicationUI.Code.Helper
{
    public static class ToasterHelper
    {
        private static MediaPlayer _player = new();
        private static readonly object _lock = new();
        private static void PlaySound(string path)
        {
            lock (_lock)
            {
                try
                {
                    if (!File.Exists(path))
                        return;

                    _player.Open(new Uri(path));
                    _player.MediaEnded += (s, e) => _player.Close();
                    _player.Play();
                }
                catch (Exception)
                {
                    throw;
                    //Console.WriteLine($"Error playing sound: {ex.Message}");
                }
            }
        }
        public static void PlayNotificationSound(string soundFileName = "ClickMouse.wav")
        {
            string soundPath = Path.Combine(Application.StartupPath, soundFileName);
            PlaySound(soundPath);
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
        public static void ShowPrinting()
        {
            ToastForm.Instance("الطباعة جارية", "يتم الطبع الان . . . . .", null).Show();
        }
        public static void ShowLoginFailed()
        {
            ToastForm.Instance("فشل تسجيل الدخول", "اسم المستخدم او كلمة السر غير صحيحة , يرجى اعادة النظر", System.Drawing.Color.Red).Show();
        }
        public static void ShowLoginSucceded()
        {
            ToastForm.Instance("تم تسجيل الدخول", "معلومات صحيحة , تم تسجيل الدخول", null).Show();
        }

        public static void ShowConnectionIsEstablished()
        {
            ToastForm.Instance("اتصال بالسيريفر", "تم الاتصال بالسيرفر بنجاح", null).Show();
        }
        public static void ShowConnectionIsNotEstablished()
        {
            ToastForm.Instance("اتصال بالسيريفر", "لم يتم الاتصال بالسيرفر ", System.Drawing.Color.Red).Show();
        }
        public static void ShowConnectionIsNotEstablishedByError(string error)
        {
            ToastForm.Instance("اتصال بالسيريفر", $"لم يتم الاتصال بالسيرفر بسبب :{error}", System.Drawing.Color.Red).Show();
        }
        public static void ShowErrorHappened(string error)
        {
            ToastForm.Instance("للاسف فشلت العملية", $"لقد حدث خطأ :{error}", System.Drawing.Color.Red).Show();
            MessageBox.Show($"لقد حدث خطأ :{error}");
        }
        public static void ShowSettingCaisse()
        {
            ToastForm.Instance("خلل في الاعدادات", "هناك خلل في الاعدادات ,من فضلك راجع شاشة اعدادات البرنامج ", System.Drawing.Color.Red).Show();
        }
        public static void ShowRestore()
        {
            ToastForm.Instance("استعادة نسخة الاحتياطية", "تم استعادة النسخ الاحتياطي لقاعدة البيانات بنجاح", null).Show();
        }
        public static void ShowBackUp()
        {
            ToastForm.Instance("اخذ نسخة الاحتياطية", "تم اخذ النسخ الاحتياطي لقاعدة البيانات بنجاح", null).Show();
        }
        public static void ShowOpenedCaisse()
        {
            ToastForm.Instance("فتح الصندوق", "تم فتح الصندوق بنجاح", null).Show();
        }
        public static void ShowCloseCaisse()
        {
            ToastForm.Instance("غلق الصندوق", "تم غلق الصندوق بنجاح", null).Show();
        }
    }
}
