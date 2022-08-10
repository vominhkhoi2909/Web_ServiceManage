using System.ComponentModel.DataAnnotations;

namespace MockProject.API.DTO
{
    public class AddCustomerModel
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Not a phone number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number length invalid")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Not an email address")]
        public string Email { get; set; } = null!;
        public int WardId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public string? Avatar { get; set; } = "default.png";
    }
}
