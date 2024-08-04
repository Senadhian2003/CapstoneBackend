using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class Topping
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        [JsonIgnore]
        public ICollection<CoffeeTopping> AllowedCoffees { get; set; }

    }
}
