using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;

namespace CoffeeStoreManagementApp.Repositories
{
    public class CoffeeCapacityRepository : IIntermediateModelRepository<int, int, CoffeeCapacity>
    {

        private readonly CoffeeManagementContext _context;
        public CoffeeCapacityRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<CoffeeCapacity> Add(CoffeeCapacity item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

    }
}
