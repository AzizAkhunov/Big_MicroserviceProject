using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMemoryCache _memoryCache;
        public OrdersController(IOrderService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllOrders()
        {
            var value = _memoryCache.Get("key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "key",
                    value: await _service.GetAllAsync());
            }
            return Ok(_memoryCache.Get("key") as List<Order>);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateOrderAsync(OrderDTO order)
        {
            if (await _service.CreateOrderAsync(order))
            {
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetOrderById(int id)
        {
            return Ok(await _service.GetOrderById(id));
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteOrderById(int id)
        {
            if (await _service.DeleteOrderAsync(id))
            {
                return Ok("Deleted!");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateOrderAsync(int id, OrderDTO order)
        {
            if (await _service.UpdateOrderAsync(id, order))
            {
                return Ok("updated");
            }
            return BadRequest("Error!");
        }
    }
}
