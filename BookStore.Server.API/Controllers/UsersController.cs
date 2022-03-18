using BookStore.Server.API.DTO;
using BookStore.Server.API.DtoHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ProductHandler _productHandler;
        private readonly OrderHandler _orderHandler;

        public UsersController(ProductHandler productHandler, OrderHandler orderHandler,
            ILogger<UsersController> logger)
        {
            _productHandler = productHandler;
            _orderHandler = orderHandler;
            _logger = logger;
        }

        // GET api/Users/Index
        /// <summary>
        /// Gets the list of products(books)
        /// </summary>
        /// <returns>Returns ProductReadDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">If the request its bad</response>
        [HttpGet,Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<ProductReadDto>> Index()
        {
            _logger.LogInformation("Getting all the products");
            return await _productHandler.GetAllProductsAsync();
        }

        // POST api/Users/CreateOrder
        /// <summary>
        /// Creates the purchase order a books 
        /// </summary>
        /// <param name="orderCreateDto"></param>
        /// <returns>Returns OrderReadDto</returns>
        /// <response code="201">Success</response> 
        /// <response code="400">Bad Request</response>
        [HttpPost, Route("CreateOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody]OrderCreateDto orderCreateDto)
        {
            _logger.LogInformation("Post method executing...");
            if (orderCreateDto == null)
            {
                _logger.LogWarning("orderCreateDto == null and cant be created");
                return BadRequest();
            }
            await _orderHandler.SaveOrderAsync(orderCreateDto);
            _logger.LogInformation($"Created Oder for the amount:{orderCreateDto.Total}");
            return new ObjectResult(orderCreateDto){ StatusCode = StatusCodes.Status201Created };
        }
    }
}
