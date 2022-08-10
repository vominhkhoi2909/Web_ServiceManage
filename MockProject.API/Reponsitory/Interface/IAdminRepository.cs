using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.API.Reponsitory.Interface
{
    public interface IAdminRepository
    {
        Task<List<DTOGetAdmin>> GetAdmin();

        Task<List<DTOGetAdmin>> GetTrash();

        Task<List<DTOGetAdmin>> GetAdminRole(int role);

        Task<List<DTOGetAdminSale>> GetStaffSale(DateTime? start, DateTime? end);

        Task<DTOGetDashboard> GetDashboard(int? year);

        Task<DTOGetAdmin?> GetAdmin(int id);

        Task<ResponseModel> Login(AdminLoginViewModel model);

        Task<int> ChangePassword(int userId, string oldPassword, string newPasssword);

        Task<ResponseModel> ForgotPassword(string email);

        Task<ResponseModel> ResetPassword(AdminResetPasswordModel model);

        Task<int> ChangeStatus(int userId, int roleId);

        Task<int> ChangePermission(int userId, string permission);

        Task<int> UpdateInfo(int id, AdminUpdateInfoModel info);

        Task<int> AddAdmin(DTOAdmin value);

        Task<int> UpdateAdmin(int id, DTOAdminInfo value);

        Task<int> DeleteAdmin(int id);
    }
}
