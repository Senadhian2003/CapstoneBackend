using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class OrderRepository : IRepository<int,Order>
    {

        private readonly CoffeeManagementContext _context;
        public OrderRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<Order> Add(Order item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Order> DeleteByKey(int key)
        {
            var order = await GetByKey(key);
            if (order != null)
            {
                _context.Remove(order);
                await _context.SaveChangesAsync(true);
                return order;
            }
            throw new ElementNotFoundException("Order");
        }

        public async Task<Order> GetByKey(int key)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(u => u.OrderId == key);

            if (order != null)
            {
                return order;
            }

            throw new ElementNotFoundException("Order");
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = await _context.Orders.Include(o=>o.OrderDetails).ThenInclude(od=>od.OrderDetailStatuses).Include(o=>o.User).ToListAsync();

            if (orders.Any())
            {
                return orders;
            }

            throw new EmptyListException("Order");

        }

        public async Task<Order> Update(Order item)
        {
            var order = await GetByKey(item.OrderId);
            if (order != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return order;
            }
            throw new ElementNotFoundException("Order");
        }



    }
}
