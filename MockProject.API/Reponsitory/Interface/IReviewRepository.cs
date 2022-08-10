using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IReviewRepository
    {
        Task<List<DTOGetReview>> GetReview();

        Task<List<DTOGetReview>> GetTrash();

        Task<Review> GetReview(int id);

        int AddReview(DTOReview value);

        int UpdateReview(int id, DTOReview value);

        int DeleteReview(int id);
    }
}
