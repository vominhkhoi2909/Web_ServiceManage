using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MockProject.WebApp.Filters;
using System.Net.Mime;

namespace MockProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(RoleName = "Staff", CPermission = 3)]
    public class SliderController : Controller
    {
        private IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly static string SLIDER_URL = @"assets\image\main";
        public SliderController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region File
        [HttpPost]
        public string Process()
        {
            var file = Request.Form.Files.FirstOrDefault();
            if (file is null)
            {
                return "";
            }

            // We do some internal application validation here with our caseId

            try
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string saveName = fileName + DateTime.Now.ToString("yyyymmddMMss") + extension;

                // Root Create Folder
                string wwwPath = _webHostEnvironment.WebRootPath;
                string path = Path.Combine(wwwPath, SLIDER_URL);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Copy File
                using (FileStream stream = new FileStream(Path.Combine(path, saveName), FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                //await UpdateImageUrl(Request.Cookies["UserAdminLogin"], saveName);
                return saveName;
            }
            catch (Exception e)
            {
                return ""; // Oops!
            }
        }
        // Load File
        public IActionResult Load(string load)
        {
            if (string.IsNullOrEmpty(load) || System.IO.File.Exists(Path.Combine(SLIDER_URL + load)))
            {
                return null;
            }
            else
            {
                string webRootpath = _webHostEnvironment.WebRootPath;
                string contentRootpath = _webHostEnvironment.ContentRootPath;

                try
                {
                    var fileBytes = System.IO.File.ReadAllBytes(Path.Combine(webRootpath, SLIDER_URL, load));
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
            string filePath = Path.Combine(webRootpath, SLIDER_URL, fileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                //await UpdateImageUrl(Request.Cookies["UserAdminLogin"], "default.png");
            }
            return Json("1");
        }
# endregion


    }
}
