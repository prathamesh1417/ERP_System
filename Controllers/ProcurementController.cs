using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.Controllers
{
    public class ProcurementController : Controller
    {
        private readonly ProcurementService _procurementService;
        public ProcurementController(ProcurementService procurementService)
        {
            _procurementService = procurementService;
        }

        // GET: Procurement
        public async Task<IActionResult> Index()
        {
            var orders = await _procurementService.GetPurchaseOrdersAsync();
            return View(orders);
        }

        // POST: Procurement/Approve/{id}
        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            var orders = await _procurementService.GetPurchaseOrdersAsync();
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            var approved = await _procurementService.ApproveOrderAsync(order);
            TempData["ApprovalMessage"] = approved ? "Order approved." : "Order does not require approval.";
            return RedirectToAction(nameof(Index));
        }
    }
}
