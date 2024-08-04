using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class EmployeeCredentialRepository : IRepository<int, EmployeeCredential>
    {

        private readonly CoffeeManagementContext _context;
        public EmployeeCredentialRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<EmployeeCredential> Add(EmployeeCredential item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<EmployeeCredential> DeleteByKey(int key)
        {
            var employeeCredential = await GetByKey(key);
            if (employeeCredential != null)
            {
                _context.Remove(employeeCredential);
                await _context.SaveChangesAsync(true);
                return employeeCredential;
            }
            throw new ElementNotFoundException("EmployeeCredential");
        }

        public async Task<EmployeeCredential> GetByKey(int key)
        {
            var employeeCredential = await _context.EmployeeCredentials.FirstOrDefaultAsync(u => u.EmployeeId == key);

            if (employeeCredential != null)
            {
                return employeeCredential;
            }

            throw new ElementNotFoundException("EmployeeCredential");
        }

        public async Task<IEnumerable<EmployeeCredential>> GetAll()
        {
            var employeeCredentials = await _context.EmployeeCredentials.ToListAsync();

            if (employeeCredentials.Any())
            {
                return employeeCredentials;
            }

            throw new EmptyListException("EmployeeCredential");

        }

        public async Task<EmployeeCredential> Update(EmployeeCredential item)
        {
            var employeeCredential = await GetByKey(item.EmployeeId);
            if (employeeCredential != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return employeeCredential;
            }
            throw new ElementNotFoundException("EmployeeCredential");
        }



    }
}
