using BookStore.Server.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrderListAsync();
        Task<Order> GetOrderAsync(int id);
        Task<Order> SaveOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
    }
}
