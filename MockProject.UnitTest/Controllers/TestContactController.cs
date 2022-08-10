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
    public class TestContactController
    {
        #region Test lấy ds.
        [Fact]
        public async Task GetContact_ShouldReturnSuccess()
        {
            //Arrange
            var Contact = new Mock<IContactRepository>();
            Contact.Setup(m => m.GetContact()).ReturnsAsync(ContactMockData.GetContacts());
            var sut = new ContactController(Contact.Object);

            //Action
            var res = await sut.All(null);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetContact_ShouldReturnFail()
        {
            //Arrange
            var Contact = new Mock<IContactRepository>();
            Contact.Setup(m => m.GetContact()).ReturnsAsync(ContactMockData.EmptyContact());
            var sut = new ContactController(Contact.Object);

            //Action
            var res = await sut.All(null);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test lấy ds theo id service.
        [Fact]
        public async Task GetContact_IdService_ShouldReturnSuccess()
        {
            //Arrange
            var Contact = new Mock<IContactRepository>();
            int idService = 1;

            Contact.Setup(m => m.GetContactService(idService)).ReturnsAsync(ContactMockData.GetContacts());
            var sut = new ContactController(Contact.Object);

            //Action
            var res = await sut.All(idService);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetContact_IdService_ShouldReturnFail()
        {
            //Arrange
            var Contact = new Mock<IContactRepository>();
            int idService = 0;

            Contact.Setup(m => m.GetContactService(idService)).ReturnsAsync(ContactMockData.EmptyContact());
            var sut = new ContactController(Contact.Object);

            //Action
            var res = await sut.All(idService);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test lấy ds tìm kiếm.
        [Fact]
        public async Task GetContact_KeySearch_ShouldReturnSuccess()
        {
            //Arrange
            var Contact = new Mock<IContactRepository>();
            Contact.Setup(m => m.GetContact()).ReturnsAsync(ContactMockData.GetContacts());
            var sut = new ContactController(Contact.Object);

            //Action
            var res = await sut.All("Jonny Khoi");

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetContact_KeySearch_ShouldReturnFail()
        {
            //Arrange
            var Contact = new Mock<IContactRepository>();
            Contact.Setup(m => m.GetContact()).ReturnsAsync(ContactMockData.EmptyContact());
            var sut = new ContactController(Contact.Object);

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
            var Contact = new Mock<IContactRepository>();
            var id = 1;
            Contact.Setup(m => m.GetContact(id)).ReturnsAsync(ContactMockData.GetContacts().FirstOrDefault);
            var sut = new ContactController(Contact.Object);

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
            DTOGetContact contact = new DTOGetContact();
            contact = null;
            var Contact = new Mock<IContactRepository>();
            int id = 0;
            Contact.Setup(m => m.GetContact(id)).ReturnsAsync(contact);
            var sut = new ContactController(Contact.Object);

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
            var Contact = new Mock<IContactRepository>();
            DTOContact contact = new DTOContact();
            Contact.Setup(m => m.AddContact(contact)).Returns(1);
            var sut = new ContactController(Contact.Object);

            //Action
            var res = await sut.Add(contact);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        /*[Fact]
        public async Task Add_ShouldReturnFail()
        {   
            //Arrange
            var Contact = new Mock<IContactRepository>();
            DTOContact Contact = new DTOContact();
            Contact.Key = "Address";
            Contact.Value = "341 Wilson Street, Almonte, Ont K0A 1A0";
            Contact.Setup(m => m.AddContact(Contact)).Returns(-1);
            var sut = new ContactController(Contact.Object);

            //Action
            var res = await sut.Add(Contact);

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
            var Contact = new Mock<IContactRepository>();
            int id = 3;
            DTOContact contact = new DTOContact();
            Contact.Setup(m => m.UpdateContact(id, contact)).Returns(1);
            var sut = new ContactController(Contact.Object);

            //Action
            var res = await sut.Update(id, contact);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Update_ShouldReturnFail()
        {
            //Arrange
            var Contact = new Mock<IContactRepository>();
            int id = 0;
            DTOContact contact = new DTOContact();
            Contact.Setup(m => m.UpdateContact(id, contact)).Returns(0);
            var sut = new ContactController(Contact.Object);

            //Action
            var res = await sut.Update(id, contact);

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
            var Contact = new Mock<IContactRepository>();
            int id = 3;
            Contact.Setup(m => m.DeleteContact(id)).Returns(1);
            var sut = new ContactController(Contact.Object);

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
            var Contact = new Mock<IContactRepository>();
            int id = 0;
            Contact.Setup(m => m.DeleteContact(id)).Returns(0);
            var sut = new ContactController(Contact.Object);

            //Action
            var res = await sut.Delete(id);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion
    }
}
