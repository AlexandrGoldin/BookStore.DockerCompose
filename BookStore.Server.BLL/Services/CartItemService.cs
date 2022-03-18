using AutoMapper;
using BookStore.Server.BLL.Interfaces;
using BookStore.Server.BLL.Models;
using BookStore.Server.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.BLL.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        //  changr on DataManger 
        public CartItemService(ICartItemRepository cartItemRepository,
            IProductRepository productRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<CartItemModel>> GetCartItemByOrderIdListAaync(int id)
        {
            List<CartItemModel> cartItemsMList = new List<CartItemModel>();
            var cartItemList = await _cartItemRepository.GetCartItemByOrderIdListAsync(id);

            foreach (var i in cartItemList)
            {
                var product = await _productRepository.GetProductAsync(i.ProductId);

                var cartItemM = new CartItemModel()
                {
                    Id = i.Id,
                    OrderId = i.OrderId,
                    ProductId = i.ProductId,
                    Count = i.Count,
                    Product = _mapper.Map<ProductModel>(product)
                };
                cartItemsMList.Add(cartItemM);
            }
            return cartItemsMList; // :))) !!!
        }

        public async Task<CartItemModel> GetCartItemAsync(int id)
        {
            var cartItem = await _cartItemRepository.GetCartItemAsync(id);
            var product = await _productRepository.GetProductAsync(cartItem.ProductId);


            var cartItemModel = new CartItemModel()
            {
                Id = cartItem.Id,
                OrderId = cartItem.OrderId,
                ProductId = cartItem.ProductId,
                Count = cartItem.Count,
                Product = _mapper.Map<ProductModel>(product)
            };
            return cartItemModel;
        }

        public async Task<CartItemModel> SaveCartItemAsync(CartItemModel cartItemModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCartItemAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}