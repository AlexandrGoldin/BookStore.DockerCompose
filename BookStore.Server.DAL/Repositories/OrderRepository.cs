using BookStore.Server.DAL.EF;
using BookStore.Server.DAL.Entities;
using BookStore.Server.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Server.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreContext _context;
        public OrderRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrderListAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public List<Order> GetOrderList()
        {
            return _context.Orders.ToList();
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _context.Orders
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Order> SaveOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
                _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
