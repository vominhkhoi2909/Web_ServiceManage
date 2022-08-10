using Microsoft.AspNetCore.Mvc;

namespace MockProject.WebApp.Areas.Admin.Controllers
{
    public class SaleController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
