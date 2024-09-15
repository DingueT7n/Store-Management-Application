namespace Store.Core.Entities.AllDeserved
{
    public class Deserved : BaseEntity<int>
    {
        public string UserName { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Notes { get; set; }
        public int TypeId { get; set; }
        public virtual DeservedType DeservedType { get; set; }

    }
}
