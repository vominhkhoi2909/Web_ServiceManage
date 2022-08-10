using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOrderController : ControllerBase
    {
        #region Khai báo repository
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly IJobOrderRepository _repos;
        //Biến gọi hàm check dữ liệu trả về.
        private CheckResult check = new CheckResult();

        //Hàm khởi tạo mặc định.
        public JobOrderController(IJobOrderRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API

        #region Lấy danh sách dữ liệu
        // GET: api/<JobOrder>/Add
        // Lấy tất cả dữ liệu active.
        [HttpGet("All")]
        public async Task<IActionResult> All(int? status)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetJobOrder();
            res = res.Where(x => (status == null) || x.State == status).ToList();
            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        //// GET: api/<JobOrder>/Trash
        //// Lấy tất cả dữ liệu inactive.
        //[HttpGet("Trash")]
        //public async Task<IActionResult> GetTrash()
        //{
        //    //Nhận dữ liệu từ db.
        //    var res = await _repos.GetTrash();

        //    //Tra dữ liệu cho FE.
        //    return Ok(check.CheckingResult(0, 0, res.Count, res));
        //}

        // GET: api/<JobOrder>/Customer/5
        // Lấy tất cả dữ liệu active.

        [HttpGet("Customer/{id}")]
        public async Task<IActionResult> All(string id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetJobOrder(id);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res)); 
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // GET: api/<JobOrder>/Search/Key
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

        // GET: api/<JobOrder>/GetPagination
        // Lấy tất cả dữ liệu active theo phân trang.
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(DataTableModel model)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetJobOrder();
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
        // GET api/<JobOrder>/Detail/5
        // Lấy dữ liệu API theo id active.
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetJobOrders(id);

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
        // POST api/<JobOrder>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTOJobOrder JobOrder, string customerId)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AddJobOrder(JobOrder, customerId);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(3, 1, res, res));
            var returns = check.CheckingResult(3, 1, res, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // PUT api/<JobOrder>/Update/5
        // Cập nhập dữ liệu theo id.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOJobOrder JobOrder, int? staffId)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.UpdateJobOrder(id, JobOrder, staffId);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(2, 2, res, res));
            var returns = check.CheckingResult(2, 2, res, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // POST api/<JobOrder>/Assign/5
        // Giao phó order cho staff.
        [HttpPost("Assign/{id}")]
        public async Task<IActionResult> Assign(int id, [FromBody] int staffId)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AssignJobOrder(id, staffId);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(2, 2, res, res));
            var returns = check.CheckingResult(2, 2, res, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // POST api/<JobOrder>/Cancel/5
        // Hủy đơn hàng.
        [HttpPost("Cancel/{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.Cancel(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 2, res, res));
        }

        // POST api/<JobOrder>/Confirm/5
        // Hủy đơn hàng.
        [HttpPost("Confirm/{id}")]
        public async Task<IActionResult> Confirm(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.Confirm(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 2, res, res));
        }

        // POST api/<JobOrder>/Checkout/5
        // Hủy đơn hàng.
        [HttpPost("Checkout/{id}")]
        public async Task<IActionResult> Checkout(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.Checkout(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 2, res, res));
        }

        // POST api/<JobOrder>/Checkin/5
        // Hủy đơn hàng.
        [HttpPost("Checkin/{id}")]
        public async Task<IActionResult> Checkin(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.Checkin(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 2, res, res));
        }

        // POST api/<JobOrder>/Postpone/5
        // Cập nhật lại ngày.
        [HttpPost("Postpone/{id}")]
        public async Task<IActionResult> Postpone(int id, [FromBody] DateTime date)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.Postpone(id,date);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(2, 2, res, res));
            var returns = check.CheckingResult(2, 2, res, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // DELETE api/<JobOrder>/Delete/5
        // Xóa dữ liệu theo id.
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.DeleteJobOrder(id);

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
