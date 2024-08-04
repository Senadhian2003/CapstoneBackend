namespace CoffeeStoreManagementApp.Models
{
    public class Coffee
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int IsAvailable { get; set; }

        public int MaxAllowedSauces { get; set; }
        public int MaxAllowedToppings { get; set; }

        public ICollection<CoffeeCapacity> AllowedCapacities { get; set; }

        public ICollection<CoffeeMilk> AllowedMilks { get; set; }

        public ICollection<CoffeeNonDairyAlternative> AllowedCoffeeNonDairyAlternatives { get; set; }
        public ICollection<CoffeeSauce> AllowedSauces { get; set; }
        public ICollection<CoffeeTopping> AllowedToppings { get; set; }


        public double Price { get; set; }

        public string? ImageURL { get; set; }

    }
}
