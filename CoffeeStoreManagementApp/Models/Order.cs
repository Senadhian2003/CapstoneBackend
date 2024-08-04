using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeStoreManagementApp.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]

        public User User { get; set; }

        public DateTime TimeOfOrder { get; set; }

        public string OrderStatus { get; set; }

        public int TotalItems { get; set; }

        public int ItemsServed { get; set; }

        public double TotalPrice { get; set;}

        public ICollection<OrderDetail> OrderDetails { get; set; }  
    }
}
