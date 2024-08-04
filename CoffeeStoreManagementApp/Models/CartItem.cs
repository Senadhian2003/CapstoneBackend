using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; } 

        public int CartId { get; set; }

        public int CoffeeId { get; set; }

        public string AddOns { get; set; }

        public int Quantity { get; set; }

        public double PricePerCartItem { get; set; }

        public double CartItemPrice { get; set; }

        public double FinalAmount => (CartItemPrice - Discount);

        public double Discount { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }

        [ForeignKey(nameof(CoffeeId))]
        public Coffee Coffee { get; set; }


    }
}
