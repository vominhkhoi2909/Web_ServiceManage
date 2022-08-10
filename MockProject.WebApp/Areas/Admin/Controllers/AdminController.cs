using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.Filters;
using MockProject.WebApp.ModelAPI;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MockProject.WebApp.Areas.AdminArea.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _BaseUrl;


        public AdminController(ILogger<AdminController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _BaseUrl = _configuration["BASE_API_HOST"];
        }

        //[Authorize(RoleName = "Admin")]
        public async Task<IActionResult> Index()
        {
            string cookie = Request.Cookies["UserAdminLogin"];
            if (string.IsNullOrEmpty(cookie))
            {
                return RedirectToAction("", "Login");
            }
            else
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(_BaseUrl);
                // get uesr info
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookie);
                var response = client.GetAsync("/api/admin/getinfo");
                var resultReponse = await response.Result.Content.ReadAsStringAsync();
                var resultModel = JsonConvert.DeserializeObject<ResponseModel>(resultReponse);
                if (resultModel?.Success == true)
                {
                    var user = JsonConvert.DeserializeObject<AdminModel>(resultModel.Data.ToString());
                    ViewBag.User = user;
                    if(user.Role_Name != "Admin")
                    {
                        return RedirectToAction("Index", "StaffNote");
                    }    
                }
                else
                {
                    return RedirectToAction("","Login");
                }
            }
            return View();
        }


        public IActionResult Login()
        {
            ViewBag.BaseAPI = _BaseUrl;
            return View();
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserAdminLogin");
            return RedirectToAction("Index", "Login");
        }

        //Forbidden Page
        public IActionResult Forbidden()
        {
            return View();
        }

        // save token into cookie when login success
        public IActionResult LoginConfirm(string tokenText)
        {
            var cookieOptions = new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.Now.AddDays(1)
            };
            Response.Cookies.Append("UserAdminLogin", tokenText, cookieOptions);

            return RedirectToAction("Index", "Admin");
        }
        // Profile
        public IActionResult Profile()
        {
            string cookie = Request.Cookies["UserAdminLogin"];
            if (string.IsNullOrEmpty(cookie))
            {

                return RedirectToAction("Login");
            }
            ViewBag.token = cookie;
            return View();
        }

    }
}
