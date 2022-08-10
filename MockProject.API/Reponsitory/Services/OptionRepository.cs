using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class OptionRepository : IOptionRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public OptionRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xứ lý dữ liệu cho API

        #region Lấy danh sách dữ liệu
        public async Task<List<Option>> GetOption()
        {
            try
            {
                var res = await _context.tOptions.Where(m => m.Status == 1).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<Option>> GetTrash()
        {
            try
            {
                var res = await _context.tOptions.Where(m => m.Status == 0).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<Option>> GetSearch(string key)
        {
            try
            {
                var res = await _context.tOptions.Where(m => m.Status == 1 && m.Title.Contains(key)).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<Option>> GetOptionType(int type)
        {
            try
            {
                var res = await _context.tOptions.Where(m => m.Status == 1 && m.Type == type).ToListAsync();

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
        public async Task<Option> GetOption(int id)
        {
            try
            {
                var res = await _context.tOptions.Where(m => m.Status == 1 && m.OptionId == id).FirstOrDefaultAsync();

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
        public int AddOption(DTOOption value)
        {
            try
            {
                Option option = new Option();

                if (CheckData(0, value.Type, value.Title))
                {
                    option.Title = value.Title;
                    option.Type = value.Type;
                    option.Image = value.Image;
                    option.Description = value.Description;
                    option.Status = 1;
                    _context.tOptions.Add(option);
                    _context.SaveChanges();

                    return 1;
                }

                return -9;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int UpdateOption(int id, DTOOption value)
        {
            try
            {
                var option = _context.tOptions.Where(m => m.Status == 1 && m.OptionId == id).FirstOrDefault();

                if (option != null)
                {
                    if (CheckData(id, value.Type, value.Title))
                    {
                        option.Title = value.Title;
                        option.Type = value.Type;
                        option.Image = value.Image;
                        option.Description = value.Description;
                        option.Status = 1;
                        _context.tOptions.Update(option);
                        _context.SaveChanges();

                        return 1;
                    }

                    return -9;
                }

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int DeleteOption(int id)
        {
            try
            {
                var option = _context.tOptions.Where(m => m.Status == 1 && m.OptionId == id).FirstOrDefault();

                if (option != null)
                {
                    option.Status = 0;
                    _context.tOptions.Update(option);
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
                var check = _context.tOptions.Where(m => m.Type == type && m.Title == name && m.Status == 1).FirstOrDefault();

                if (check == null)
                {
                    return true;
                }
            }
            else
            {
                var check = _context.tOptions.Where(m => m.OptionId != id && m.Type == type && m.Title == name && m.Status == 1).FirstOrDefault();

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
