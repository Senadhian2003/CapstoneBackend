using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class EmployeeRepository : IRepository<int,Employee>
    {

        private readonly CoffeeManagementContext _context;
        public EmployeeRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Employee> DeleteByKey(int key)
        {
            var employee = await GetByKey(key);
            if (employee != null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync(true);
                return employee;
            }
            throw new ElementNotFoundException("Employee");
        }

        public async Task<Employee> GetByKey(int key)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(u => u.EmployeeId == key);

            if (employee != null)
            {
                return employee;
            }

            throw new ElementNotFoundException("Employee");
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();

            if (employees.Any())
            {
                return employees;
            }

            throw new EmptyListException("Employee");

        }

        public async Task<Employee> Update(Employee item)
        {
            var employee = await GetByKey(item.EmployeeId);
            if (employee != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return employee;
            }
            throw new ElementNotFoundException("Employee");
        }


    }
}
