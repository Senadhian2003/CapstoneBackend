using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Models.DTO;

namespace CoffeeStoreManagementApp.Services.Interfaces
{
    public interface ICoffeeServices
    {

        public Task<List<Coffee>> GetAllCofffee();
        
        public Task<Coffee> GetCoffeeById(int id);

        public Task<Coffee> UpdateCoffeDetails(UpdateCoffeeDTO updateCoffeeDTO);

        public Task<GetDetailsForAddingNewCoffeeDTO> GetDetailsForAddingNewCoffee();

        public Task<Coffee> addNewCoffee(AddNewCoffeeDTO addNewCoffeeDTO);
    }
}
