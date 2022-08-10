using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IPromotionRepository
    {
        Task<List<DTOGetPromotion>> GetPromotion();

        Task<List<DTOGetPromotion>> GetTrash();

        Task<List<DTOGetPromotion>> GetSearch(string key);

        Task<List<DTOGetPromotion>> GetPromotionService(int service);

        Task<Promotion> GetPromotion(int id);

        int AddPromotion(DTOPromotion value);

        int UpdatePromotion(int id, DTOPromotion value);

        int DeletePromotion(int id);
    }
}
