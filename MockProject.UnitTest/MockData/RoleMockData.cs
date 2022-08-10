using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.UnitTest.MockData
{
    public class RoleMockData
    {
        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    RoleId = 1,
                    Name = "Admin",
                    Status = 1,
                },
                new Role
                {
                    RoleId = 2,
                    Name = "Staff",
                    Status = 1,
                },
                new Role
                {
                    RoleId = 3,
                    Name = "Guest",
                    Status = 1,
                },
            };
        }

        public static List<Role> EmptyRole()
        {
            return new List<Role>();
        }
    }
}
