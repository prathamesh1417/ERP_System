using System.ComponentModel.DataAnnotations.Schema;

namespace ERPSystem.Models.Procurement
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Approval status and logic
        public bool IsApproved { get; set; }

        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }

        // Business rule: Orders over threshold require approval
        public bool RequiresApproval => TotalAmount > 5000;
    }
}
