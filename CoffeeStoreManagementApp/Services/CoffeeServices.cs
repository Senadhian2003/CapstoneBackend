using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Models.DTO;
using CoffeeStoreManagementApp.Repositories;
using CoffeeStoreManagementApp.Repositories.Interface;
using CoffeeStoreManagementApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeStoreManagementApp.Services
{
    public class CoffeeServices : ICoffeeServices
    {

        public readonly IRepository<int,Coffee> _coffeeRepository;
        public readonly IRepository<int, Capacity> _capacityRepository;
        public readonly IRepository<int, Milk> _milkRepository;
        public readonly IRepository<int, NonDairyAlternative> _nonDairyAlternativeRepository;
        public readonly IRepository<int, Sauce> _sauceRepository;
        public readonly IRepository<int, Topping> _toppingRepository;
        public readonly IIntermediateModelRepository<int,int, CoffeeCapacity> _coffeeCapacityRepository;
        public readonly IIntermediateModelRepository<int, int, CoffeeMilk> _coffeeMilkRepository;
        public readonly IIntermediateModelRepository<int, int, CoffeeNonDairyAlternative> _coffeeNonDairyAlternativeRepository;
        public readonly IIntermediateModelRepository<int, int, CoffeeSauce> _coffeeSauceRepository;
        public readonly IIntermediateModelRepository<int, int, CoffeeTopping> _coffeeToppingRepository;
        public readonly IBlobService _blobService;

        public CoffeeServices(IBlobService blobService, IRepository<int,Coffee> coffeeRepository, IRepository<int,Capacity> capacityRepository, IRepository<int, Milk> milkRepository, IRepository<int, NonDairyAlternative> nonDairyAlternativeRepository, IRepository<int, Sauce> sauceRepository, IRepository<int, Topping> toppingRepository, IIntermediateModelRepository<int, int, CoffeeTopping> coffeeToppingRepository, IIntermediateModelRepository<int, int, CoffeeSauce> coffeeSauceRepository, IIntermediateModelRepository<int, int, CoffeeNonDairyAlternative> coffeeNonDairyAlternativeRepository, IIntermediateModelRepository<int, int, CoffeeMilk> coffeeMilkRepository, IIntermediateModelRepository<int, int, CoffeeCapacity> coffeeCapacityRepository) {
            _coffeeRepository = coffeeRepository;
            _capacityRepository = capacityRepository;
            _milkRepository = milkRepository;
            _nonDairyAlternativeRepository = nonDairyAlternativeRepository;
            _sauceRepository = sauceRepository;
            _toppingRepository = toppingRepository;
            _coffeeCapacityRepository = coffeeCapacityRepository;
            _coffeeMilkRepository = coffeeMilkRepository;
            _coffeeNonDairyAlternativeRepository = coffeeNonDairyAlternativeRepository;
            _coffeeSauceRepository = coffeeSauceRepository;
            _coffeeToppingRepository = coffeeToppingRepository;
            _blobService = blobService;
        }

        public async Task<Coffee> addNewCoffee(AddNewCoffeeDTO addNewCoffeeDTO)
        {

            Coffee coffee = new Coffee()
            {
                Name = addNewCoffeeDTO.Name,
                Description = addNewCoffeeDTO.Description,
                Price = addNewCoffeeDTO.Price,
                MaxAllowedSauces = addNewCoffeeDTO.MaxAllowedSauces,
                MaxAllowedToppings = addNewCoffeeDTO.MaxAllowedToppings,
                IsAvailable = 1
            };

            await _coffeeRepository.Add(coffee);

            string fileExtension = Path.GetExtension(addNewCoffeeDTO.CoffeeImage.FileName);
            string blobName = $"product-{coffee.Id}{fileExtension}";
            string imageUrl = await _blobService.UploadImageAsync(addNewCoffeeDTO.CoffeeImage, blobName);

            coffee.ImageURL = imageUrl;

            await _coffeeRepository.Update(coffee);

            if (addNewCoffeeDTO.AllowedCapacities.Any())
            {
                foreach(var capacityId in addNewCoffeeDTO.AllowedCapacities)
                {
                    CoffeeCapacity coffeeCapacity = new CoffeeCapacity()
                    {
                        CoffeeId = coffee.Id,
                        CapacityId = capacityId
                    };

                    await _coffeeCapacityRepository.Add(coffeeCapacity);

                }

            }

            if (addNewCoffeeDTO.AllowedMilks.Any())
            {
                foreach (var milkId in addNewCoffeeDTO.AllowedMilks)
                {
                    CoffeeMilk coffeeMilk = new CoffeeMilk()
                    {
                        CoffeeId = coffee.Id,
                        MilkId = milkId
                    };

                    await _coffeeMilkRepository.Add(coffeeMilk);

                }


            }

            if (addNewCoffeeDTO.AllowedNonDairyAlternatives.Any())
            {
                foreach (var nonDairyAlternativeId in addNewCoffeeDTO.AllowedNonDairyAlternatives)
                {
                    CoffeeNonDairyAlternative coffeeNonDairyAlternative = new CoffeeNonDairyAlternative()
                    {
                        CoffeeId = coffee.Id,
                         NonDairyAlternativeId = nonDairyAlternativeId
                    };

                    await _coffeeNonDairyAlternativeRepository.Add(coffeeNonDairyAlternative);

                }


            }


            if (addNewCoffeeDTO.AllowedToppings.Any())
            {
                foreach (var toppingId in addNewCoffeeDTO.AllowedToppings)
                {
                    CoffeeTopping     coffeeTopping = new CoffeeTopping()
                    {
                        CoffeeId = coffee.Id,
                        ToppingId = toppingId
                    };

                    await _coffeeToppingRepository.Add(coffeeTopping);

                }


            }

            if (addNewCoffeeDTO.AllowedSauces.Any())
            {
                foreach (var sauceId in addNewCoffeeDTO.AllowedSauces)
                {
                    CoffeeSauce coffeeSauce = new CoffeeSauce()
                    {
                        CoffeeId = coffee.Id,
                        SauceId = sauceId
                    };

                    await _coffeeSauceRepository.Add(coffeeSauce);

                }


            }



            return coffee;
        }


        public async Task<List<Coffee>> GetAllCofffee()
        {
            var coffees = await _coffeeRepository.GetAll();
            
            if(coffees.Any())
            {
                return coffees.OrderBy(c=>c.Price).ToList();
            }

            throw new EmptyListException("Coffee");

        }

        public async Task<Coffee> GetCoffeeById(int id)
        {
            var coffee = await _coffeeRepository.GetByKey(id);

            if(coffee == null)
            {
                throw new ElementNotFoundException("Coffee");
            }

            return coffee;
        }

        public async Task<Coffee> UpdateCoffeDetails(UpdateCoffeeDTO updateCoffeeDTO)
        {
            var coffee = await _coffeeRepository.GetByKey(updateCoffeeDTO.CoffeeId);

            if (coffee == null)
            {
                throw new ElementNotFoundException("Coffee");
            }

            coffee.Name = updateCoffeeDTO.Name;
            coffee.Description = updateCoffeeDTO.Description;
            coffee.Price = updateCoffeeDTO.Price;
            coffee.IsAvailable = updateCoffeeDTO.Status;

            await _coffeeRepository.Update(coffee);

            return coffee;


        }


        public async Task<GetDetailsForAddingNewCoffeeDTO> GetDetailsForAddingNewCoffee()
        {

            GetDetailsForAddingNewCoffeeDTO resultDTO = new GetDetailsForAddingNewCoffeeDTO();

            var capacities = await _capacityRepository.GetAll();
            var milks = await _milkRepository.GetAll();
            var nonDairyAlternatives = await _nonDairyAlternativeRepository.GetAll();
            var sauces = await _sauceRepository.GetAll();
            var toppings = await _toppingRepository.GetAll();

            resultDTO.Capacities = capacities.ToList();
            resultDTO.Milks = milks.ToList();
            resultDTO.NonDairyAlternatives = nonDairyAlternatives.ToList();
            resultDTO.Sauces = sauces.ToList();
            resultDTO.Toppings = toppings.ToList();

            return resultDTO;
        }


    }
}
