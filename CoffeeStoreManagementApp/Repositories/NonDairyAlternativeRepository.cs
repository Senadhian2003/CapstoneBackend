using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class NonDairyAlternativeRepository : IRepository<int,NonDairyAlternative>
    {
        private readonly CoffeeManagementContext _context;
        public NonDairyAlternativeRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<NonDairyAlternative> Add(NonDairyAlternative item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<NonDairyAlternative> DeleteByKey(int key)
        {
            var nonDairyAlternative = await GetByKey(key);
            if (nonDairyAlternative != null)
            {
                _context.Remove(nonDairyAlternative);
                await _context.SaveChangesAsync(true);
                return nonDairyAlternative;
            }
            throw new ElementNotFoundException("NonDairyAlternative");
        }

        public async Task<NonDairyAlternative> GetByKey(int key)
        {
            var nonDairyAlternative = await _context.NonDairyAlternatives.FirstOrDefaultAsync(u => u.Id == key);

            if (nonDairyAlternative != null)
            {
                return nonDairyAlternative;
            }

            throw new ElementNotFoundException("NonDairyAlternative");
        }

        public async Task<IEnumerable<NonDairyAlternative>> GetAll()
        {
            var nonDairyAlternatives = await _context.NonDairyAlternatives.ToListAsync();



            return nonDairyAlternatives;




        }

        public async Task<NonDairyAlternative> Update(NonDairyAlternative item)
        {
            var nonDairyAlternative = await GetByKey(item.Id);
            if (nonDairyAlternative != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return nonDairyAlternative;
            }
            throw new ElementNotFoundException("NonDairyAlternative");
        }



    }
}
