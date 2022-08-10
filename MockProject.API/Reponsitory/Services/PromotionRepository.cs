using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class PromotionRepository : IPromotionRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public PromotionRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xứ lý dữ liệu cho API

        #region Lấy danh sách dữ liệu
        public async Task<List<DTOGetPromotion>> GetPromotion()
        {
            try
            {
                List<DTOGetPromotion> res = new List<DTOGetPromotion>();
                var promotion = await _context.tPromotions.Where(m => m.Status == 1).OrderByDescending(m => m.PromotionId).ToListAsync();

                foreach (var item in promotion)
                {
                    var option = await _context.tOptions.Where(m => m.OptionId == item.ParentServiceId).FirstOrDefaultAsync();

                    DTOGetPromotion itemList = new DTOGetPromotion();

                    itemList.PromotionId = item.PromotionId;
                    itemList.Title = item.Title;
                    itemList.DateStart = item.DateStart;
                    itemList.DateEnd = item.DateEnd;
                    itemList.DiscountPercent = item.DiscountPercent;
                    itemList.DiscountMoney = item.DiscountMoney;
                    itemList.Discription = item.Discription;
                    itemList.Image = item.Image;
                    itemList.ParentServiceId = item.ParentServiceId;
                    if (option != null)
                    {
                        itemList.Service_Name = option.Title;
                    }

                    res.Add(itemList);
                }

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<DTOGetPromotion>> GetTrash()
        {
            try
            {
                List<DTOGetPromotion> res = new List<DTOGetPromotion>();
                var promotion = await _context.tPromotions.Where(m => m.Status == 0).OrderByDescending(m => m.PromotionId).ToListAsync();

                foreach (var item in promotion)
                {
                    var option = await _context.tOptions.Where(m => m.OptionId == item.ParentServiceId).FirstOrDefaultAsync();

                    DTOGetPromotion itemList = new DTOGetPromotion();

                    itemList.PromotionId = item.PromotionId;
                    itemList.Title = item.Title;
                    itemList.DateStart = item.DateStart;
                    itemList.DateEnd = item.DateEnd;
                    itemList.DiscountPercent = item.DiscountPercent;
                    itemList.DiscountMoney = item.DiscountMoney;
                    itemList.Discription = item.Discription;
                    itemList.Image = item.Image;
                    itemList.ParentServiceId = item.ParentServiceId;
                    if (option != null)
                    {
                        itemList.Service_Name = option.Title;
                    }

                    res.Add(itemList);
                }

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<DTOGetPromotion>> GetSearch(string key)
        {
            try
            {
                List<DTOGetPromotion> res = new List<DTOGetPromotion>();
                var promotion = await _context.tPromotions.Where(m => m.Status == 1).OrderByDescending(m => m.PromotionId).ToListAsync();

                foreach (var item in promotion)
                {
                    var option = await _context.tOptions.Where(m => m.OptionId == item.ParentServiceId).FirstOrDefaultAsync();

                    if (option != null && option.Title.Contains(key) || item.Title.Contains(key))
                    {
                        DTOGetPromotion itemList = new DTOGetPromotion();

                        itemList.PromotionId = item.PromotionId;
                        itemList.Title = item.Title;
                        itemList.DateStart = item.DateStart;
                        itemList.DateEnd = item.DateEnd;
                        itemList.DiscountPercent = item.DiscountPercent;
                        itemList.DiscountMoney = item.DiscountMoney;
                        itemList.Discription = item.Discription;
                        itemList.Image = item.Image;
                        itemList.ParentServiceId = item.ParentServiceId;
                        if (option != null)
                        {
                            itemList.Service_Name = option.Title;
                        }

                        res.Add(itemList);
                    }
                }

                return res;
            }
            catch (Exception ex)
            {
                //Truy vấn lỗi.
                return null;
            }
        }

        public async Task<List<DTOGetPromotion>> GetPromotionService(int service)
        {
            try
            {
                List<DTOGetPromotion> res = new List<DTOGetPromotion>();
                var promotion = await _context.tPromotions.Where(m => m.Status == 1 && m.ParentServiceId == service).OrderByDescending(m => m.PromotionId).ToListAsync();

                foreach (var item in promotion)
                {
                    var option = await _context.tOptions.Where(m => m.OptionId == item.ParentServiceId).FirstOrDefaultAsync();

                    DTOGetPromotion itemList = new DTOGetPromotion();

                    itemList.PromotionId = item.PromotionId;
                    itemList.Title = item.Title;
                    itemList.DateStart = item.DateStart;
                    itemList.DateEnd = item.DateEnd;
                    itemList.DiscountPercent = item.DiscountPercent;
                    itemList.DiscountMoney = item.DiscountMoney;
                    itemList.Discription = item.Discription;
                    itemList.Image = item.Image;
                    itemList.ParentServiceId = item.ParentServiceId;
                    if (option != null)
                    {
                        itemList.Service_Name = option.Title;
                    }

                    res.Add(itemList);
                }

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
        public async Task<Promotion> GetPromotion(int id)
        {
            try
            {
                var res = await _context.tPromotions.Where(m => m.Status == 1 && m.PromotionId == id).FirstOrDefaultAsync();

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
        public int AddPromotion(DTOPromotion value)
        {
            try
            {
                Promotion promotion = new Promotion();

                if (CheckData(0, value.ParentServiceId, value.Title))
                {
                    promotion.Title = value.Title;
                    promotion.DateStart = value.DateStart;
                    promotion.DateEnd = value.DateEnd;
                    promotion.DiscountPercent = value.DiscountPercent;
                    promotion.DiscountMoney = value.DiscountMoney;
                    promotion.Discription = value.Discription;
                    promotion.Image = value.Image;
                    promotion.ParentServiceId = value.ParentServiceId;
                    promotion.Status = 1;
                    _context.tPromotions.Add(promotion);
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

        public int UpdatePromotion(int id, DTOPromotion value)
        {
            try
            {
                var promotion = _context.tPromotions.Where(m => m.Status == 1 && m.PromotionId == id).FirstOrDefault();

                if (promotion != null)
                {
                    if (CheckData(id, value.ParentServiceId, value.Title))
                    {
                        promotion.Title = value.Title;
                        promotion.DateStart = value.DateStart;
                        promotion.DateEnd = value.DateEnd;
                        promotion.DiscountPercent = value.DiscountPercent;
                        promotion.DiscountMoney = value.DiscountMoney;
                        promotion.Discription = value.Discription;
                        promotion.Image = value.Image;
                        promotion.ParentServiceId = value.ParentServiceId;
                        promotion.Status = 1;
                        _context.tPromotions.Update(promotion);
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

        public int DeletePromotion(int id)
        {
            try
            {
                var promotion = _context.tPromotions.Where(m => m.Status == 1 && m.PromotionId == id).FirstOrDefault();

                if (promotion != null)
                {
                    promotion.Status = 0;
                    _context.tPromotions.Update(promotion);
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
        private bool CheckData(int id, int service, string name)
        {
            //Id == 0 là thêm mới.
            if (id == 0)
            {
                var check = _context.tPromotions.Where(m => m.ParentServiceId == service && m.Title == name && m.Status == 1).FirstOrDefault();

                if (check == null)
                {
                    return true;
                }
            }
            else
            {
                var check = _context.tPromotions.Where(m => m.PromotionId != id && m.ParentServiceId == service && m.Title == name && m.Status == 1).FirstOrDefault();

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
