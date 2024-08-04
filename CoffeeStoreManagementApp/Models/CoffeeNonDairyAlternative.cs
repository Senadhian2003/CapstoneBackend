using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class CoffeeNonDairyAlternative
    {

        public int CoffeeId { get; set; }

        public int NonDairyAlternativeId { get; set; }

        [JsonIgnore]
        public Coffee Coffee { get; set; }

        public NonDairyAlternative NonDairyAlternative { get; set; }

    }
}
