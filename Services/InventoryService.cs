using ERPSystem.Data;
using ERPSystem.Models.Inventory;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.Services
{
    public class InventoryService
    {
        private readonly ApplicationDbContext _context;
        public InventoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(p => p.Stock).ToListAsync();
        }
    }
}
