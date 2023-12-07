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
            var value = _memoryCache.Get("key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "key",
                    value: await _service.GetAllAsync());
            }
            return Ok(_memoryCache.Get("key") as List<YPX>);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateYPXAsync(YPXDTO ypxDTO)
        {
            bool result = await _service.CreateYPXAsync(ypxDTO);
            if (result is true)
            {
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
                return Ok("Deleted");
            }
            return BadRequest("NotDeleted!");
        }
    }
}
