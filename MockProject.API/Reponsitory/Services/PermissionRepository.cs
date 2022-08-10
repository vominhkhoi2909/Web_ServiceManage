using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class PermissionRepository : IPermissionRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public PermissionRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xử lý dữ liệu cho API

        #region Lấy danh sách dữ liệu
        // Lấy tất cả ds active.
        public async Task<List<Permission>> GetPermission()
        {
            try
            {
                var res = await _context.tPermissions.Where(m => m.Status == 1).OrderByDescending(m => m.PermissionId).ToListAsync();

                return res; // Success.
            }
            catch (Exception ex)
            {
                return null; // Fail.
            }
        }

        // Lấy tất cả ds inactive.
        public async Task<List<Permission>> GetTrash()
        {
            try
            {
                var res = await _context.tPermissions.Where(m => m.Status == 0).OrderByDescending(m => m.PermissionId).ToListAsync();

                return res; // Success.
            }
            catch (Exception ex)
            {
                return null; // Fail.
            }
        }

        // Lấy ds dữ liệu theo từ khóa.
        // Các từ khóa có thể lấy: Key / value.
        public async Task<List<Permission>> GetSearch(string key)
        {
            try
            {
                var res = await _context.tPermissions.Where(m => m.Status == 1 && m.Title.Contains(key)).OrderByDescending(m => m.PermissionId).ToListAsync();

                return res; // Success.
            }
            catch (Exception ex)
            {
                return null; // Fail.
            }
        }
        #endregion

        #region Chi tiết
        //Xem chi tiết Permission.
        public async Task<Permission> GetPermission(int id)
        {
            try
            {
                var res = await _context.tPermissions.Where(m => m.Status == 1 && m.PermissionId == id).FirstOrDefaultAsync();

                return res; // Success.
            }
            catch
            {
                return null; // Fail.
            }
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        //Thêm mới 1 Permission.
        public int AddPermission(DTOPermission value)
        {
            try
            {
                Permission permission = new Permission();

                permission.Title = value.Title;
                permission.Link = value.Link;
                permission.Status = 1;
                _context.tPermissions.Add(permission);
                _context.SaveChanges();

                return 1; // Success.
            }
            catch (Exception ex)
            {
                return -1; // Faul.
            }

        }

        //Chỉnh sửa Permission theo id.
        public int UpdatePermission(int id, DTOPermission value)
        {
            try
            {
                // Lấy dữ liệu theo id.
                var permission = _context.tPermissions.Where(m => m.Status == 1 && m.PermissionId == id).FirstOrDefault();

                // Check dữ liệu có tồn tại.
                if (permission != null)
                {
                    permission.Title = value.Title;
                    permission.Link = value.Link;
                    permission.Status = 1;
                    _context.tPermissions.Update(permission);
                    _context.SaveChanges();

                    return 1; // Success.
                }

                return 0; // Dữ liệu k tồn tại trong db.
            }
            catch (Exception ex)
            {
                return -1; // Fail.
            }
        }

        //Xóa Permission theo id.
        public int DeletePermission(int id)
        {
            try
            {
                // Lấy dữ liệu theo id.
                var permission = _context.tPermissions.Where(m => m.Status == 1 && m.PermissionId == id).FirstOrDefault();

                // Check dữ liệu có tồn tại.
                if (permission != null)
                {
                    permission.Status = 0;
                    _context.tPermissions.Update(permission);
                    _context.SaveChanges();

                    return 1; // Success.
                }

                return 0; // Dữ liệu k tồn tại trong db.
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
