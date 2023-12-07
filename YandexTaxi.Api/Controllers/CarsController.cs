using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;

namespace YandexTaxi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCars()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCarAsync(CarDTO car)
        {
            if (await _service.CreateCarAsync(car))
            {
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetCarById(int id)
        {
            return Ok(await _service.GetCarById(id));
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCarById(int id)
        {
            if (await _service.DeleteCarAsync(id))
            {
                return Ok("Deleted!");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateCarAsync(int id, CarDTO car)
        {
            if (await _service.UpdateCarAsync(id, car))
            {
                return Ok("updated");
            }
            return BadRequest("Error!");
        }
    }
}
