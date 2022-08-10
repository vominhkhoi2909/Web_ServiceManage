using MockProject.API.Models;
using System.ComponentModel.DataAnnotations;

namespace MockProject.API.DTO
{
    public class DTOModels
    {

    }

    # region Model thêm / cập nhật.
    public class DTOAdmin
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Not a phone number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number length invalid")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Not an email address")]
        public string Email { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string? Avatar { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public int roleId { get; set; }
    }

    public class DTOAdminInfo
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Not a phone number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number length invalid")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Not an email address")]
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public string? Password { get; set; }
    }

    public class DTOComment
    {
        public string CreateBy { get; set; }
        public string Title { get; set; }
        public int NotifId { get; set; }
    }

    public class DTOConfig
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class DTOContact
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
        public int ParentServiceId { get; set; }
    }

    public class DTOJobOrder
    {
        public float Duration { get; set; }
        public DateTime StartAt { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
    }

    public class DTOJobOrderDetail
    {
        public int Quantily { get; set; }
        public string Image { get; set; }
        public int OptionId { get; set; }
        public int ServiceId { get; set; }
        public int JOId { get; set; }
    }

    public class DTOLog
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }
        public int CreateBy { get; set; } //Admin
    }

    public class DTONote
    {
        public string Title { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; } //Admin
    }

    public class DTONotification
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public int Type { get; set; }
        public string? Link { get; set; }
        public string SendTo { get; set; } //User
        public int CreateBy { get; set; } //Admin
    }

    public class DTOOption
    {
        public string Title { get; set; }
        public int Type { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
    }

    public class DTOPermission
    {
        public string Title { get; set; }
        public string? Link { get; set; }
    }

    public class DTOPromotion
    {
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public float? DiscountPercent { get; set; }
        public float? DiscountMoney { get; set; }
        public string? Discription { get; set; }
        public string? Image { get; set; }
        public int ParentServiceId { get; set; }
    }

    public class DTOReview
    {
        public float RatingScore { get; set; }
        public string? Comment { get; set; }
        public string CreateBy { get; set; }
    }

    public class DTORole
    {
        public string Name { get; set; }
    }

    public class DTOService
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public float Price { get; set; }
        public float Duration { get; set; }
        public string? Description { get; set; }
    }

    public class DTOSlider
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Alt { get; set; }
        public string? Image { get; set; }
        public string Link { get; set; }
    }

    public class DTOVan
    {
        public string RegisterNumber { get; set; }
        public int StaffId { get; set; }
    }
    #endregion

    #region Model trả về.
    public class DTOGetAdmin
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public int RoleId { get; set; }
        public string Role_Name { get; set; }
        public int status { get; set; }
        public string Username { get; set; }
        public string Permission { get; set; }
        public int TotalPoint { get; set; }
        public float TotalOrder { get; set; }
    }

    public class DTOGetAdminSale
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public int RoleId { get; set; }
        public string Role_Name { get; set; }
        public int status { get; set; }
        public string Username { get; set; }
        public int TotalPoint { get; set; }
        public float TotalOrder { get; set; }
        public int CountOrder { get; set; }
    }

    public class DTOGetDashboard
    {
        public int CountStaff;
        public int CountCustomer;
        public int CountJobOrder;
        public int CountJobOrderCancel;
        public int CountJobOrderWaiting;
        public int CountJobOrderConfirm;
        public int CountJobOrderDone;
        public int CountJobOrderCheckin;
        public float[] TotalMonth = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
    }

    public class DTOGetReview
    {
        public int ReviewId { get; set; }
        public float RatingScore { get; set; }
        public string? Comment { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
    }

    public class DTOGetComment
    {
        public int CommentId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string Comment_Title { get; set; }
        public int NotifId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public string? Notifi_Title { get; set; }
    }

    public class DTOGetContact
    {
        public int ContactId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int ParentServiceId { get; set; }
        public string? Service_Name { get; set; }
    }

    public class DTOGetJobOrder
    {
        public int JOId { get; set; }
        public float Duration { get; set; }
        public DateTime StartAt { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public int? State { get; set; }
        public string CustomerId { get; set; }
        public string? User_Name { get; set; }
        public string? User_Email { get; set; }
        public string? User_Avatar { get; set; }
        public int StaffId { get; set; }
        public string? Admin_Name { get; set; }
        public string? Admin_Email { get; set; }
        public string? Admin_Avatar { get; set; }
        public float totalPrice { get; set; }
    }

    public class DTOGetNote
    {
        public int NoteId { get; set; }
        public DateTime CreateAt { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public string? Description { get; set; }
        public int CreateBy { get; set; }
        public string? CreateBy_Name { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
    }

    public class DTOGetNotification
    {
        public int NotifId { get; set; }
        public DateTime CreateAt { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string SendTo { get; set; }
        public string? User_Name { get; set; }
        public string? User_Email { get; set; }
        public string? User_Avatar { get; set; }
        public int CreateBy { get; set; }
        public string? Admin_Name { get; set; }
        public string? Admin_Email { get; set; }
        public string? Admin_Avatar { get; set; }
        public string? Link { get; set; }
        public int Status { get; set; }
    }

    public class DTOGetPromotion
    {
        public int PromotionId { get; set; }
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public float? DiscountPercent { get; set; }
        public float? DiscountMoney { get; set; }
        public string Discription { get; set; }
        public string? Image { get; set; }
        public int ParentServiceId { get; set; }
        public string Service_Name { get; set; }
    }
    #endregion
}
