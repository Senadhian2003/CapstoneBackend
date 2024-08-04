using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;

namespace CoffeeStoreManagementApp.Repositories
{
    public class CoffeeNonDairyAlternativeRepository : IIntermediateModelRepository<int, int, CoffeeNonDairyAlternative>
    {
        private readonly CoffeeManagementContext _context;
        public CoffeeNonDairyAlternativeRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<CoffeeNonDairyAlternative> Add(CoffeeNonDairyAlternative item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
