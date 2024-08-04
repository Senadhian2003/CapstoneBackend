using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoffeeStoreManagementApp.Models
{
    public class EmployeeCredential
    {
        [Key]
        public string Email { get; set; }
        public int EmployeeId { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] HashKey { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

    }
}
