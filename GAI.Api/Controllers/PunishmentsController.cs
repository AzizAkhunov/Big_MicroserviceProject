using GAI.Application.Interfaces;
using GAI.Domain.DTOs;
using GAI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GAI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PunishmentsController : ControllerBase
    {
        private readonly IPunishmentService _service;
        private readonly IMemoryCache _memoryCache;
        public PunishmentsController(IPunishmentService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }
        [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllPunishmentsAsync()
        {
            var value = _memoryCache.Get("key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "key",
                    value: await _service.GetAllPunishmentsAsync());
            }
            return Ok(_memoryCache.Get("key") as List<Punishment>);
        }
        [Authorize]
        [HttpPost]
        public async ValueTask<IActionResult> CreatePunishmentAsync(PunishmentDTO punishmentDTO)
        {
            bool result = await _service.CreatePunishmentAsync(punishmentDTO);
            if (result is true)
            {
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetPunishmentByIdAsync(int id)
        {
            return Ok(await _service.GetPunishmentByIdAsync(id));
        }
        [Authorize]
        [HttpPut]
        public async ValueTask<IActionResult> UpdatePunishmentAsync(int id, PunishmentDTO punishmentDTO)
        {
            var result = await _service.UpdatePunishmentAsync(id, punishmentDTO);
            if (result is true)
            {
                return Ok("Updated");
            }
            return BadRequest("Error!");
        }
        [Authorize]
        [HttpDelete]
        public async ValueTask<IActionResult> DeletePunishmentByIdAsync(int id)
        {
            var result = await _service.DeletePunishmentByIdAsync(id);
            if (result is true)
            {
                return Ok("Deleted");
            }
            return BadRequest("NotDeleted!");
        }
    }
}
