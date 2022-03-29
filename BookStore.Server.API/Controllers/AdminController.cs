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
    public class AdminController : ControllerBase
    {
        private readonly OrderHandler _orderHandler;
        private readonly ProductHandler _productHandler;
        private readonly ILogger<AdminController> _logger;

        public AdminController(OrderHandler orderHandler, ProductHandler productHandler,
            ILogger<AdminController> logger)
        {
            _orderHandler = orderHandler;
            _productHandler = productHandler;
            _logger = logger;
        }

        //GET api/Admin/Index
        /// <summary>
        /// Gets the list of orders
        /// </summary>
        /// <returns>Returns list OrderReadDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">If the request its bad</response>
        [HttpGet, Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> Index()
        {
            _logger.LogDebug("GettingAll Orders method executing...");
            var orders = await _orderHandler.GetOrderListAsync();
            _logger.LogInformation($"Returning {orders.Count} orders.");

            return Ok(orders);
        }

        // GET api/Admin/5
        /// <summary>
        /// Gets a order by id
        /// </summary>
        /// Semple request:
        /// GET api/Admin/5
        /// <param name="id"></param>
        /// <returns>OrderReadDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">If the request its bad</response>
        [HttpGet, Route("GetOrder/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            var orderReadDto = await _orderHandler.GetOrderAsync(id);
            if (orderReadDto.Id == 0)
            {
                return BadRequest();
            }
            return Ok(orderReadDto);
        }

        // DELETE api/Admin/DeleteOrder/5
        /// <summary>
        /// Deletes the order by id
        /// </summary>
        /// <remarks>
        /// Semple request:
        /// DELETE api/AdminAdmin/DeleteOrder/5
        /// </remarks>
        /// <param name="id">Id of the order (int)</param>
        /// <returns>Returns Ok</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        [HttpDelete, Route("DeleteOrder/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var order = await _orderHandler.GetOrderAsync(id);
            if(order.Id==0)
            {
                return BadRequest();
            }
            await _orderHandler.DeleteOrderAsync(id);
            _logger.LogInformation($"Deleting order with Id:{id}");

            return Ok();
        }

        //GET api/Admin
        /// <summary>
        /// Gets the list of products(books)
        /// </summary>
        /// <returns>Returns list ProductReadDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">If the request its bad</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<ProductReadDto>> GetAllProductsAsync()
        {
            _logger.LogInformation("Getting all products");
            return await _productHandler.GetAllProductsAsync();
        }

        //GET api/Admin/5
        /// <summary>
        /// Gets a product by id
        /// </summary>
        /// Semple request:
        /// GET api/Admin/3
        /// <param name="id"></param>
        /// <returns>ProductReadDto</returns>
        ///  /// <response code="200">Success</response>
        /// <response code="400">If the request its bad</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductReadDto>> GetProduct(int id)
        {
            _logger.LogInformation($"Getting product with Id:{id}");
            var productReadDto= await _productHandler.GetProductAsync(id);
            if(productReadDto==null)
            {
                return BadRequest();
            }
            return Ok(productReadDto);
        }

        // POST api/Admin/SaveProduct
        /// <summary>
        /// Creates a product(book)
        /// </summary>
        /// <Rrmarks>
        /// Sample request:
        /// POST api/Admin/SaveProduct
        /// {
        ///   title:""Девушка в тумане"",
        ///   author:"Донато Карризи",
        ///   image:"https://cv2.litres.ru/pub/c/elektronnaya-kniga/cover_330/27066425-donato-karrizi-devushka-v-tumane.jpg",
        ///   price: 399.00,
        ///   genre:"Детектив",
        ///   rating:"4",
        ///   description:"От дома, где сияют огни елки и лежат подарки, до празднично украшенной местной церкви всего триста 
        ///   метров, но в церкви юная Анна Лу так и не появилась… "
        /// }
        /// </Rrmarks>
        /// <param name="productCreateDto"></param>
        /// <returns>Returns ProductReadDto</returns>
        /// <response code="201">Creates a book</response> 
        /// <response code="400">Bad Request</response>
        [HttpPost, Route("SaveProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductReadDto>> SaveProduct([FromBody]ProductCreateDto productCreateDto)
        {
            _logger.LogInformation($"Saving product with name:{productCreateDto.Title}");
            return new ObjectResult(await _productHandler.SaveProductAsync(productCreateDto)){ StatusCode = StatusCodes.Status201Created }; 
        }

        // DELETE api/products/DeleteProduct/5
        /// <summary>
        /// Deletes the product(book) by id
        /// </summary>
        /// <remarks>
        /// Semple request:
        /// DELETE api/products/DeleteProduct/5
        /// </remarks>
        /// <param name="id">Id of the product (int)</param>
        /// <returns>Returns Ok</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        [HttpDelete, Route("DeleteProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _productHandler.GetProductAsync(id);
            if(product==null)
            {
                return BadRequest();
            }

            await _productHandler.DeleteProductAsync(id);
            _logger.LogInformation($"Deleting order with Id:{id}");

            return Ok();
        }
    }
}
