using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMemoryCache _memoryCache;

        public ProductsController(IProductService productService, IMemoryCache memoryCache)
        {
            _service = productService;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllProductsAsync()
        {
            var value = _memoryCache.Get("Product_key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "Product_key",
                    value: await _service.GetAllProductsAsync());
            }
            return Ok(_memoryCache.Get("Product_key") as List<Product>);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateUserAsync(ProductsDTO product)
        {
            if (await _service.CreateUserAsync(product))
            {
                var value = _memoryCache.Get("Product_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Product_key");
                }
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
                var value = _memoryCache.Get("Product_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Product_key");
                }
                return Ok("deleted");
            }
            return BadRequest("Error");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateUserAsync(int id, ProductsDTO product)
        {
            if (await _service.UpdateProductAsync(id, product))
            {
                var value = _memoryCache.Get("Product_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Product_key");
                }
                return Ok("Updated");
            }
            return BadRequest("Error!");
        }
    }
}
