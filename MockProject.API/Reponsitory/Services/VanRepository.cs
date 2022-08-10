using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class VanRepository : IVanRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public VanRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xứ lý dữ liệu cho API
        public async Task<List<Van>> GetVan()
        {
            var res = await _context.tVans.Where(m => m.Status == 1).OrderByDescending(m => m.VanId).ToListAsync();

            return res;
        }

        public async Task<List<Van>> GetTrash()
        {
            var res = await _context.tVans.Where(m => m.Status == 0).OrderByDescending(m => m.VanId).ToListAsync();

            return res;
        }

        public async Task<Van> GetVan(int id)
        {
            var res = await _context.tVans.Where(m => m.Status == 1 && m.VanId == id).FirstOrDefaultAsync();

            return res;
        }

        public int AddVan(DTOVan value)
        {
            try
            {
                Van van = new Van();

                if (CheckData(0, value.RegisterNumber))
                {
                    van.RegisterNumber = value.RegisterNumber;
                    van.CreateAt = DateTime.Now;
                    van.StaffId = value.StaffId;
                    van.Status = 1;
                    _context.tVans.Add(van);
                    _context.SaveChanges();

                    return 1;
                }

                return -2;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int UpdateVan(int id, DTOVan value)
        {
            try
            {
                var van = _context.tVans.Where(m => m.Status == 1 && m.VanId == id).FirstOrDefault();

                if (van != null)
                {
                    if (CheckData(id, value.RegisterNumber))
                    {
                        van.RegisterNumber = value.RegisterNumber;
                        van.StaffId = value.StaffId;
                        van.Status = 1;
                        _context.tVans.Update(van);
                        _context.SaveChanges();

                        return 1;
                    }

                    return -2;
                }

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int DeleteVan(int id)
        {
            try
            {
                var van = _context.tVans.Where(m => m.Status == 1 && m.VanId == id).FirstOrDefault();

                if (van != null)
                {
                    van.Status = 0;
                    _context.tVans.Update(van);
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

        public async Task<List<Van>> Search(string searchString)
        {
            var result = await _context.tVans.Where(x => x.Status == 1 && x.RegisterNumber.Contains(searchString)).ToListAsync();
            return result;
        }
        #endregion

        #region Check sự tồn tại của data
        private bool CheckData(int id, string name)
        {
            //Id == 0 là thêm mới.
            if (id == 0)
            {
                var check = _context.tVans.Where(m => m.RegisterNumber == name && m.Status == 1).FirstOrDefault();

                if (check == null)
                {
                    return true;
                }
            }
            else
            {
                var check = _context.tVans.Where(m => m.VanId != id && m.RegisterNumber == name && m.Status == 1).FirstOrDefault();

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
