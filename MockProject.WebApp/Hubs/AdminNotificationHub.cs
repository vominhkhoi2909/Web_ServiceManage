using Microsoft.AspNetCore.SignalR;
using MockProject.WebApp.ModelAPI;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Net.Http.Headers;

namespace MockProject.WebApp.Hubs
{
    public class AdminNotificationHub : Hub
    {
        private IConfiguration _configuration;
        private IHttpContextAccessor _accessor;
        public AdminNotificationHub(IConfiguration configuration, IHttpContextAccessor accessor)
        {
            //_repos = repos;
            //_userManager = userManager;
            _configuration = configuration;
            _accessor = accessor;
        }
        #region Get notification
        public async Task GetAdminNotification()
        {
            // Check if user token exist
            var userToken = _accessor.HttpContext.Request.Cookies["UserAdminLogin"];
            if (userToken == null) return;
            // Admin notification
            string? userId = await ReturnUserId(userToken);
            // get notification list
            var _BaseUrl = _configuration["BASE_API_HOST"];
            var client = new HttpClient();
            client.BaseAddress = new Uri(_BaseUrl);
            var responseNotification = client.GetAsync("/api/notification/allbyadminid?id=" + userId);
            var resultNotificationAPI = await responseNotification.Result.Content.ReadAsStringAsync();
            var resultNotification = JsonConvert.DeserializeObject<ResponseModel>(resultNotificationAPI);
            if (resultNotification?.Success ?? false)
            {
                var notis = JsonConvert.DeserializeObject<List<NotificationModel>>(resultNotification.Data.ToString());
                // Check if user connection exist
                UserHubModel receiver;
                if (Users.TryGetValue(userId.ToString(), out receiver))
                {
                    var cid = receiver.ConnectionIds.FirstOrDefault();
                    await Clients.Client(cid).SendAsync("YourNotification", notis);
                }
            }
        }
        #endregion

        #region Send notification
        public async Task SendAdminNotification(int sendTo)
        {
            // Send Admin notification
            // get notification list
            var _BaseUrl = _configuration["BASE_API_HOST"];
            var client = new HttpClient();
            client.BaseAddress = new Uri(_BaseUrl);
            var responseNotification = client.GetAsync("/api/notification/allbyadminid?id=" + sendTo);
            var resultNotificationAPI = await responseNotification.Result.Content.ReadAsStringAsync();
            var resultNotification = JsonConvert.DeserializeObject<ResponseModel>(resultNotificationAPI);
            if (resultNotification?.Success ?? false)
            {
                var notis = JsonConvert.DeserializeObject<List<NotificationModel>>(resultNotification.Data.ToString());
                // Check if user connection exist
                UserHubModel receiver;
                if (Users.TryGetValue(sendTo.ToString(), out receiver))
                {
                    var cid = receiver.ConnectionIds.FirstOrDefault();
                    await Clients.Client(cid).SendAsync("YourNotification", notis);
                }
            }
        }
        #endregion

        #region Connect / Disconnect
        // Init
        private static readonly ConcurrentDictionary<string, UserHubModel> Users = new ConcurrentDictionary<string, UserHubModel>();
        // -----------------------------------------------------------------------------------
        public override async Task OnConnectedAsync()
        {
            // Check if user token exist and valid
            var userToken = _accessor.HttpContext.Request.Cookies["UserAdminLogin"];
            if (userToken == null) return;
            string? userID = await ReturnUserId(userToken);
            if (userID == null) return;
            string connectionId = Context.ConnectionId;

            var user = Users.GetOrAdd(userID, _ => new UserHubModel
            {
                userId = userID,
                ConnectionIds = new HashSet<string>()
            });

            lock (user.ConnectionIds)
            {
                user.ConnectionIds.Add(connectionId);
                if (user.ConnectionIds.Count == 1)
                {
                    Clients.Others.SendAsync("userConnected", userID);
                }
            }
        }

        public override async Task OnDisconnectedAsync(Exception? ex)
        {
            // Check if user token exist
            var userToken = _accessor.HttpContext.Request.Cookies["UserAdminLogin"];
            if (userToken == null) return;
            string? userID = await ReturnUserId(userToken);
            string connectionId = Context.ConnectionId;

            UserHubModel user;
            Users.TryGetValue(userID, out user);

            if (user != null)
            {
                lock (user.ConnectionIds)
                {
                    user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));
                    if (!user.ConnectionIds.Any())
                    {
                        UserHubModel removedUser;
                        Users.TryRemove(userID, out removedUser);
                        Clients.Others.SendAsync("userDisconnected", userID);
                    }
                }
            }
        }

        #endregion

        private async Task<string?> ReturnUserId(string userToken)
        {
            var _BaseUrl = _configuration["BASE_API_HOST"];
            var client = new HttpClient();
            client.BaseAddress = new Uri(_BaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);
            // get user information
            var response = client.GetAsync("/api/admin/getinfo");
            var resultReponse = await response.Result.Content.ReadAsStringAsync();
            var resultModel = JsonConvert.DeserializeObject<ResponseModel>(resultReponse);
            if (resultModel?.Success == true)
            {
                var user = JsonConvert.DeserializeObject<AdminModel>(resultModel.Data.ToString());
                return user?.UserId.ToString();
            }
            return null;
        }
    }
}
