using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.Controllers;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;
using MockProject.UnitTest.MockData;
using Moq;

namespace MockProject.UnitTest.Controllers
{
    public class TestConfigController
    {
        #region Test lấy ds.
        [Fact]
        public async Task GetConfig_ShouldReturnSuccess()
        {
            //Arrange
            var Config = new Mock<IConfigRepository>();
            Config.Setup(m => m.GetConfig()).ReturnsAsync(ConfigMockData.GetConfigs());
            var sut = new ConfigController(Config.Object);

            //Action
            var res = await sut.All(null);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetConfig_ShouldReturnFail()
        {
            //Arrange
            var Config = new Mock<IConfigRepository>();
            Config.Setup(m => m.GetConfig()).ReturnsAsync(ConfigMockData.EmptyConfig());
            var sut = new ConfigController(Config.Object);

            //Action
            var res = await sut.All(null);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test lấy ds tìm kiếm.
        [Fact]
        public async Task GetConfig_KeySearch_ShouldReturnSuccess()
        {
            //Arrange
            var Config = new Mock<IConfigRepository>();
            Config.Setup(m => m.GetConfig()).ReturnsAsync(ConfigMockData.GetConfigs());
            var sut = new ConfigController(Config.Object);

            //Action
            var res = await sut.All("Phone");

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetConfig_KeySearch_ShouldReturnFail()
        {
            //Arrange
            var Config = new Mock<IConfigRepository>();
            Config.Setup(m => m.GetConfig()).ReturnsAsync(ConfigMockData.EmptyConfig());
            var sut = new ConfigController(Config.Object);

            //Action
            var res = await sut.All("Information");

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test lấy thông tin chi tiết.
        [Fact]
        public async Task Detail_ShouldReturnSuccess()
        {
            //Arrange
            var Config = new Mock<IConfigRepository>();
            var id = 1;
            Config.Setup(m => m.GetConfig(id)).ReturnsAsync(ConfigMockData.GetConfigs().FirstOrDefault);
            var sut = new ConfigController(Config.Object);

            //Action
            var res = await sut.Detail(id);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Detail_ShouldReturnFail()
        {
            //Arrange
            Config con = new Config();
            con = null;
            var config = new Mock<IConfigRepository>();
            int id = 0;
            config.Setup(m => m.GetConfig(id)).ReturnsAsync(con);
            var sut = new ConfigController(config.Object);

            //Action
            var res = await sut.Detail(id);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test thêm dữ liệu.
        [Fact]
        public async Task Add_ShouldReturnSuccess()
        {
            //Arrange
            var Config = new Mock<IConfigRepository>();
            DTOConfig config = new DTOConfig();
            config.Key = "ABC";
            config.Value = "XYZ";
            Config.Setup(m => m.AddConfig(config)).Returns(1);
            var sut = new ConfigController(Config.Object);

            //Action
            var res = await sut.Add(config);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        /*[Fact]
        public async Task Add_ShouldReturnFail()
        {   
            //Arrange
            var Config = new Mock<IConfigRepository>();
            DTOConfig config = new DTOConfig();
            config.Key = "Address";
            config.Value = "341 Wilson Street, Almonte, Ont K0A 1A0";
            Config.Setup(m => m.AddConfig(config)).Returns(-1);
            var sut = new ConfigController(Config.Object);

            //Action
            var res = await sut.Add(config);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }*/
        #endregion

        #region Test cập nhật dữ liệu.
        [Fact]
        public async Task Update_ShouldReturnSuccess()
        {
            //Arrange
            var Config = new Mock<IConfigRepository>();
            int id = 3;
            DTOConfig config = new DTOConfig();
            config.Key = "Address Test";
            config.Value = "341 Wilson Street, Almonte, Ont K0A 1A0";
            Config.Setup(m => m.UpdateConfig(id, config)).Returns(1);
            var sut = new ConfigController(Config.Object);

            //Action
            var res = await sut.Update(id, config);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Update_ShouldReturnFail()
        {   
            //Arrange
            var Config = new Mock<IConfigRepository>();
            int id = 0;
            DTOConfig config = new DTOConfig();
            config.Key = "Address Test";
            config.Value = "341 Wilson Street, Almonte, Ont K0A 1A0";
            Config.Setup(m => m.UpdateConfig(id, config)).Returns(0);
            var sut = new ConfigController(Config.Object);

            //Action
            var res = await sut.Update(id, config);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test xóa dữ liệu.
        [Fact]
        public async Task Delete_ShouldReturnSuccess()
        {
            //Arrange
            var Config = new Mock<IConfigRepository>();
            int id = 3;
            Config.Setup(m => m.DeleteConfig(id)).Returns(1);
            var sut = new ConfigController(Config.Object);

            //Action
            var res = await sut.Delete(id);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Delete_ShouldReturnFail()
        {
            //Arrange
            var Config = new Mock<IConfigRepository>();
            int id = 0;
            Config.Setup(m => m.DeleteConfig(id)).Returns(0);
            var sut = new ConfigController(Config.Object);

            //Action
            var res = await sut.Delete(id);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion
    }
}
