using System.Drawing;
using System.Text.Json.Serialization;

namespace CoffeeStoreManagementApp.Models
{
    public class CoffeeCapacity
    {
        public int CoffeeId { get; set; }

        public int CapacityId { get; set; }

        [JsonIgnore]
        public Coffee Coffee { get; set; }

        public Capacity Capacity { get; set; }

    }
}
