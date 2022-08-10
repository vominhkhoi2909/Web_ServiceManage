using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.UnitTest.MockData
{
    public class JobOrderMockData
    {
        public static List<DTOGetJobOrder> GetJobOrders()
        {
            return new List<DTOGetJobOrder>
            {
                new DTOGetJobOrder
                {
                    JOId = 27,
                    Duration = 5/2,
                    StartAt = new DateTime(2022, 02, 03, 15, 23, 00),
                    Address = "America, Inc.5454 I 55 NorthJackson, Mississippi 39211",
                    Description = "Please on time",
                    State = 4,
                    CustomerId = "2d2b3f87-5620-4bf5-a549-cd9278088ccc",
                    StaffId = 30,
                },
                new DTOGetJobOrder
                {
                    JOId = 31,
                    Duration = 5/2,
                    StartAt = new DateTime(2022, 02, 05, 15, 47, 00),
                    Address = "America, Inc.5454 I 55 NorthJackson, Mississippi 39211",
                    Description = "",
                    State = 4,
                    CustomerId = "311b3baf-431a-49dc-8c8e-f2b40f3fb30f",
                    StaffId = 34,
                },
                new DTOGetJobOrder
                {
                    JOId = 22,
                    Duration = 3/2,
                    StartAt = new DateTime(2022,02,08,15,49,00),
                    Address = "America, Inc.5454 I 55 NorthJackson, Mississippi 39211",
                    Description = "",
                    State = 3,
                    CustomerId = "311b3baf-431a-49dc-8c8e-f2b40f3fb30f",
                    StaffId = 33,
                },
            };
        }

        public static List<DTOGetJobOrder> EmptyJobOrder()
        {
            return new List<DTOGetJobOrder>();
        }
    }
}
