using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetService();

        Task<List<Service>> GetTrash();

        Task<Service> GetService(int id);

        Task<List<Service>> GetServiceType(int type);
        Task<List<Service>> Search(string key);

        int AddService(DTOService value);

        int UpdateService(int id, DTOService value);

        int DeleteService(int id);
    }
}
