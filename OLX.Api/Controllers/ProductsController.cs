using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;

namespace OLX.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService productService)
        {
                _service = productService;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllProductsAsync()
        {
            return Ok(await _service.GetAllProductsAsync());
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateUserAsync(ProductsDTO product)
        {
            if (await _service.CreateUserAsync(product))
            {
                return Ok("Added!");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetProductByIdAsync(int id)
        {
            return Ok(await _service.GetProductById(id));
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteProductAsync(int id)
        {
            if (await _service.DeleteProductAsync(id))
            {
                return Ok("deleted");
            }
            return BadRequest("Error");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateUserAsync(int id, ProductsDTO product)
        {
            if (await _service.UpdateProductAsync(id, product))
            {
                return Ok("Updated");
            }
            return BadRequest("Error!");
        }
    }
}
