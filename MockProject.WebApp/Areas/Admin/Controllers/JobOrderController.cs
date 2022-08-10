using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.Filters;

namespace MockProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(RoleName = "Admin")]
    public class JobOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            ViewBag.JOId = id;
            return View();
        }
    }
}
