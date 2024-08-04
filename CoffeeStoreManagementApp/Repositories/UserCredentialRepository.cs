using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class UserCredentialRepository : IRepository<int,UserCredential>
    {

        private readonly CoffeeManagementContext _context;
        public UserCredentialRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<UserCredential> Add(UserCredential item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<UserCredential> DeleteByKey(int key)
        {
            var userCredential = await GetByKey(key);
            if (userCredential != null)
            {
                _context.Remove(userCredential);
                await _context.SaveChangesAsync(true);
                return userCredential;
            }
            throw new ElementNotFoundException("UserCredential");
        }

        public async Task<UserCredential> GetByKey(int key)
        {
            var userCredential = await _context.UserCredentials.FirstOrDefaultAsync(u => u.UserId == key);

            if (userCredential != null)
            {
                return userCredential;
            }

            throw new ElementNotFoundException("UserCredential");
        }

        public async Task<IEnumerable<UserCredential>> GetAll()
        {
            var userCredentials = await _context.UserCredentials.ToListAsync();

            if (userCredentials.Any())
            {
                return userCredentials;
            }

            throw new EmptyListException("UserCredential");

        }

        public async Task<UserCredential> Update(UserCredential item)
        {
            var userCredential = await GetByKey(item.UserId);
            if (userCredential != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return userCredential;
            }
            throw new ElementNotFoundException("UserCredential");
        }

    }
}
