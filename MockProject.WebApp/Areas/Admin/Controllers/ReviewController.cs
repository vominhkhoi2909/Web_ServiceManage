
using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.Filters;

namespace MockProject.WebApp.Areas.Admin.Controllers
{
    public class ReviewController : Controller
    {
        [Area("Admin")]
        [Authorize(RoleName = "Staff", CPermission = 4)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
