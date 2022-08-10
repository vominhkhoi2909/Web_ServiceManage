using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOrderDetailController : ControllerBase
    {
        #region Khai báo repository
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly IJobOrderDetailRepository _repos;
        //Biến gọi hàm check dữ liệu trả về.
        private CheckResult check = new CheckResult();

        //Hàm khởi tạo mặc định.
        public JobOrderDetailController(IJobOrderDetailRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API

        #region Lấy danh sách dữ liệu
        // GET: api/<JobOrderDetail>/Add
        // Lấy tất cả dữ liệu của 1 order.
        [HttpGet("All")]
        public async Task<IActionResult> All(int idJO)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetJOD(idJO);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // GET: api/<JobOrderDetail>/GetPagination
        // Lấy tất cả dữ liệu không bị xóa (dành cho DataTable).
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(DataTableModel model, int idJO)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetJOD(idJO);
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

        // GET: api/<JobOrderDetail>/JO/5/Service/5
        // Lấy tất cả dữ liệu dự trên service của 1 order.
        [HttpGet("Service")]
        public async Task<IActionResult> GetService(int idJO, int idService)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetJODService(idJO, idService);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // GET: api/<JobOrderDetail>/JO/5/Option/5
        // Lấy tất cả dữ liệu dự trên option của 1 order.
        [HttpGet("Option")]
        public async Task<IActionResult> GetOption(int idJO, int idOption)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetJODOption(idJO, idOption);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        // POST api/<JobOrderDetail>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTOJobOrderDetail jod)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AddJOD(jod);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(2, 1, res, res));
            var returns = check.CheckingResult(2, 1, res, res);
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
