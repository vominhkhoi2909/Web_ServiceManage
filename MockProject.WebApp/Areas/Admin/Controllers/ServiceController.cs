using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.Filters;

namespace MockProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(RoleName = "Admin")]
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
