using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.Filters;

namespace MockProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(RoleName = "Staff", CPermission = 1)]
    public class StaffJobOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JobOrderDetail(int id)
        {
            ViewBag.JOId = id;
            return View();
        }
    }
}
