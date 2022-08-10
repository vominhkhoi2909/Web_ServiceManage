using MockProject.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockProject.UnitTest.MockData
{
    public static class AccountMockData
    {
        // Register model
        public static RegisterViewModel ReturnRegisterModel()
        {
            return new RegisterViewModel()
            {
                Email = "abc@email.com",
                Password = "R@nd0mPass",
                ConfirmPassword = "R@nd0mPass"
            };
        }
        public static RegisterViewModel ReturnFailRegisterModel()
        {
            return new RegisterViewModel();
        }

        // Login model
        public static LoginViewModel ReturnLoginModel()
        {
            return new LoginViewModel()
            {
                Email = "abc@email.com",
                Password = "R@nd0mPass"
            };
        }
        public static LoginViewModel ReturnFailLoginModel()
        {
            return new LoginViewModel();
        }

        // Customer user info model
        public static UserInfoModel ReturnUserInfo()
        {
            return new UserInfoModel()
            {
                UserId = "2d2b3f87-5620-4bf5-a549-cd9278088ccc",
                Name = "Hoang Long",
                Address = "Thu Duc",
                Phone = "0987676545",
                Email = "long02@example.com",
                Avatar = "default.png",
                Status = 1
            };
        }

        // Customer user info model
        public static UpdateInfoModel ReturnUpdateUserInfo()
        {
            return new UpdateInfoModel()
            {
                UserId = "311b3baf-431a-49dc-8c8e-f2b40f3fb30f",
                Name = "Hoang Long Nguyen",
                Address = "District 9",
                Phone = "0876328312"
            };
        }
    }
}
