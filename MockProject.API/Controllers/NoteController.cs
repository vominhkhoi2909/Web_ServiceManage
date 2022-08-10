using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        #region Khai báo repository
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly INoteRepository _repos;
        //Biến gọi hàm check dữ liệu trả về.
        private CheckResult check = new CheckResult();

        //Hàm khởi tạo mặc định.
        public NoteController(INoteRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API

        #region Lấy danh sách dữ liệu
        // GET: api/<Note>/All
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("All")]
        public async Task<IActionResult> All(int? type, int? userId)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetNote();

            // Filter Search type
            res = res.Where(x => (type == null) || x.Type == type).ToList();
            res = res.Where(x => (userId == null) || x.CreateBy == userId).ToList();

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // GET: api/<Note>/Trash
        // Lấy tất cả dữ liệu đã bị xóa.
        [HttpGet("Trash")]
        public async Task<IActionResult> GetTrash()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetTrash();

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Note>/Search/Key
        // Lấy tất cả dữ liệu theo từ khóa tìm kiếm.
        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetSearch(key);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // GET api/<Note>/Service/5
        // Lấy dữ liệu API theo service không bị xóa.
        [HttpGet("Service/{service}")]
        public async Task<IActionResult> All(int type)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetNoteType(type);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // GET: api/<Note>/GetPagination
        // Lấy tất cả dữ liệu không bị xóa (dành cho DataTable).
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(DataTableModel model)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetNote();
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
        // GET api/<Note>/Detail/5
        // Lấy dữ liệu API theo id không bị xóa.
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetNote(id);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(1, 0, 0, res));
            var returns = check.CheckingResult(1, 0, 0, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        // POST api/<Note>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTONote Note)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AddNote(Note);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(2, 1, res, res));
            var returns = check.CheckingResult(2, 1, res, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // PUT api/<Note>/Update/5
        // Cập nhập dữ liệu theo id.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTONote Note)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.UpdateNote(id, Note);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(2, 2, res, res));
            var returns = check.CheckingResult(2, 2, res, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // DELETE api/<Note>/Delete/5
        // Xóa dữ liệu theo id.
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.DeleteNote(id);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(2, 3, res, res));
            var returns = check.CheckingResult(2, 3, res, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }
        #endregion

        #endregion
    }
}
