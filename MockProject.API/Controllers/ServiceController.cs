using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Service : ControllerBase
    {
        #region Khai báo repository
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly IServiceRepository _repos;
        //Biến gọi hàm check dữ liệu trả về.
        private CheckResult check = new CheckResult();

        //Hàm khởi tạo mặc định.
        public Service(IServiceRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API
        // GET: api/<Service>/All
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("All")]
        public async Task<IActionResult> All(string? searchString, int? type)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetService();

            // Filter Search string
            searchString = searchString?.ToLower();
            res = res.Where(x => string.IsNullOrEmpty(searchString) || x.Name.ToLower().Contains(searchString)
            || x.Description.ToLower().Contains(searchString)).ToList();
            // Filter Search type
            res = res.Where(x => (type == null) || x.Type == type).ToList();

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Van>/GetPagination
        // Lấy tất cả dữ liệu không bị xóa (dành cho DataTable).
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(DataTableModel model)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetService();
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

        // GET: api/<Service>/Trash
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("Trash")]
        public async Task<IActionResult> GetTrash()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetTrash();

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET api/<Service>/Type/5
        // Lấy dữ liệu API theo type không bị xóa.
        [HttpGet("Type/{type}")]
        public async Task<IActionResult> All(int type)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetServiceType(type);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // GET api/<Service>/Detail/5
        // Lấy dữ liệu API theo id không bị xóa.
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetService(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(1, 0, 0, res));
        }

        // GET: api/<Comment>/Search/Key
        // Lấy tất cả dữ liệu theo từ khóa tìm kiếm.
        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.Search(key);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(0, 0, res.Count, res));
        }

        // POST api/<Service>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTOService service)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AddService(service);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 1, res, res));
        }

        // PUT api/<Service>/Update/5
        // Cập nhập dữ liệu theo id.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOService service)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.UpdateService(id, service);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 2, res, res));
        }

        // DELETE api/<Service>/Delete/5
        // Xóa dữ liệu theo id.
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.DeleteService(id);

            //Tra dữ liệu cho FE.
            return Ok(check.CheckingResult(2, 3, res, res));
        }
        #endregion
    }
}
