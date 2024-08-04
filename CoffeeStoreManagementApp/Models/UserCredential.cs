using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoffeeStoreManagementApp.Models
{
    public class UserCredential
    {

        [Key]
        public string Email { get; set; }
        public int UserId { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] HashKey { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }


    }
}
