using GAI.Application.Interfaces;
using GAI.Domain.DTOs;
using GAI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace GAI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _service;
        private readonly IDistributedCache _distributedCache;

        public DriversController(IDriverService service, IDistributedCache distributedCache)
        {
            _service = service;
            _distributedCache = distributedCache;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllDriversAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateDriverAsync(DriverDTO driver)
        {
            bool result = await _service.CreateDriverAsync(driver);
            if (result is true)
            {
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetDriverByIdAsync(int id)
        {
            var fromCache = await _distributedCache.GetStringAsync($"Driver{id}");

            if (fromCache is null)
            {
                var values = await _service.GetDriverById(id);

                fromCache = JsonSerializer.Serialize(values);
                await _distributedCache.SetStringAsync($"Driver{values.Id}", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });

            }

            var result = JsonSerializer.Deserialize<Driver>(fromCache);
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateDriverAsync(int id,DriverDTO driverDTO)
        {
            var result = await _service.UpdateDriverAsync(id, driverDTO);
            if (result is true)
            {
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
                return Ok("Deleted");
            }
            return BadRequest("NotDeleted!");
        }

    }
}
