using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class CapacityRepository : IRepository<int,Capacity>
    {
        private readonly CoffeeManagementContext _context;
        public CapacityRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<Capacity> Add(Capacity item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Capacity> DeleteByKey(int key)
        {
            var capacity = await GetByKey(key);
            if (capacity != null)
            {
                _context.Remove(capacity);
                await _context.SaveChangesAsync(true);
                return capacity;
            }
            throw new ElementNotFoundException("Capacity");
        }

        public async Task<Capacity> GetByKey(int key)
        {
            var capacity = await _context.Capacities.FirstOrDefaultAsync(u => u.CapacityId == key);

            if (capacity != null)
            {
                return capacity;
            }

            throw new ElementNotFoundException("Capacity");
        }

        public async Task<IEnumerable<Capacity>> GetAll()
        {
            var capacities = await _context.Capacities.ToListAsync();



            return capacities;




        }

        public async Task<Capacity> Update(Capacity item)
        {
            var capacity = await GetByKey(item.CapacityId);
            if (capacity != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return capacity;
            }
            throw new ElementNotFoundException("Capacity");
        }




    }
}
