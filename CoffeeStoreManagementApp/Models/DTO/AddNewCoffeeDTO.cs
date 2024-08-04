using System.ComponentModel.DataAnnotations;

namespace CoffeeStoreManagementApp.Models.DTO
{
    public class AddNewCoffeeDTO
    {
       
        public string Name { get; set; }

      
        public string Description { get; set; }
        //public string Author { get; set; }
    
        public double Price { get; set; }

        public int MaxAllowedSauces { get; set; }
        public int MaxAllowedToppings { get; set; }

        public ICollection<int> AllowedCapacities { get; set; }

        public ICollection<int> AllowedMilks { get; set; }

        public ICollection<int> AllowedNonDairyAlternatives { get; set; }
        public ICollection<int> AllowedSauces { get; set; }
        public ICollection<int> AllowedToppings { get; set; }

        public IFormFile CoffeeImage { get; set; }

    }
}
