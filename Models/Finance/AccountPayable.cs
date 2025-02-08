using System.ComponentModel.DataAnnotations;

namespace ERPSystem.Models.Finance
{
    public class AccountPayable
    {
        public int Id { get; set; }

        [Required]
        public string VendorName { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
    }
}
