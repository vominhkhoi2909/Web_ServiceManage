using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class SliderRepository : ISliderRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public SliderRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xử lý dữ liệu cho API.

        #region Lấy danh sách dữ liệu
        public async Task<List<Slider>> GetSlider()
        {
            try
            {
                var res = await _context.tSliders.Where(m => m.Status == 1).OrderByDescending(m => m.SliderId).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<Slider>> GetTrash()
        {
            try
            {
                var res = await _context.tSliders.Where(m => m.Status == 0).OrderByDescending(m => m.SliderId).ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<Slider>> GetSearch(string key)
        {
            try
            {
                var res = await _context.tSliders.Where(m => m.Status == 1 && (m.Title.Contains(key) || m.Alt.Contains(key))).OrderByDescending(m => m.SliderId).ToListAsync();

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
        public async Task<Slider> GetSlider(int id)
        {
            try
            {
                var res = await _context.tSliders.Where(m => m.Status == 1 && m.SliderId == id).FirstOrDefaultAsync();

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
        public int AddSlider(DTOSlider value)
        {
            try
            {
                Slider slider = new Slider();

                if (CheckData(0, value.Title))
                {
                    slider.Title = value.Title;
                    slider.Description = value.Description;
                    slider.Alt = value.Alt;
                    slider.Image = value.Image;
                    slider.Link = value.Link;
                    slider.Status = 1;
                    _context.tSliders.Add(slider);
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

        public int UpdateSlider(int id, DTOSlider value)
        {
            try
            {
                var slider = _context.tSliders.Where(m => m.Status == 1 && m.SliderId == id).FirstOrDefault();

                if (slider != null)
                {
                    if (CheckData(id, value.Title))
                    {
                        slider.Title = value.Title;
                        slider.Description = value.Description;
                        slider.Alt = value.Alt;
                        slider.Image = value.Image;
                        slider.Link = value.Link;
                        slider.Status = 1;
                        _context.tSliders.Update(slider);
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

        public int DeleteSlider(int id)
        {
            try
            {
                var slider = _context.tSliders.Where(m => m.Status == 1 && m.SliderId == id).FirstOrDefault();

                if (slider != null)
                {
                    slider.Status = 0;
                    _context.tSliders.Update(slider);
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
                var check = _context.tSliders.Where(m => m.Title == name && m.Status == 1).FirstOrDefault();

                if (check == null)
                {
                    return true;
                }
            }
            else
            {
                var check = _context.tSliders.Where(m => m.SliderId != id && m.Title == name && m.Status == 1).FirstOrDefault();

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
