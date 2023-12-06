using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;

namespace OLX.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SellsController : ControllerBase
    {
        private readonly ISellService _service;

        public SellsController(ISellService service)
        {
            _service = service;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllSells()
        {
            return Ok(await _service.GetAllSellAsync());
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateSellAsync(SellsDTO sell)
        {
            if (await _service.CreateSellAsync(sell))
            {
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetSellById(int id)
        {
            return Ok(await _service.GetSellById(id));
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteSellById(int id)
        {
            if (await _service.DeleteSellAsync(id))
            {
                return Ok("Deleted!");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateSellAsync(int id, SellsDTO sell)
        {
            if (await _service.UpdateSellAsync(id, sell))
            {
                return Ok("updated");
            }
            return BadRequest("Error!");
        }
    }
}
