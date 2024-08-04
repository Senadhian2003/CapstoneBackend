using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;

namespace CoffeeStoreManagementApp.Repositories
{
    public class CoffeeMilkRepository : IIntermediateModelRepository<int, int, CoffeeMilk>
    {
        private readonly CoffeeManagementContext _context;
        public CoffeeMilkRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<CoffeeMilk> Add(CoffeeMilk item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

    }
}
