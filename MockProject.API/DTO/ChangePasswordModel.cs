using System.ComponentModel.DataAnnotations;

namespace MockProject.API.DTO
{
    public class ChangePasswordModel
    { 
        [Required(ErrorMessage = "Old password is required")]
        public string OldPassword { get; set; } = null!;
        [Required(ErrorMessage = "New password is required")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password length must between {2}-{1}")]
        public string NewPassword { get; set; } = null!;
        [Required(ErrorMessage = "Confirm password is required")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
