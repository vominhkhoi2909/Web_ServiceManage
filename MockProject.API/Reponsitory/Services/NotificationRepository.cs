using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class NotificationRepository : INotificationRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public NotificationRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xứ lý dữ liệu cho API
        public async Task<List<DTOGetNotification>> GetNotification()
        {
            try
            {
                List<DTOGetNotification> res = new List<DTOGetNotification>();
                var notifi = await _context.tNotifications.Where(m => m.Status == 1).OrderByDescending(m => m.NotifId).ToListAsync();

                foreach (var item in notifi)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.CreateBy).FirstOrDefaultAsync();
                    var user = await _context.Users.Where(m => m.Id == item.SendTo).FirstOrDefaultAsync();

                    DTOGetNotification itemList = new DTOGetNotification();

                    itemList.NotifId = item.NotifId;

                    TimeZoneInfo vn = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                    DateTime vnDatetime = TimeZoneInfo.ConvertTimeFromUtc(item.CreateAt, vn);
                    itemList.CreateAt = vnDatetime;

                    itemList.Title = item.Title;
                    itemList.Type = item.Type;
                    itemList.Image = item.Image;
                    itemList.Description = item.Description;
                    itemList.CreateBy = item.CreateBy;
                    itemList.SendTo = item.SendTo;
                    itemList.Link = item.Link;
                    if (admin != null)
                    {
                        itemList.Admin_Name = admin.FullName;
                        itemList.Admin_Email = admin.Email;
                        itemList.Admin_Avatar = admin.Avatar;
                    }
                    if (admin != null)
                    {
                        itemList.User_Name = user.Name;
                        itemList.User_Email = user.Email;
                        itemList.User_Avatar = user.Avatar;
                    }

                    res.Add(itemList);
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<DTOGetNotification>> GetTrash()
        {
            try
            {
                List<DTOGetNotification> res = new List<DTOGetNotification>();
                var notifi = await _context.tNotifications.Where(m => m.Status == 0).OrderByDescending(m => m.NotifId).ToListAsync();

                foreach (var item in notifi)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.CreateBy).FirstOrDefaultAsync();
                    var user = await _context.Users.Where(m => m.Id == item.SendTo).FirstOrDefaultAsync();

                    DTOGetNotification itemList = new DTOGetNotification();

                    itemList.NotifId = item.NotifId;
                    itemList.CreateAt = item.CreateAt;
                    itemList.Title = item.Title;
                    itemList.Type = item.Type;
                    itemList.Image = item.Image;
                    itemList.Description = item.Description;
                    itemList.CreateBy = item.CreateBy;
                    itemList.SendTo = item.SendTo;
                    itemList.Link = item.Link;
                    if (admin != null)
                    {
                        itemList.Admin_Name = admin.FullName;
                        itemList.Admin_Email = admin.Email;
                        itemList.Admin_Avatar = admin.Avatar;
                    }
                    if (admin != null)
                    {
                        itemList.User_Name = user.Name;
                        itemList.User_Email = user.Email;
                        itemList.User_Avatar = user.Avatar;
                    }

                    res.Add(itemList);
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<DTOGetNotification>> GetSearch(string key)
        {
            try
            {
                List<DTOGetNotification> res = new List<DTOGetNotification>();
                var notifi = await _context.tNotifications.Where(m => m.Status == 1).OrderByDescending(m => m.NotifId).ToListAsync();

                foreach (var item in notifi)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.CreateBy).FirstOrDefaultAsync();
                    var user = await _context.Users.Where(m => m.Id == item.SendTo).FirstOrDefaultAsync();

                    if (admin != null && (admin.FullName.Contains(key) || admin.Email.Contains(key)) ||
                        user != null && (user.Name.Contains(key) || user.Email.Contains(key)) ||
                        item.Title.Contains(key))
                    {
                        DTOGetNotification itemList = new DTOGetNotification();

                        itemList.NotifId = item.NotifId;
                        itemList.CreateAt = item.CreateAt;
                        itemList.Title = item.Title;
                        itemList.Type = item.Type;
                        itemList.Image = item.Image;
                        itemList.Description = item.Description;
                        itemList.CreateBy = item.CreateBy;
                        itemList.SendTo = item.SendTo;
                        itemList.Link = item.Link;
                        if (admin != null)
                        {
                            itemList.Admin_Name = admin.FullName;
                            itemList.Admin_Email = admin.Email;
                            itemList.Admin_Avatar = admin.Avatar;
                        }
                        if (admin != null)
                        {
                            itemList.User_Name = user.Name;
                            itemList.User_Email = user.Email;
                            itemList.User_Avatar = user.Avatar;
                        }

                        res.Add(itemList);
                    }
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<DTOGetNotification>> GetNotificationType(int type)
        {
            try
            {
                List<DTOGetNotification> res = new List<DTOGetNotification>();
                var notifi = await _context.tNotifications.Where(m => m.Status == 1 && m.Type == type).OrderByDescending(m => m.NotifId).ToListAsync();

                foreach (var item in notifi)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.CreateBy).FirstOrDefaultAsync();
                    var user = await _context.Users.Where(m => m.Id == item.SendTo).FirstOrDefaultAsync();

                    DTOGetNotification itemList = new DTOGetNotification();

                    itemList.NotifId = item.NotifId;
                    itemList.CreateAt = item.CreateAt;
                    itemList.Title = item.Title;
                    itemList.Type = item.Type;
                    itemList.Image = item.Image;
                    itemList.Description = item.Description;
                    itemList.CreateBy = item.CreateBy;
                    itemList.SendTo = item.SendTo;
                    itemList.Link = item.Link;
                    if (admin != null)
                    {
                        itemList.Admin_Name = admin.FullName;
                        itemList.Admin_Email = admin.Email;
                        itemList.Admin_Avatar = admin.Avatar;
                    }
                    if (admin != null)
                    {
                        itemList.User_Name = user.Name;
                        itemList.User_Email = user.Email;
                        itemList.User_Avatar = user.Avatar;
                    }

                    res.Add(itemList);
                }

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lỗi.
                return null;
            }
        }

        #region Chi tiết
        public async Task<Notification> GetNotification(int id)
        {
            try
            {
                var res = await _context.tNotifications.Where(m => m.NotifId == id).FirstOrDefaultAsync();

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lỗi.
                return null;
            }
        }
        public async Task<List<DTOGetNotification>> GetNotificationByUserId(string id)
        {
            try
            {
                List<DTOGetNotification> res = new List<DTOGetNotification>();
                var notifi = await _context.tNotifications.Where(m => m.SendTo == id).ToListAsync();

                foreach (var item in notifi)
                {
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.CreateBy).FirstOrDefaultAsync();
                    var user = await _context.Users.Where(m => m.Id == item.SendTo).FirstOrDefaultAsync();

                    DTOGetNotification itemList = new DTOGetNotification();

                    itemList.NotifId = item.NotifId;

                    TimeZoneInfo vn = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                    DateTime vnDatetime = TimeZoneInfo.ConvertTimeFromUtc(item.CreateAt, vn);
                    itemList.CreateAt = vnDatetime;

                    itemList.Title = item.Title;
                    itemList.Type = item.Type;
                    itemList.Image = item.Image;
                    itemList.Description = item.Description;
                    itemList.CreateBy = item.CreateBy;
                    itemList.SendTo = item.SendTo;
                    itemList.Link = item.Link;
                    itemList.Status = item.Status;
                    if (admin != null)
                    {
                        itemList.Admin_Name = admin.FullName;
                        itemList.Admin_Email = admin.Email;
                        itemList.Admin_Avatar = admin.Avatar;
                    }
                    if (admin != null)
                    {
                        itemList.User_Name = user.Name;
                        itemList.User_Email = user.Email;
                        itemList.User_Avatar = user.Avatar;
                    }

                    res.Add(itemList);
                }

                return res.OrderByDescending(x => x.CreateAt).ToList();
            }
            catch (Exception ex)
            {
                // Truy vấn lỗi.
                return null;
            }
        }
        public async Task<List<DTOGetNotification>> GetNotificationByAdminUserId(int id)
        {
            try
            {
                List<DTOGetNotification> res = new List<DTOGetNotification>();
                var notifi = await _context.tNotifications.Where(m => m.SendTo == id.ToString()).ToListAsync();

                foreach (var item in notifi)
                {
                    var sendTo = Convert.ToInt32(item.SendTo);
                    var admin = await _context.tAdminUsers.Where(m => m.UserId == item.CreateBy).FirstOrDefaultAsync();
                    var user = await _context.tAdminUsers.Where(m => m.UserId == sendTo).FirstOrDefaultAsync();

                    DTOGetNotification itemList = new DTOGetNotification();

                    itemList.NotifId = item.NotifId;

                    TimeZoneInfo vn = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                    DateTime vnDatetime = TimeZoneInfo.ConvertTimeFromUtc(item.CreateAt, vn);
                    itemList.CreateAt = vnDatetime;

                    itemList.Title = item.Title;
                    itemList.Type = item.Type;
                    itemList.Image = item.Image;
                    itemList.Description = item.Description;
                    itemList.CreateBy = item.CreateBy;
                    itemList.SendTo = item.SendTo;
                    itemList.Link = item.Link;
                    itemList.Status = item.Status;
                    if (admin != null)
                    {
                        itemList.Admin_Name = admin.FullName;
                        itemList.Admin_Email = admin.Email;
                        itemList.Admin_Avatar = admin.Avatar;
                    }
                    if (admin != null)
                    {
                        itemList.User_Name = user.Username;
                        itemList.User_Email = user.Email;
                        itemList.User_Avatar = user.Avatar;
                    }

                    res.Add(itemList);
                }

                return res.OrderByDescending(x => x.CreateAt).ToList();
            }
            catch (Exception ex)
            {
                // Truy vấn lỗi.
                return null;
            }
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        public int AddNotification(DTONotification value)
        {
            try
            {
                Notification notifi = new Notification();

                //if (CheckData(0, value.Type, value.Title))
                //{
                notifi.CreateAt = DateTime.UtcNow;
                notifi.Title = value.Title;
                notifi.Description = value.Description;
                notifi.Image = value.Image;
                notifi.Image = value.Image;
                notifi.Type = value.Type;
                notifi.SendTo = value.SendTo;
                notifi.CreateBy = value.CreateBy;
                notifi.Link = value.Link;
                notifi.Status = 1;
                _context.tNotifications.Add(notifi);
                _context.SaveChanges();

                return 1;
                //}

                //return -8;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int UpdateNotification(int id, DTONotification value)
        {
            try
            {
                var notifi = _context.tNotifications.Where(m => m.Status == 1 && m.NotifId == id).FirstOrDefault();

                if (notifi != null)
                {
                    if (CheckData(id, value.Type, value.Title))
                    {
                        notifi.Title = value.Title;
                        notifi.Description = value.Description;
                        notifi.Image = value.Image;
                        notifi.Image = value.Image;
                        notifi.Type = value.Type;
                        notifi.SendTo = value.SendTo;
                        notifi.CreateBy = value.CreateBy;
                        notifi.Link = value.Link;
                        notifi.Status = 1;
                        _context.tNotifications.Update(notifi);
                        _context.SaveChanges();

                        return 1;
                    }

                    return -8;
                }

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> ReadNotification(int id)
        {
            try
            {
                var notifi = await _context.tNotifications.Where(m => m.Status == 1 && m.NotifId == id).FirstOrDefaultAsync();

                if (notifi != null)
                {
                    notifi.Status = 0;
                    _context.tNotifications.Update(notifi);
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

        public async Task<int> ReadAllNotification(int id)
        {
            try
            {
                var notifi = await _context.tNotifications.Where(m => m.Status == 1 && m.SendTo == id.ToString()).ToListAsync();

                if (notifi != null)
                {
                    foreach (var item in notifi)
                    {
                        item.Status = 0;
                        _context.tNotifications.Update(item);
                    }
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
        private bool CheckData(int id, int type, string name)
        {
            //Id == 0 là thêm mới.
            if (id == 0)
            {
                var check = _context.tNotifications.Where(m => m.Type == type && m.Title == name && m.Status == 1).FirstOrDefault();

                if (check == null)
                {
                    return true;
                }
            }
            else
            {
                var check = _context.tNotifications.Where(m => m.NotifId != id && m.Type == type && m.Title == name && m.Status == 1).FirstOrDefault();

                if (check == null)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
