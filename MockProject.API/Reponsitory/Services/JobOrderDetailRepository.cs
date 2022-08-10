using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class JobOrderDetailRepository : IJobOrderDetailRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public JobOrderDetailRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xử lý dữ liệu cho API

        #region Lấy danh sách dữ liệu
        // Lấy tất cả ds active theo id của JO.
        public async Task<List<JobOrderDetail>> GetJOD(int idJO)
        {
            try
            {
                var res = await _context.tJobOrderDetails.Where(m => m.JOId == idJO).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }

        // Lấy ds theo id của JO + service.
        public async Task<List<JobOrderDetail>> GetJODService(int idJO, int idService)
        {
            try
            {
                var res = await _context.tJobOrderDetails.Where(m => m.JOId == idJO && m.ServiceId == idService).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }

        // Lấy ds theo id của JO + option.
        public async Task<List<JobOrderDetail>> GetJODOption(int idJO, int idOption)
        {
            try
            {
                var res = await _context.tJobOrderDetails.Where(m => m.JOId == idJO && m.OptionId == idOption).ToListAsync();

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
        //Thêm mới 1 JO Detail.
        public int AddJOD(DTOJobOrderDetail value)
        {
            try
            {
                JobOrderDetail jod = new JobOrderDetail();
                var service = _context.tServices.Where(m => m.ServiceId == value.ServiceId).FirstOrDefault();

                jod.Quantily = value.Quantily;
                jod.Image = value.Image;
                jod.OptionId = value.OptionId;
                jod.ServiceId = value.ServiceId;
                jod.Price = service.Price;
                jod.JOId = value.JOId;

                _context.tJobOrderDetails.Add(jod);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion

        #endregion
    }
}
