using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class RoleRepository : IRoleRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public RoleRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xử lý dữ liệu cho API.
        #region Lấy danh sách dữ liệu
        public async Task<List<Role>> GetRole()
        {
            try
            {
                var res = await _context.tRoles.Where(m => m.Status == 1).OrderByDescending(m => m.RoleId).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<Role>> GetTrash()
        {
            try
            {
                var res = await _context.tRoles.Where(m => m.Status == 0).OrderByDescending(m => m.RoleId).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<Role>> GetSearch(string key)
        {
            try
            {
                var res = await _context.tRoles.Where(m => m.Status == 1 && m.Name.Contains(key)).OrderByDescending(m => m.RoleId).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }
        #endregion

        #region Chi tiết
        public async Task<Role> GetRole(int id)
        {
            try
            {
                var res = await _context.tRoles.Where(m => m.Status == 1 && m.RoleId == id).FirstOrDefaultAsync();

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        public int AddRole(DTORole value)
        {
            try
            {
                Role role = new Role();

                if (CheckData(0, value.Name))
                {
                    role.Name = value.Name;
                    role.Status = 1;
                    _context.tRoles.Add(role);
                    _context.SaveChanges();

                    return 1;
                }

                return -10;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int UpdateRole(int id, DTORole value)
        {
            try
            {
                var role = _context.tRoles.Where(m => m.Status == 1 && m.RoleId == id).FirstOrDefault();

                if (role != null)
                {
                    if (CheckData(0, value.Name))
                    {
                        role.Name = value.Name;
                        role.Status = 1;
                        _context.tRoles.Add(role);
                        _context.SaveChanges();

                        return 1;
                    }

                    return -10;
                }

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int DeleteRole(int id)
        {
            try
            {
                var role = _context.tRoles.Where(m => m.Status == 1 && m.RoleId == id).FirstOrDefault();

                if (role != null)
                {
                    role.Status = 1;
                    _context.tRoles.Add(role);
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
        #endregion

        #endregion

        #region Check sự tồn tại của data
        private bool CheckData(int id, string name)
        {
            //Id == 0 là thêm mới.
            if (id == 0)
            {
                var check = _context.tRoles.Where(m => m.Name == name && m.Status == 1).FirstOrDefault();

                if (check == null)
                {
                    return true;
                }
            }
            else
            {
                var check = _context.tRoles.Where(m => m.RoleId != id && m.Name == name && m.Status == 1).FirstOrDefault();

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
