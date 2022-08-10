using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Slider : ControllerBase
    {
        #region Khai báo repository
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly ISliderRepository _repos;
        //Biến gọi hàm check dữ liệu trả về.
        private CheckResult check = new CheckResult();

        //Hàm khởi tạo mặc định.
        public Slider(ISliderRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API

        #region Lấy danh sách dữ liệu
        // GET: api/<Slider>/All
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("All")]
        public async Task<IActionResult> All()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetSlider();

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Slider>/Trash
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("Trash")]
        public async Task<IActionResult> GetTrash()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetTrash();

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Slider>/Search/Key
        // Lấy tất cả dữ liệu theo từ khóa tìm kiếm.
        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetSearch(key);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Slider>/GetPagination
        // Lấy tất cả dữ liệu không bị xóa (dành cho DataTable).
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(DataTableModel model)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetSlider();
            int total = res.Count();

            //Tra dữ liệu cho FE.
            return Ok(new
            {
                draw = model.draw,
                recordsTotal = total,
                recordsFiltered = total,
                data = res
            });
        }
        #endregion

        #region Chi tiết
        // GET api/<Slider>/Detail/5
        // Lấy dữ liệu API theo id không bị xóa.
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetSlider(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(1, 0, 0, res));
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        // POST api/<Slider>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTOSlider slider)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AddSlider(slider);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 1, res, res));
        }

        // PUT api/<Slider>/Update/5
        // Cập nhập dữ liệu theo id.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOSlider slider)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.UpdateSlider(id, slider);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 2, res, res));
        }

        // DELETE api/<Slider>/Delete/5
        // Xóa dữ liệu theo id.
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.DeleteSlider(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 3, res, res));
        }
        #endregion

        #endregion
    }
}
