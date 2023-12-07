using Microsoft.AspNetCore.Mvc;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;

namespace YandexTaxi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllClients()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateClientAsync(ClientDTO client)
        {
            if (await _service.CreateClientAsync(client))
            {
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetClientById(int id)
        {
            return Ok(await _service.GetClientById(id));
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteClientById(int id)
        {
            if (await _service.DeleteClientAsync(id))
            {
                return Ok("Deleted!");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateClientAsync(int id, ClientDTO client)
        {
            if (await _service.UpdateClientAsync(id, client))
            {
                return Ok("updated");
            }
            return BadRequest("Error!");
        }
        [HttpPost]
        public async ValueTask<IActionResult> Leave_FeedBack(int driverId,string description)
        {
            if (await _service.Leave_FeedBack(driverId, description))
            {
                return Ok("FeedBack qabul qilindi!");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetClientOrders(int id)
        {
            return Ok(await _service.GetClientOrdersAsync(id));
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetClientCards(int id)
        {
            return Ok(await _service.GetClientCardsAsync(id));
        }
    }
}
