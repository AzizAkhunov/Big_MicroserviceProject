using GAI.Application.Interfaces;
using GAI.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GAI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _service;

        public DriversController(IDriverService service)
        {
            _service = service;
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
            return Ok(await _service.GetDriverById(id));
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
