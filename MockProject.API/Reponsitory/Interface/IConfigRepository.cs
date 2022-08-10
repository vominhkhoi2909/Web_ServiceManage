using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IConfigRepository
    {
        Task<List<Config>> GetConfig();

        Task<List<Config>> GetTrash();

        Task<List<Config>> GetSearch(string key);

        Task<Config> GetConfig(int id);

        int AddConfig(DTOConfig value);

        int UpdateConfig(int id, DTOConfig value);

        int DeleteConfig(int id);
    }
}
