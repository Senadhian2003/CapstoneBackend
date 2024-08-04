using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class CoffeeMilk
    {
        public int CoffeeId { get; set; }

        public int MilkId { get; set; }

        [JsonIgnore]
        public Coffee Coffee { get; set; }

        public Milk Milk { get; set; }

    }
}
