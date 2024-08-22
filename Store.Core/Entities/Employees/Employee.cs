namespace Store.Core.Entities.Employees
{
    public class Employee : BaseEntity<int>
    {
        public string EmployeeName { get; set; }
        public float Salary { get; set; }
        public DateTime DateJoined { get; set; }
        public string National_ID { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        ICollection<EmployeeBorrowItem> BorrowItems { get; set; }
        ICollection<EmployeeBorrowMoney> BorrowMoney { get; set; }
        ICollection<EmployeeSalary> BorrowSalary { get; set; }
        ICollection<EmployeeSalaryMinus> BorrowSalaryMinus { get; set; }
    }

}
