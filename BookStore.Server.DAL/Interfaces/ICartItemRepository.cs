using BookStore.Server.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.DAL.Interfaces
{
    public interface ICartItemRepository
    {
        Task<List<CartItem>> GetCartItemByOrderIdListAsync(int id);
        List<CartItem> GetCartItemByOrderIdList(int id);
        Task<CartItem> GetCartItemAsync(int id);
        Task<CartItem> SaveCartItemAsync(CartItem cartItem);
    }
}
