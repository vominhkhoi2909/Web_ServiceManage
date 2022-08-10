using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.UnitTest.MockData
{
    public class NotificationMockData
    {
        public static List<DTOGetNotification> GetNotifications()
        {
            return new List<DTOGetNotification>
            {
                new DTOGetNotification
                {
                    NotifId = 2,
                    CreateAt= DateTime.Now,
                    Title="Job Order Assigned",
                    Type= 1,
                    SendTo="311b3baf-431a-49dc-8c8e-f2b40f3fb30f",
                    CreateBy=2,
                },
                new DTOGetNotification
                {
                    NotifId = 3,
                    CreateAt= DateTime.Now,
                    Title="Job Order Assigned",
                    Type= 1,
                    SendTo="311b3baf-431a-49dc-8c8e-f2b40f3fb30f",
                    CreateBy=2,
                },
                new DTOGetNotification
                {
                    NotifId = 28,
                    CreateAt= DateTime.Now,
                    Title="Job Order Assigned",
                    Type= 2,
                    SendTo="311b3baf-431a-49dc-8c8e-f2b40f3fb30f",
                    CreateBy=2,
                },
            };
        }

        public static List<DTOGetNotification> EmptyNotification()
        {
            return new List<DTOGetNotification>();
        }
    }
}
