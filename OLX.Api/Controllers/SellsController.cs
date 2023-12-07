using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SellsController : ControllerBase
    {
        private readonly ISellService _service;
        private readonly IMemoryCache _memoryCache;

        public SellsController(ISellService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllSells()
        {
            var value = _memoryCache.Get("key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "key",
                    value: await _service.GetAllSellAsync());
            }
            return Ok(_memoryCache.Get("key") as List<Sell>);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateSellAsync(SellsDTO sell)
        {
            if (await _service.CreateSellAsync(sell))
            {
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetSellById(int id)
        {
            return Ok(await _service.GetSellById(id));
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteSellById(int id)
        {
            if (await _service.DeleteSellAsync(id))
            {
                return Ok("Deleted!");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateSellAsync(int id, SellsDTO sell)
        {
            if (await _service.UpdateSellAsync(id, sell))
            {
                return Ok("updated");
            }
            return BadRequest("Error!");
        }
    }
}
