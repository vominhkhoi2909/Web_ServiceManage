using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        #region Khai báo repository
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly ICommentRepository _repos;
        //Biến gọi hàm check dữ liệu trả về.
        private CheckResult check = new CheckResult();

        //Hàm khởi tạo mặc định.
        public CommentController(ICommentRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API

        #region Lấy danh sách dữ liệu
        // GET: api/<Comment>/All
        // Lấy tất cả dữ liệu đang active.
        [HttpGet("All")]
        public async Task<IActionResult> All()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetComment();

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if(returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // GET: api/<Comment>/Notification/5
        // Lấy tất cả dữ liệu theo id của notification.
        [HttpGet("Comment/{noti}")]
        public async Task<IActionResult> All(int noti)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetCommentNotifi(noti);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Comment>/Trash
        // Lấy tất cả dữ liệu inactive.
        [HttpGet("Trash")]
        public async Task<IActionResult> GetTrash()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetTrash();

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Comment>/Search/Key
        // Lấy tất cả dữ liệu theo từ khóa tìm kiếm.
        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetSearch(key);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Comment>/GetPagination
        // Lấy tất cả dữ liệu active dưới dạng phân trang.
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(DataTableModel model)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetComment();
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
        // GET api/<Comment>/Detail/5
        // Lấy dữ liệu API theo id active.
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetComment(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(1, 0, 0, res));
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        // POST api/<Comment>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTOComment comment)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AddComment(comment);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 1, res, res));
        }

        // PUT api/<Comment>/Update/5
        // Cập nhập dữ liệu theo id.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOComment comment)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.UpdateComment(id, comment);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 2, res, res));
        }

        // DELETE api/<Comment>/Delete/5
        // Xóa dữ liệu theo id.
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.DeleteComment(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 3, res, res));
        }
        #endregion

        #endregion
    }
}
