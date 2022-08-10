using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface ICommentRepository
    {
        Task<List<DTOGetComment>> GetComment();

        Task<List<DTOGetComment>> GetTrash();

        Task<List<DTOGetComment>> GetSearch(string key);

        Task<List<DTOGetComment>> GetCommentNotifi(int noti);

        Task<Comment> GetComment(int id);

        int AddComment(DTOComment value);

        int UpdateComment(int id, DTOComment value);

        int DeleteComment(int id);
    }
}
