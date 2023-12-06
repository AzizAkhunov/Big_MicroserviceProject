using GAI.Application.Interfaces;
using GAI.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GAI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PunishmentsController : ControllerBase
    {
        private readonly IPunishmentService _service;

        public PunishmentsController(IPunishmentService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllPunishmentsAsync()
        {
            var result = await _service.GetAllPunishmentsAsync();
            return Ok(result);
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
