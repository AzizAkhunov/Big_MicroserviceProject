using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;
        private readonly IMemoryCache _memoryCache;
        public ClientsController(IClientService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllClients()
        {
            var value = _memoryCache.Get("Clients_key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "Clients_key",
                    value: await _service.GetAllAsync());
            }
            return Ok(_memoryCache.Get("Clients_key") as List<Client>);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateClientAsync(ClientDTO client)
        {
            if (await _service.CreateClientAsync(client))
            {
                var value = _memoryCache.Get("Clients_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Clients_key");
                }
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
                var value = _memoryCache.Get("Clients_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Clients_key");
                }
                return Ok("Deleted!");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateClientAsync(int id, ClientDTO client)
        {
            if (await _service.UpdateClientAsync(id, client))
            {
                var value = _memoryCache.Get("Clients_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Clients_key");
                }
                return Ok("updated");
            }
            return BadRequest("Error!");
        }
        [HttpPost]
        public async ValueTask<IActionResult> Leave_FeedBack(int driverId,string description)
        {
            if (await _service.Leave_FeedBack(driverId, description))
            {
                var value = _memoryCache.Get("Clients_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Clients_key");
                }
                return Ok("FeedBack qabul qilindi!");
            }
            return BadRequest("Error!");
        }
    }
}
