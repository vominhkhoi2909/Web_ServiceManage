using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.ModelAPI;
using Newtonsoft.Json;

namespace MockProject.WebApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _BaseUrl;

        public BookingController(IConfiguration configuration)
        {
            _configuration = configuration;
            _BaseUrl = _configuration["BASE_API_HOST"];
        }

        // booking
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_BaseUrl);
            // get option list - brand and size
            var responseOption= client.GetAsync($"/api/Option/All");
            var resultOptionAPI = await responseOption.Result.Content.ReadAsStringAsync();
            var resultOption = JsonConvert.DeserializeObject<ResponseModel>(resultOptionAPI);
            var optionList = JsonConvert.DeserializeObject<List<OptionModel>>(resultOption.Data.ToString());
            
            // get service
            var responseService = client.GetAsync($"/api/Service/All");
            var resultServiceAPI = await responseService.Result.Content.ReadAsStringAsync();
            var resultService = JsonConvert.DeserializeObject<ResponseModel>(resultServiceAPI);
            var serviceList = JsonConvert.DeserializeObject<List<ServiceModel>>(resultService.Data.ToString());

            // get promotion
            //var responsePromotion = client.GetAsync($"/api/Promotion/All");
            //var resultPromotionAPI = await responsePromotion.Result.Content.ReadAsStringAsync();
            //var resultPromotion = JsonConvert.DeserializeObject<ResponseModel>(resultPromotionAPI);
            //var promotionList = JsonConvert.DeserializeObject<List<PromotionModel>>(resultPromotion.Data.ToString());

            // send data to view by Viewbag
            ViewBag.optionList = optionList;
            ViewBag.serviceList = serviceList;
            //ViewBag.promotionList = promotionList;

            return View();
        }

        // get data from view and send it to cookie
        [HttpPost]
        public ActionResult PreSubmitBookingForm([FromBody] List<JobOrderDetail> myParam)
        {
            var cookieOptions = new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.Now.AddDays(1)
            };
            Response.Cookies.Append("Data", JsonConvert.SerializeObject(myParam), cookieOptions);

            return RedirectToAction("BookingForm","Booking");
        }

        // get the booking detail if the cookie exist
        public IActionResult BookingForm()
        {
            var data = Request.Cookies["Data"];
            if (data != null)
            {
                var resultPromotion = JsonConvert.DeserializeObject<List<JobOrderDetail>>(data);
                return View(resultPromotion);
            }
            return RedirectToAction("Index", "Booking");
        }


    }
}
