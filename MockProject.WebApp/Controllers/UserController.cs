using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace MockProject.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly static string PROFILE_URL = @"assets\image\profileImg";

        public UserController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Login()
        {
            ViewBag.BaseAPI = _configuration["BASE_API_HOST"];
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
            Response.Cookies.Append("UserLogin", tokenText, cookieOptions);
            return RedirectToAction("Index", "Home");
        }

        // Register
        public IActionResult Register()
        {
            ViewBag.BaseAPI = _configuration["BASE_API_HOST"];
            return View();
        }

        // request login 
        public IActionResult LoginRequest()
        {
            return View();
        }

        // Job Order Detail of each account
        public IActionResult JobOrderDetail(int id)
        {
            return View(id);
        }

        // Forgot Password
        public IActionResult ForgotPassword()
        {
            ViewBag.BaseAPI = _configuration["BASE_API_HOST"];
            return View();
        }

        //Confirm Email
        public IActionResult ConfirmEmail()
        {
            ViewBag.BaseAPI = _configuration["BASE_API_HOST"];
            return View();
        }

        // Reset Password
        public IActionResult ResetPassword(string email, string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login");
            }
            ViewBag.Email = email;
            ViewBag.Token = token;
            ViewBag.BaseAPI = _configuration["BASE_API_HOST"];
            return View();
        }
        public async Task<IActionResult> ConfirmAccountSuccessfully(string userid, string token)
        {

            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Home");
            }

            var query = new Dictionary<string, string>()
            {
                ["userid"] = userid,
                ["token"] = token
            };
            //Get host Api
            var host = _configuration["BASE_API_HOST"];
            var endPoint = host + "api/account/confirmemail";
            //Add Query Parameters
            var uri = QueryHelpers.AddQueryString(endPoint, query);

            var response = await new HttpClient().GetAsync(uri);

            var result = await response.Content.ReadAsStringAsync();

            return View();
        }
        // Log OUT
        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserLogin");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile()
        {
            ViewBag.BaseAPI = _configuration["BASE_API_HOST"];
            return View();
        }


        // File Manage
        //[HttpPost]
        //public async Task<ActionResult> Process()
        //{
        //    var file = Request.Form.Files.FirstOrDefault();
        //    if (file is null)
        //    {
        //        return BadRequest("Process Error: No file submitted");
        //    }

        //    // We do some internal application validation here with our caseId

        //    try
        //    {
        //        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
        //        string extension = Path.GetExtension(file.FileName);
        //        string saveName = fileName + DateTime.Now.ToString("yyyymmddMMss") + extension;

        //        // Root Create Folder
        //        string wwwPath = _webHostEnvironment.WebRootPath;
        //        string path = Path.Combine(wwwPath, @"\assets\image\profileImg");
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }

        //        // Copy File
        //        using (FileStream stream = new FileStream(Path.Combine(path, saveName), FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }

        //        await UpdateImageUrl(Request.Cookies["UserLogin"], saveName);


        //        return Ok(saveName);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest($"Process Error: {e.Message}"); // Oops!
        //    }
        //}
        // File Manage
        [HttpPost]
        public async Task<ActionResult> Process()
        {
            var file = Request.Form.Files.FirstOrDefault();
            if (file is null)
            {
                return BadRequest("Process Error: No file submitted");
            }

            // We do some internal application validation here with our caseId

            try
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string saveName = fileName + DateTime.Now.ToString("yyyymmddMMss") + extension;

                // Root Create Folder
                string wwwPath = _webHostEnvironment.WebRootPath;
                string path = Path.Combine(wwwPath, @"assets\image\profileImg");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Copy File
                using (FileStream stream = new FileStream(Path.Combine(path, saveName), FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                await UpdateImageUrl(Request.Cookies["UserLogin"], saveName);
                return Ok(saveName);
            }
            catch (Exception e)
            {
                return BadRequest($"Process Error: {e.Message}"); // Oops!
            }
        }

        public async Task<Boolean> UpdateImageUrl(string token, string ImageName)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(ImageName))
            {
                return false;
            }
            var query = new Dictionary<string, string>()
            {
                ["fileName"] = ImageName,
            };
            var encodedContent = new FormUrlEncodedContent(query);

            //Get host Api
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var host = _configuration["BASE_API_HOST"];
            var endPoint = host + "api/account/changeavatar";
            //Add Query Parameters
            var uri = QueryHelpers.AddQueryString(endPoint, query);

            // Get Response
            var response = await client.PostAsync(uri, encodedContent);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            return false;
        }
        // Load File
        public IActionResult Load(string load)
        {
            if (string.IsNullOrEmpty(load) || System.IO.File.Exists(Path.Combine(PROFILE_URL + load)))
            {
                return null;
            }
            else
            {
                string webRootpath = _webHostEnvironment.WebRootPath;
                string contentRootpath = _webHostEnvironment.ContentRootPath;

                try
                {
                    var fileBytes = System.IO.File.ReadAllBytes(Path.Combine(webRootpath, PROFILE_URL, load));
                    var mimeType = GetMimeTypeForFileExtension(load);
                    Response.Headers.Add("Content-Disposition", new ContentDisposition
                    {
                        FileName = load,
                        Inline = true // false = prompt the user for downloading; true = browser to try to show the file inline
                    }.ToString());
                    return File(fileBytes, mimeType);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public string GetMimeTypeForFileExtension(string filePath)
        {
            const string DefaultContentType = "application/octet-stream";

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(filePath, out string contentType))
            {
                contentType = DefaultContentType;
            }

            return contentType;
        }
        [HttpPost]
        public async Task<IActionResult> Revert(string fileName)
        {
            string webRootpath = _webHostEnvironment.WebRootPath;
            string filePath = Path.Combine(webRootpath, PROFILE_URL, fileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                await UpdateImageUrl(Request.Cookies["UserLogin"], "default.png");
            }
            return Json("1");
        }
    }
}
