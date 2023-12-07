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
        [HttpGet]
        public async ValueTask<IActionResult> GetAllScrins()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCarAsync(int clientId,ScrinDTO scrin)
        {
            if (await _service.CreateScrinAsync(clientId,scrin))
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
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteScrinById(int id)
        {
            if (await _service.DeleteScrinAsync(id))
            {
                return Ok("Deleted!");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateScrinAsync(int id, ScrinDTO car)
        {
            if (await _service.UpdateScrinAsync(id, car))
            {
                return Ok("updated");
            }
            return BadRequest("Error!");
        }
    }
}
