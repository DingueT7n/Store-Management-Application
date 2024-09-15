namespace Store.Core.Entities.AllDeserved
{
    public class DeservedType : BaseEntity<int>
    {
        public string Description { get; set; }
        public override string ToString()
        {
            return Description;
        }
    }

}