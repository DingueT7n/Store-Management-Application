using Store.Infrastructure.Data;

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
        public static void ShowMaxDebtAllowedExceeded()
        {
            MessageBox.Show("لا يمكن السماح باجراء هاته العملية , لقد تعدى الدين المحدد",
                  "عدم السماح بهاته العملية"
                  , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowRequiredFields2()
        {
            MessageBox.Show("يرجى تعبئة جميع الحقول المطلوبة.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        public static void ShowDuplicatedItems()
        {
            MessageBox.Show("تم اضافة هذه البيانات بالفعل. تأكد من تغيير بعض بيانات بعض الحقول ثم اعدة المحاولة ",
                  "بيانات مكررة"
                  , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static bool ShowSalaryMinusIsNegative(string EmployeeName, string Salary)
        {
            var result = MessageBox.Show($"مرتب السيد {EmployeeName} لهذا الشهر {Salary} اذا اردت الاكمل اضغظ على القبول",
                   "تنبيه بيانات غير مسبوقة"
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
        public static bool ShowBareCodeIsGoingToChange()
        {
            var result = MessageBox.Show($"الباركود سيتغير بغد الموافقة , هل توافق؟",
                   "تنبيه بيانات ستستبدل"
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
        public static bool ShowProductNameIsSame()
        {
            var result = MessageBox.Show($"اسم المنتج موجود بالفعل! , هل تريد الاضافة على كل حال؟",
                   "تنبيه بيانات متشابهة"
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
        public static void ShowSameDirectionTransfert()
        {
            MessageBox.Show("لا يمكن التحويل الى نفس المخزن. تأكد من تغيير بعض بيانات ثم اعدة المحاولة ",
                  "بيانات غير متوافقة"
                  , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowInvalidQuentityTotransfert()
        {
            MessageBox.Show("لا يمكن التحويل لأن الكمية المحولة اكبر من الموجودة. تأكد من تغيير بعض بيانات ثم اعدة المحاولة ",
                  "بيانات غير متوافقة"
                  , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static bool ShowBareCodeDuplicated(ApplicationDbContext _context, string barCode)
        {

            try
            {
                var p = _context.Products.Where(x =>
                x.CodeBar == (barCode)
                )
                    .FirstOrDefault();
                if (p is not null)
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("لا يمكن حفظ العملية لأن الباركود موجود بالفعل في قاعدة البيانات ",
               "بيانات متكررة"
               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

            }
            catch
            {
                return false;
            }

        }
        public static bool ShowBareCodeDuplicatedWithoutMessages(ApplicationDbContext _context, string barCode)
        {

            try
            {
                var p = _context.Products.Where(x =>
                x.CodeBar == (barCode)
                )
                    .FirstOrDefault();
                if (p is not null)
                {
                    return false;
                }
                else
                {

                    return true;
                }

            }
            catch
            {
                return false;
            }

        }
        public static bool ShowProductNameDuplicated(ApplicationDbContext _context, string productName)
        {

            try
            {
                var p = _context.Products.Where(x =>
                x.ProductName == (productName)
                )
                    .FirstOrDefault();
                if (p is not null)
                {
                    return false;
                }
                else
                {

                    return true;
                }

            }
            catch
            {
                return false;
            }

        }
        public static void ShowInvalidMoneyTrasfert()
        {
            MessageBox.Show("لا يمكن التحويل لأن القيمة المحولة اكبر من الموجودة. تأكد من تغيير بعض بيانات ثم اعدة المحاولة ",
                  "بيانات غير متوافقة"
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
        public static bool ShowRefundDialog()
        {
            var result = MessageBox.Show("هل انت متأكد من هذا الاجراء ؟ لا يمكن استرجاع البيانات ",
                   "اجراء ارجاع مواد"
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
