using System.ComponentModel.DataAnnotations;

namespace ERPSystem.Models.Finance
{
    public class AccountReceivable
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
    }
}
