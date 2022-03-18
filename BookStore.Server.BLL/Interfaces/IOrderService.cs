using BookStore.Server.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetOrderListAsync();      
        Task<OrderModel> GetOrderAsync(int id);
        Task<OrderModel> SaveOrderAsync(OrderModel orderModel);
        Task DeleteOrderAsync(int id);
    }
}
