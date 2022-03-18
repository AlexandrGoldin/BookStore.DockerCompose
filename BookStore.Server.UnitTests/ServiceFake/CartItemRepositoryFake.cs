using BookStore.Server.DAL.Entities;
using BookStore.Server.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.UnitTests.ServiceFake
{
    public class CartItemRepositoryFake : ICartItemRepository
    {
        private readonly List<CartItem> _cartItems;
        public CartItemRepositoryFake()
        {
            _cartItems = new List<CartItem>()
            {
                new CartItem(){Id=3, OrderId=8, ProductId=2, Count=4},
                new CartItem(){Id=11, OrderId=14, ProductId=2, Count=2},
                new CartItem(){Id= 12,OrderId=14, ProductId= 3, Count= 2 },
                new CartItem(){Id=14, OrderId=15, ProductId=3, Count=1},
                new CartItem(){Id= 15, OrderId=15, ProductId= 6, Count= 2 },
                new CartItem(){Id= 16, OrderId=15, ProductId= 10, Count= 1 },
                new CartItem() {Id=18, OrderId=16, ProductId=1, Count=1}
            };
        }

        public Task<CartItem> GetCartItemAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<CartItem> GetCartItemByOrderIdList(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<CartItem>> GetCartItemByOrderIdListAsync(int id)
        {
            return _cartItems;
        }

        public Task<CartItem> SaveCartItemAsync(CartItem cartItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
