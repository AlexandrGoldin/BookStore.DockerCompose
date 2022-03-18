using BookStore.Server.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.BLL.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductAsync(int id);
        Task<ProductModel> SaveProductAsync(ProductModel productModel);
        Task DeleteProductAsync(int id);
    }
}
