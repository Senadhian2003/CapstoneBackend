using System.ComponentModel.DataAnnotations;

namespace CoffeeStoreManagementApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }

        public Cart Cart { get; set; }

    }
}
