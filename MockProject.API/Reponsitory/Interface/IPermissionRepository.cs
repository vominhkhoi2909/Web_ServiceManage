using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetPermission();

        Task<List<Permission>> GetTrash();

        Task<List<Permission>> GetSearch(string key);

        Task<Permission> GetPermission(int id);

        int AddPermission(DTOPermission value);

        int UpdatePermission(int id, DTOPermission value);

        int DeletePermission(int id);
    }
}
