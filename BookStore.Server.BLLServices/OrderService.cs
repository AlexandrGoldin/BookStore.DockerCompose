using AutoMapper;
using BookStore.Server.BLL.Interfaces;
using BookStore.Server.BLL.Models;
using BookStore.Server.DAL.Entities;
using BookStore.Server.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.BLLServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _roductRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ICartItemRepository cartItemRepository,
           IProductRepository roductRepository, IMapper mapper, ILogger<OrderService> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _cartItemRepository = cartItemRepository ?? throw new ArgumentNullException(nameof(cartItemRepository));
            _roductRepository = roductRepository ?? throw new ArgumentNullException(nameof(roductRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task DeleteOrderAsync(int id)
        {
            _logger.LogInformation($"Deleting order with Id:{id}");
            await _orderRepository.DeleteOrderAsync(id);
        }

        public async Task<OrderModel> GetOrderAsync(int id)
        {
            Order order = await _orderRepository.GetOrderAsync(id);
            OrderModel orderModel = new OrderModel();
            List<CartItemModel> cartItemModelList = new List<CartItemModel>();
            List<CartItem> cartItemList = _cartItemRepository.GetCartItemByOrderIdList(id);

            foreach (var i in cartItemList)
            {
                var product = await _roductRepository.GetProductAsync(i.ProductId);

                var cartItemModel = new CartItemModel()
                {
                    Id = i.Id,
                    OrderId = i.OrderId,
                    ProductId = i.ProductId,
                    Count = i.Count,
                    Product = _mapper.Map<ProductModel>(product)
                };
                cartItemModelList.Add(cartItemModel);
            }
            _logger.LogInformation($"GetOrderList method created cartItemModelList in quantity:{cartItemModelList.Count}");

            if (order != null)
                orderModel = new OrderModel()
                {
                    Id = order.Id,
                    Name = order.Name,
                    Email = order.Email,
                    Address = order.Address,
                    OrderDate = order.OrderDate,
                    Total = order.Total,
                    CartItems = cartItemModelList
                };
            _logger.LogInformation($"GetOrderList method  creatied orderModelList in quantity:{orderModel.Total}");
            return orderModel;
        }

        public async Task<IEnumerable<OrderModel>> GetOrderListAsync()
        {
            _logger.LogInformation("Getting all orders method executing...");
            List<OrderModel> orderModelList = new List<OrderModel>();
            var orderIdList = await _orderRepository.GetOrderListAsync();

            foreach (var o in orderIdList)
            {
                List<CartItemModel> cartItemModelList = new List<CartItemModel>();
                IEnumerable<CartItem> cartItemList = _cartItemRepository.GetCartItemByOrderIdList(o.Id);
                OrderModel orderModel = new OrderModel();

                foreach (var i in cartItemList)
                {
                    var product = await _roductRepository.GetProductAsync(i.ProductId);

                    var cartItemModel = new CartItemModel()
                    {
                        Id = i.Id,
                        OrderId = i.OrderId,
                        ProductId = i.ProductId,
                        Count = i.Count,
                        Product = _mapper.Map<ProductModel>(product)
                    };
                    cartItemModelList.Add(cartItemModel);
                }
                _logger.LogInformation($"GetOrderList method created cartItemModelList in quantity:{cartItemModelList.Count}");

                var order = await _orderRepository.GetOrderAsync(o.Id);

                if (order != null)
                    orderModel = new OrderModel()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Email = o.Email,
                        Address = o.Address,
                        OrderDate = o.OrderDate,
                        Total = o.Total,
                        CartItems = cartItemModelList
                    };
                orderModelList.Add(orderModel);
            }
            _logger.LogInformation($"GetOrderList method  creatied orderModelList in quantity:{orderModelList.Count}");
            return orderModelList;
        }

        public async Task<OrderModel> SaveOrderAsync(OrderModel orderModel)
        {
            var order = _mapper.Map<Order>(orderModel);
            _logger.LogInformation($"Created Oder for the amount:{order.Total}");

            await _orderRepository.SaveOrderAsync(order);
            return _mapper.Map<OrderModel>(order);

        }
    }
}
