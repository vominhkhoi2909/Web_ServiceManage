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
    public class TestNoteController
    {
        #region Test lấy ds.
        [Fact]
        public async Task GetNote_ShouldReturnSuccess()
        {
            //Arrange
            var Note = new Mock<INoteRepository>();
            int? idType = null;
            int? idUser = null;
            Note.Setup(m => m.GetNote()).ReturnsAsync(NoteMockData.GetNotes());
            var sut = new NoteController(Note.Object);

            //Action
            var res = await sut.All(idType, idUser);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetNote_ShouldReturnFail()
        {
            //Arrange
            var Note = new Mock<INoteRepository>();
            int? idType = null;
            int? idUser = null;
            Note.Setup(m => m.GetNote()).ReturnsAsync(NoteMockData.EmptyNote());
            var sut = new NoteController(Note.Object);

            //Action
            var res = await sut.All(idType, idUser);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test lấy ds theo id service.
        [Fact]
        public async Task GetNote_IdService_ShouldReturnSuccess()
        {
            //Arrange
            var Note = new Mock<INoteRepository>();
            int idService = 1;

            Note.Setup(m => m.GetNoteType(idService)).ReturnsAsync(NoteMockData.GetNotes());
            var sut = new NoteController(Note.Object);

            //Action
            var res = await sut.All(idService);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetNote_IdService_ShouldReturnFail()
        {
            //Arrange
            var Note = new Mock<INoteRepository>();
            int idService = 0;

            Note.Setup(m => m.GetNoteType(idService)).ReturnsAsync(NoteMockData.EmptyNote());
            var sut = new NoteController(Note.Object);

            //Action
            var res = await sut.All(idService);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion

        #region Test lấy ds tìm kiếm.
        [Fact]
        public async Task GetNote_KeySearch_ShouldReturnSuccess()
        {
            //Arrange
            var Note = new Mock<INoteRepository>();
            int? idType = 1;
            int? idUser = null;
            Note.Setup(m => m.GetNote()).ReturnsAsync(NoteMockData.GetNotes());
            var sut = new NoteController(Note.Object);

            //Action
            var res = await sut.All(idType, idUser);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetNote_KeySearch_ShouldReturnFail()
        {
            //Arrange
            var Note = new Mock<INoteRepository>();
            int? idType = null;
            int? idUser = 0;
            Note.Setup(m => m.GetNote()).ReturnsAsync(NoteMockData.EmptyNote());
            var sut = new NoteController(Note.Object);

            //Action
            var res = await sut.All(idType, idUser);

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
            var Note = new Mock<INoteRepository>();
            int id = 2;
            Note.Setup(m => m.GetNote(id)).ReturnsAsync(NoteMockData.GetNotes().FirstOrDefault);
            var sut = new NoteController(Note.Object);

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
            var Note = new Mock<INoteRepository>();
            DTOGetNote note = new DTOGetNote();
            note = null;
            int id = 1;
            Note.Setup(m => m.GetNote(id)).ReturnsAsync(note);
            var sut = new NoteController(Note.Object);

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
            var Note = new Mock<INoteRepository>();
            DTONote note = new DTONote();
            Note.Setup(m => m.AddNote(note)).Returns(1);
            var sut = new NoteController(Note.Object);

            //Action
            var res = await sut.Add(note);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        /*[Fact]
        public async Task Add_ShouldReturnFail()
        {   
            //Arrange
            var Note = new Mock<INoteRepository>();
            DTONote Note = new DTONote();
            Note.Key = "Address";
            Note.Value = "341 Wilson Street, Almonte, Ont K0A 1A0";
            Note.Setup(m => m.AddNote(Note)).Returns(-1);
            var sut = new NoteController(Note.Object);

            //Action
            var res = await sut.Add(Note);

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
            var Note = new Mock<INoteRepository>();
            int id = 3;
            DTONote note = new DTONote();
            Note.Setup(m => m.UpdateNote(id, note)).Returns(1);
            var sut = new NoteController(Note.Object);

            //Action
            var res = await sut.Update(id, note);

            //Assert
            res.GetType().Should().Be(typeof(OkObjectResult));
            (res as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Update_ShouldReturnFail()
        {
            //Arrange
            var Note = new Mock<INoteRepository>();
            int id = 0;
            DTONote note = new DTONote();
            Note.Setup(m => m.UpdateNote(id, note)).Returns(0);
            var sut = new NoteController(Note.Object);

            //Action
            var res = await sut.Update(id, note);

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
            var Note = new Mock<INoteRepository>();
            int id = 3;
            Note.Setup(m => m.DeleteNote(id)).Returns(1);
            var sut = new NoteController(Note.Object);

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
            var Note = new Mock<INoteRepository>();
            int id = 0;
            Note.Setup(m => m.DeleteNote(id)).Returns(0);
            var sut = new NoteController(Note.Object);

            //Action
            var res = await sut.Delete(id);

            //Assert
            res.GetType().Should().Be(typeof(BadRequestObjectResult));
            (res as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion
    }
}
