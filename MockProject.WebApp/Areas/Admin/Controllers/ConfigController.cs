using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.Filters;

namespace MockProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(RoleName = "Staff", CPermission = 2)]
    public class ConfigController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
