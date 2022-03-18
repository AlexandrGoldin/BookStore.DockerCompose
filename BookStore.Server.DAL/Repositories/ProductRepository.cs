using BookStore.Server.DAL.EF;
using BookStore.Server.DAL.Entities;
using BookStore.Server.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BookStoreContext _context;
        public ProductRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveProductAsync(Product product)
        {
            if (product.Id != 0)
                _context.Entry(product).State = EntityState.Modified;
            else
                _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(e => e.Id == id);
            if (product != null)
                _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
