namespace Store.ApplicationUI.Code.Helper
{
    public static class MsgHelper
    {

        public static void ShowServerError()
        {
            MessageBox.Show("يبدو ان هنالك مشكلة في الاتصال بالسيرفر . يرجى المحاولة مرة اخرى",
                "عدم توفر الاتصال",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowRequiredFields()
        {
            MessageBox.Show("جميع الحقول التي تتضمن علامة * هي حقول مطلوبة. تأكد من ادخالها واعد المحاولة مرة اخرى",
                  "حقول مطلوبة"
                  , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowDuplicatedItems()
        {
            MessageBox.Show("تم اضافة هذه البيانات بالفعل. تأكد من تغيير بعض بيانات بعض الحقول ثم اعدة المحاولة ",
                  "بيانات مكررة"
                  , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowDuplicatedItemsAndInformTeCaiser()
        {
            MessageBox.Show("تمت اضافة هذا المنتج بالفعل. لقد تمت تغيير الكمية واضافة 1 ",
                  "منتج في الجدول بالفعل"
                  , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowEmptyDataGridView()
        {
            MessageBox.Show("لاجراء هذه العملية, يجب ان تختار بيانات ",
                  "لا يوجد بيانات"
                  , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowEmptyResult()
        {
            MessageBox.Show("لا توجد بيانات ,يرجى التحقق من معلوماتك ",
                  "لا يوجد بيانات"
                  , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowDeleteSelectRow()
        {
            MessageBox.Show("لحساسية اجراء الحذف يجب عليك ان تختار كامل السطر ",
                  "اجراء حذف"
                  , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ShowDeleteDialog()
        {
            var result = MessageBox.Show("هل انت متأكد من هذا الاجراء؟ لا يمكن استرجاع البيانات ",
                   "اجراء حذف"
                   , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ShowErrorValidating()
        {
            var result = MessageBox.Show("هل انت متأكد من تجاهل الأخطاء؟  ",
                   "التأكد من الاخطاء"
                   , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ShowEditDialog()
        {
            var result = MessageBox.Show("هل انت متأكد من هذا الاجراء؟ لا يمكن استرجاع البيانات السابقة",
                   "اجراء تعديل"
                   , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ShowNumberValid()
        {
            MessageBox.Show("قم بأدخال قيمة رقيمة فقط! ",
                  "ادخال غير صحيح "
                  , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
