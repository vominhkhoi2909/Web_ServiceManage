using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IVanRepository
    {
        Task<List<Van>> GetVan();

        Task<List<Van>> GetTrash();

        Task<Van> GetVan(int id);
        Task<List<Van>> Search(string key);

        int AddVan(DTOVan value);

        int UpdateVan(int id, DTOVan value);

        int DeleteVan(int id);
    }
}
