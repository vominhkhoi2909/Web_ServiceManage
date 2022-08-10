using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class ConfigRepository : IConfigRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public ConfigRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xử lý dữ liệu cho API

        #region Lấy danh sách dữ liệu
        // Lấy tất cả ds active.
        public async Task<List<Config>> GetConfig()
        {
            try
            {
                var res = await _context.tConfigs.Where(m => m.Status == 1).OrderByDescending(m => m.ConfigId).ToListAsync();

                return res; // Success.
            }
            catch (Exception ex)
            {
                return null; // Fail.
            }
        }

        // Lấy tất cả ds inactive.
        public async Task<List<Config>> GetTrash()
        {
            try
            {
                var res = await _context.tConfigs.Where(m => m.Status == 0).OrderByDescending(m => m.ConfigId).ToListAsync();

                return res; // Success.
            }
            catch (Exception ex)
            {
                return null; // Fail.
            }
        }

        // Lấy ds dữ liệu theo từ khóa.
        // Các từ khóa có thể lấy: Key / value.
        public async Task<List<Config>> GetSearch(string key)
        {
            try
            {
                var res = await _context.tConfigs.Where(m => m.Status == 1 && (m.Key.Contains(key) || m.Value.Contains(key))).OrderByDescending(m => m.ConfigId).ToListAsync();

                return res; // Success.
            }
            catch (Exception ex)
            {
                return null; // Fail.
            }
        }
        #endregion

        #region Chi tiết
        //Xem chi tiết config.
        public async Task<Config> GetConfig(int id)
        {
            try
            {
                var res = await _context.tConfigs.Where(m => m.Status == 1 && m.ConfigId == id).FirstOrDefaultAsync();

                return res; // Success.
            }
            catch
            {
                return null; // Fail.
            }
        }
        #endregion

        #region Thêm / Cập nhật / Xóa
        //Thêm mới 1 config.
        public int AddConfig(DTOConfig value)
        {
            try
            {
                Config config = new Config();

                config.Key = value.Key;
                config.Value = value.Value;
                config.Status = 1;
                _context.tConfigs.Add(config);
                _context.SaveChanges();

                return 1; // Success.
            }
            catch (Exception ex)
            {
                return -1; // Faul.
            }

        }

        //Chỉnh sửa config theo id.
        public int UpdateConfig(int id, DTOConfig value)
        {
            try
            {
                // Lấy dữ liệu theo id.
                var config = _context.tConfigs.Where(m => m.Status == 1 && m.ConfigId == id).FirstOrDefault();

                // Check dữ liệu có tồn tại.
                if (config != null)
                {
                    config.Key = value.Key;
                    config.Value = value.Value;
                    config.Status = 1;
                    _context.tConfigs.Update(config);
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

        //Xóa config theo id.
        public int DeleteConfig(int id)
        {
            try
            {
                // Lấy dữ liệu theo id.
                var Config = _context.tConfigs.Where(m => m.Status == 1 && m.ConfigId == id).FirstOrDefault();

                // Check dữ liệu có tồn tại.
                if (Config != null)
                {
                    Config.Status = 0;
                    _context.tConfigs.Update(Config);
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
