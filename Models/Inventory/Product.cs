using System.ComponentModel.DataAnnotations;

namespace ERPSystem.Models.Inventory
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        // Navigation property for Stock

        public Stock? Stock { get; set; }

        // Business logic: Low stock alert
        public bool IsLowStock => Stock != null && Stock.Quantity < 10;
    }
}
