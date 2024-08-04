using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class OrderDetailRepository : IRepository<int,OrderDetail>
    {

        private readonly CoffeeManagementContext _context;
        public OrderDetailRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<OrderDetail> Add(OrderDetail item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<OrderDetail> DeleteByKey(int key)
        {
            var orderDetail = await GetByKey(key);
            if (orderDetail != null)
            {
                _context.Remove(orderDetail);
                await _context.SaveChangesAsync(true);
                return orderDetail;
            }
            throw new ElementNotFoundException("OrderDetail");
        }

        public async Task<OrderDetail> GetByKey(int key)
        {
            var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(u => u.OrderDetailId == key);

            if (orderDetail != null)
            {
                return orderDetail;
            }

            throw new ElementNotFoundException("OrderDetail");
        }

        public async Task<IEnumerable<OrderDetail>> GetAll()
        {
            var orderDetails = await _context.OrderDetails.ToListAsync();

            if (orderDetails.Any())
            {
                return orderDetails;
            }

            throw new EmptyListException("OrderDetail");

        }

        public async Task<OrderDetail> Update(OrderDetail item)
        {
            var orderDetail = await GetByKey(item.OrderDetailId);
            if (orderDetail != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return orderDetail;
            }
            throw new ElementNotFoundException("OrderDetail");
        }



    }
}
