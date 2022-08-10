using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class ServiceRepository : IServiceRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public ServiceRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xử lý dữ liệu cho API.

        #region Lấy danh sách dữ liệu.
        public async Task<List<Service>> GetService()
        {
            var res = await _context.tServices.Where(m => m.Status == 1).OrderByDescending(m => m.ServiceId).ToListAsync();

            return res;
        }

        public async Task<List<Service>> GetServiceType(int type)
        {
            var res = await _context.tServices.Where(m => m.Status == 1 && m.Type == type).OrderByDescending(m => m.ServiceId).ToListAsync();

            return res;
        }

        public async Task<List<Service>> GetTrash()
        {
            var res = await _context.tServices.Where(m => m.Status == 0).OrderByDescending(m => m.ServiceId).ToListAsync();

            return res;
        }

        public async Task<List<Service>> Search(string searchString)
        {
            var result = await _context.tServices.Where(x => x.Status == 1 && (
            x.Name.Contains(searchString) ||
            x.Price.ToString().Contains(searchString) ||
            x.Duration.ToString().Contains(searchString) ||
            x.Description.Contains(searchString)
            )).ToListAsync();
            return result;
        }
        #endregion

        #region Chi tiết
        public async Task<Service> GetService(int id)
        {
            var res = await _context.tServices.Where(m => m.Status == 1 && m.ServiceId == id).FirstOrDefaultAsync();

            return res;
        }
        #endregion

        #region Thêm / Cập nhật / Xóa.
        public int AddService(DTOService value)
        {
            try
            {
                Service service = new Service();

                try
                {
                    int testInt = Convert.ToInt32(value.Duration);
                    double testFloat = Convert.ToDouble(value.Duration);
                }
                catch (Exception ex)
                {
                    // Duration isnt number.
                    return -11;
                }

                if (CheckData(0, value.Type, value.Name))
                {
                    service.Name = value.Name;
                    service.Type = value.Type;
                    service.Price = value.Price;
                    service.Duration = value.Duration;
                    service.Description = value.Description;
                    service.Status = 1;
                    _context.tServices.Add(service);
                    _context.SaveChanges();

                    return 1;
                }

                return -12;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int UpdateService(int id, DTOService value)
        {
            try
            {
                var service = _context.tServices.Where(m => m.Status == 1 && m.ServiceId == id).FirstOrDefault();

                try
                {
                    int testInt = Convert.ToInt32(value.Duration);
                    double testFloat = Convert.ToDouble(value.Duration);
                }
                catch (Exception ex)
                {
                    // Duration isnt number.
                    return -11;
                }

                if (service != null)
                {
                    if (CheckData(id, value.Type, value.Name))
                    {
                        service.Name = value.Name;
                        service.Type = value.Type;
                        service.Price = value.Price;
                        service.Duration = value.Duration;
                        service.Description = value.Description;
                        service.Status = 1;
                        _context.tServices.Update(service);
                        _context.SaveChanges();

                        return 1;
                    }

                    return -12;
                }

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int DeleteService(int id)
        {
            try
            {
                var service = _context.tServices.Where(m => m.Status == 1 && m.ServiceId == id).FirstOrDefault();

                if (service != null)
                {
                    service.Status = 0;
                    _context.tServices.Update(service);
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
        private bool CheckData(int id, int type, string name)
        {
            //Id == 0 là thêm mới.
            if (id == 0)
            {
                var check = _context.tServices.Where(m => m.Type == type && m.Name == name && m.Status == 1).FirstOrDefault();

                if (check == null)
                {
                    return true;
                }
            }
            else
            {
                var check = _context.tServices.Where(m => m.ServiceId != id && m.Type == type && m.Name == name && m.Status == 1).FirstOrDefault();

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
