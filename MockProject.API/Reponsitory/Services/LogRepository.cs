using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class LogRepository : ILogRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public LogRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xử lý dữ liệu cho API

        #region Lấy danh sách dữ liệu
        // Lấy tất cả ds active.
        public async Task<List<Log>> GetLog()
        {
            try
            {
                var res = await _context.tLog.Where(m => m.Status == 1).OrderByDescending(m => m.LogId).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lỗi.
                return null;
            }
        }

        // Lấy tất cả ds inactive.
        public async Task<List<Log>> GetTrash()
        {
            try
            {
                var res = await _context.tLog.Where(m => m.Status == 0).OrderByDescending(m => m.LogId).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lỗi.
                return null;
            }
        }

        // Lấy ds theo id của type.
        public async Task<List<Log>> GetLogType(int type)
        {
            try
            {
                var res = await _context.tLog.Where(m => m.Status == 1 && m.Type == type).OrderByDescending(m => m.LogId).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lỗi.
                return null;
            }
        }
        #endregion

        #region Chi tiết
        //Xem chi tiết log.
        public async Task<Log> GetLog(int id)
        {
            try
            {
                var res = await _context.tLog.Where(m => m.Status == 1 && m.LogId == id).FirstOrDefaultAsync();

                return res;
            }
            catch (Exception ex)
            {
                // Truy vấn lỗi.
                return null;
            }
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        //Thêm mới 1 log.
        public int AddLog(DTOLog value)
        {
            try
            {
                Log log = new Log();

                log.CreateAt = DateTime.Now;
                log.Title = value.Title;
                log.Image = value.Image;
                log.Type = value.Type;
                log.CreateBy = value.CreateBy;
                log.Status = 1;
                _context.tLog.Add(log);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        //Chỉnh sửa log theo id.
        public int UpdateLog(int id, DTOLog value)
        {
            try
            {
                var log = _context.tLog.Where(m => m.Status == 1 && m.LogId == id).FirstOrDefault();

                if (log != null)
                {
                    log.Title = value.Title;
                    log.Image = value.Image;
                    log.Type = value.Type;
                    log.CreateBy = value.CreateBy;
                    log.Status = 1;
                    _context.tLog.Update(log);
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

        //Xóa log theo id.
        public int DeleteLog(int id)
        {
            try
            {
                var Log = _context.tLog.Where(m => m.Status == 1 && m.LogId == id).FirstOrDefault();

                if (Log != null)
                {
                    Log.Status = 0;
                    _context.tLog.Update(Log);
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
    }
}
