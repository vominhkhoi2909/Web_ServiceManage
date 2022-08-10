using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRole();

        Task<List<Role>> GetTrash();

        Task<List<Role>> GetSearch(string key);

        Task<Role> GetRole(int id);

        int AddRole(DTORole value);

        int UpdateRole(int id, DTORole value);

        int DeleteRole(int id);
    }
}
