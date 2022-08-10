using System.ComponentModel.DataAnnotations;

namespace MockProject.API.DTO
{
    public class AdminResetPasswordModel
    {
        [Required]
        public string Token { get; set; } = null!;
        [Required]
        public string UserId { get; set; } = null!;
        [Required(ErrorMessage = "New password is required")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password length must between {2}-{1}")]
        public string NewPassword { get; set; } = null!;
        [Required(ErrorMessage = "Confirm password is required")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
