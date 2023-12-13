using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _service;
        private readonly IMemoryCache _memoryCache;
        public DriversController(IDriverService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllDrivers()
        {
            var value = _memoryCache.Get("Drivers_key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "Drivers_key",
                    value: await _service.GetAllAsync());
            }
            return Ok(_memoryCache.Get("Drivers_key") as List<Driver>);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateDriverAsync(DriverDTO driver)
        {
            if (await _service.CreateDriverAsync(driver))
            {
                var value = _memoryCache.Get("Drivers_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Drivers_key");
                }
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetDriverById(int id)
        {
            return Ok(await _service.GetDriverById(id));
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteDriverById(int id)
        {
            if (await _service.DeleteDriverAsync(id))
            {
                var value = _memoryCache.Get("Drivers_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Drivers_key");
                }
                return Ok("Deleted!");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateClientAsync(int id, DriverDTO driver)
        {
            if (await _service.UpdateDriverAsync(id, driver))
            {
                var value = _memoryCache.Get("Drivers_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Drivers_key");
                }
                return Ok("updated");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> AskForIncrease(int driverId,decimal approximate_amount)
        {
            if (await _service.AskForIncrease(driverId, approximate_amount))
            {
                var value = _memoryCache.Get("Drivers_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Drivers_key");
                }
                return Ok("Sizning Oiligingiz suralgan naxrga kutarildi !");
            }
            return BadRequest("Sizning Oilingizni kutara olmaymiz siz yetarli vaqt ishlamadingiz Yoki Kotta narx talab qolipsiz");
        }
    }
}
