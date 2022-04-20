using AutoMapper;
using BookStore.Server.BLL.BLLMappingProfile;
using BookStore.Server.BLL.Models;
using BookStore.Server.BLLServices;
using BookStore.Server.DAL.Interfaces;
using BookStore.Server.UnitTests.ServiceFake;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Server.UnitTests.Tests
{
    public class UsersController_ProductListTests
    {
        private readonly ProductService _productService;
        private readonly IProductRepository _productRepository;
        private static IMapper _mapper;

        public UsersController_ProductListTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ProductProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            //var logger = new Mock<ILogger<UsersController>>();

            using var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var _logger = logFactory.CreateLogger<ProductService>();

            _productRepository = new ProductRepositoryFake();
            _productService = new ProductService(_productRepository, _mapper, _logger);
        }

        [Fact]
        public async Task GetAllProducts_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = await _productService.GetAllProductsAsync();

            //// Assert
            //Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
            Assert.IsType<List<ProductModel>>(okResult);
        }

        [Fact]
        public async Task GetAllProducts_WhenCalled_ReturnsAllItems()
        {
            //Act
            var okResult = await _productService.GetAllProductsAsync();

            //Assert
            var items = Assert.IsType<List<ProductModel>>(okResult);
            Assert.Equal(4, items.Count);
        }
    }
}
