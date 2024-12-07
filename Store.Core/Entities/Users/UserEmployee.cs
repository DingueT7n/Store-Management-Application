namespace Store.Core.Entities.Users
{
    public class UserEmployee : BaseEntity<int>
    {
        public int User_Id { get; set; }
        public bool AllEmployee { get; set; }
        public bool AddEmployee { get; set; }
        public bool EmployeeBorrowItem { get; set; }
        public bool EmployeeBorrowMoney { get; set; }
        public bool EmployeeSalaries { get; set; }
        public bool EmployeeBorrowItemsReport { get; set; }
        public bool EmployeeBorrowMoneyReport { get; set; }
        public bool EmployeeSalariesReport { get; set; }
        public User User { get; set; }

    }
}
