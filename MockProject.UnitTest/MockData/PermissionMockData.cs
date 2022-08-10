using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.UnitTest.MockData
{
    public class PermissionMockData
    {
        public static List<Permission> GetPermissions()
        {
            return new List<Permission>
            {
                new Permission
                {
                    PermissionId = 1,
                    Title = "Staff Job Order",
                    Link = "Admin/StaffJobOrder",
                    Status = 1,
                },
                new Permission
                {
                    PermissionId = 2,
                    Title = "Config Management",
                    Link = "Admin/Config",
                    Status = 1,
                },
                new Permission
                {
                    PermissionId = 3,
                    Title = "Slider Management",
                    Link = "Admin/Slider",
                    Status = 1,
                },
            };
        }

        public static List<Permission> EmptyPermission()
        {
            return new List<Permission>();
        }
    }
}
