using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.UnitTest.MockData
{
    public class ConfigMockData
    {
        public static List<Config> GetConfigs()
        {
            return new List<Config>
            {
                new Config
                {
                    ConfigId = 1,
                    Key = "Address",
                    Value = "341 Wilson Street, Almonte, Ont K0A 1A0",
                    Status = 1
                },
                new Config
                {
                    ConfigId = 2,
                    Key = "Phone",
                    Value = "613-257-3396",
                    Status = 1
                },
                new Config
                {
                    ConfigId = 3,
                    Key = "Mail",
                    Value = "info@info9000.ca",
                    Status = 1
                },
            };
        }

        public static List<Config> EmptyConfig()
        {
            return new List<Config>();
        }
    }
}
