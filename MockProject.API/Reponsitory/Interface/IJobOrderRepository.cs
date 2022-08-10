using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IJobOrderRepository
    {
        Task<List<DTOGetJobOrder>> GetJobOrder();

        Task<List<DTOGetJobOrder>> GetTrash();

        Task<List<DTOGetJobOrder>> GetJobOrder(string id);

        Task<List<DTOGetJobOrder>> GetSearch(string key);

        Task<DTOGetJobOrder> GetJobOrders(int id);

        int AddJobOrder(DTOJobOrder value, string customerId);

        int UpdateJobOrder(int id, DTOJobOrder value, int? staffId);

        int AssignJobOrder(int id, int staffId);

        int Cancel(int id);

        int Confirm(int id);

        int Checkout(int id);

        int Checkin(int id);

        int Postpone(int id, DateTime date);

        int DeleteJobOrder(int id);
    }
}
