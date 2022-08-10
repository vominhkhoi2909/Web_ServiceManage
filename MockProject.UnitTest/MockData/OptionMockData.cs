using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.UnitTest.MockData
{
    public class OptionMockData
    {
        public static List<Option> GetOptions()
        {
            return new List<Option>
            {
                new Option
                {
                    OptionId = 1,
                    Title = "HEATING AND AIR\nCONDITIONING REPAIR AND\nINSTALLATION COMPANY",
                    Type = 9,
                    Description = "Accumsan bibendum the sit amet, consectetur adipiscing elit.\nPellentesque accumsan bibendum bibendum diam et. Ac\nvulputate morbi egestas porta posuere curabitur.\nPellentesque accumsan bibendum bibendum diam et. \nAcvulputate morbi egestas porta posuere curabitur.",
                    Status = 1
                },
                new Option
                {
                    OptionId = 2,
                    Title = "Air Conditioner",
                    Type = 1,
                    Description = "Test 02",
                    Status = 1
                },
                new Option
                {
                    OptionId = 3,
                    Title = "",
                    Type = 2,
                    Description = "Test 03",
                    Status = 1
                },
            };
        }

        public static List<Option> EmptyOption()
        {
            return new List<Option>();
        }
    }
}
