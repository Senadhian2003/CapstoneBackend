using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class OrderDetailStatus
    {
        [Key]
        public int Id { get; set; }

        public int OrderDetailId { get; set; }


        [JsonIgnore]
        [ForeignKey(nameof(OrderDetailId))]
        public OrderDetail OrderDetail { get; set; }

        public string Status { get; set; }



    }
}
