using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IOptionRepository
    {
        Task<List<Option>> GetOption();

        Task<List<Option>> GetTrash();

        Task<List<Option>> GetSearch(string key);

        Task<List<Option>> GetOptionType(int type);

        Task<Option> GetOption(int id);

        int AddOption(DTOOption value);

        int UpdateOption(int id, DTOOption value);

        int DeleteOption(int id);
    }
}
