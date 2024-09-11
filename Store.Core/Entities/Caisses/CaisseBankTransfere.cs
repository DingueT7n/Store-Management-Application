namespace Store.Core.Entities.Caisses
{
    public class CaisseBankTransfere : BaseEntity<int>
    {
        public decimal Money { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string From_ { get; set; }
        public string To_ { get; set; }
        public string Name { get; set; }

    }


}
