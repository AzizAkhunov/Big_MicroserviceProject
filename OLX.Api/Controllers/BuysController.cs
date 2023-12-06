using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;

namespace OLX.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuysController : ControllerBase
    {
        private readonly IBuyService _service;

        public BuysController(IBuyService service)
        {
            _service = service;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllBuys()
        {
            return Ok(await _service.GetAllBuyAsync());
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateBuyAsync(BuysDTO buy)
        {
            if (await _service.CreateBuyAsync(buy))
            {
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetBuyById(int id)
        {
            return Ok(await _service.GetBuyById(id));
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteBuyById(int id)
        {
            if (await _service.DeleteBuyAsync(id))
            {
                return Ok("Deleted!");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateBuyAsync(int id, BuysDTO buy)
        {
            if (await _service.UpdateBuyAsync(id, buy))
            {
                return Ok("updated");
            }
            return BadRequest("Error!");
        }

    }
}
