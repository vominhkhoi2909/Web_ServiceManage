using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        #region Khai báo repository
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly IConfigRepository _repos;
        //Biến gọi hàm check dữ liệu trả về.
        private CheckResult check = new CheckResult();

        //Hàm khởi tạo mặc định.
        public ConfigController(IConfigRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API

        #region Lấy danh sách dữ liệu
        // GET: api/<Config>/All
        // Lấy tất cả dữ liệu active.
        [HttpGet("All")]
        public async Task<IActionResult> All(string? searchString)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetConfig();
            res = res.Where(x => string.IsNullOrEmpty(searchString) || x.Value.ToLower().Contains(searchString.ToLower()) || x.Key.ToLower().Contains(searchString.ToLower())).ToList();

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(0, 0, res.Count, res));
            var returns = check.CheckingResult(0, 0, res.Count, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        /*// GET: api/<Config>/Trash
        // Lấy tất cả dữ liệu inactive.
        [HttpGet("Trash")]
        public async Task<IActionResult> GetTrash()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetTrash();

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }*/

        // GET: api/<Config>/Search/Key
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

        // GET: api/<Config>/GetPagination
        // Lấy tất cả dữ liệu active theo dạng phân trang.
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(DataTableModel model)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetConfig();
            int total = res.Count();

            //Tra dữ liệu cho FE.
            if(total > 0)
            {
                return Ok(new
                {
                    draw = model.draw,
                    recordsTotal = total,
                    recordsFiltered = total,
                    data = res
                });
            }
            return BadRequest(new ResponseModel
            {
                Success = false,
                Message = "Fail function."
            });
        }
        #endregion

        #region Chi tiết
        // GET api/<Config>/Detail/5
        // Lấy dữ liệu API theo id không bị xóa.
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetConfig(id);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(1, 0, 0, res));
            var returns = check.CheckingResult(1, 0, 0, res);
            if (returns.Success == true && returns.Data != null)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        // POST api/<Config>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTOConfig config)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AddConfig(config);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(2, 1, res, res));
            var returns = check.CheckingResult(2, 1, res, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // PUT api/<Config>/Update/5
        // Cập nhập dữ liệu theo id.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOConfig config)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.UpdateConfig(id, config);

            //Tra dữ liệu cho FE.
            //return Ok(check.CheckingResult(2, 2, res, res)); 
            var returns = check.CheckingResult(2, 2, res, res);
            if (returns.Success == true)
            {
                return Ok(returns);
            }
            return BadRequest(returns);
        }

        // DELETE api/<Config>/Delete/5
        // Xóa dữ liệu theo id.
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.DeleteConfig(id);

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
