namespace Store.Core.Entities.AllDeserved
{
    public class Deserved : BaseEntity<int>
    {
        public float? Price { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Notes { get; set; }
        public int? TypeId { get; set; }


        public virtual DeservedType DeservedType { get; set; }

    }
}
