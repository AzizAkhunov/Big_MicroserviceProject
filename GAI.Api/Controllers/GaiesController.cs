using GAI.Application.Interfaces;
using GAI.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GAI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GaiesController : ControllerBase
    {
        private readonly IYPXService _service;

        public GaiesController(IYPXService service)
        {
            _service = service;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllYPXAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
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
        [HttpGet]
        public IActionResult YPXsPunishments(int GaiId)
        {
            var result = _service.GetYPXPunishments(GaiId);
            return Ok(result.Punishments);
        }
    }
}
