namespace Store.Core.Entities.Returns
{
    public class Return : BaseEntity<int>
    {

        public DateTime OrderDate { get; set; }
        public string Time { get; set; }
        public string OrderType { get; set; }
        public string User_Name { get; set; }
        public float TotalOrder { get; set; }
        public float PaidUP { get; set; }
        public float Remain { get; set; }

        // Navigation property for one-to-many relationship with ReturnsDetails

    }
}