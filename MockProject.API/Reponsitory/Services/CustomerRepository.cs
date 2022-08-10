using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Init data
        private readonly iHomeContext _context;
        private UserManager<User> _userManager;
        private IMailRepository _mail;
        public CustomerRepository(DbContextOptions<iHomeContext> options, UserManager<User> userManager, IMailRepository mail)
        {
            _context = new iHomeContext(options);
            _userManager = userManager;
            _mail = mail;
        }
        #endregion

        #region Generate random password for Google login
        public string GeneratePassword()
        {
            var opts = new PasswordOptions()
            {
                RequiredLength = 12,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
        #endregion

        #region Add new customer
        public async Task<ResponseModel> Add(AddCustomerModel model)
        {
            try
            {
                // Create new customer
                var user = new User()
                {
                    UserName = model.Email,
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.Phone,
                    Email = model.Email,
                    WardId = model.WardId,
                    DistrictId = model.DistrictId,
                    CityId = model.CityId,
                    Avatar = model.Avatar
                };
                // Create random password for user
                var userPassword = GeneratePassword();
                // Return result
                var result = await _userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    //Send passsword to customer email
                    await _mail.SendMail(user.Email, "Password for login to your account", $"<h1>Admin have create your account for you</h1><p><span style='font-size:15.6px'>Your password to login to our service is: <b>{userPassword}</b></span></p>");
                    return new ResponseModel()
                    {
                        Success = true,
                        Message = "Add customer success"
                    };
                }
                return new ResponseModel()
                {
                    Success = false,
                    Message = string.Join(" ", result.Errors.Select(x => x.Description))
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
        #endregion

        #region Change status customer
        public async Task<ResponseModel> ChangeStatus(string userId, bool isActive)
        {
            try
            {
                // Get data from DB
                var user = await _userManager.FindByIdAsync(userId);
                // Check if user exist
                if (user == null)
                {
                    return new ResponseModel()
                    {
                        Success = false,
                        Message = "Customer not found"
                    };
                }
                // Change status of user
                user.Status = isActive ? 1 : 0;
                // Return result
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new ResponseModel()
                    {
                        Success = true,
                        Message = "Change status customer success"
                    };
                }
                return new ResponseModel()
                {
                    Success = false,
                    Message = string.Join(" ", result.Errors.Select(x => x.Description))
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
        #endregion

        #region Get all customer
        public async Task<ResponseModel> GetAll(string? searchString)
        {
            try
            {
                // Get data from DB
                var data = await _context.Users
                    .Where(x => string.IsNullOrEmpty(searchString)
                    || (x.Name == null ? false : x.Name.Contains(searchString))
                    || x.PhoneNumber.Contains(searchString)
                    || (x.Address == null ? false : x.Address.Contains(searchString))
                    || x.Email.Contains(searchString))
                    .ToListAsync();
                // Create list of DTO
                var list = new List<UserInfoModel>();
                foreach (var item in data)
                {
                    #region Tổng số tiền khách hàng đã từng book.
                    var jo = await _context.tJobOrders.Where(m => m.CustomerId == item.Id && m.State == 4).ToListAsync();
                    float totalPrice = 0;

                    foreach (var itemJO in jo)
                    {
                        var joDetail = await _context.tJobOrderDetails.Where(m => m.JOId == itemJO.JOId).ToListAsync();

                        foreach (var itemDetail in joDetail)
                        {
                            //var service = await _context.tServices.Where(m => m.ServiceId == itemDetail.ServiceId).FirstOrDefaultAsync();
                            //totalPrice += itemDetail.Quantily * service.Price;

                            totalPrice += itemDetail.Quantily * itemDetail.Price;
                        }
                    }
                    #endregion

                    // Map data from entity to DTO
                    var model = new UserInfoModel()
                    {
                        UserId = item.Id,
                        Name = item.Name,
                        Address = item.Address,
                        Phone = item.PhoneNumber,
                        Email = item.Email,
                        Avatar = item.Avatar,
                        Status = item.Status ?? 0,
                        CreateAt = item.CreateDate,
                        TotalPrice = totalPrice
                    };
                    list.Add(model);
                }
                // Return result
                return new ResponseModel()
                {
                    Success = true,
                    Message = "Get list customer success",
                    Data = list.OrderByDescending(x => x.CreateAt).ToList()
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
        #endregion

        #region Get 1 customer
        public async Task<ResponseModel> Get(string userId)
        {
            try
            {
                // Get data from DB
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
                // Check if user exist
                if (user == null)
                {
                    return new ResponseModel()
                    {
                        Success = false,
                        Message = "Customer not found"
                    };
                }

                #region Tổng số tiền khách hàng đã từng book.
                var jo = await _context.tJobOrders.Where(m => m.CustomerId == userId && m.State == 4).ToListAsync();
                float totalPrice = 0;

                foreach (var itemJO in jo)
                {
                    var joDetail = await _context.tJobOrderDetails.Where(m => m.JOId == itemJO.JOId).ToListAsync();

                    foreach (var itemDetail in joDetail)
                    {
                        //var service = await _context.tServices.Where(m => m.ServiceId == itemDetail.ServiceId).FirstOrDefaultAsync();
                        //totalPrice += itemDetail.Quantily * service.Price;

                        totalPrice += itemDetail.Quantily * itemDetail.Price;
                    }
                }
                #endregion


                // Map data from entity to DTO
                var model = new UserInfoModel()
                {
                    UserId = user.Id,
                    Name = user.Name,
                    Address = user.Address,
                    Phone = user.PhoneNumber,
                    Email = user.Email,
                    Avatar = user.Avatar,
                    Status = user.Status ?? 0
                };
                // Return result
                return new ResponseModel()
                {
                    Success = true,
                    Message = "Get customer success",
                    Data = model
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
        #endregion

        #region Update user
        public async Task<ResponseModel> Update(UpdateInfoModel model)
        {
            try
            {
                // Get data from DB
                var user = await _userManager.FindByIdAsync(model.UserId);
                // Check if user exist
                if (user == null || user.Status == 0)
                {
                    return new ResponseModel()
                    {
                        Success = false,
                        Message = "Customer not found"
                    };
                }
                // Change info of customer
                user.Name = model.Name;
                user.Address = model.Address;
                user.PhoneNumber = model.Phone;
                user.WardId = model.WardId;
                user.DistrictId = model.DistrictId;
                user.CityId = model.CityId;
                user.Avatar = string.IsNullOrEmpty(model.Avatar) ? user.Avatar : model.Avatar;
                // Return result
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new ResponseModel()
                    {
                        Success = true,
                        Message = "Update customer success"
                    };
                }
                return new ResponseModel()
                {
                    Success = false,
                    Message = string.Join(" ", result.Errors.Select(x => x.Description))
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
        #endregion
    }
}
