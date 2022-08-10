using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VanController : ControllerBase
    {
        #region Khai báo repository
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly IVanRepository _repos;

        //Hàm khởi tạo mặc định.
        public VanController(IVanRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API
        // GET: api/<Van>/All
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("All")]
        public async Task<IActionResult> All()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetVan();

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Van>/GetPagination
        // Lấy tất cả dữ liệu không bị xóa (dành cho DataTable).
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(DataTableModel model)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetVan();
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

        // GET: api/<Van>/Trash
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("Trash")]
        public async Task<IActionResult> GetTrash()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetTrash();

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(0, 0, res.Count, res));
        }

        // GET api/<ValuesController>/Detail/5
        // Lấy dữ liệu API theo id không bị xóa.
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetVan(id);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(1, 0, 0, res));
        }

        // GET: api/<Comment>/Search/Key
        // Lấy tất cả dữ liệu theo từ khóa tìm kiếm.
        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.Search(key);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(0, 0, res.Count, res));
        }

        // POST api/<ValuesController>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTOVan van)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AddVan(van);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(2, 1, res, res));
        }

        // PUT api/<ValuesController>/Update/5
        // Cập nhập dữ liệu theo id.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOVan van)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.UpdateVan(id, van);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(2, 2, res, res));
        }

        // DELETE api/<ValuesController>/Delete/5
        // Xóa dữ liệu theo id.
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.DeleteVan(id);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(2, 3, res, res));
        }
        #endregion

        #region Hàm support
        //Hàm thực hiện trả về kết quả phản hồi của return.
        private ResponseModel CheckingResult(int type, int act, int? number, object res)
        {
            string action = "", mess = "";
            //act = 0 hay number = 0 tức là k dùng tới.
            //Type 0 = list / 1 = detail / 2 =  add - update - delete.            
            if (type == 0)
            {
                if (number >= 0)
                {
                    action = (number > 0) ? "Get " : "No ";
                }
                else
                {
                    action = "Invalid ";
                }

                mess = action + "data send to server.";

                return new ResponseModel()
                {
                    //Number > 0 là dữ liệu trả về có ít nhất 1 dòng dữ liệu tồn tại.
                    //Number = 0 là dữ liệu trả về rỗng.
                    //Number = null là thực hiện chức năng bị fail.
                    Success = (number > 0) ? true : false,
                    Message = mess,
                    Data = (number > 0) ? res : null
                };
            }
            else if (type == 1)
            {
                return new ResponseModel()
                {
                    //Nếu giá trị nhận từ repon khác null thì trả về true + giá trị nhận được. 
                    Success = (res != null) ? true : false,
                    Message = (res != null) ? "Get data to server success." : "Invalid data send to server.",
                    Data = (res != null) ? res : null
                };
            }
            else
            {
                switch (act)
                {
                    case 1: action = "Added "; break;
                    case 2: action = "Updated "; break;
                    case 3: action = "Deleted "; break;
                }

                if (number == 1) //Nếu chức năng thực hiện thành công.
                {
                    mess = action + "data to server success.";
                }
                else if (number == -2) //Dữ liệu đã tồn tại.
                {
                    mess = action + "not found.";
                }
                else if (number == 0) //Nếu không kiếm được id cần để thực hiện chức năng.
                {
                    mess = action + "data already exist.";
                }
                else //Thực hiện thất bại.
                {
                    mess = action + "data to server fail.";
                }

                return new ResponseModel()
                {
                    Success = (number == 1) ? true : false,
                    Message = mess,
                    Data = (number == 1) ? res : null
                };
            }
        }
        #endregion    
    }
}
