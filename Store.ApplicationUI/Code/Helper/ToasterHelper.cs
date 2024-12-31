using Store.ApplicationUI.Gui.ToasterGui;

namespace Store.ApplicationUI.Code.Helper
{
    public static class ToasterHelper
    {
        public static void ShowAddToast()
        {
            ToastForm.Instance("اضافة البيانات", "تم اضافة البيانات بنجاح").Show();
        }
        public static void ShowEditToast()
        {
            ToastForm.Instance("تعديل البيانات", "تم تعديل البيانات بنجاح").Show();
        }
        public static void ShowDeletedToast()
        {
            ToastForm.Instance("حذف البيانات", "تم حذف البيانات بنجاح").Show();
        }
        public static void ShowTransfertProduct()
        {
            ToastForm.Instance("تحويل المنتجات", "تم تحويل المنتجات بنجاح").Show();
        }
        public static void ShowOutStockProduct()
        {
            ToastForm.Instance(" تحويل المنتجات الفاسدة", "تم تحويل المنتجات الفاسدة بنجاح").Show();
        }
        public static void ShowProductDiscountAdded()
        {
            ToastForm.Instance("اضافة التخفيض", "تم اضافة التخفيض على المنتجات بنجاح").Show();
        }
        public static void ShowNewBuyAdd()
        {
            ToastForm.Instance("اضافة شراء", "تم اضافة الشراء بنجاح").Show();
        }
        public static void ShowNewSaleAdd()
        {
            ToastForm.Instance("اضافة مبيعات", "تم اضافة المبيعة بنجاح").Show();
        }
        public static void ShowWithdraw()
        {
            ToastForm.Instance("سحب اموال", "تم سحب المال بنجاح").Show();
        }
        public static void ShowDeposit()
        {
            ToastForm.Instance("ايداع اموال", "تم ايداع المال بنجاح").Show();
        }

        public static void ShowTransfert()
        {
            ToastForm.Instance("تحويل اموال", "تم تحويل المال بنجاح").Show();
        }
        public static void ShowDebtAdded()
        {
            ToastForm.Instance("دفع الدين", "تم دفع الدين بنجاح").Show();
        }
        public static void ShowSalarie()
        {
            ToastForm.Instance("دفع الرواتب", "تم دفع الراتب بنجاح").Show();
        }
        public static void ShowBorrowMoney()
        {
            ToastForm.Instance("اضافة الدين", "تم اضافة الدين بنجاح").Show();
        }
        public static void ShowBorrowItem()
        {
            ToastForm.Instance("اضافة بيانات", "تم سحب المنتج بنجاح").Show();
        }
        public static void ShowAddedRefund()
        {
            ToastForm.Instance("اضافة المرتجعات", "تم اضافة المرتجعات بنجاح").Show();
        }
    }
}
