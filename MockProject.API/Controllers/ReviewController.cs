using Microsoft.AspNetCore.Mvc;
using MockProject.API.Models;
using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Review : ControllerBase
    {
        #region Khai báo repository
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly IReviewRepository _repos;

        //Hàm khởi tạo mặc định.
        public Review(IReviewRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API
        // GET: api/<Review>/All
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("All")]
        public async Task<IActionResult> All(string? searchString, int? rating)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetReview();

            // Filter Search string
            searchString = searchString?.ToLower();
            res = res.Where(x => string.IsNullOrEmpty(searchString) || x.FullName.ToLower().Contains(searchString)
            || x.Email.ToLower().Contains(searchString) || x.Comment.ToLower().Contains(searchString)
            ).ToList();
            // Filter Search rating
            res = res.Where(x => (rating==null) || x.RatingScore == rating).ToList();

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Review>/Trash
        // Lấy tất cả dữ liệu bị xóa.
        [HttpGet("Trash")]
        public async Task<IActionResult> GetTrash()
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetTrash();

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(0, 0, res.Count, res));
        }

        // GET api/<Review>/Detail/5
        // Lấy dữ liệu API theo id không bị xóa.
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetReview(id);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(1, 0, 0, res));
        }

        // POST api/<Review>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTOReview review)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.AddReview(review);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(2, 1, res, res));
        }

        // PUT api/<Review>/Update/5
        // Cập nhập dữ liệu theo id.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOReview review)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.UpdateReview(id, review);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(2, 2, res, res));
        }

        // DELETE api/<Review>/Delete/5
        // Xóa dữ liệu theo id.
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Nhận dữ liệu từ db.
            var res = _repos.DeleteReview(id);

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
