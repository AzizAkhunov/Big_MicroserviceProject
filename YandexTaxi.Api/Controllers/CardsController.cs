using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _service;
        private readonly IMemoryCache _memoryCache;
        public CardsController(ICardService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllCards()
        {
            var value = _memoryCache.Get("Card_key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "Card_key",
                    value: await _service.GetAllAsync());
            }
            return Ok(_memoryCache.Get("Card_key") as List<Card>);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCardAsync(CardDTO card)
        {
            if (await _service.CreateCardAsync(card))
            {
                var value = _memoryCache.Get("Card_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Card_key");
                }
                return Ok("Added");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetCardById(int id)
        {
            return Ok(await _service.GetCardById(id));
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCardById(int id)
        {
            if (await _service.DeleteCardAsync(id))
            {
                var value = _memoryCache.Get("Card_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Card_key");
                }
                return Ok("Deleted!");
            }
            return BadRequest("Error!");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateCardAsync(int id, CardDTO card)
        {
            if (await _service.UpdateCardAsync(id, card))
            {
                var value = _memoryCache.Get("Card_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Card_key");
                }
                return Ok("updated");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetCardAmount(int id)
        {
            var result = await _service.GetCardById(id);
            return Ok(result.Amount);
        }
        [HttpPost]
        public async ValueTask<IActionResult> Replenishment(int cardNumber,decimal amount)
        {
            if (await _service.Replenishment(cardNumber, amount))
            {
                var value = _memoryCache.Get("Card_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Card_key");
                }
                return Ok("Balansingiz tuldirildi");
            }
            return BadRequest("Error!");
        }
    }
}
