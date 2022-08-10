using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace MockProject.API.Reponsitory.Services
{
    public class AdminRepository : IAdminRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;
        private IConfiguration _configuration;
        private IMailRepository _mail;

        public AdminRepository(iHomeContext context, IConfiguration configuration, IMailRepository mail)
        {
            _context = context;
            _configuration = configuration;
            _mail = mail;
        }
        #endregion

        #region Xử lý dữ liệu cho API

        #region Lấy danh sách dữ liệu
        public async Task<List<DTOGetAdmin>> GetAdmin()
        {
            List<DTOGetAdmin> res = new List<DTOGetAdmin>();
            var admin = await _context.tAdminUsers.Where(m => m.Status == 1).OrderByDescending(m => m.UserId).ToListAsync();

            foreach (var item in admin)
            {
                var role = await _context.tRoles.Where(m => m.RoleId == item.RoleId).FirstOrDefaultAsync();

                DTOGetAdmin itemList = new DTOGetAdmin();

                itemList.UserId = item.UserId;
                itemList.FullName = item.FullName;
                itemList.Phone = item.Phone;
                itemList.Email = item.Email;
                itemList.Address = item.Address;
                itemList.Avatar = item.Avatar;
                itemList.RoleId = item.RoleId;
                itemList.Username = item.Username;
                itemList.status = item.Status;

                var total = sale(item.UserId, null, null);
                itemList.TotalOrder = total[1];
                itemList.TotalPoint = Convert.ToInt32(total[0]);


                if (role != null)
                {
                    itemList.Role_Name = role.Name;
                }

                res.Add(itemList);
            }

            return res;
        }

        public async Task<List<DTOGetAdmin>> GetTrash()
        {
            List<DTOGetAdmin> res = new List<DTOGetAdmin>();
            var admin = await _context.tAdminUsers.Where(m => m.Status == 0).OrderByDescending(m => m.UserId).ToListAsync();

            foreach (var item in admin)
            {
                var role = await _context.tRoles.Where(m => m.RoleId == item.RoleId).FirstOrDefaultAsync();

                DTOGetAdmin itemList = new DTOGetAdmin();

                itemList.UserId = item.UserId;
                itemList.FullName = item.FullName;
                itemList.Phone = item.Phone;
                itemList.Email = item.Email;
                itemList.Address = item.Address;
                itemList.Avatar = item.Avatar;
                itemList.RoleId = item.RoleId;
                itemList.Username = item.Username;
                itemList.status = item.Status;

                var total = sale(item.UserId, null, null);
                itemList.TotalOrder = total[1];
                itemList.TotalPoint = Convert.ToInt32(total[0]);

                if (role != null)
                {
                    itemList.Role_Name = role.Name;
                }

                res.Add(itemList);
            }

            return res;
        }

        public async Task<List<DTOGetAdmin>> GetAdminRole(int roleId)
        {
            List<DTOGetAdmin> res = new List<DTOGetAdmin>();
            var admin = await _context.tAdminUsers.Where(m => m.Status == 1 && m.RoleId == roleId).OrderByDescending(m => m.UserId).ToListAsync();

            foreach (var item in admin)
            {
                var role = await _context.tRoles.Where(m => m.RoleId == item.RoleId).FirstOrDefaultAsync();

                DTOGetAdmin itemList = new DTOGetAdmin();

                itemList.UserId = item.UserId;
                itemList.FullName = item.FullName;
                itemList.Phone = item.Phone;
                itemList.Email = item.Email;
                itemList.Address = item.Address;
                itemList.Avatar = item.Avatar;
                itemList.RoleId = item.RoleId;
                itemList.Username = item.Username;
                itemList.status = item.Status;

                var total = sale(item.UserId, null, null);
                itemList.TotalOrder = total[1];
                itemList.TotalPoint = Convert.ToInt32(total[0]);

                if (role != null)
                {
                    itemList.Role_Name = role.Name;
                }

                res.Add(itemList);
            }

            return res;
        }

        public async Task<List<DTOGetAdminSale>> GetStaffSale(DateTime? start, DateTime? end)
        {
            try
            {
                //Lưu trữ danh sách kết quả.
                List<DTOGetAdminSale> res = new List<DTOGetAdminSale>();
                //Danh sách staff ngoại trừ admin.
                var admin = await _context.tAdminUsers.Where(m => m.Status == 1 && m.RoleId == 2).ToListAsync();

                //Set thời gian là cuối ngày cho end time.
                if (end != null)
                {
                    end = new DateTime(end.Value.Year, end.Value.Month, end.Value.Day, 23, 59, 00);
                }

                //Dựa trên id staff lấy danh sách thông tin và lưu tình trạng doanh thu của staff đó trong khoảng thời gian.
                foreach (var item in admin)
                {
                    var role = await _context.tRoles.Where(m => m.RoleId == item.RoleId).FirstOrDefaultAsync();

                    DTOGetAdminSale itemList = new DTOGetAdminSale();

                    itemList.UserId = item.UserId;
                    itemList.FullName = item.FullName;
                    itemList.Phone = item.Phone;
                    itemList.Email = item.Email;
                    itemList.Address = item.Address;
                    itemList.Avatar = item.Avatar;
                    itemList.RoleId = item.RoleId;
                    itemList.Username = item.Username;
                    itemList.status = item.Status;

                    var total = sale(item.UserId, start, end);
                    itemList.TotalOrder = total[1];
                    itemList.TotalPoint = Convert.ToInt32(total[0]);
                    itemList.CountOrder = Convert.ToInt32(total[2]);

                    if (role != null)
                    {
                        itemList.Role_Name = role.Name;
                    }

                    res.Add(itemList);
                }

                //Sắp xếp lại danh sách theo thứ tự doanh thu của staff.
                var result = res.OrderByDescending(m => m.TotalOrder).ToList();


                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<DTOGetDashboard> GetDashboard(int? year)
        {
            try
            {
                DTOGetDashboard res = new DTOGetDashboard();
                var admin = await _context.tAdminUsers.Where(m => m.Status == 1).ToListAsync();
                var customer = await _context.tUsers.Where(m => m.Status == 1).ToListAsync();
                var jo = year != null ?
                    await _context.tJobOrders.Where(m => m.Status == 1 && m.StartAt.Year == year).ToListAsync() :
                    await _context.tJobOrders.Where(m => m.Status == 1 && m.StartAt.Year == DateTime.Now.Year).ToListAsync();
                int[] count = { 0, 0, 0, 0, 0, 0 };

                foreach (var item in jo)
                {
                    // Đếm số đơn dựa trên state.
                    count[Convert.ToInt32(item.State)]++;
                }

                // Tổng doanh thu từng tháng trong năm.
                for (int i = 1; i <= 12; i++)
                {
                    res.TotalMonth[i] = sale(i, year);
                    res.TotalMonth[0] += res.TotalMonth[i];
                }

                res.CountStaff = admin.Count;
                res.CountCustomer = customer.Count;
                res.CountJobOrder = jo.Count;
                res.CountJobOrderCancel = count[3];
                res.CountJobOrderConfirm = count[2];
                res.CountJobOrderWaiting = count[1];
                res.CountJobOrderDone = count[4];
                res.CountJobOrderCheckin = count[5];

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Chi tiết
        public async Task<DTOGetAdmin?> GetAdmin(int id)
        {
            var item = await _context.tAdminUsers.Where(m => m.Status == 1 && m.UserId == id).FirstOrDefaultAsync();
            if (item == null) return null;
            var role = await _context.tRoles.Where(m => m.RoleId == item.RoleId).FirstOrDefaultAsync();

            DTOGetAdmin res = new DTOGetAdmin();

            res.UserId = item.UserId;
            res.Username = item.Username;
            res.FullName = item.FullName;
            res.Phone = item.Phone;
            res.Email = item.Email;
            res.Address = item.Address;
            res.Avatar = item.Avatar;
            res.RoleId = item.RoleId;
            res.Username = item.Username;
            res.status = item.Status;
            res.Permission = item.Permission;

            var total = sale(item.UserId, null, null);
            res.TotalOrder = total[1];
            res.TotalPoint = Convert.ToInt32(total[0]);

            if (role != null)
            {
                res.Role_Name = role.Name;
            }
            return res;
        }
        #endregion

        #region Admin login
        // Generate token when login
        private Tuple<string, DateTime> GenerateToken(AdminUser user, string role)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("Username", user.Username),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration["JWT:KeyAdmin"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:IssuerAdmin"],
                audience: _configuration["JWT:AudienceAdmin"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new Tuple<string, DateTime>(jwt, token.ValidTo);
        }
        // Create password hash
        private void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }
        }

        // Check password hash (password correct or not)
        private bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            var passwordSaltBytes = Convert.FromBase64String(passwordSalt);
            using (var hmac = new HMACSHA512(passwordSaltBytes))
            {
                var computedHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
                return computedHash == passwordHash;
            }
        }
        // Main login logic
        public async Task<ResponseModel> Login(AdminLoginViewModel model)
        {
            // Check if user exist
            var user = await _context.tAdminUsers.FirstOrDefaultAsync(x => x.Username.Equals(model.Username));
            if (user == null)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "User not found"
                };
            }
            // Check if user password correct
            if (!VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "Invalid password"
                };
            }
            // Generate JWT token if everything correct
            var roleName = (await _context.tRoles.FirstOrDefaultAsync(x => x.RoleId == user.RoleId))?.Name ?? "";
            var token = GenerateToken(user, roleName);
            return new ResponseModel()
            {
                Success = true,
                Message = "Admin login success",
                Data = new
                {
                    token = token.Item1,
                    expire = token.Item2
                }
            };
        }
        #endregion

        public async Task<int> ChangePassword(int userId, string oldPassword, string newPassword)
        {
            try
            {
                var id = Convert.ToInt32(userId);
                var adminUser = await _context.tAdminUsers.Where(m => m.Status == 1 && m.UserId == userId).FirstOrDefaultAsync();

                if (adminUser != null)
                {
                    if (VerifyPasswordHash(oldPassword, adminUser.PasswordHash, adminUser.PasswordSalt))
                    {
                        if (oldPassword != newPassword)
                        {
                            var valid = Regex.IsMatch(newPassword, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,50}$");
                            if (!valid) return -4;
                            CreatePasswordHash(newPassword, out string passwordHash, out string passwordSalt);
                            adminUser.PasswordHash = passwordHash;
                            adminUser.PasswordSalt = passwordSalt;
                            adminUser.Status = 1;
                            _context.tAdminUsers.Update(adminUser);
                            await _context.SaveChangesAsync();

                            return 1;
                        }

                        return -3;
                    }

                    return -2;

                }

                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<ResponseModel> ForgotPassword(string email)
        {
            try
            {
                var user = await _context.tAdminUsers.FirstOrDefaultAsync(x => x.Email.Equals(email));
                if (user == null)
                    return new ResponseModel()
                    {
                        Success = false,
                        Message = "User not found"
                    };
                // Random letter for token
                string letter = new string("qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890");
                string token = "";
                var rand = new Random();
                for (int i = 0; i < 64; i++)
                {
                    token += letter[rand.Next(0, letter.Length)];
                }
                // Save token to DB
                user.ResetToken = token;
                user.ResetTokenExpire = DateTime.Now.AddDays(1);
                _context.tAdminUsers.Update(user);
                await _context.SaveChangesAsync();
                // Prepair email and send
                string url = $"{_configuration["ClientUrl"]}/Admin/Login/ResetPassword?userid={user.UserId}&token={token}";
                await _mail.SendMail(user.Email, "Reset your password", $"<h1>Reset your password</h1><p><span style='font-size:15.6px'>You have requested to reset your password.</span></p><p><span style='font-size:15.6px'>Please use this link to reset password: <b><a href='{url}'>Click here</a></b></span></p><p><span style='font-size:15.6px'>If you didn't request that, you could ignore this email</span></p>");
                return new ResponseModel()
                {
                    Success = true,
                    Message = "New password has been send to your email"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseModel> ResetPassword(AdminResetPasswordModel model)
        {
            // Check if user exist
            var id = Convert.ToInt32(model.UserId);
            var user = await _context.tAdminUsers.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "User not exist"
                };
            }
            // Check if password strong enough
            if (!Regex.IsMatch(model.NewPassword, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,50}$"))
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "Password must have at least 1 upper char, 1 lower char, 1 digit and 1 special char and between 8-50 char"
                };
            }
            // Check if 2 password match
            if (!model.NewPassword.Equals(model.ConfirmPassword))
            {
                return new ResponseModel()
                {
                    Success = false,
                    Message = "Password doesn't match"
                };
            }
            // Check if token correct
            if (user.ResetToken != null && user.ResetToken.Equals(model.Token)
                && user.ResetTokenExpire != null && user.ResetTokenExpire >= DateTime.Now)
            {
                try
                {
                    // Set new password for that user
                    CreatePasswordHash(model.NewPassword, out string passHash, out string passSalt);
                    user.PasswordHash = passHash;
                    user.PasswordSalt = passSalt;
                    // Remove token
                    user.ResetToken = null;
                    user.ResetTokenExpire = null;
                    _context.tAdminUsers.Update(user);
                    await _context.SaveChangesAsync();
                    return new ResponseModel()
                    {
                        Success = true,
                        Message = "Reset password success"
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseModel()
                    {
                        Success = false,
                        Message = ex.Message
                    };
                }
            }
            // If not then show invalid message
            return new ResponseModel()
            {
                Success = false,
                Message = "Invalid token"
            };
        }

        public async Task<int> ChangeStatus(int userId, int status)
        {
            try
            {
                var adminUser = await _context.tAdminUsers.Where(m => m.UserId == userId).FirstOrDefaultAsync();

                if (adminUser != null)
                {
                    adminUser.Status = status;
                    _context.tAdminUsers.Update(adminUser);
                    await _context.SaveChangesAsync();

                    return 1;
                }

                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> ChangePermission(int userId, string permission)
        {
            try
            {
                var adminUser = await _context.tAdminUsers.Where(m => m.UserId == userId).FirstOrDefaultAsync();

                if (adminUser != null)
                {
                    adminUser.Permission = permission;
                    _context.tAdminUsers.Update(adminUser);
                    await _context.SaveChangesAsync();

                    return 1;
                }

                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> UpdateInfo(int id, AdminUpdateInfoModel info)
        {
            try
            {
                var adminUser = await _context.tAdminUsers.Where(m => m.Status == 1 && m.UserId == id).FirstOrDefaultAsync();

                if (adminUser != null)
                {
                    adminUser.FullName = info.FullName;
                    adminUser.Phone = info.Phone;
                    adminUser.Email = info.Email;
                    adminUser.Address = info.Address;
                    adminUser.Avatar = string.IsNullOrEmpty(info.Avatar) ? adminUser.Avatar : info.Avatar;
                    _context.tAdminUsers.Update(adminUser);
                    _context.SaveChanges();

                    return 1;
                }

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        #region Add admin
        public async Task<int> AddAdmin(DTOAdmin value)
        {

            try
            {
                AdminUser adminUser = new AdminUser();

                if (await CheckData(0, value.Username))
                {
                    if (value.roleId == 1 && await _context.tAdminUsers.AnyAsync(x => x.RoleId == 1))
                    {
                        return -4;
                    }
                    adminUser.FullName = value.FullName;
                    adminUser.Phone = value.Phone;
                    adminUser.Email = value.Email;
                    adminUser.Address = value.Address;
                    adminUser.Username = value.Username;
                    CreatePasswordHash(value.Password, out string passwordHash, out string passwordSalt);
                    adminUser.PasswordHash = passwordHash;
                    adminUser.PasswordSalt = passwordSalt;
                    adminUser.Avatar = value.Avatar;
                    adminUser.Status = 1;
                    adminUser.RoleId = value.roleId;
                    await _context.tAdminUsers.AddAsync(adminUser);
                    await _context.SaveChangesAsync();

                    return 1;
                }

                return -2;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion

        #region Update admin
        public async Task<int> UpdateAdmin(int id, DTOAdminInfo value)
        {
            try
            {
                var adminUser = _context.tAdminUsers.Where(m => m.Status == 1 && m.UserId == id).FirstOrDefault();

                if (adminUser != null)
                {
                    adminUser.FullName = value.FullName;
                    adminUser.Phone = value.Phone;
                    adminUser.Email = value.Email;
                    adminUser.Address = value.Address;
                    adminUser.Avatar = value.Avatar;
                    adminUser.Status = 1;
                    // Admin có thể đổi mật khẩu cho những người khác
                    if (!string.IsNullOrEmpty(value.Password))
                    {
                        CreatePasswordHash(value.Password, out string passwordHash, out string passwordSalt);
                        adminUser.PasswordHash = passwordHash;
                        adminUser.PasswordSalt = passwordSalt;
                    }
                    _context.tAdminUsers.Update(adminUser);
                    await _context.SaveChangesAsync();

                    return 1;
                }

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion

        #region Delete admin
        public async Task<int> DeleteAdmin(int id)
        {
            try
            {
                var adminUser = await _context.tAdminUsers.Where(m => m.Status == 1 && m.UserId == id).FirstOrDefaultAsync();

                if (adminUser != null)
                {
                    adminUser.Status = 0;
                    _context.tAdminUsers.Update(adminUser);
                    await _context.SaveChangesAsync();

                    return 1;
                }

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion

        #endregion

        #region Check sự tồn tại của data
        private async Task<bool> CheckData(int id, string username)
        {
            //Id == 0 là thêm mới.
            if (id == 0)
            {
                var check = await _context.tAdminUsers.FirstOrDefaultAsync(m => m.Username == username && m.Status == 1);

                if (check == null)
                {
                    return true;
                }
            }
            else
            {
                var check = await _context.tAdminUsers.FirstOrDefaultAsync(m => m.UserId != id && m.Status == 1);

                if (check == null)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Other Function
        //Hàm tính tổng số điểm của staff / đơn hàng.
        public float[] sale(int staffId, DateTime? start, DateTime? end)
        {
            //res[0] là total point. res[1] là total price.
            float[] res = { 0, 0, 0 };
            try
            {
                var jo = start != null && end != null ? _context.tJobOrders.Where(m => m.StaffId == staffId && m.State == 4 && m.StartAt >= start && m.StartAt <= end).ToList() : _context.tJobOrders.Where(m => m.StaffId == staffId && m.State == 4).ToList();

                foreach (var item in jo)
                {
                    var jod = _context.tJobOrderDetails.Where(m => m.JOId == item.JOId).ToList();
                    float price = 0;
                    foreach (var detail in jod)
                    {
                        //var service = _context.tServices.Where(m => m.ServiceId == detail.ServiceId).FirstOrDefault();
                        //price += service.Price * detail.Quantily;

                        price += detail.Price * detail.Quantily;
                    }
                    res[0] += Convert.ToInt32(price / 10);
                    res[1] += price;
                }
                res[2] = jo.Count;

                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public float sale(int month, int? year)
        {
            //res[0] là total point. res[1] là total price.
            float res = 0;
            try
            {
                var jo = year != null ?
                    _context.tJobOrders.Where(m => m.State == 4 && m.StartAt.Month == month && m.StartAt.Year == year).ToList() :
                    _context.tJobOrders.Where(m => m.State == 4 && m.StartAt.Month == month && m.StartAt.Year == DateTime.Now.Year).ToList();

                foreach (var item in jo)
                {
                    var jod = _context.tJobOrderDetails.Where(m => m.JOId == item.JOId).ToList();

                    float price = 0;

                    foreach (var detail in jod)
                    {
                        //var service = _context.tServices.Where(m => m.ServiceId == detail.ServiceId).FirstOrDefault();
                        //price += service.Price * detail.Quantily;

                        price += detail.Price * detail.Quantily;
                    }

                    res += price;
                }

                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
