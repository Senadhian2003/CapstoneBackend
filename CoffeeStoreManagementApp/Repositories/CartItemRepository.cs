using CoffeeStoreManagementApp.Context;
using CoffeeStoreManagementApp.Exceptions;
using CoffeeStoreManagementApp.Models;
using CoffeeStoreManagementApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Repositories
{
    public class CartItemRepository : IRepository<int, CartItem>
    {

        private readonly CoffeeManagementContext _context;
        public CartItemRepository(CoffeeManagementContext context)
        {
            _context = context;
        }
        public async Task<CartItem> Add(CartItem item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<CartItem> DeleteByKey(int key)
        {
            var cartItem = await GetByKey(key);
            if (cartItem != null)
            {
                _context.Remove(cartItem);
                await _context.SaveChangesAsync(true);
                return cartItem;
            }
            throw new ElementNotFoundException("CartItem");
        }

        public async Task<CartItem> GetByKey(int key)
        {
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(u => u.CartItemId == key);

            if (cartItem != null)
            {
                return cartItem;
            }

            throw new ElementNotFoundException("CartItem");
        }

        public async Task<IEnumerable<CartItem>> GetAll()
        {
            var cartItems = await _context.CartItems.ToListAsync();

            if (cartItems.Any())
            {
                return cartItems;
            }

            throw new EmptyListException("CartItem");

        }

        public async Task<CartItem> Update(CartItem item)
        {
            var cartItem = await GetByKey(item.CartItemId);
            if (cartItem != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return cartItem;
            }
            throw new ElementNotFoundException("CartItem");
        }



    }
}
