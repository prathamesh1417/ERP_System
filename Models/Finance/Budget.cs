namespace ERPSystem.Models.Finance
{
    public class Budget
    {
        public int Id { get; set; }
        public decimal AllocatedAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public string Department { get; set; }
    }
}
