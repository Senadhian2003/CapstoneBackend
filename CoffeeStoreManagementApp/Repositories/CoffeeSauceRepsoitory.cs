using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class CoffeeSauceRepsoitory : IIntermediateModelRepository<int, int, CoffeeSauce>
    {

        private readonly CoffeeManagementContext _context;
        public CoffeeSauceRepsoitory(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<CoffeeSauce> Add(CoffeeSauce item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

    }
}
