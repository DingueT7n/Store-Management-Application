using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Core.Entities.Employees
{
    public class EmployeeSalaryMinus : BaseEntity<int>
    {

        public int Emp_ID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public float Price { get; set; }
        public string Pay { get; set; }

        [ForeignKey("Emp_ID")]
        public virtual Employee Employee { get; set; }
    }

}
