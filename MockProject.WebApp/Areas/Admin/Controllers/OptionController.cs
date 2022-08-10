using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.Filters;

namespace MockProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(RoleName = "Admin")]
    public class OptionController : Controller
    {
        public IActionResult Brand()
        {
            return View();
        }

        public IActionResult Size()
        {
            return View();
        }
    }
}
