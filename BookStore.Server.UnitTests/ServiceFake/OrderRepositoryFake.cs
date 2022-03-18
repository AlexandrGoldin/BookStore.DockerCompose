using BookStore.Server.DAL.Entities;
using BookStore.Server.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.UnitTests.ServiceFake
{
    public class OrderRepositoryFake : IOrderRepository
    {
        private readonly List<Order> _orders;

        public OrderRepositoryFake()
        {
            var orderDate = DateTime.Now;
            _orders = new List<Order>()
            {
                new Order()
                {
                    Id=8,
                    Email="m.1960@gmail.com",
                    Name="Static",
                    Address="Vostochnaya 9",
                    OrderDate=DateTime.Now,
                    Total=1660.00m,
                    CartItems= new List<CartItem>()
                    {
                     new CartItem() {Id=3, OrderId=8, ProductId=2, Count=4},
                    }
                },                  
                new Order()
                {
                    Id=14,
                    Email="m.1960@gmail.com",
                    Name="test",
                    Address="Vostoc 9",
                    OrderDate=DateTime.Now,
                    Total=2126.00m,
                    CartItems= new List<CartItem>()
                    {
                     new CartItem() {Id=11, OrderId=14, ProductId=2, Count=2},
                     new CartItem() {Id= 12, OrderId=14, ProductId= 3, Count= 2 }
                     }
                },
                new Order(){
                   Id=15,
                    Email="m.1960@gmail.com",
                    Name="test",
                    Address="tochnaya 9",
                    OrderDate=DateTime.Now,
                    Total=1471.00m,
                    CartItems= new List<CartItem>()
                    {
                     new CartItem() {Id=14, OrderId=15, ProductId=3, Count=1},
                     new CartItem() {Id= 15, OrderId=15, ProductId= 6, Count= 2 },
                     new CartItem() {Id= 16, OrderId=15, ProductId= 10, Count= 1 }
                     }
                },
                new Order(){
                    Id=16,
                    Email="m.1960@gmail.com",
                    Name="Static",
                    Address="Vostoc 3",
                    OrderDate=DateTime.Now,
                    Total=959.00m,
                    CartItems= new List<CartItem>()
                    {
                     new CartItem() {Id=18, OrderId=16, ProductId=1, Count=1,},
                    }
                }
            };

        }

        public Task DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetOrderListAsync()
        {
            return _orders;
        }

        public async Task<Order> SaveOrderAsync(Order order)
        {
            _orders.Add(order);
            return order;
        }
    }
}
