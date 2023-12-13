using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMemoryCache _memoryCache;
        public UsersController(IUserService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllUsersAsync()
        {
            var value = _memoryCache.Get("Users_key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "Users_key",
                    value: await _service.GetAllUserAsync());
            }
            return Ok(_memoryCache.Get("Users_key") as List<User>);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateUserAsync(UsersDTO users)
        {
            if (await _service.CreateUserAsync(users))
            {
                var value = _memoryCache.Get("Users_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Users_key");
                }
                return Ok("Added!");
            }
            return BadRequest("Error!");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetUserByIdAsync(int id)
        {
            return Ok(await _service.GetUserById(id));
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteUserAsync(int id)
        {
            if (await _service.DeleteUserAsync(id))
            {
                var value = _memoryCache.Get("Users_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Users_key");
                }
                return Ok("deleted");
            }
            return BadRequest("Error");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateUserAsync(int id,UsersDTO user)
        {
            if (await _service.UpdateUserAsync(id,user))
            {
                var value = _memoryCache.Get("Users_key");
                if (value is not null)
                {
                    _memoryCache.Remove("Users_key");
                }
                return Ok("Updated");
            }
            return BadRequest("Error!");
        }
    }
}
