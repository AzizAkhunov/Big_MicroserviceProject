using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;

namespace YandexTaxi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllOrders()
        {
            return Ok(await _service.GetAllAsync());
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
        public async ValueTask<IActionResult> DeleteCardById(int id)
        {
            if (await _service.DeleteOrderAsync(id))
            {
                return Ok("Deleted!");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateOrderAsync(int id, OrderDTO card)
        {
            if (await _service.UpdateOrderAsync(id, card))
            {
                return Ok("updated");
            }
            return BadRequest("Error!");
        }
    }
}
