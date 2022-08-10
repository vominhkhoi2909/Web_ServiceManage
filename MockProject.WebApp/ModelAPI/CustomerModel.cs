using System.ComponentModel.DataAnnotations;

namespace MockProject.WebApp.ModelAPI
{
    public class CustomerModel
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string name { get; set; } = null!;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Not an email address")]
        public string email { get; set; } = null!;
        [Required(ErrorMessage = "Phone is required")]
        public string phone { get; set; } = null!;
        public string? address { get; set; }

   
    }
}
