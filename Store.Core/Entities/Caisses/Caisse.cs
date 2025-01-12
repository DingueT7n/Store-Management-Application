namespace Store.Core.Entities.Caisses
{
    public class Caisse : BaseEntity<int>
    {
        public string CaisseName { get; set; }
        public decimal MoneyinCaisse { get; set; }
        public CaisseStatus Status { get; set; } = CaisseStatus.Closed; // Default to Closed
                                                                        // Navigation Properties
        public virtual ICollection<CaisseStatusDetail> StatusDetails { get; set; } = new HashSet<CaisseStatusDetail>();
        public virtual ICollection<CaisseOperation> Operations { get; set; } = new HashSet<CaisseOperation>();

        public override string ToString()
        {
            return CaisseName;
        }
    }

    public enum CaisseStatus
    {
        Open,
        Closed
    }
    public class CaisseStatusDetail : BaseEntity<int>
    {
        public int CaisseId { get; set; }
        public string CaisseName { get; set; }
        public string OpenedBy { get; set; }
        public string ClosedBy { get; set; }
        public decimal MoneyBeforeInCaisse { get; set; }
        public decimal MoneyBefore { get; set; }
        public decimal MoneyAfterInCaisse { get; set; }
        public decimal MoneyAfter { get; set; }
        public DateTime? OpeningTime { get; set; }
        public DateTime? ClosingTime { get; set; }
        public CaisseStatus Status { get; set; }
        public string Duration { get; set; }
        // Navigation Property
        public bool IsBalanced { get; set; }
        public virtual Caisse Caisse { get; set; }
        public override string ToString()
        {
            return CaisseName;
        }
    }
    public class CaisseOperation : BaseEntity<int>
    {

        public CaisseStatus Status { get; set; } // Closed, Opened
        public string PerformedBy { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Nbr2000DA { get; set; }
        public decimal Nbr1000DA { get; set; }
        public decimal Nbr500DA { get; set; }
        public decimal Nbr200DA { get; set; }
        public decimal Nbr100DA { get; set; }
        public decimal Nbr50DA { get; set; }
        public decimal Nbr20DA { get; set; }
        public decimal Nbr10DA { get; set; }
        public decimal Nbr5DA { get; set; }
        public decimal ValueAddedDefault { get; set; }

        public string Time { get; set; }
        public int CaisseStatusDetailId { get; set; }
        // Navigation Property
        public virtual CaisseStatusDetail CaisseStatusDetail { get; set; }


    }

}
