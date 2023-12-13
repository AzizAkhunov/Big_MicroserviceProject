using GAI.Application.Interfaces;
using GAI.Domain.DTOs;
using GAI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GAI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GaiesController : ControllerBase
    {
        private readonly IYPXService _service;
        private readonly IMemoryCache _memoryCache;
        public GaiesController(IYPXService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllYPXAsync()
        {
            var value = _memoryCache.Get("Gaies_key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "Gaies_key",
                    value: await _service.GetAllAsync());
            }
            return Ok(_memoryCache.Get("Gaies_key") as List<YPX>);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateYPXAsync(YPXDTO ypxDTO)
        {
            bool result = await _service.CreateYPXAsync(ypxDTO);
            if (result is true)
            {
                var value = _memoryCache.Get("Gaies_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Gaies_key");
                }
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetYPXByIdAsync(int id)
        {
            return Ok(await _service.GetYPXById(id));
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateYPXAsync(int id, YPXDTO ypxDTO)
        {
            var result = await _service.UpdateYPXAsync(id, ypxDTO);
            if (result is true)
            {
                var value = _memoryCache.Get("Gaies_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Gaies_key");
                }
                return Ok("Updated");
            }
            return BadRequest("Error!");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteYPXByIdAsync(int id)
        {
            var result = await _service.DeleteYPXAsync(id);
            if (result is true)
            {
                var value = _memoryCache.Get("Gaies_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Gaies_key");
                }
                return Ok("Deleted");
            }
            return BadRequest("NotDeleted!");
        }
    }
}
