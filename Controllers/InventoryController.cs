using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryService _inventoryService;
        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // GET: Inventory
        public async Task<IActionResult> Index()
        {
            var products = await _inventoryService.GetProductsAsync();
            return View(products);
        }
    }
}
