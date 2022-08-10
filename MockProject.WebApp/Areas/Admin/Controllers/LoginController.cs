using Microsoft.AspNetCore.Mvc;

namespace MockProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewBag.BaseAPI = _configuration["BASE_API_HOST"];
            return View();
        }
        public IActionResult ForgotPassword()
        {
            ViewBag.BaseAPI = _configuration["BASE_API_HOST"];
            return View();
        }
        public IActionResult ResetPassword(int userid, string token)
        {
            ViewBag.BaseAPI = _configuration["BASE_API_HOST"];
            ViewBag.userId = userid;
            ViewBag.token = token;
            return View();
        }
    }
}
