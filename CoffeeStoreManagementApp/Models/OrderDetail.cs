using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }

        public string CoffeeName { get; set; }

        public string AddOns { get; set; }

        public int Quanitty { get; set; }

        public double PricePerItem { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public double FinalAmount => Price - Discount;

        public ICollection<OrderDetailStatus> OrderDetailStatuses { get; set; }



    }
}
