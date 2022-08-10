using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface ILogRepository
    {
        Task<List<Log>> GetLog();

        Task<List<Log>> GetTrash();

        Task<List<Log>> GetLogType(int type);

        Task<Log> GetLog(int id);

        int AddLog(DTOLog value);

        int UpdateLog(int id, DTOLog value);

        int DeleteLog(int id);
    }
}
