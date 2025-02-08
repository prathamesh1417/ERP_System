using System.Threading.Tasks;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.Controllers
{
    public class FinanceController : Controller
    {
        private readonly FinanceService _financeService;

        public FinanceController(FinanceService financeService)
        {
            _financeService = financeService;
        }

        // GET: Finance
        public async Task<IActionResult> Index()
        {
            var transactions = await _financeService.GetTransactionsAsync();
            ViewBag.TotalReconciled = _financeService.ReconcileTransactions(transactions);
            return View(transactions);
        }
    }
}
