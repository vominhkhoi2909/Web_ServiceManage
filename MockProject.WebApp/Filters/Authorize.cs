

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MockProject.WebApp.ModelAPI;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MockProject.WebApp.Filters
{

    public class Authorize : ActionFilterAttribute
    {
        public string RoleName { get; set; }
        public int CPermission { get; set; }


        // CPermission = ControllerPerrmission
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string cookie = context.HttpContext.Request.Cookies["UserAdminLogin"];
            if (string.IsNullOrEmpty(cookie))
            {
                context.Result = new RedirectToRouteResult(
                new RouteValueDictionary {
                    { "Controller", "Login" },
                    { "Action", "Index" }
                });
            }
            else
            {
                // Get Configuration
                var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
                var connString = configuration["BASE_API_HOST"];

                // Get User Info
                var client = new HttpClient();
                client.BaseAddress = new Uri(connString);
                // get uesr info
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cookie);
                var response = client.GetAsync("/api/admin/getinfo");
                var resultReponse = await response.Result.Content.ReadAsStringAsync();
                var resultModel = JsonConvert.DeserializeObject<ResponseModel>(resultReponse);
                if (resultModel?.Success == true)
                {
                    var user = JsonConvert.DeserializeObject<AdminModel>(resultModel.Data.ToString());
                    // Kiểm tra Role
                    if(user?.Role_Name == RoleName)
                    {
                        //base.OnActionExecuting(context); MVC
                        //kiểm tra Permission
                        if (RoleName != "Admin")
                        {
                            var permiss = user?.Permission?.Split(",");
                            if (permiss != null && permiss.Contains(CPermission.ToString()))
                            {
                                await next();
                            }
                            else
                            {
                                context.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary {
                                { "Controller", "Admin" },
                                { "Action", "Forbidden" }
                                   });
                            }
                        }
                        else
                        {
                            await next();// Core
                        }    
                    }    
                    else
                    {
                        if(user?.Role_Name == "Admin")
                        {
                            await next();// Core
                        }  
                        else
                        {
                            context.Result = new RedirectToRouteResult(
                          new RouteValueDictionary {
                                { "Controller", "Admin" },
                                { "Action", "Forbidden" }
                          });
                        }    
                    }
                }
                else
                {
                    context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "Controller", "Login" },
                        { "Action", "Index" }
                    });
                }
            }
        }
    }
}
