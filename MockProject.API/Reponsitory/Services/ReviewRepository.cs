using Microsoft.EntityFrameworkCore;
using MockProject.API.DTO;
using MockProject.API.Models;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Reponsitory.Services
{
    public class ReviewRepository : IReviewRepository
    {
        #region Khai báo db.        
        private readonly iHomeContext _context;

        public ReviewRepository(iHomeContext context)
        {
            _context = context;
        }
        #endregion

        #region Xử lý dữ liệu cho API.
        public async Task<List<DTOGetReview>> GetReview()
        {
            List<DTOGetReview> res = new List<DTOGetReview>();
            var review = await _context.tReviews.Where(m => m.Status == 1).OrderByDescending(m => m.ReviewId).ToListAsync();

            foreach (var item in review)
            {
                var user = _context.tUsers.Where(m => m.Id == item.CreateBy).FirstOrDefault();

                DTOGetReview itemList = new DTOGetReview();
                itemList.ReviewId = item.ReviewId;
                itemList.RatingScore = item.RatingScore;
                itemList.Comment = item.Comment;

                TimeZoneInfo vn = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                DateTime vnDatetime = TimeZoneInfo.ConvertTimeFromUtc(item.CreateAt, vn);
                itemList.CreateAt = vnDatetime;


                itemList.CreateBy = item.CreateBy;
                itemList.FullName = user.Name;
                itemList.Email = user.Email;
                itemList.Avatar = user.Avatar;
                res.Add(itemList);
            }

            return res;
        }

        public async Task<List<DTOGetReview>> GetTrash()
        {
            List<DTOGetReview> res = new List<DTOGetReview>();
            var review = await _context.tReviews.Where(m => m.Status == 0).OrderByDescending(m => m.ReviewId).ToListAsync();

            foreach (var item in review)
            {
                var user = _context.tUsers.Where(m => m.Id == item.CreateBy).FirstOrDefault();

                DTOGetReview itemList = new DTOGetReview();
                itemList.ReviewId = item.ReviewId;
                itemList.RatingScore = item.RatingScore;
                itemList.Comment = item.Comment;
                itemList.CreateAt = item.CreateAt;
                itemList.CreateBy = item.CreateBy;
                itemList.FullName = user.Name;
                itemList.Email = user.Email;
                itemList.Avatar = user.Avatar;
                res.Add(itemList);
            }

            return res;
        }

        public async Task<Review> GetReview(int id)
        {
            var res = await _context.tReviews.Where(m => m.Status == 1 && m.ReviewId == id).FirstOrDefaultAsync();

            return res;
        }

        public int AddReview(DTOReview value)
        {

            try
            {
                Review review = new Review();

                review.RatingScore = value.RatingScore;
                review.Comment = value.Comment;
                review.CreateAt = DateTime.UtcNow;
                review.CreateBy = value.CreateBy;
                review.Status = 1;
                _context.tReviews.Add(review);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int UpdateReview(int id, DTOReview value)
        {
            try
            {
                var review = _context.tReviews.Where(m => m.Status == 1 && m.ReviewId == id).FirstOrDefault();

                if (review != null)
                {
                    review.RatingScore = value.RatingScore;
                    review.Comment = value.Comment;
                    review.CreateBy = value.CreateBy;
                    review.Status = 1;
                    _context.tReviews.Update(review);
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

        public int DeleteReview(int id)
        {
            try
            {
                var review = _context.tReviews.Where(m => m.Status == 1 && m.ReviewId == id).FirstOrDefault();

                if (review != null)
                {
                    review.Status = 0;
                    _context.tReviews.Update(review);
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
    }
}
