using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.Controllers;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;
using MockProject.UnitTest.MockData;
using Moq;

namespace MockProject.UnitTest.Controllers
{
    public class TestAccountController
    {
        #region Test register account
        [Fact]
        public async Task Register_WithData_ShouldSuccess()
        {
            // Arrange
            var repos = new Mock<IAccountRepository>();
            var registerModel = AccountMockData.ReturnRegisterModel();
            repos.Setup(x => x.RegisterUser(registerModel))
                .ReturnsAsync(new ResponseModel()
                {
                    Success = true,
                    Message = "Register success"
                });
            var controller = new AccountController(repos.Object);

            // Act
            var result = await controller.Register(registerModel);

            // Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task Register_WithoutData_ShouldFailed()
        {
            // Arrange
            var repos = new Mock<IAccountRepository>();
            var registerModel = AccountMockData.ReturnFailRegisterModel();
            repos.Setup(x => x.RegisterUser(registerModel))
                .ReturnsAsync(new ResponseModel()
                {
                    Success = false,
                    Message = "Register failed"
                });
            var controller = new AccountController(repos.Object);

            // Act
            var result = await controller.Register(registerModel);

            // Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test login account
        [Fact]
        public async Task Login_WithData_ShouldSuccess()
        {
            // Arrange
            var repos = new Mock<IAccountRepository>();
            var loginModel = AccountMockData.ReturnLoginModel();
            repos.Setup(x => x.LoginUser(loginModel))
                .ReturnsAsync(new ResponseModel()
                {
                    Success = true,
                    Message = "Login success"
                });
            var controller = new AccountController(repos.Object);

            // Act
            var result = await controller.Login(loginModel);

            // Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task Login_WithoutData_ShouldFailed()
        {
            // Arrange
            var repos = new Mock<IAccountRepository>();
            var loginModel = AccountMockData.ReturnFailLoginModel();
            repos.Setup(x => x.LoginUser(loginModel))
                .ReturnsAsync(new ResponseModel()
                {
                    Success = false,
                    Message = "Login failed"
                });
            var controller = new AccountController(repos.Object);

            // Act
            var result = await controller.Login(loginModel);

            // Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test get user info
        [Fact]
        public async Task GetInfoById_WithUserId_ShouldSuccess()
        {
            // Arrange
            var repos = new Mock<IAccountRepository>();
            var userId = "2d2b3f87-5620-4bf5-a549-cd9278088ccc";
            var userInfoModel = AccountMockData.ReturnUserInfo();
            repos.Setup(x => x.GetInfo(userId))
                .ReturnsAsync(new ResponseModel()
                {
                    Success = true,
                    Message = "Get user info success",
                    Data = userInfoModel
                });
            var controller = new AccountController(repos.Object);

            // Act
            var result = await controller.GetInfoById(userId);

            // Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetInfoById_WithEmptyUserId_ShouldFailed()
        {
            // Arrange
            var repos = new Mock<IAccountRepository>();
            var userId = "";
            repos.Setup(x => x.GetInfo(userId))
                .ReturnsAsync(new ResponseModel()
                {
                    Success = false,
                    Message = "User invalid"
                });
            var controller = new AccountController(repos.Object);

            // Act
            var result = await controller.GetInfoById(userId);

            // Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test forgot password
        [Fact]
        public async Task ForgotPassword_WithEmail_ShouldSuccess()
        {
            // Arrange
            var repos = new Mock<IAccountRepository>();
            var email = "abc@email.com";
            repos.Setup(x => x.ForgetPassword(email))
                .ReturnsAsync(new ResponseModel()
                {
                    Success = true,
                    Message = "Reset password link has been sent to email. Please check your email to continue"
                });
            var controller = new AccountController(repos.Object);

            // Act
            var result = await controller.ForgetPassword(email);

            // Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task ForgotPassword_WithInvalidEmail_ShouldFailed()
        {
            // Arrange
            var repos = new Mock<IAccountRepository>();
            var email = "abcemail.com";
            repos.Setup(x => x.ForgetPassword(email))
                .ReturnsAsync(new ResponseModel()
                {
                    Success = false,
                    Message = "Invalid email"
                });
            var controller = new AccountController(repos.Object);

            // Act
            var result = await controller.ForgetPassword(email);

            // Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test resend confirm email
        [Fact]
        public async Task ResendConfirmEmail_WithEmail_ShouldSuccess()
        {
            // Arrange
            var repos = new Mock<IAccountRepository>();
            var email = "abc@email.com";
            repos.Setup(x => x.ResendConfirmEmail(email))
                .ReturnsAsync(new ResponseModel()
                {
                    Success = true,
                    Message = "Confirm email sent. Please check your email again"
                });
            var controller = new AccountController(repos.Object);

            // Act
            var result = await controller.ResendConfirmEmail(email);

            // Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task ResendConfirmEmail_WithoutEmail_ShouldFailed()
        {
            // Arrange
            var repos = new Mock<IAccountRepository>();
            var email = "";
            repos.Setup(x => x.ResendConfirmEmail(email))
                .ReturnsAsync(new ResponseModel()
                {
                    Success = false,
                    Message = "Email is empty"
                });
            var controller = new AccountController(repos.Object);

            // Act
            var result = await controller.ResendConfirmEmail(email);

            // Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task ResendConfirmEmail_WithInvalidEmail_ShouldFailed()
        {
            // Arrange
            var repos = new Mock<IAccountRepository>();
            var email = "abcemail.com";
            repos.Setup(x => x.ResendConfirmEmail(email))
                .ReturnsAsync(new ResponseModel()
                {
                    Success = false,
                    Message = "Invalid email"
                });
            var controller = new AccountController(repos.Object);

            // Act
            var result = await controller.ResendConfirmEmail(email);

            // Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion
    }
}