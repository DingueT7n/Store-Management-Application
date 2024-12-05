namespace Store.Core.Entities.Employees
{
    public class EmployeeBorrowMoney : BaseEntity<int>
    {
        public int Emp_Id { get; set; }

        public string BorrowFrom { get; set; }
        public string BorrowTo { get; set; }
        public DateTime OrderDate { get; set; }
        public string Time { get; set; }
        public DateTime DateReminder { get; set; }
        public decimal Value { get; set; }
        public string Notes { get; set; }

        public virtual Employee Employee { get; set; }
    }

}
