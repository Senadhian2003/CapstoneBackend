using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class CoffeeTopping
    {
        public int CoffeeId { get; set; }

        public int ToppingId { get; set; }

        [JsonIgnore]
        public Coffee Coffee { get; set; }

        public Topping Topping { get; set; }

    }
}
