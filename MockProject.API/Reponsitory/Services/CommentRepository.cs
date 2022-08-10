using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class CommentRepository : ICommentRepository
    {
        #region Khai báo db.        
        // Khởi tạo biến kết nối tới model.
        private readonly iHomeContext _context;

        // Khởi tạo mặc định của class.
        public CommentRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xử lý dữ liệu cho API

        #region Lấy danh sách dữ liệu
        // Lấy tất cả ds active.
        public async Task<List<DTOGetComment>> GetComment()
        {
            try
            {
                // Lưu lại mảng dữ liệu trả về client.
                List<DTOGetComment> res = new List<DTOGetComment>();
                // Lấy tất cả ds.
                var comment = await _context.tComments.Where(m => m.Status == 1).OrderByDescending(m => m.CommentId).ToListAsync();

                // Chuyển ds lấy được sang ds trả về + thêm trường tên của các khóa ngoại.
                foreach (var item in comment)
                {
                    var user = await _context.tUsers.Where(m => m.Id == item.CreateBy).FirstOrDefaultAsync();
                    var notifi = await _context.tNotifications.Where(m => m.NotifId == item.NotifId).FirstOrDefaultAsync();

                    DTOGetComment itemList = new DTOGetComment();

                    itemList.CommentId = item.CommentId;
                    itemList.Comment_Title = item.Title;
                    itemList.NotifId = item.NotifId;
                    itemList.CreateAt = item.CreateAt;
                    itemList.CreateBy = item.CreateBy;
                    if (user != null)
                    {
                        itemList.FullName = user.Name;
                        itemList.Email = user.Email;
                        itemList.Avatar = user.Avatar;
                    }
                    if (notifi != null)
                    {
                        itemList.Notifi_Title = notifi.Title;
                    }

                    res.Add(itemList);
                }

                // Trả ds về cho client.
                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn xảy ra lỗi.
                return null;
            }
        }

        // Lấy ds theo id của notification.
        public async Task<List<DTOGetComment>> GetCommentNotifi(int noti)
        {
            try
            {
                // Lưu lại mảng dữ liệu trả về client.
                List<DTOGetComment> res = new List<DTOGetComment>();
                // Lấy tất cả ds theo id của notification.
                var comment = await _context.tComments.Where(m => m.Status == 1 && m.NotifId == noti).OrderByDescending(m => m.CommentId).ToListAsync();

                // Chuyển ds lấy được sang ds trả về + thêm trường tên của các khóa ngoại.
                foreach (var item in comment)
                {
                    var user = await _context.tUsers.Where(m => m.Id == item.CreateBy).FirstOrDefaultAsync();
                    var notifi = await _context.tNotifications.Where(m => m.NotifId == item.NotifId).FirstOrDefaultAsync();

                    DTOGetComment itemList = new DTOGetComment();

                    itemList.CommentId = item.CommentId;
                    itemList.Comment_Title = item.Title;
                    itemList.NotifId = item.NotifId;
                    itemList.CreateAt = item.CreateAt;
                    itemList.CreateBy = item.CreateBy;
                    if (user != null)
                    {
                        itemList.FullName = user.Name;
                        itemList.Email = user.Email;
                        itemList.Avatar = user.Avatar;
                    }
                    if (notifi != null)
                    {
                        itemList.Notifi_Title = notifi.Title;
                    }

                    res.Add(itemList);
                }

                // Trả ds về cho client.
                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn xảy ra lỗi.
                return null;
            }
        }

        // Lấy tất cả ds inactive.
        public async Task<List<DTOGetComment>> GetTrash()
        {
            try
            {
                // Lưu lại mảng dữ liệu trả về client.
                List<DTOGetComment> res = new List<DTOGetComment>();
                // Lấy tất cả ds.
                var comment = await _context.tComments.Where(m => m.Status == 0).OrderByDescending(m => m.CommentId).ToListAsync();

                // Chuyển ds lấy được sang ds trả về + thêm trường tên của các khóa ngoại.
                foreach (var item in comment)
                {
                    var user = await _context.tUsers.Where(m => m.Id == item.CreateBy).FirstOrDefaultAsync();
                    var notifi = await _context.tNotifications.Where(m => m.NotifId == item.NotifId).FirstOrDefaultAsync();

                    DTOGetComment itemList = new DTOGetComment();

                    itemList.CommentId = item.CommentId;
                    itemList.Comment_Title = item.Title;
                    itemList.NotifId = item.NotifId;
                    itemList.CreateAt = item.CreateAt;
                    itemList.CreateBy = item.CreateBy;
                    if (user != null)
                    {
                        itemList.FullName = user.Name;
                        itemList.Email = user.Email;
                        itemList.Avatar = user.Avatar;
                    }
                    if (notifi != null)
                    {
                        itemList.Notifi_Title = notifi.Title;
                    }

                    res.Add(itemList);
                }

                // Trả ds về cho client.
                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn xảy ra lỗi.
                return null;
            }
        }

        // Lấy ds dữ liệu theo từ khóa.
        // Các từ khóa có thể lấy: Tên user / email / notification title / comment title.
        public async Task<List<DTOGetComment>> GetSearch(string key)
        {
            try
            {
                // Lưu lại mảng dữ liệu trả về client.
                List<DTOGetComment> res = new List<DTOGetComment>();
                // Lấy tất cả ds.
                var comment = await _context.tComments.Where(m => m.Status == 1).OrderByDescending(m => m.CommentId).ToListAsync();

                // Chuyển ds lấy được sang ds trả về + thêm trường tên của các khóa ngoại.
                foreach (var item in comment)
                {
                    var user = await _context.tUsers.Where(m => m.Id == item.CreateBy).FirstOrDefaultAsync();
                    var notifi = await _context.tNotifications.Where(m => m.NotifId == item.NotifId).FirstOrDefaultAsync();

                    // Kiểm tra dữ liệu các trường càn tím kiếm có thỏa từ khóa tìm kiếm.
                    if (user != null && (user.Name.Contains(key) || user.Email.Contains(key)) || notifi != null && notifi.Title.Contains(key) || item.Title.Contains(key))
                    {
                        DTOGetComment itemList = new DTOGetComment();

                        itemList.CommentId = item.CommentId;
                        itemList.Comment_Title = item.Title;
                        itemList.NotifId = item.NotifId;
                        itemList.CreateAt = item.CreateAt;
                        itemList.CreateBy = item.CreateBy;
                        if (user != null)
                        {
                            itemList.FullName = user.Name;
                            itemList.Email = user.Email;
                            itemList.Avatar = user.Avatar;
                        }
                        if (notifi != null)
                        {
                            itemList.Notifi_Title = notifi.Title;
                        }

                        res.Add(itemList);
                    }
                }

                // Trả ds về cho client.
                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn xảy ra lỗi.
                return null;
            }
        }
        #endregion

        #region Xem chi tiết
        //Xem chi tiết comment.
        public async Task<Comment> GetComment(int id)
        {
            try
            {
                // Lấy Comment theo id.
                var res = await _context.tComments.Where(m => m.Status == 1 && m.CommentId == id).FirstOrDefaultAsync();

                // Trả dữ liệu về client.
                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn xảy ra lỗi.
                return null;
            }
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        //Thêm mới 1 comment.
        public int AddComment(DTOComment value)
        {
            try
            {
                Comment comment = new Comment();
                //Lấy thông tin notification để check xem có tồn tại k.
                var noti = _context.tNotifications.Where(m => m.NotifId == value.NotifId).FirstOrDefault();

                if (noti != null)
                {
                    comment.CreateBy = value.CreateBy;
                    comment.CreateAt = DateTime.Now;
                    comment.Title = value.Title;
                    comment.NotifId = value.NotifId;
                    comment.Status = 1;
                    _context.tComments.Add(comment);
                    _context.SaveChanges();

                    return 1; //Success.
                }

                return -4; //Notification k tồn tại.
            }
            catch (Exception ex)
            {
                return -1; //Fail.
            }

        }

        //Chỉnh sửa comment theo id.
        public int UpdateComment(int id, DTOComment value)
        {
            try
            {
                //Check id của comment.
                var comment = _context.tComments.Where(m => m.Status == 1 && m.CommentId == id).FirstOrDefault();

                if (comment != null)
                {
                    //Lấy thông tin notification để check xem có tồn tại k.
                    var noti = _context.tNotifications.Where(m => m.NotifId == value.NotifId).FirstOrDefault();

                    if (noti != null)
                    {
                        comment.CreateBy = value.CreateBy;
                        comment.Title = value.Title;
                        comment.NotifId = value.NotifId;
                        comment.Status = 1;
                        _context.tComments.Update(comment);
                        _context.SaveChanges();

                        return 1; // Success.
                    }

                    return -4; // Notification k tồn tại.
                }

                return 0; // Id không tồn tại.
            }
            catch (Exception ex)
            {
                return -1; // Fail.
            }
        }

        //Xóa comment theo id.
        public int DeleteComment(int id)
        {
            try
            {
                //Check id của comment.
                var Comment = _context.tComments.Where(m => m.Status == 1 && m.CommentId == id).FirstOrDefault();

                if (Comment != null)
                {
                    Comment.Status = 0;
                    _context.tComments.Update(Comment);
                    _context.SaveChanges();

                    return 1; // Success
                }

                return 0; // Id không tồn tại.

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
