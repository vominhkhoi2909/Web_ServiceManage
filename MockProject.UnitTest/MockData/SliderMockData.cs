using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.UnitTest.MockData
{
    public class SliderMockData
    {
        public static List<Slider> GetSliders()
        {
            return new List<Slider>
            {
                new Slider
                {
                    SliderId = 1,
                    Title = "We Provide  Professional Services",
                    Description = "Adipiscing the dolor sit amet, consectetur adipiscing elit. Eu sit pharetra aorem et faucibus quis enim dolor.",
                    Status = 1
                },
                new Slider
                {
                    SliderId = 2,
                    Title = "Best Professional Services",
                    Description = "Pharetra ipsum dolor sit amet, consectetur adipiscing elit. Eu sit pharetra iorem et faucibus quis enim dolor.",
                    Status = 1
                },
                new Slider
                {
                    SliderId = 3,
                    Title = "We Provide Professional Services",
                    Description = "Adipiscing the dolor sit amet, consectetur adipiscing elit. Eu sit pharetra aorem et faucibus quis enim dolor.",
                    Status = 1
                },
            };
        }

        public static List<Slider> EmptySlider()
        {
            return new List<Slider>();
        }
    }
}
