using MockProject.API.DTO;

namespace MockProject.API.Reponsitory.Interface
{
    public interface ICustomerRepository
    {
        Task<ResponseModel> Get(string userId);
        Task<ResponseModel> GetAll(string? searchString);
        Task<ResponseModel> Add(AddCustomerModel model);
        Task<ResponseModel> Update(UpdateInfoModel model);
        Task<ResponseModel> ChangeStatus(string userId, bool isActive);
    }
}
