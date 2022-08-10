namespace MockProject.API.DTO
{
    public class UserInfoModel
    {
        public string UserId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public int Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public float TotalPrice { get; set; }
    }
}
