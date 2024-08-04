namespace CoffeeStoreManagementApp.Models.DTO
{
    public class UpdateCoffeeDTO
    {

        public int CoffeeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        public int Status { get; set; } 

    }
}
