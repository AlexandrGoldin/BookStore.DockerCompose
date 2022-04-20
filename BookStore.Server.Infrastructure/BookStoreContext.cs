using BookStore.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Server.Infrastructure
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
