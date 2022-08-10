using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        #region Khai báo repository
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly IOptionRepository _repos;
        //Biến gọi hàm check dữ liệu trả về.
        private CheckResult check = new CheckResult();

        //Hàm khởi tạo mặc định.
        public OptionController(IOptionRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API

        #region Lấy danh sách dữ liệu
        // GET: api/<Option>/All
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("All")]
        public async Task<IActionResult> All()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetOption();

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET api/<Option>/Type/5
        // Lấy dữ liệu API theo type không bị xóa.
        [HttpGet("Type/{type}")]
        public async Task<IActionResult> All(int type)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetOptionType(type);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Option>/Trash
        // Lấy tất cả dữ liệu bị xóa.
        [HttpGet("Trash")]
        public async Task<IActionResult> GetTrash()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetTrash();

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Option>/Search/Key
        // Lấy tất cả dữ liệu theo từ khóa tìm kiếm.
        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetSearch(key);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Option>/GetPagination
        // Lấy tất cả dữ liệu không bị xóa (dành cho DataTable).
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(DataTableModel model)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetOption();
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
        // GET api/<Option>/Detail/5
        // Lấy dữ liệu API theo id không bị xóa.
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetOption(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(1, 0, 0, res));
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        // POST api/<Option>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTOOption option)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AddOption(option);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 1, res, res));
        }

        // PUT api/<Option>/Update/5
        // Cập nhập dữ liệu theo id.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOOption option)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.UpdateOption(id, option);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 2, res, res));

        }

        // DELETE api/<Option>/Delete/5
        // Xóa dữ liệu theo id.
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.DeleteOption(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 3, res, res));
        }
        #endregion

        #endregion
    }
}
