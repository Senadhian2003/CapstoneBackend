using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class NonDairyAlternative
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        [JsonIgnore]
        public ICollection<CoffeeNonDairyAlternative> AllowedCoffees { get; set; }
    }
}
