using Microsoft.AspNetCore.Mvc;
using ProductApp.API.Contracts;
using ProductApp.Core.Abstractions;
using ProductApp.Core.Models;

namespace ProductApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsCategoriesController : ControllerBase
    {
        private readonly IProductsCategoriesService _productsCategoriesService;

        public ProductsCategoriesController(IProductsCategoriesService productsCategoriesService)
        {
            _productsCategoriesService = productsCategoriesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductCategory>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<List<ProductCategoryResponse>>> GetProductsCategories()
        {
            try
            {
                var productsCategories = await _productsCategoriesService.GetAllProductsCategories();

                var response = productsCategories.Select(p => new ProductCategoryResponse(p.Id, p.Name, p.Description));

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
        public async Task<ActionResult<string>> CreateProductCategory([FromBody] ProductCategoryRequest request)
        {
            try
            {
                var error = ProductCategory.ValidateData(request.Name, request.Description);

                if (!string.IsNullOrEmpty(error))
                {
                    return BadRequest(error);
                }

                var productCategory = ProductCategory.Create(request.Name, request.Description);

                await _productsCategoriesService.CreateProductCategory(productCategory);

                return Ok($"Category {request.Name} created successfully");
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
        public async Task<ActionResult<string>> UpdateProductCategory(int id, [FromBody] ProductCategoryRequest request)
        {
            try
            {
                var error = ProductCategory.ValidateData(request.Name, request.Description);

                if (!string.IsNullOrEmpty(error))
                {
                    return BadRequest(error);
                }

                var result = await _productsCategoriesService.UpdateProductCategory(id, request.Name, request.Description);

                if (result == 0)
                {
                    return NotFound("Category not found");
                }

                return Ok("Category updated successfully");
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
        public async Task<ActionResult<string>> DeleteProductCategory(int id)
        {
            try
            {
                var result = await _productsCategoriesService.DeleteProductCategory(id);

                if (result == 0)
                {
                    return NotFound("Category not found");
                }

                return Ok("Category deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
