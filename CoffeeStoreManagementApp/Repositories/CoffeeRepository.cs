using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class CoffeeRepository : IRepository<int, Coffee>    
    {

        private readonly CoffeeManagementContext _context;
        public CoffeeRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<Coffee> Add(Coffee item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Coffee> DeleteByKey(int key)
        {
            var coffee = await GetByKey(key);
            if (coffee != null)
            {
                _context.Remove(coffee);
                await _context.SaveChangesAsync(true);
                return coffee;
            }
            throw new ElementNotFoundException("Coffee");
        }

        public async Task<Coffee> GetByKey(int key)
        {
            var coffee = await _context.Coffees
    .Include(c => c.AllowedCapacities)
        .ThenInclude(cc => cc.Capacity)
    .Include(c => c.AllowedMilks)
        .ThenInclude(cm => cm.Milk)
    .Include(c => c.AllowedCoffeeNonDairyAlternatives)
        .ThenInclude(cnda => cnda.NonDairyAlternative)
    .Include(c => c.AllowedSauces)
        .ThenInclude(cs => cs.Sauce)
    .Include(c => c.AllowedToppings)
        .ThenInclude(ct => ct.Topping)
    .FirstOrDefaultAsync(c => c.Id == key);

            if (coffee != null)
            {
                return coffee;
            }

            throw new ElementNotFoundException("Coffee");
        }

        public async Task<IEnumerable<Coffee>> GetAll()
        {
            var coffees = await _context.Coffees.ToListAsync();

            if (coffees.Any())
            {
                return coffees;
            }

            throw new EmptyListException("Coffee");

        }

        public async Task<Coffee> Update(Coffee item)
        {
            var coffee = await GetByKey(item.Id);
            if (coffee != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return coffee;
            }
            throw new ElementNotFoundException("Coffee");
        }



    }
}
