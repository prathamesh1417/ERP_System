namespace ERPSystem.Models.Finance
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        // Helper: Format transaction details for reports
        public string ReportFormat => $"{TransactionDate.ToShortDateString()} - {Description}: {Amount:C}";
    }
}
