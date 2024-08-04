using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class Capacity
    {
        [Key]
        public int CapacityId { get; set; }
        public string CapacityName { get; set;}

        public double Price { get; set; }

        [JsonIgnore]
        public List<CoffeeCapacity> AllowedCoffees { get; set; }

    }
}
