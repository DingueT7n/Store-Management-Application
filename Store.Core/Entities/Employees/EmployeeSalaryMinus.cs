namespace Store.Core.Entities.Employees
{
    public class EmployeeSalaryMinus : BaseEntity<int>
    {

        public int Emp_ID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public decimal Price { get; set; }
        public string Pay { get; set; }


        public virtual Employee Employee { get; set; }
    }

}
