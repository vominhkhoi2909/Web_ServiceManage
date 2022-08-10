using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface ISliderRepository
    {
        Task<List<Slider>> GetSlider();

        Task<List<Slider>> GetTrash();

        Task<List<Slider>> GetSearch(string key);

        Task<Slider> GetSlider(int id);

        int AddSlider(DTOSlider value);

        int UpdateSlider(int id, DTOSlider value);

        int DeleteSlider(int id);
    }
}
