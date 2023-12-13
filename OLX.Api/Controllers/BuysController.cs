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
    public class BuysController : ControllerBase
    {
        private readonly IBuyService _service;
        private readonly IMemoryCache _memoryCache;
        public BuysController(IBuyService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllBuys()
        {
            var value = _memoryCache.Get("Buys_key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "Buys_key",
                    value: await _service.GetAllBuyAsync());
            }
            return Ok(_memoryCache.Get("Buys_key") as List<Buy>);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateBuyAsync(BuysDTO buy)
        {
            if (await _service.CreateBuyAsync(buy))
            {
                var value = _memoryCache.Get("Buys_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Buys_key");
                }
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetBuyById(int id)
        {
            return Ok(await _service.GetBuyById(id));
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteBuyById(int id)
        {
            if (await _service.DeleteBuyAsync(id))
            {
                var value = _memoryCache.Get("Buys_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Buys_key");
                }
                return Ok("Deleted!");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateBuyAsync(int id, BuysDTO buy)
        {
            if (await _service.UpdateBuyAsync(id, buy))
            {
                var value = _memoryCache.Get("Buys_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Buys_key");
                }
                return Ok("updated");
            }
            return BadRequest("Error!");
        }

    }
}
