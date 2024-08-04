using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class CoffeeSauce
    {
        public int CoffeeId { get; set; }

        public int SauceId { get; set; }

        [JsonIgnore]
        public Coffee Coffee { get; set; }
     
        public Sauce Sauce { get; set; }

    }
}
