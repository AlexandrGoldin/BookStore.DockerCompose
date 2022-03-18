using BookStore.Server.DAL.EF;
using BookStore.Server.DAL.Entities;
using BookStore.Server.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Server.DAL.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly BookStoreContext _context;
        public CartItemRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<CartItem> GetCartItemAsync(int id)
        {
            return await _context.CartItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public List<CartItem> GetCartItemByOrderIdList(int id)
        {
            return _context.CartItems.Where(p => p.OrderId == id).ToList();
        }

        public async Task<List<CartItem>> GetCartItemByOrderIdListAsync(int id)
        {
            return await _context.CartItems.Where(p => p.OrderId == id).ToListAsync();
        }

        public async Task<CartItem> SaveCartItemAsync(CartItem cartItem)
        {
            if (cartItem == null)
            {
                throw new ArgumentNullException($"NotFound");
            }

            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return  cartItem;
        }
    }
}
