using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        #region Khai báo repository
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly ILogRepository _repos;
        //Biến gọi hàm check dữ liệu trả về.
        private CheckResult check = new CheckResult();

        //Hàm khởi tạo mặc định.
        public LogController(ILogRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API

        #region Lấy danh sách dữ liệu
        // GET: api/<Log>/Add
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("All")]
        public async Task<IActionResult> All()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetLog();

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Log>/Trash
        // Lấy tất cả dữ liệu bị xóa.
        [HttpGet("Trash")]
        public async Task<IActionResult> GetTrash()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetTrash();

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET api/<Log>/Service/5
        // Lấy dữ liệu API theo service không bị xóa.
        [HttpGet("Service/{service}")]
        public async Task<IActionResult> All(int type)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetLogType(type);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Log>/GetPagination
        // Lấy tất cả dữ liệu không bị xóa (dành cho DataTable).
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(DataTableModel model)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetLog();
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
        // GET api/<Log>/Detail/5
        // Lấy dữ liệu API theo id không bị xóa.
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetLog(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(1, 0, 0, res));
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        // POST api/<Log>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTOLog log)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AddLog(log);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 1, res, res));
        }

        // PUT api/<Log>/Update/5
        // Cập nhập dữ liệu theo id.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOLog log)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.UpdateLog(id, log);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 2, res, res));
        }

        // DELETE api/<Log>/Delete/5
        // Xóa dữ liệu theo id.
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.DeleteLog(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 3, res, res));
        }
        #endregion

        #endregion
    }
}
