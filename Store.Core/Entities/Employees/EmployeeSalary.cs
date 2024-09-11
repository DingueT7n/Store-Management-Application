namespace Store.Core.Entities.Employees
{
    public class EmployeeSalary : BaseEntity<int>
    {

        public int Emp_ID { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal TotalBorrow { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime OrderDate { get; set; }
        public string Time { get; set; }
        public DateTime DateReminder { get; set; }
        public string Notes { get; set; }

        public virtual Employee Employee { get; set; }
    }

}
