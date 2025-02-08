using System.ComponentModel.DataAnnotations.Schema;

namespace ERPSystem.Models.Procurement
{
    public class SupplierInvoice
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Amount { get; set; }

        public int PurchaseOrderId { get; set; }
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }
    }
}
