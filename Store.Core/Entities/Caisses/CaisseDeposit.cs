namespace Store.Core.Entities.Caisses
{
    public class CaisseDeposit : BaseEntity<int>
    {

        public int Caisse_ID { get; set; }
        public decimal Money { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Reason { get; set; }


        public virtual Caisse Caisse { get; set; }

    }


}
