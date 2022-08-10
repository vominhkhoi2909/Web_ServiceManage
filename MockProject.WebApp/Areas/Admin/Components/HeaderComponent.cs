using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.ModelAPI;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MockProject.WebApp.Areas.Admin.Components
{
    public class HeaderComponent : ViewComponent
    {
        private readonly IConfiguration _configuration;
        private readonly string _BaseUrl;
        public HeaderComponent(IConfiguration configuration)
        {
            _configuration = configuration;
            _BaseUrl = _configuration["BASE_API_HOST"];
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string cookie = Request.Cookies["UserAdminLogin"];
            var client = new HttpClient();
            client.BaseAddress = new Uri(_BaseUrl);
            // get uesr info
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookie);
            var response = client.GetAsync("/api/admin/getinfo");
            var resultReponse = await response.Result.Content.ReadAsStringAsync();
            var resultModel = JsonConvert.DeserializeObject<ResponseModel>(resultReponse);
            if (resultModel.Success == true)
            {
                var user = JsonConvert.DeserializeObject<AdminModel>(resultModel.Data.ToString());
                return View("_HeaderComponent", user);
            }
            return null;
        }
    }
}
