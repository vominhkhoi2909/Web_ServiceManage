using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.ModelAPI;
using MockProject.WebApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MockProject.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _BaseUrl;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _BaseUrl = _configuration["BASE_API_HOST"];
        }
        
        public async Task<IActionResult> Index()
        {
            var client =  new HttpClient();
            client.BaseAddress = new Uri(_BaseUrl);
            // get slider list
            var responseSlider =  client.GetAsync("/api/Slider/All");
            var resultSliderAPI = await responseSlider.Result.Content.ReadAsStringAsync(); 
            var resultSlider = JsonConvert.DeserializeObject<ResponseModel>(resultSliderAPI);
            
            var sliderList = JsonConvert.DeserializeObject<List<SliderModel>>(resultSlider.Data.ToString());

            // get reivew list
            var responseReview = client.GetAsync("/api/Review/All");
            var resultReviewAPI = await responseReview.Result.Content.ReadAsStringAsync();
            var resultReview = JsonConvert.DeserializeObject<ResponseModel>(resultReviewAPI);
            var reviewList = JsonConvert.DeserializeObject<List<ReviewModel>>(resultReview.Data.ToString());

            // send data to view
            ViewBag.reviewList = reviewList.Take(4);
            return View(sliderList);
        }

        public async Task<IActionResult> ServiceDetail(int type)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_BaseUrl);
            // get slider list
            var responseService = client.GetAsync($"/api/Option/Type/{type}");
            var resultServiceAPI = await responseService.Result.Content.ReadAsStringAsync();
            var resultService = JsonConvert.DeserializeObject<ResponseModel>(resultServiceAPI);

            var serviceList = JsonConvert.DeserializeObject<List<OptionModel>>(resultService.Data.ToString());

            ViewBag.typeId = type;
            return View(serviceList);
        }

        public IActionResult Review()
        {
            return View();
        }












        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}