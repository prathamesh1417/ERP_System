using ERPSystem.Data;
using ERPSystem.Models.Procurement;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.Services
{
    public class ProcurementService
    {
        private readonly ApplicationDbContext _context;
        public ProcurementService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve all purchase orders including vendor info.
        public async Task<IEnumerable<PurchaseOrder>> GetPurchaseOrdersAsync()
        {
            return await _context.PurchaseOrders.Include(po => po.Vendor).ToListAsync();
        }

        // Business logic: Approve orders that require it if certain conditions are met.
        public async Task<bool> ApproveOrderAsync(PurchaseOrder order)
        {
            if (order.RequiresApproval)
            {
                // Implement additional checks here (e.g., manager approval, budget availability)
                order.IsApproved = true;
                _context.Update(order);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
