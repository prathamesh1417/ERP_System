using ERPSystem.Data;
using ERPSystem.Models.Procurement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PurchaseOrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrder
        public async Task<IActionResult> Index()
        {
            var orders = await _context.PurchaseOrders.Include(po => po.Vendor).ToListAsync();
            return View(orders);
        }

        // GET: PurchaseOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var order = await _context.PurchaseOrders.Include(po => po.Vendor)
                .FirstOrDefaultAsync(po => po.Id == id);
            if (order == null)
                return NotFound();
            return View(order);
        }

        // GET: PurchaseOrder/Create
        public IActionResult Create()
        {
            // Optionally, load list of vendors for a dropdown
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "VendorName");
            return View();
        }

        // POST: PurchaseOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseOrder order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "VendorName", order.VendorId);
            return View(order);
        }

        // GET: PurchaseOrder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var order = await _context.PurchaseOrders.FindAsync(id);
            if (order == null)
                return NotFound();
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "VendorName", order.VendorId);
            return View(order);
        }

        // POST: PurchaseOrder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PurchaseOrder order)
        {
            if (id != order.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.PurchaseOrders.Any(po => po.Id == order.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "VendorName", order.VendorId);
            return View(order);
        }

        // GET: PurchaseOrder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var order = await _context.PurchaseOrders.Include(po => po.Vendor)
                .FirstOrDefaultAsync(po => po.Id == id);
            if (order == null)
                return NotFound();
            return View(order);
        }

        // POST: PurchaseOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.PurchaseOrders.FindAsync(id);
            if (order != null)
            {
                _context.PurchaseOrders.Remove(order);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
