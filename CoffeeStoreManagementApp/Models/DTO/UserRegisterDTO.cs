using System.ComponentModel.DataAnnotations;

namespace CoffeeStoreManagementApp.Models.DTO
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 characters.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters long.")]
        public string Password { get; set; }

    }
}
