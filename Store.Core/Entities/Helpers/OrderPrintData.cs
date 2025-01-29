namespace Store.Core.Entities.Helpers
{
    public class OrderPrintData : BaseEntity<int>
    {
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone1 { get; set; }
        public string Fax { get; set; }
        public string CompteRib { get; set; }
        public string RC { get; set; }
        public string AI { get; set; }
        public string IDFiscal { get; set; }
        public string NIS { get; set; }
    }
    public class AlertTable : BaseEntity<int>
    {
        public string AlertType { get; set; } // Type of the alert (e.g., "Stock Low", "Price Change")
        public string Message { get; set; } // Detailed description of the alert
        public PriorityAlert Priority { get; set; } // Priority level (e.g., "High", "Medium", "Low")
        public DateTime CreatedDate { get; set; } // The date and time when the alert was created
        public DateTime? DueDate { get; set; } // The deadline or target date for resolving the alert
        public bool IsResolved { get; set; } // A flag indicating if the alert is resolved
        public DateTime? ResolvedDate { get; set; } // The date when the alert was resolved
        public string ResolvedBy { get; set; } // The user or team responsible for the alert
        public string Category { get; set; } // Category of the alert (e.g., "Inventory", "Orders")

    }
    public enum PriorityAlert
    {
        High,
        Medium,
        Low
    }
    public class AlertDto
    {
        public int Id { get; set; }
        public string AlertType { get; set; }
        public string Message { get; set; }
        public PriorityAlert Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Category { get; set; } // Category of the alert (e.g., "Inventory", "Orders")

    }
}
