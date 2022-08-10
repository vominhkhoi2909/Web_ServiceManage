using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.Filters;
using MockProject.WebApp.ModelAPI;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Reflection;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace MockProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(RoleName = "Admin")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _BaseUrl;

        public CustomerController(ILogger<CustomerController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _BaseUrl = _configuration["BASE_API_HOST"];
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit(string id)
        {
            ViewBag.userId = id;
            return View();
        }
        public JsonResult ImportExcel([FromBody] IEnumerable<CustomerModel> list)
        {
            List<CustomerModel> listError = new List<CustomerModel>();
            foreach(CustomerModel item in list)
            {
                bool temp = AddCustomer(item).Result;
                if(!temp)
                {
                    listError.Add(item);    
                }    
            }    
            if(listError.Any())
            {
                var cookieOptions = new CookieOptions
                {
                    Secure = true,
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.Cookies.Append("ERROR_LIST", JsonConvert.SerializeObject(listError), cookieOptions);
            }    
            return Json(listError);
        }  
        public async Task<bool> AddCustomer(CustomerModel model)
        {
            if (!string.IsNullOrEmpty(model.phone) && !string.IsNullOrEmpty(model.name) && !string.IsNullOrEmpty(model.email))
            {
                var json = JsonConvert.SerializeObject(model);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var client = new HttpClient();
                client.BaseAddress = new Uri(_BaseUrl);


                var response = await client.PostAsync("/api/customer", httpContent);
                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            //var errors = ModelState.Select(x => x.Value.Errors)
            //               .Where(y => y.Count > 0)
            //               .ToList();
            return false;
        }
        public ActionResult DownloadError()
        {
            //---=== Init ===---
            var data = Request.Cookies["ERROR_LIST"];
            if (data != null)
            {
                List<CustomerModel> listError = JsonConvert.DeserializeObject<List<CustomerModel>>(data);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage pkg = new ExcelPackage();
                ExcelWorksheet sheet = pkg.Workbook.Worksheets.Add("Error List");
                string[] listColName = new string[] { "Customer Name", "Email", "Phone", "Address" };
                //---=== Configure ===---
                //Column name
                int posRow = 1; //Start position of row
                int posCol = 1; //Start position of column
                foreach (string name in listColName)
                {
                    ExcelRange colTitle = sheet.Cells[posRow, posCol];
                    colTitle.Value = name;
                    colTitle.Style.Font.Bold = true;
                    colTitle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    posCol++;
                }
                //Column data
                posRow++; // Set to 2 (next row)
                Color highlight = ColorTranslator.FromHtml("#FFFF00"); //Highlight color
                foreach (CustomerModel item in listError)
                {
                    posCol = 1;
                    foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
                    {
                        ExcelRange cellData = sheet.Cells[posRow, posCol];
                        cellData.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        if (propertyInfo.GetValue(item) == null)
                        {
                            cellData.Value = null;
                        }
                        else //Add invaild condition here
                        {
                            cellData.Value = propertyInfo.GetValue(item);
                        }
                        posCol++;
                    }
                    posRow++;
                }
                //Set data to date
                ExcelRange dateCol = sheet.Cells[2, listColName.Length - 1, posRow, listColName.Length - 1];
                dateCol.Style.Numberformat.Format = "dd/MM/yyyy";
                //Auto fit all row
                ExcelRange fitRow = sheet.Cells[1, 1, posRow, listColName.Length];
                fitRow.AutoFitColumns();
                //Add sorting to column name
                ExcelRange colTitleRow = sheet.Cells[1, 1, 1, listColName.Length];
                colTitleRow.AutoFilter = true;
                //Send back to client for download
                MemoryStream stream = new MemoryStream();
                pkg.SaveAs(stream);
                stream.Position = 0;

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml", "Error " + DateTime.Now.ToString() + ".xlsx");
            }
            return null;
           
        }
    }
}

