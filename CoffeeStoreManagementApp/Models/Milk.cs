using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class Milk
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        [JsonIgnore]
        public List<CoffeeMilk> AllowedCoffees { get; set; }
    }
}
