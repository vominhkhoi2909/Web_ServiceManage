using System.ComponentModel.DataAnnotations;

namespace MockProject.API.DTO
{
    public class AdminUpdateInfoModel
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string FullName { get; set; } = null!;
        
        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Not a phone number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number length invalid")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Not an email address")]
        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;
        public string? Avatar { get; set; }
    }
}
