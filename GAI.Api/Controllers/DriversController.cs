using GAI.Application.Interfaces;
using GAI.Domain.DTOs;
using GAI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace GAI.Api.Controllers
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
        public async ValueTask<IActionResult> GetAllDriversAsync()
        {
            var value = _memoryCache.Get("key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "key",
                    value: await _service.GetAllAsync());
            }
            return Ok(_memoryCache.Get("key") as List<Driver>);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateDriverAsync(DriverDTO driver)
        {
            bool result = await _service.CreateDriverAsync(driver);
            if (result is true)
            {
                var value = _memoryCache.Get("key");
                if (value is not null)
                {
                    _memoryCache.Remove("key");
                }
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetDriverByIdAsync(int id)
        {
            return Ok(await _service.GetDriverById(id));
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateDriverAsync(int id,DriverDTO driverDTO)
        {
            var result = await _service.UpdateDriverAsync(id, driverDTO);
            if (result is true)
            {
                var value = _memoryCache.Get("key");
                if (value is not null)
                {
                    _memoryCache.Remove("key");
                }
                return Ok("Updated");
            }
            return BadRequest("Error!");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteDriverByIdAsync(int id)
        {
            var result = await _service.DeleteDriverAsync(id);
            if (result is true)
            {
                var value = _memoryCache.Get("key");
                if (value is not null)
                {
                    _memoryCache.Remove("key");
                }
                return Ok("Deleted");
            }
            return BadRequest("NotDeleted!");
        }

    }
}
