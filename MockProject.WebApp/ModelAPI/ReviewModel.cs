namespace MockProject.WebApp.ModelAPI
{
    public class ReviewModel
    {
        public float RatingScore { get; set; }
        public string? Comment { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }

        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }

    }
}
