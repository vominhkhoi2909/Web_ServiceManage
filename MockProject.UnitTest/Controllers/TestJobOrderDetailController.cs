using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.Controllers;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;
using MockProject.UnitTest.MockData;
using Moq;

namespace MockProject.UnitTest.Controllers
{
    public class TestJobOrderDetailController
    {
        #region Test lấy ds.
        [Fact]
        public async Task GetJOD_ShouldReturnSuccess()
        {
            //Arrange
            var JOD = new Mock<IJobOrderDetailRepository>();
            int id = 44;
            JOD.Setup(m => m.GetJOD(id)).ReturnsAsync(JobOrderDetailMockData.GetJobOrderDetails());
            var sut = new JobOrderDetailController(JOD.Object);

            //Action
            var res = await sut.All(id);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetJOD_ShouldReturnFail()
        {
            //Arrange
            var JOD = new Mock<IJobOrderDetailRepository>();
            int id = 0;
            JOD.Setup(m => m.GetJOD(id)).ReturnsAsync(JobOrderDetailMockData.EmptyJobOrderDetail());
            var sut = new JobOrderDetailController(JOD.Object);

            //Action
            var res = await sut.All(id);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test lấy ds theo id service.
        [Fact]
        public async Task GetJOD_IdService_ShouldReturnSuccess()
        {
            //Arrange
            var JOD = new Mock<IJobOrderDetailRepository>();
            int idService = 13;
            int id =44;

            JOD.Setup(m => m.GetJODService(id, idService)).ReturnsAsync(JobOrderDetailMockData.GetJobOrderDetails());
            var sut = new JobOrderDetailController(JOD.Object);

            //Action
            var res = await sut.GetService(id, idService);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetJOD_IdService_ShouldReturnFail()
        {
            //Arrange
            var JOD = new Mock<IJobOrderDetailRepository>();
            int idService = 0;
            int id = 44;


            JOD.Setup(m => m.GetJODService(id, idService)).ReturnsAsync(JobOrderDetailMockData.EmptyJobOrderDetail());
            var sut = new JobOrderDetailController(JOD.Object);

            //Action
            var res = await sut.GetService(id, idService);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test lấy ds theo id option.
        [Fact]
        public async Task GetJOD_IdOption_ShouldReturnSuccess()
        {
            //Arrange
            var JOD = new Mock<IJobOrderDetailRepository>();
            int idOption = 10;
            int id = 44;

            JOD.Setup(m => m.GetJODOption(id, idOption)).ReturnsAsync(JobOrderDetailMockData.GetJobOrderDetails());
            var sut = new JobOrderDetailController(JOD.Object);

            //Action
            var res = await sut.GetOption(id, idOption);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetJOD_IdOption_ShouldReturnFail()
        {
            //Arrange
            var JOD = new Mock<IJobOrderDetailRepository>();
            int idOption = 0;
            int id = 44;


            JOD.Setup(m => m.GetJODOption(id, idOption)).ReturnsAsync(JobOrderDetailMockData.EmptyJobOrderDetail());
            var sut = new JobOrderDetailController(JOD.Object);

            //Action
            var res = await sut.GetOption(id, idOption);

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
            var JOD = new Mock<IJobOrderDetailRepository>();
            DTOJobOrderDetail jod = new DTOJobOrderDetail();
            JOD.Setup(m => m.AddJOD(jod)).Returns(1);
            var sut = new JobOrderDetailController(JOD.Object);

            //Action
            var res = await sut.Add(jod);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        /*[Fact]
        public async Task Add_ShouldReturnFail()
        {   
            //Arrange
            var JOD = new Mock<JobOrderDetailController>();
            DTOJOD JOD = new DTOJOD();
            JOD.Key = "Address";
            JOD.Value = "341 Wilson Street, Almonte, Ont K0A 1A0";
            JOD.Setup(m => m.AddJOD(JOD)).Returns(-1);
            var sut = new JobOrderDetailController(JOD.Object);

            //Action
            var res = await sut.Add(JOD);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }*/
        #endregion
    }
}
