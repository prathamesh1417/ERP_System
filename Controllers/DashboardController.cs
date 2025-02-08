using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
