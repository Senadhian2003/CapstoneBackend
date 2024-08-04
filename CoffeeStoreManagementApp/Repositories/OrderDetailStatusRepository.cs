using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class OrderDetailStatusRepository : IRepository<int, OrderDetailStatus>
    {
        private readonly CoffeeManagementContext _context;
        public OrderDetailStatusRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<OrderDetailStatus> Add(OrderDetailStatus item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<OrderDetailStatus> DeleteByKey(int key)
        {
            var orderDetailStatus = await GetByKey(key);
            if (orderDetailStatus != null)
            {
                _context.Remove(orderDetailStatus);
                await _context.SaveChangesAsync(true);
                return orderDetailStatus;
            }
            throw new ElementNotFoundException("OrderDetailStatus");
        }

        public async Task<OrderDetailStatus> GetByKey(int key)
        {
            var orderDetailStatus = await _context.OrderDetailStatuses.FirstOrDefaultAsync(u => u.Id == key);

            if (orderDetailStatus != null)
            {
                return orderDetailStatus;
            }

            throw new ElementNotFoundException("OrderDetailStatus");
        }

        public async Task<IEnumerable<OrderDetailStatus>> GetAll()
        {
            var orderDetailStatuses = await _context.OrderDetailStatuses.ToListAsync();

            if (orderDetailStatuses.Any())
            {
                return orderDetailStatuses;
            }

            throw new EmptyListException("OrderDetailStatus");

        }

        public async Task<OrderDetailStatus> Update(OrderDetailStatus item)
        {
            var orderDetailStatus = await GetByKey(item.Id);
            if (orderDetailStatus != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return orderDetailStatus;
            }
            throw new ElementNotFoundException("OrderDetailStatus");
        }

    }
}
