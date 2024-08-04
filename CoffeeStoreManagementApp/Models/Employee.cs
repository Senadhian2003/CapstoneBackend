using System.ComponentModel.DataAnnotations;

namespace CoffeeStoreManagementApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
