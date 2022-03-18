using BookStore.Server.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task SaveProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
