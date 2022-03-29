using AutoMapper;
using BookStore.Server.BLL.Interfaces;
using BookStore.Server.BLL.Models;
using BookStore.Server.DAL.Entities;
using BookStore.Server.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BookStore.Server.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, IMapper mapper, 
            ILogger<ProductService> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            _logger.LogInformation("GetAll method executing...");
            var products = await _productRepository.GetAllProductsAsync();
            _logger.LogInformation($"Returning {products.Count} products.");

            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<ProductModel> GetProductAsync(int id)
        {
            var product = await _productRepository.GetProductAsync(id);
            
            _logger.LogInformation($"Getting the product with Id:{id}");
            return _mapper.Map<ProductModel>(product);
        }

        public async Task<ProductModel> SaveProductAsync(ProductModel productModel)
        {
            _logger.LogInformation("SaveProduct method executing...");
            var product = _mapper.Map<Product>(productModel);
            await _productRepository.SaveProductAsync(product);
            _logger.LogInformation($"Saving product with name:{productModel.Title}");

            return _mapper.Map<ProductModel>(product);          
        }

        public async Task DeleteProductAsync(int id)
        {
            _logger.LogInformation($"Deleting product with Id:{id}");
            await _productRepository.DeleteProductAsync(id);
        }
    }
}

