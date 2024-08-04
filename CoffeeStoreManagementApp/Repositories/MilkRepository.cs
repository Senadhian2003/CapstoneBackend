using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class MilkRepository : IRepository<int, Milk>
    {
        private readonly CoffeeManagementContext _context;
        public MilkRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<Milk> Add(Milk item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Milk> DeleteByKey(int key)
        {
            var milk = await GetByKey(key);
            if (milk != null)
            {
                _context.Remove(milk);
                await _context.SaveChangesAsync(true);
                return milk;
            }
            throw new ElementNotFoundException("Milk");
        }

        public async Task<Milk> GetByKey(int key)
        {
            var milk = await _context.Milks.FirstOrDefaultAsync(u => u.Id == key);

            if (milk != null)
            {
                return milk;
            }

            throw new ElementNotFoundException("Milk");
        }

        public async Task<IEnumerable<Milk>> GetAll()
        {
            var milks = await _context.Milks.ToListAsync();



            return milks;




        }

        public async Task<Milk> Update(Milk item)
        {
            var milk = await GetByKey(item.Id);
            if (milk != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return milk;
            }
            throw new ElementNotFoundException("Milk");
        }




    }
}
