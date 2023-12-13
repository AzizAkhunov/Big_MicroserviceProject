using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScrinsController : ControllerBase
    {
        private readonly IScrinService _service;
        private readonly IMemoryCache _memoryCache;
        public ScrinsController(IScrinService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateScrinAsync(ScrinDTO scrin)
        {
            if (await _service.CreateScrinAsync(scrin))
            {
                var value = _memoryCache.Get("Scrins_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Scrins_key");
                }
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetScrinById(int id)
        {
            return Ok(await _service.GetScrinById(id));
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var value = _memoryCache.Get("Scrins_key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "Scrins_key",
                    value: await _service.GetAllAsync());
            }
            return Ok(_memoryCache.Get("Scrins_key") as List<Scrin>);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteScrinById(int id)
        {
            var result = await _service.DeleteScrinAsync(id);
            if (result != "Error!")
            {
                var value = _memoryCache.Get("Scrins_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Scrins_key");
                }
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
