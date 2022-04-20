using AutoMapper;
using BookStore.Server.BLL.Models;
using BookStore.Server.BLLServices;
using BookStore.Server.DAL.Interfaces;
using BookStore.Server.UnitTests.ServiceFake;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Server.UnitTests.Tests
{
    public class UsersController_CreateOrderTests
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly OrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private static IMapper _orderMapper;

        public UsersController_CreateOrderTests()
        {
            if (_orderMapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new BLL.BLLMappingProfile.OrderProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _orderMapper = mapper;
            }

            using var logOrderFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var _orderLogger = logOrderFactory.CreateLogger<OrderService>();

            _orderRepository = new OrderRepositoryFake();
            _productRepository = new ProductRepositoryFake();
            _cartItemRepository = new CartItemRepositoryFake();

            _orderService = new OrderService(_orderRepository, _cartItemRepository, _productRepository,
                _orderMapper, _orderLogger);
        }

        [Fact]
        public async Task AddOrder_InvalidObjectPassed_Success()
        {
            // Arrange
            var orderDate = DateTime.Now;
            var orderModel = new OrderModel()
            {
                Id = 8,
                Email = "m.1960@gmail.com",
                Name = "Static",
                Address = "Vostochnaya 9",
                OrderDate = DateTime.Now,
                Total = 1660.00m,
                CartItems = new List<CartItemModel>()
            };

            //Act
            var createdOrder = await _orderService.SaveOrderAsync(orderModel);

            //Assert
            Assert.IsType<OrderModel>(createdOrder);
            Assert.Equal("Vostochnaya 9", createdOrder.Address);
            Assert.Equal("m.1960@gmail.com", createdOrder.Email);
        }      
    }
}
