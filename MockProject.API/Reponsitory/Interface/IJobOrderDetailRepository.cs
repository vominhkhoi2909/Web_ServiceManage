using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IJobOrderDetailRepository
    {
        Task<List<JobOrderDetail>> GetJOD(int idJO);

        Task<List<JobOrderDetail>> GetJODService(int idJO, int idService);

        Task<List<JobOrderDetail>> GetJODOption(int idJO, int idOption);

        int AddJOD(DTOJobOrderDetail value);
    }
}
