using MockProject.API.DTO;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IAccountRepository
    {
        Task<ResponseModel> RegisterUser(RegisterViewModel model);
        Task<ResponseModel> LoginUser(LoginViewModel model);
        Task<ResponseModel> LoginGoogle(string token);
        Task<ResponseModel> ConfirmEmail(string userId, string token);
        Task<ResponseModel> ResendConfirmEmail(string email);
        Task<ResponseModel> ForgetPassword(string email);
        Task<ResponseModel> ResetPassword(ResetPasswordModel model);
        Task<ResponseModel> ChangePassword(string userId, ChangePasswordModel model);
        Task<ResponseModel> GetInfo(string userId);
        Task<ResponseModel> UpdateInfo(string userId, UpdateInfoModel model);
        Task<ResponseModel> ChangeAvatar(string userId, string fileName);
        Task<ResponseModel> ChangeStatus(string userId, bool isActive);
    }
}
