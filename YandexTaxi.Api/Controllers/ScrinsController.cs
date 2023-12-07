using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;

namespace YandexTaxi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScrinsController : ControllerBase
    {
        private readonly IScrinService _service;

        public ScrinsController(IScrinService service)
        {
            _service = service;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateScrinAsync(ScrinDTO scrin)
        {
            if (await _service.CreateScrinAsync(scrin))
            {
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
            return Ok(await _service.GetAllAsync());
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteScrinById(int id)
        {
            return Ok(await _service.DeleteScrinAsync(id));
        }
    }
}
