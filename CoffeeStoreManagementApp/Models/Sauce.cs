using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class Sauce
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        [JsonIgnore]
        public ICollection<CoffeeSauce> AllowedCoffees { get; set; }
       
    }
}
