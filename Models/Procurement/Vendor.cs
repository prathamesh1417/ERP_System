using System.ComponentModel.DataAnnotations;

namespace ERPSystem.Models.Procurement
{
    public class Vendor
    {
        public int Id { get; set; }
        [Required]
        public string VendorName { get; set; }
        public string ContactInfo { get; set; }
    }
}
