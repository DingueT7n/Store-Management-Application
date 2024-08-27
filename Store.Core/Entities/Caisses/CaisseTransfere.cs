namespace Store.Core.Entities.Caisses
{
    public class CaisseTransfere : BaseEntity<int>
    {
        public float Money { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }

        public int Caisse_From { get; set; }
        public int Caisse_To { get; set; }

        public virtual Caisse CaisseFrom { get; set; }


        public virtual Caisse CaisseTo { get; set; }
    }


}
