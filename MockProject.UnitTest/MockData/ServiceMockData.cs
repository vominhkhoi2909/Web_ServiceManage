using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.UnitTest.MockData
{
    public class ServiceMockData
    {
        public static List<Service> GetServices()
        {
            return new List<Service>
            {
                new Service
                {
                    ServiceId = 1,
                    Name = "General Aircon Services",
                    Type = 1,
                    Price = 22,
                    Duration = 3,
                    Status = 1,
                },
                new Service
                {
                    ServiceId = 7,
                    Name = "Mattress Cleaning",
                    Type = 2,
                    Price = 15,
                    Duration = 1,
                    Status = 1,
                },
                new Service
                {
                    ServiceId = 13,
                    Name = "Carpet Cleaning",
                    Type = 3,
                    Price = 20,
                    Duration = 1/2,
                    Status = 1,
                },
            };
        }

        public static List<Service> EmptyService()
        {
            return new List<Service>();
        }
    }
}
