using AutoMapper;
using BookStore.Server.API.DTO;
using BookStore.Server.BLL.Interfaces;
using BookStore.Server.BLL.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BookStore.Server.API.DtoHandlers
{
    public class ProductHandler
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ProductHandler(IProductService productService, IMapper mapper, IMemoryCache cache)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));

        }

        public async Task<List<ProductReadDto>> GetAllProductsAsync()
        {
            List<ProductModel> productModels = null;
            if (!_cache.TryGetValue("currentProductList", out productModels))
            {
                productModels = await _productService.GetAllProductsAsync();
                if (productModels != null)
                {
                    _cache.Set("currentProductList", productModels, new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(30)));
                }
            }
            return _mapper.Map<List<ProductReadDto>>(productModels);
        }

        public async Task<ProductReadDto> GetProductAsync(int id)
        {
            var productModel = await _productService.GetProductAsync(id);
            if (productModel == null)
                throw new ValidationException();

            return _mapper.Map<ProductReadDto>(productModel);
        }

        public async Task<ProductReadDto> SaveProductAsync(ProductCreateDto productCreateDto)
        {
            var productModel = _mapper.Map<ProductModel>(productCreateDto);
            await _productService.SaveProductAsync(productModel);

            var productReadDto = _mapper.Map<ProductReadDto>(productModel);

            return productReadDto;
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productService.DeleteProductAsync(id);

        }
    }
}
