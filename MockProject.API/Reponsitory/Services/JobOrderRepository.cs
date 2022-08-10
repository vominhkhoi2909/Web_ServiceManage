using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class JobOrderRepository : IJobOrderRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public JobOrderRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xử lý dữ liệu cho API

        #region Danh sách dữ liệu
        // Lấy tất cả ds active.
        public async Task<List<DTOGetJobOrder>> GetJobOrder()
        {
            try
            {
                // Lưu lại mảng dữ liệu trả về client.
                List<DTOGetJobOrder> res = new List<DTOGetJobOrder>();
                // Lấy tất cả ds.
                var jobOrder = await _context.tJobOrders.Where(m => m.Status == 1).OrderByDescending(m => m.JOId).ToListAsync();

                // Chuyển ds lấy được sang ds trả về + thêm trường tên của các khóa ngoại.
                foreach (var item in jobOrder)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.StaffId).FirstOrDefaultAsync();
                    var user = await _context.Users.Where(m => m.Id == item.CustomerId).FirstOrDefaultAsync();
                    var joDetail = await _context.tJobOrderDetails.Where(m => m.JOId == item.JOId).ToListAsync();

                    DTOGetJobOrder itemList = new DTOGetJobOrder();

                    itemList.totalPrice = 0;
                    itemList.JOId = item.JOId;
                    itemList.Duration = item.Duration;
                    itemList.StartAt = item.StartAt;
                    itemList.Address = item.Address;
                    itemList.State = item.State;
                    itemList.Description = item.Description;
                    itemList.StaffId = Convert.ToInt32(item.StaffId);
                    itemList.CustomerId = item.CustomerId;
                    if (admin != null)
                    {
                        itemList.Admin_Name = admin.FullName;
                        itemList.Admin_Email = admin.Email;
                        itemList.Admin_Avatar = admin.Avatar;
                    }
                    if (user != null)
                    {
                        itemList.User_Name = user.Name;
                        itemList.User_Email = user.Email;
                        itemList.User_Avatar = user.Avatar;
                    }
                    foreach (var itemDetail in joDetail)
                    {
                        //var service = await _context.tServices.Where(m => m.ServiceId == itemDetail.ServiceId).FirstOrDefaultAsync();
                        //itemList.totalPrice += itemDetail.Quantily * service.Price;

                        itemList.totalPrice += itemDetail.Quantily * itemDetail.Price;
                    }

                    res.Add(itemList);
                }

                // Trả ds về cho client.
                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn xảy ra lỗi.
                return null;
            }
        }

        // Lấy tất cả ds inactive.
        public async Task<List<DTOGetJobOrder>> GetTrash()
        {
            try
            {
                // Lưu lại mảng dữ liệu trả về client.
                List<DTOGetJobOrder> res = new List<DTOGetJobOrder>();
                // Lấy tất cả ds.
                var jobOrder = await _context.tJobOrders.Where(m => m.Status == 0).OrderByDescending(m => m.JOId).ToListAsync();

                // Chuyển ds lấy được sang ds trả về + thêm trường tên của các khóa ngoại.
                foreach (var item in jobOrder)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.StaffId).FirstOrDefaultAsync();
                    var user = await _context.Users.Where(m => m.Id == item.CustomerId).FirstOrDefaultAsync();
                    var joDetail = await _context.tJobOrderDetails.Where(m => m.JOId == item.JOId).ToListAsync();

                    DTOGetJobOrder itemList = new DTOGetJobOrder();

                    itemList.totalPrice = 0;
                    itemList.JOId = item.JOId;
                    itemList.Duration = item.Duration;
                    itemList.StartAt = item.StartAt;
                    itemList.Address = item.Address;
                    itemList.State = item.State;
                    itemList.Description = item.Description;
                    itemList.StaffId = Convert.ToInt32(item.StaffId);
                    itemList.CustomerId = item.CustomerId;
                    if (admin != null)
                    {
                        itemList.Admin_Name = admin.FullName;
                        itemList.Admin_Email = admin.Email;
                        itemList.Admin_Avatar = admin.Avatar;
                    }
                    if (user != null)
                    {
                        itemList.User_Name = user.Name;
                        itemList.User_Email = user.Email;
                        itemList.User_Avatar = user.Avatar;
                    }
                    foreach (var itemDetail in joDetail)
                    {
                        //var service = await _context.tServices.Where(m => m.ServiceId == itemDetail.ServiceId).FirstOrDefaultAsync();
                        //itemList.totalPrice += itemDetail.Quantily * service.Price;

                        itemList.totalPrice += itemDetail.Quantily * itemDetail.Price;
                    }

                    res.Add(itemList);
                }

                // Trả ds về cho client.
                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn xảy ra lỗi.
                return null;
            }
        }

        // Lấy tất cả ds theo id người dùng.
        public async Task<List<DTOGetJobOrder>> GetJobOrder(string id)
        {
            try
            {
                // Lưu lại mảng dữ liệu trả về client.
                List<DTOGetJobOrder> res = new List<DTOGetJobOrder>();
                // Lấy tất cả ds.
                var jobOrder = await _context.tJobOrders.Where(m => m.Status == 1 && m.CustomerId == id).OrderByDescending(m => m.JOId).ToListAsync();

                // Chuyển ds lấy được sang ds trả về + thêm trường tên của các khóa ngoại.
                foreach (var item in jobOrder)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.StaffId).FirstOrDefaultAsync();
                    var user = await _context.Users.Where(m => m.Id == item.CustomerId).FirstOrDefaultAsync();
                    var joDetail = await _context.tJobOrderDetails.Where(m => m.JOId == item.JOId).ToListAsync();

                    DTOGetJobOrder itemList = new DTOGetJobOrder();

                    itemList.totalPrice = 0;
                    itemList.JOId = item.JOId;
                    itemList.Duration = item.Duration;
                    itemList.StartAt = item.StartAt;
                    itemList.Address = item.Address;
                    itemList.State = item.State;
                    itemList.Description = item.Description;
                    itemList.StaffId = Convert.ToInt32(item.StaffId);
                    itemList.CustomerId = item.CustomerId;
                    if (admin != null)
                    {
                        itemList.Admin_Name = admin.FullName;
                        itemList.Admin_Email = admin.Email;
                        itemList.Admin_Avatar = admin.Avatar;
                    }
                    if (user != null)
                    {
                        itemList.User_Name = user.Name;
                        itemList.User_Email = user.Email;
                        itemList.User_Avatar = user.Avatar;
                    }
                    foreach (var itemDetail in joDetail)
                    {
                        //var service = await _context.tServices.Where(m => m.ServiceId == itemDetail.ServiceId).FirstOrDefaultAsync();
                        //itemList.totalPrice += itemDetail.Quantily * service.Price;

                        itemList.totalPrice += itemDetail.Quantily * itemDetail.Price;
                    }

                    res.Add(itemList);
                }

                // Trả ds về cho client.
                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn xảy ra lỗi.
                return null;
            }
        }

        // Lấy ds dữ liệu theo từ khóa.
        // Các từ khóa có thể lấy: Tên user / email / tên admin / địa chỉ / id order.
        public async Task<List<DTOGetJobOrder>> GetSearch(string key)
        {
            try
            {
                // Lưu lại mảng dữ liệu trả về client.
                List<DTOGetJobOrder> res = new List<DTOGetJobOrder>();
                // Lấy tất cả ds.
                var jobOrder = await _context.tJobOrders.Where(m => m.Status == 1).OrderByDescending(m => m.JOId).ToListAsync();

                // Chuyển ds lấy được sang ds trả về + thêm trường tên của các khóa ngoại.
                foreach (var item in jobOrder)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.StaffId).FirstOrDefaultAsync();
                    var user = await _context.Users.Where(m => m.Id == item.CustomerId).FirstOrDefaultAsync();
                    var joDetail = await _context.tJobOrderDetails.Where(m => m.JOId == item.JOId).ToListAsync();

                    // Kiểm tra dữ liệu các trường càn tím kiếm có thỏa từ khóa tìm kiếm.
                    if (admin != null && (admin.FullName.Contains(key) || admin.Email.Contains(key)) ||
                        user != null && (user.Name.Contains(key) || user.Email.Contains(key)) ||
                        item.Address.Contains(key) || item.JOId.ToString() == key)
                    {
                        DTOGetJobOrder itemList = new DTOGetJobOrder();

                        itemList.totalPrice = 0;
                        itemList.JOId = item.JOId;
                        itemList.Duration = item.Duration;
                        itemList.StartAt = item.StartAt;
                        itemList.Address = item.Address;
                        itemList.State = item.State;
                        itemList.Description = item.Description;
                        itemList.StaffId = Convert.ToInt32(item.StaffId);
                        itemList.CustomerId = item.CustomerId;
                        if (admin != null)
                        {
                            itemList.Admin_Name = admin.FullName;
                            itemList.Admin_Email = admin.Email;
                            itemList.Admin_Avatar = admin.Avatar;
                        }
                        if (user != null)
                        {
                            itemList.User_Name = user.Name;
                            itemList.User_Email = user.Email;
                            itemList.User_Avatar = user.Avatar;
                        }
                        foreach (var itemDetail in joDetail)
                        {
                            //var service = await _context.tServices.Where(m => m.ServiceId == itemDetail.ServiceId).FirstOrDefaultAsync();
                            //itemList.totalPrice += itemDetail.Quantily * service.Price;

                            itemList.totalPrice += itemDetail.Quantily * itemDetail.Price;
                        }

                        res.Add(itemList);
                    }
                }

                // Trả ds về cho client.
                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn xảy ra lỗi.
                return null;
            }
        }
        #endregion

        #region Chi tiết
        //Xem chi tiết job order.
        public async Task<DTOGetJobOrder> GetJobOrders(int id)
        {
            try
            {
                // Lấy Comment theo id.
                var jo = await _context.tJobOrders.Where(m => m.Status == 1 && m.JOId == id).FirstOrDefaultAsync();

                if (jo != null)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == jo.StaffId).FirstOrDefaultAsync();
                    var user = await _context.Users.Where(m => m.Id == jo.CustomerId).FirstOrDefaultAsync();
                    var joDetail = await _context.tJobOrderDetails.Where(m => m.JOId == jo.JOId).ToListAsync();

                    DTOGetJobOrder itemList = new DTOGetJobOrder();

                    itemList.totalPrice = 0;
                    itemList.JOId = jo.JOId;
                    itemList.Duration = jo.Duration;
                    itemList.StartAt = jo.StartAt;
                    itemList.Address = jo.Address;
                    itemList.State = jo.State;
                    itemList.Description = jo.Description;
                    itemList.StaffId = Convert.ToInt32(jo.StaffId);
                    itemList.CustomerId = jo.CustomerId;
                    if (admin != null)
                    {
                        itemList.Admin_Name = admin.FullName;
                        itemList.Admin_Email = admin.Email;
                        itemList.Admin_Avatar = admin.Avatar;
                    }
                    if (user != null)
                    {
                        itemList.User_Name = user.Name;
                        itemList.User_Email = user.Email;
                        itemList.User_Avatar = user.Avatar;
                    }
                    foreach (var itemDetail in joDetail)
                    {
                        //var service = await _context.tServices.Where(m => m.ServiceId == itemDetail.ServiceId).FirstOrDefaultAsync();
                        //itemList.totalPrice += itemDetail.Quantily * service.Price;

                        itemList.totalPrice += itemDetail.Quantily * itemDetail.Price;
                    }

                    // Trả dữ liệu về client.
                    return itemList;
                }

                return null;
            }
            catch (Exception ex)
            {
                //Truy vấn xảy ra lỗi.
                return null;
            }
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        //Thêm mới 1 job order.
        public int AddJobOrder(DTOJobOrder value, string customerId)
        {
            try
            {
                JobOrder jo = new JobOrder();
                //Lấy thông tin customer để check xem có tồn tại k.
                var customer = _context.tUsers.Where(m => m.Id == customerId && m.Status == 1).FirstOrDefault();

                if (customer != null)
                {
                    if (value.StartAt > DateTime.Now)
                    {
                        jo.Duration = value.Duration;
                        jo.StartAt = value.StartAt;
                        jo.Address = value.Address;
                        jo.Description = value.Description;
                        jo.State = 1;
                        jo.CustomerId = customerId;
                        jo.Status = 1;
                        _context.tJobOrders.Add(jo);
                        _context.SaveChanges();

                        var res = _context.tJobOrders.OrderByDescending(m => m.JOId).FirstOrDefault();

                        return res.JOId; // Success trả về id.
                    }

                    return -7; //Ngày bắt đầu k dc nhỏ hơn ngày hiện tại.
                }

                return -5; // Customer k tồn tại.
            }
            catch (Exception ex)
            {
                return -1; // Fail.
            }
        }

        //Chỉnh sửa job order theo id.
        public int UpdateJobOrder(int id, DTOJobOrder value, int? staffId)
        {
            try
            {
                // Lấy thông tin jo theo id truyền vào và check.
                var jo = _context.tJobOrders.Where(m => m.Status == 1 && m.JOId == id).FirstOrDefault();

                if (jo != null)
                {
                    jo.Duration = value.Duration;
                    jo.Address = value.Address;
                    jo.Description = value.Description;
                    if (staffId != null)
                    {
                        jo.StaffId = Convert.ToInt32(staffId);
                    }
                    jo.Status = 1;
                    _context.tJobOrders.Update(jo);
                    _context.SaveChanges();

                    return 1; // Success.
                }

                return 0; // JO k tồn tại.
            }
            catch (Exception ex)
            {
                return -1; // Fail.
            }
        }

        //Cập nhật staff vào order (phần quyền staff quản lý order đó).
        public int AssignJobOrder(int id, int staffId)
        {
            try
            {
                var jo = _context.tJobOrders.Where(m => m.Status == 1 && m.JOId == id).FirstOrDefault();
                //Lấy thông tin staff để check xem có tồn tại k.
                var staff = _context.tAdminUsers.Where(m => m.Status == 1 && m.UserId == staffId).FirstOrDefault();

                if (jo != null)
                {
                    if (staff != null)
                    {
                        jo.StaffId = staffId;
                        jo.Status = 1;
                        _context.tJobOrders.Update(jo);
                        _context.SaveChanges();

                        return 1; // Success.
                    }

                    return -6; // Staff k tồn tại.
                }

                return 0; // JO k tồn tại.
            }
            catch (Exception ex)
            {
                return -1; // Fail.
            }
        }

        //Cập nhật trạng thái state.
        public int Cancel(int id)
        {
            try
            {
                //Lấy thông tin order theo id.
                var jo = _context.tJobOrders.Where(m => m.Status == 1 && m.JOId == id).FirstOrDefault();

                if (jo != null)
                {
                    jo.State = 3;
                    _context.tJobOrders.Update(jo);
                    _context.SaveChanges();

                    return 1; // Success.
                }

                return 0; // JO k tồn tại.
            }
            catch (Exception ex)
            {
                return -1; // Fail.
            }
        }

        //Cập nhật trạng thái state.
        public int Confirm(int id)
        {
            try
            {
                //Lấy thông tin order theo id.
                var jo = _context.tJobOrders.Where(m => m.Status == 1 && m.JOId == id).FirstOrDefault();

                if (jo != null)
                {
                    jo.State = 2;
                    _context.tJobOrders.Update(jo);
                    _context.SaveChanges();

                    return 1; // Success.
                }

                return 0; // JO k tồn tại.
            }
            catch (Exception ex)
            {
                return -1; // Fail.
            }
        }

        //Cập nhật trạng thái state.
        public int Checkout(int id)
        {
            try
            {
                //Lấy thông tin order theo id.
                var jo = _context.tJobOrders.Where(m => m.Status == 1 && m.JOId == id).FirstOrDefault();

                if (jo != null)
                {
                    jo.State = 4;
                    _context.tJobOrders.Update(jo);
                    _context.SaveChanges();

                    return 1; // Success.
                }

                return 0; // JO k tồn tại.
            }
            catch (Exception ex)
            {
                return -1; // Fail.
            }
        }

        //Cập nhật trạng thái state.
        public int Checkin(int id)
        {
            try
            {
                //Lấy thông tin order theo id.
                var jo = _context.tJobOrders.Where(m => m.Status == 1 && m.JOId == id).FirstOrDefault();

                if (jo != null)
                {
                    jo.State = 5;
                    _context.tJobOrders.Update(jo);
                    _context.SaveChanges();

                    return 1; // Success.
                }

                return 0; // JO k tồn tại.
            }
            catch (Exception ex)
            {
                return -1; // Fail.
            }
        }

        //Cập nhật trạng thái ngày.
        public int Postpone(int id, DateTime date)
        {
            try
            {
                //Lấy thông tin order theo id.
                var jo = _context.tJobOrders.Where(m => m.Status == 1 && m.JOId == id).FirstOrDefault();

                if (jo != null)
                {
                    if (DateTime.Now < date)
                    {
                        jo.StartAt = date;
                        _context.tJobOrders.Update(jo);
                        _context.SaveChanges();

                        return 1; // Success.
                    }

                    return -7; //Ngày bắt đầu k thể nhỏ nhỏ hơn ngày hiện tại.
                }

                return 0; // JO k tồn tại.
            }
            catch (Exception ex)
            {
                return -1; // Fail.
            }
        }

        //Xóa job order theo id.
        public int DeleteJobOrder(int id)
        {
            try
            {
                // Lấy thông tin jo theo id truyền vào và check.
                var JobOrder = _context.tJobOrders.Where(m => m.Status == 1 && m.JOId == id).FirstOrDefault();

                if (JobOrder != null)
                {
                    JobOrder.Status = 0;
                    _context.tJobOrders.Update(JobOrder);
                    _context.SaveChanges();

                    return 1; // Success.
                }

                return 0; // JO k tồn tại.

            }
            catch (Exception ex)
            {
                return -1; // Fail.
            }
        }
        #endregion

        #endregion
    }
}
