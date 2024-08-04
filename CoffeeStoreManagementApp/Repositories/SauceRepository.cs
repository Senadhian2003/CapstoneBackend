using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class SauceRepository : IRepository<int,Sauce>
    {

        private readonly CoffeeManagementContext _context;
        public SauceRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<Sauce> Add(Sauce item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Sauce> DeleteByKey(int key)
        {
            var sauce = await GetByKey(key);
            if (sauce != null)
            {
                _context.Remove(sauce);
                await _context.SaveChangesAsync(true);
                return sauce;
            }
            throw new ElementNotFoundException("Sauce");
        }

        public async Task<Sauce> GetByKey(int key)
        {
            var sauce = await _context.Sauces.FirstOrDefaultAsync(u => u.Id == key);

            if (sauce != null)
            {
                return sauce;
            }

            throw new ElementNotFoundException("Sauce");
        }

        public async Task<IEnumerable<Sauce>> GetAll()
        {
            var sauces = await _context.Sauces.ToListAsync();

            if (sauces.Any())
            {
                return sauces;
            }

            throw new EmptyListException("Sauce");

        }

        public async Task<Sauce> Update(Sauce item)
        {
            var sauce = await GetByKey(item.Id);
            if (sauce != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return sauce;
            }
            throw new ElementNotFoundException("Sauce");
        }




    }
}
