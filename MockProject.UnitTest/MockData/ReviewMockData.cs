using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.UnitTest.MockData
{
    public class ReviewMockData
    {
        public static List<DTOGetReview> GetReviews()
        {
            return new List<DTOGetReview>
            {
                new DTOGetReview
                {
                    ReviewId = 1,
                    RatingScore = 3,
                    Comment = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Accusamus numquam assumenda...",
                    CreateAt = DateTime.Now,
                    CreateBy = "52b64d3f-aee1-41c2-92eb-cce2fa22b121",
                },
                new DTOGetReview
                {
                    ReviewId = 2,
                    RatingScore = 2,
                    Comment = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Accusamus numquam assumenda...",
                    CreateAt = DateTime.Now,
                    CreateBy = "52b64d3f-aee1-41c2-92eb-cce2fa22b121",
                },
                new DTOGetReview
                {
                    ReviewId = 4,
                    RatingScore = 5,
                    Comment = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Accusamus numquam assumenda...",
                    CreateAt = DateTime.Now,
                    CreateBy = "311b3baf-431a-49dc-8c8e-f2b40f3fb30f",
                },
            };
        }

        public static List<DTOGetReview> EmptyReview()
        {
            return new List<DTOGetReview>();
        }
    }
}
