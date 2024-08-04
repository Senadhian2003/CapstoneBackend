using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;

namespace CoffeeStoreManagementApp.Repositories
{
    public class CoffeeToppingRepository : IIntermediateModelRepository<int, int, CoffeeTopping>
    {
        private readonly CoffeeManagementContext _context;
        public CoffeeToppingRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<CoffeeTopping> Add(CoffeeTopping item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
