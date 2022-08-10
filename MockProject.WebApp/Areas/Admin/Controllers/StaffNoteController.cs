using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MockProject.WebApp.Hubs;
using MockProject.WebApp.ModelAPI;
using Newtonsoft.Json;
using System.Text;

namespace MockProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaffNoteController : Controller
    {
        private IHubContext<AdminNotificationHub> _hubContext;
        private readonly string _BaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _accessor;
        public StaffNoteController(IHubContext<AdminNotificationHub> hubContext, IConfiguration configuration, IHttpContextAccessor accessor)
        {
            _hubContext = hubContext;
            _configuration = configuration;
            _BaseUrl = _configuration["BASE_API_HOST"];
            _accessor = accessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNoteNotification([FromBody] NoteModel model)
        {
            var notis = new NotificationModel()
            {
                Title = model.Title,
                Description = model.Description,
                Image = null,
                Type = 1,
                SendTo = "0",
                CreateBy = model.CreateBy
            };
            var client = new HttpClient();
            client.BaseAddress = new Uri(_BaseUrl);
            // add notification list
            // Serialize data to json
            var json = JsonConvert.SerializeObject(notis);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            // Call API to add notification
            var responseNotification = client.PostAsync("/api/Notification/Add", data);
            var resultNotificationAPI = await responseNotification.Result.Content.ReadAsStringAsync();
            var resultNotification = JsonConvert.DeserializeObject<ResponseModel>(resultNotificationAPI);
            if (resultNotification?.Success ?? false)
            {
                await _hubContext.Clients.All.SendAsync("YourNotification","success");
            }
            return RedirectToAction("Index");
            //var sliderList = JsonConvert.DeserializeObject<List<SliderModel>>(resultNotification.Data.ToString());

        }
    }
}
