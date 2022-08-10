using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface INotificationRepository
    {
        Task<List<DTOGetNotification>> GetNotification();

        Task<List<DTOGetNotification>> GetTrash();

        Task<List<DTOGetNotification>> GetSearch(string key);

        Task<List<DTOGetNotification>> GetNotificationType(int type);

        Task<Notification> GetNotification(int id);

        Task<List<DTOGetNotification>> GetNotificationByUserId(string id);

        Task<List<DTOGetNotification>> GetNotificationByAdminUserId(int id);

        int AddNotification(DTONotification value);

        int UpdateNotification(int id, DTONotification value);

        Task<int> ReadNotification(int id);
        Task<int> ReadAllNotification(int id);
    }
}
