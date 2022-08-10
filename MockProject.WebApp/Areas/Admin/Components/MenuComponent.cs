using Microsoft.AspNetCore.Mvc;
using MockProject.WebApp.ModelAPI;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MockProject.WebApp.Areas.Admin.Components
{
    public class MenuComponent : ViewComponent
    {
        private readonly IConfiguration _configuration;
        private readonly string _BaseUrl;
        public MenuComponent(IConfiguration configuration)
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

            var responsePer = client.GetAsync("/api/permission/all");
            var resultReponsePer = await responsePer.Result.Content.ReadAsStringAsync();
            var resultModelPer = JsonConvert.DeserializeObject<ResponseModel>(resultReponsePer);
            var permission = JsonConvert.DeserializeObject<List<PermissionModel>>(resultModelPer.Data.ToString());
            if (resultModel?.Success == true)
            {
                var user = JsonConvert.DeserializeObject<AdminModel>(resultModel.Data.ToString());

                var arr = new List<string>();
                if(user.Permission != null)
                {
                    arr = user.Permission.Split(",").ToList();
                }

                ViewBag.permission = permission.Where(x => arr.Contains(x.PermissionId.ToString())).ToList();  
                    
                return View("_MenuPartial", user);
            }
            return null;
        }
    }
}
