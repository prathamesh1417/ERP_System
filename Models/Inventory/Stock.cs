using System.ComponentModel.DataAnnotations.Schema;

namespace ERPSystem.Models.Inventory
{
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        // Foreign key to Product
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
