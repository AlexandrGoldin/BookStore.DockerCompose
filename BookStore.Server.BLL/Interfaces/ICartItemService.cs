using BookStore.Server.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.BLL.Interfaces
{
    public interface ICartItemService
    {
        Task<List<CartItemModel>> GetCartItemByOrderIdListAaync(int id);
        Task<CartItemModel> GetCartItemAsync(int id);
    }
}
