namespace CoffeeStoreManagementApp.Models.DTO
{
    public class GetDetailsForAddingNewCoffeeDTO
    {
        public ICollection<Capacity> Capacities { get; set; }
        public ICollection<Milk> Milks { get; set; }
        public ICollection<NonDairyAlternative> NonDairyAlternatives { get; set; }
        public ICollection<Sauce> Sauces { get; set; }
        public ICollection<Topping> Toppings { get; set; }

    }
}
