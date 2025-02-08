using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.Controllers
{
    public class ReportingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
