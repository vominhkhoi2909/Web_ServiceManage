using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.Controllers;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;
using MockProject.UnitTest.MockData;
using Moq;

namespace MockProject.UnitTest.Controllers
{
    public class TestJobOrderController
    {
        #region Test lấy ds.
        [Fact]
        public async Task GetJobOrder_ShouldReturnSuccess()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            int? status = null;
            JobOrder.Setup(m => m.GetJobOrder()).ReturnsAsync(JobOrderMockData.GetJobOrders());
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.All(status);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetJobOrder_ShouldReturnFail()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            int? status = null;
            JobOrder.Setup(m => m.GetJobOrder()).ReturnsAsync(JobOrderMockData.EmptyJobOrder());
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.All(status);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test lấy ds theo id state.
        [Fact]
        public async Task GetJobOrder_IdState_ShouldReturnSuccess()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            int state = 4;

            JobOrder.Setup(m => m.GetJobOrder()).ReturnsAsync(JobOrderMockData.GetJobOrders());
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.All(state);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetJobOrder_IdService_ShouldReturnFail()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            int state = 4;

            JobOrder.Setup(m => m.GetJobOrder()).ReturnsAsync(JobOrderMockData.EmptyJobOrder());
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.All(state);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test lấy ds theo id customer.
        [Fact]
        public async Task GetJobOrder_IdCustomer_ShouldReturnSuccess()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            string id = "311b3baf-431a-49dc-8c8e-f2b40f3fb30f";

            JobOrder.Setup(m => m.GetJobOrder(id)).ReturnsAsync(JobOrderMockData.GetJobOrders());
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.All(id);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetJobOrder_IdCustomer_ShouldReturnFail()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            string id = "kvm";

            JobOrder.Setup(m => m.GetJobOrder(id)).ReturnsAsync(JobOrderMockData.EmptyJobOrder());
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.All(id);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test lấy ds tìm kiếm.
        [Fact]
        public async Task GetJobOrder_KeySearch_ShouldReturnSuccess()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            JobOrder.Setup(m => m.GetSearch("27")).ReturnsAsync(JobOrderMockData.GetJobOrders());
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.Search("27");

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetJobOrder_KeySearch_ShouldReturnFail()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            JobOrder.Setup(m => m.GetSearch("0")).ReturnsAsync(JobOrderMockData.EmptyJobOrder());
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.Search("0");

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
            var JobOrder = new Mock<IJobOrderRepository>();
            var id = 27;
            JobOrder.Setup(m => m.GetJobOrders(id)).ReturnsAsync(JobOrderMockData.GetJobOrders().FirstOrDefault);
            var sut = new JobOrderController(JobOrder.Object);

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
            DTOGetJobOrder jobOrder = new DTOGetJobOrder();
            jobOrder = null;
            var JobOrder = new Mock<IJobOrderRepository>();
            int id = 1;
            JobOrder.Setup(m => m.GetJobOrders(id)).ReturnsAsync(jobOrder);
            var sut = new JobOrderController(JobOrder.Object);

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
            var JobOrder = new Mock<IJobOrderRepository>();
            DTOJobOrder jo = new DTOJobOrder();            
            string id = "311b3baf-431a-49dc-8c8e-f2b40f3fb30f";
            JobOrder.Setup(m => m.AddJobOrder(jo, id)).Returns(1);
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.Add(jo, id);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        /*[Fact]
        public async Task Add_ShouldReturnFail()
        {   
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            DTOJobOrder JobOrder = new DTOJobOrder();
            JobOrder.Key = "Address";
            JobOrder.Value = "341 Wilson Street, Almonte, Ont K0A 1A0";
            JobOrder.Setup(m => m.AddJobOrder(JobOrder)).Returns(-1);
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.Add(JobOrder);

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
            var JobOrder = new Mock<IJobOrderRepository>();
            int id = 27;
            DTOJobOrder jo = new DTOJobOrder();
            JobOrder.Setup(m => m.UpdateJobOrder(id, jo, 2)).Returns(1);
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.Update(id, jo, 2);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Update_ShouldReturnFail()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            int id = 1;
            DTOJobOrder jo = new DTOJobOrder();
            JobOrder.Setup(m => m.UpdateJobOrder(id, jo, 2)).Returns(0);
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.Update(id, jo, 2);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test cập nhật dữ liệu postcat.
        [Fact]
        public async Task Update_Postpone_ShouldReturnSuccess()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            DateTime date = new DateTime(2022,08,04);
            int id = 27;
            JobOrder.Setup(m => m.Postpone(id, date)).Returns(1);
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.Postpone(id, date);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Update_Postpone_ShouldReturnFail()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            DateTime date = new DateTime(2022, 07, 04);
            int id = 27;
            JobOrder.Setup(m => m.Postpone(id, date)).Returns(0);
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.Postpone(id, date);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test cập nhật dữ liệu assign.
        [Fact]
        public async Task Update_Assign_ShouldReturnSuccess()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            int staff = 2;
            int id = 27;
            JobOrder.Setup(m => m.AssignJobOrder(id, staff)).Returns(1);
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.Assign(id, staff);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Update_Assign_ShouldReturnFail()
        {
            //Arrange
            var JobOrder = new Mock<IJobOrderRepository>();
            int staff = 0;
            int id = 27;
            JobOrder.Setup(m => m.AssignJobOrder(id, staff)).Returns(0);
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.Assign(id, staff);

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
            var JobOrder = new Mock<IJobOrderRepository>();
            int id = 27;
            JobOrder.Setup(m => m.DeleteJobOrder(id)).Returns(1);
            var sut = new JobOrderController(JobOrder.Object);

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
            var JobOrder = new Mock<IJobOrderRepository>();
            int id = 0;
            JobOrder.Setup(m => m.DeleteJobOrder(id)).Returns(0);
            var sut = new JobOrderController(JobOrder.Object);

            //Action
            var res = await sut.Delete(id);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion
    }
}
