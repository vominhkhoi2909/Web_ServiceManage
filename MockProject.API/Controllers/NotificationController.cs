using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        #region Khai báo repository
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly INotificationRepository _repos;
        //Biến gọi hàm check dữ liệu trả về.
        private CheckResult check = new CheckResult();

        //Hàm khởi tạo mặc định.
        public NotificationController(INotificationRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API

        #region Lấy danh sách dữ liệu
        // GET: api/<Notification>/All
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("All")]
        public async Task<IActionResult> All()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetNotification();

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // GET: api/<Notification>/All
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("AllByUserId")]
        public async Task<IActionResult> AllByUserId(string id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetNotificationByUserId(id);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // GET: api/<Notification>/All
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("AllByAdminId")]
        public async Task<IActionResult> AllByAdminId(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetNotificationByAdminUserId(id);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // GET: api/<Notification>/Trash
        // Lấy tất cả dữ liệu đã bị xóa.
        [HttpGet("Trash")]
        public async Task<IActionResult> GetTrash()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetTrash();

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Notification>/Search/Key
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

        // GET api/<Notification>/Type/5
        // Lấy dữ liệu API theo type không bị xóa.
        [HttpGet("Type/{type}")]
        public async Task<IActionResult> All(int type)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetNotificationType(type);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // GET: api/<Notification>/GetPagination
        // Lấy tất cả dữ liệu không bị xóa (dành cho DataTable).
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(DataTableModel model)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetNotification();
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

        // POST: api/<Notification>/ReadNotif/{id}
        // Đánh dấu đã đọc Notification
        [HttpPost("ReadNotif/{id}")]
        public async Task<IActionResult> ReadNotification(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.ReadNotification(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 2, res, res));
        }

        // POST: api/<Notification>/ReadNotifAll/{id}
        // Đánh dấu đã đọc Notification All
        [HttpPost("ReadNotifAll/{id}")]
        public async Task<IActionResult> ReadAllNotification(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.ReadAllNotification(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 2, res, res));
        }

        #endregion

        #region Chi tiết
        // GET api/<Notification>/Detail/5
        // Lấy dữ liệu API theo id không bị xóa.
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetNotification(id);

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
        // POST api/<Notification>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTONotification notifi)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AddNotification(notifi);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(2, 1, res, res));
            var returns = check.CheckingResult(2, 1, res, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // PUT api/<Notification>/Update/5
        // Cập nhập dữ liệu theo id.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTONotification notifi)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.UpdateNotification(id, notifi);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 2, res, res));
            var returns = check.CheckingResult(2, 2, res, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);

        }

        // DELETE api/<Notification>/Delete/5
        // Xóa dữ liệu theo id.
        //[HttpDelete("Delete/{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    //Nhận dữ liệu từ db.
        //    var res = _repos.DeleteNotification(id);

        //    //Tra dữ liệu cho FE.
        //    return Ok(check.CheckingResult(2, 3, res, res));
        //}
        #endregion

        #endregion
    }
}
