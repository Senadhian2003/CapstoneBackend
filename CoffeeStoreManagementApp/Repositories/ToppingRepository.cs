using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class ToppingRepository : IRepository<int, Topping>
    {

        private readonly CoffeeManagementContext _context;
        public ToppingRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<Topping> Add(Topping item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Topping> DeleteByKey(int key)
        {
            var topping = await GetByKey(key);
            if (topping != null)
            {
                _context.Remove(topping);
                await _context.SaveChangesAsync(true);
                return topping;
            }
            throw new ElementNotFoundException("Topping");
        }

        public async Task<Topping> GetByKey(int key)
        {
            var topping = await _context.Toppings.FirstOrDefaultAsync(u => u.Id == key);

            if (topping != null)
            {
                return topping;
            }

            throw new ElementNotFoundException("Topping");
        }

        public async Task<IEnumerable<Topping>> GetAll()
        {
            var toppings = await _context.Toppings.ToListAsync();

            
            
                return toppings;
            

          

        }

        public async Task<Topping> Update(Topping item)
        {
            var topping = await GetByKey(item.Id);
            if (topping != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return topping;
            }
            throw new ElementNotFoundException("Topping");
        }




    }
}
