using ProductApp.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;
using ProductApp.API.Contracts;
using ProductApp.Core.Models;

namespace ProductApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        { 
            _productsService = productsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<ProductResponse>>> GetProducts()
        {
            try
            {
                var products = await _productsService.GetAllProducts();

                var response = products.Select(p => new ProductResponse(p.Id, p.Name, p.Description, p.Price, p.CategoryId));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<string>> CreateProduct([FromBody] ProductRequest request)
        {
            try
            {
                var error = Product.ValidateData(request.Name, request.Description, request.Price);

                if (!string.IsNullOrEmpty(error))
                {
                    return BadRequest(error);
                }

                var product = Product.Create(request.Name, request.Description, request.Price, request.CategoryId);

                await _productsService.CreateProduct(product);

                return Ok($"Product {request.Name} created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<string>> UpdateProduct(int id, [FromBody] ProductRequest request)
        {
            try
            {
                var error = Product.ValidateData(request.Name, request.Description, request.Price);

                if (!string.IsNullOrEmpty(error))
                {
                    return BadRequest(error);
                }

                var result = await _productsService.UpdateProduct(id, request.Name, request.Description, request.Price);

                if (result == 0)
                {
                    return NotFound("Product not found");
                }

                return Ok("Product updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<string>> DeleteProduct(int id)
        {
            try
            {
                var result = await _productsService.DeleteProduct(id);

                if (result == 0) 
                {
                    return NotFound("Product not found");
                }

                return Ok("Product deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
