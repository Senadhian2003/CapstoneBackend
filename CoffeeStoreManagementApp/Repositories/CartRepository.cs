using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class CartRepository : IRepository<int,Cart>
    {

        private readonly CoffeeManagementContext _context;
        public CartRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<Cart> Add(Cart item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Cart> DeleteByKey(int key)
        {
            var cart = await GetByKey(key);
            if (cart != null)
            {
                _context.Remove(cart);
                await _context.SaveChangesAsync(true);
                return cart;
            }
            throw new ElementNotFoundException("Cart");
        }

        public async Task<Cart> GetByKey(int key)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(u => u.CartId == key);

            if (cart != null)
            {
                return cart;
            }

            throw new ElementNotFoundException("Cart");
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            var carts = await _context.Carts.Include(c=>c.CartItems).ThenInclude(ci=>ci.Coffee).ToListAsync();

            if (carts.Any())
            {
                return carts;
            }

            throw new EmptyListException("Cart");

        }

        public async Task<Cart> Update(Cart item)
        {
            var cart = await GetByKey(item.CartId);
            if (cart != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return cart;
            }
            throw new ElementNotFoundException("Cart");
        }




    }
}
