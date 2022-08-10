using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.Filters;

namespace MockProject.WebApp.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        [Area("Admin")]
        [Authorize(RoleName = "Staff", CPermission = 5)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
