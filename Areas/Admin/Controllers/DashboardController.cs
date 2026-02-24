using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShoping.Areas.Admin.Controllers
{
    
    [Area("Admin")]
        public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
