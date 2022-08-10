using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;
using System.Security.Claims;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "AdminJWT")]
    public class AdminController : ControllerBase
    {
        #region Khai báo repository.
        //Biến để ánh xạ gọi hàm từ repository.
        private readonly IAdminRepository _repos;

        //Hàm khởi tạo mặc định.
        public AdminController(IAdminRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region API

        #region Lấy danh sách dữ liệu
        // GET: api/<Admin>/All
        // Lấy tất cả dữ liệu không bị xóa.
        //[Authorize(Roles = "Admin")]
        [HttpGet("All")]
        public async Task<IActionResult> All(string? searchString, int? role)
        {
            var res = await _repos.GetAdmin();
            res = res.Where(x => string.IsNullOrEmpty(searchString)
                    || (x.FullName == null ? false : x.FullName.Contains(searchString))
                    || (x.Phone == null ? false : x.Phone.Contains(searchString))
                    || (x.Address == null ? false : x.Address.Contains(searchString))
                    || x.Email.Contains(searchString)).ToList();

            res = res.Where(x => (role == null)
                || (x.RoleId == role)
            ).ToList();

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(0, 0, res.Count, res));
        }

        // GET: api/<Admin>/Trash
        // Lấy tất cả dữ liệu không bị xóa.
        [HttpGet("Trash")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTrash()
        {
            var res = await _repos.GetTrash();

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(0, 0, res.Count, res));
        }
                
        // GET api/<Admin>/Role/5
        // Lấy dữ liệu API admin theo role không bị xóa.
        [HttpGet("Role/{roleId}")]
        public async Task<IActionResult> All(int role)
        {
            var res = await _repos.GetAdminRole(role);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(0, 0, res.Count, res));
        }

        // GET api/<Admin>/AllStaffSale/
        // Lấy dữ liệu API admin theo role không bị xóa.
        [HttpGet("AllStaffSale")]
        public async Task<IActionResult> AllStaffSale(DateTime? start, DateTime? end, string? searchString)
        {
            if(start > end)
            {
                return Ok(new ResponseModel()
                {
                    Success = false,
                    Message = "Start date cannot be greater than end date."
                });
            }

            var res = await _repos.GetStaffSale(start,end);

            // Search filter
            if(!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
            }    
            res = res.Where(x => string.IsNullOrEmpty(searchString) || x.FullName.ToLower().Contains(searchString)
            || x.Email.ToLower().Contains(searchString) || x.Address.ToLower().Contains(searchString)
            ).ToList();

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(0, 0, res.Count, res));
        }

        // GET api/<Admin>/Dashboard/
        // Lấy dữ liệu API admin theo role không bị xóa.
        [HttpGet("GetDashboard")]
        public async Task<IActionResult> GetDashboard(int? year)
        {
            try
            {
                var res = await _repos.GetDashboard(year);

                //Tra dữ liệu cho FE.
                return Ok(CheckingResult(1, 0, 0, res));
            }
            catch
            {
                return Ok(CheckingResult(0, 0, null, null));
            }
        }

        // GET: api/<Admin>/GetPagination
        // Lấy tất cả dữ liệu không bị xóa (dành cho DataTable).
        [HttpGet("GetPagination")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPagination(DataTableModel model)
        {
            //Nhận dữ liệu từ db.
            var res = await _repos.GetAdmin();
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

        // GET api/<Admin>/Role/5
        // Lấy dữ liệu API admin theo role không bị xóa.
        [HttpGet("getinfo")]
        public async Task<IActionResult> GetInfo()
        {
            var userId = User.FindFirst("UserId")?.Value ?? "0";
            var id = Convert.ToInt32(userId);
            var res = await _repos.GetAdmin(id);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(1, 0, 0, res));
        }

        // GET api/<Admin>/Login
        // Lấy dữ liệu API theo thông tin đăng nhập.
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        {
            var res = await _repos.Login(model);

            return Ok(res);
        }

        // PUT api/<ValuesController>.
        // Cập nhật lại password cho tài khoản.
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (model.NewPassword == model.ConfirmPassword)
            {
                var userId = User.FindFirst("UserId")?.Value ?? "0";
                var id = Convert.ToInt32(userId);
                var res = await _repos.ChangePassword(id, model.OldPassword, model.NewPassword);

                if (res == 1)
                    return Ok(new ResponseModel()
                    {
                        Success = true,
                        Message = "Change password success.",
                        Data = res
                    });
                else if (res == -2)
                    return BadRequest(new ResponseModel()
                    {
                        Success = false,
                        Message = "Old password incorrect.",
                    });
                else if (res == -3)
                    return BadRequest(new ResponseModel()
                    {
                        Success = false,
                        Message = "New Password can't be the same with Old Password.",
                    });
                else if (res == -4)
                    return BadRequest(new ResponseModel()
                    {
                        Success = false,
                        Message = "Password must have at least 1 upper char, 1 lower char, 1 digit and 1 special char.",
                    });
                else if (res == 0)
                    return BadRequest(new ResponseModel()
                    {
                        Success = false,
                        Message = "User not found.",
                    });

                return BadRequest(new ResponseModel()
                {
                    Success = false,
                    Message = "Change password fail."
                });
            }

            return BadRequest(new ResponseModel()
            {
                Success = false,
                Message = "New Password does not match Confirm Password."
            });
        }

        // POST api/<ValuesController>.
        // Khôi phục lại password cho tài khoản.
        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var res = await _repos.ForgotPassword(email);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }

        // POST api/<ValuesController>.
        // Khôi phục lại password cho tài khoản.
        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(AdminResetPasswordModel model)
        {
            var res = await _repos.ResetPassword(model);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }

        // POST api/<ValuesController>.
        // Tự cập nhật thông tin tài khoản
        [HttpPost("UpdateInfo")]
        public async Task<IActionResult> UpdateInfo(AdminUpdateInfoModel info)
        {
            var userId = User.FindFirst("UserId")?.Value ?? "0";
            var id = Convert.ToInt32(userId);
            var res = await _repos.UpdateInfo(id, info);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(2, 2, res, res));
        }

        // PUT api/<ValuesController>.
        // Cập nhật lại quyền hạn cho tài khoản.
        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeRoleChangeStatus(int id, int status)
        {
            var res = await _repos.ChangeStatus(id, status);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(2, 2, res, res));
        }

        // PUT api/<ValuesController>.
        // Cập nhật permission cho user.
        [HttpPost("ChangePermission")]
        public async Task<IActionResult> ChangePermission(int id, string? permission)
        {
            permission = (string.IsNullOrEmpty(permission)) ?"":permission;
            var res = await _repos.ChangePermission(id, permission);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(2, 2, res, res));
        }

        // GET api/<Admin>/Detail/5
        // Lấy dữ liệu API theo id không bị xóa.
        [HttpGet("Detail/{id}")]

        public async Task<IActionResult> Detail(int id)
        {
            var res = await _repos.GetAdmin(id);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(1, 0, 0, res));
        }

        // POST api/<Admin>/Add
        // Thêm mới dữ liệu.
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DTOAdmin admin)
        {
            var res = await _repos.AddAdmin(admin);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(2, 1, res, res));
        }

        // PUT api/<Admin>/Update/5
        // Cập nhập dữ liệu theo id.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOAdminInfo admin)
        {
            var res = await _repos.UpdateAdmin(id, admin);

            //Tra dữ liệu cho FE.
            return Ok(CheckingResult(2, 2, res, res));
        }

        // DELETE api/<Admin>/Delete/5
        // Xóa dữ liệu theo id.
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _repos.DeleteAdmin(id);

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
                else if (number == 0) //Dữ liệu đã tồn tại.
                {
                    mess = action + "not found.";
                }
                else if (number == 2) //Nếu không kiếm được id cần để thực hiện chức năng.
                {
                    mess = "New password has been send to your email.";
                }
                else if (number == -2) //Nếu không kiếm được id cần để thực hiện chức năng.
                {
                    mess = "Username already exist.";
                }
                else if (number == -3) //Password mới không được trùng với password cũ.
                {
                    mess = "New Password can't be the same with Old Password.";
                }
                else if (number == -4) //Tài khoản admin đã tồn tại
                {
                    mess = "Admin account already exist.";
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
