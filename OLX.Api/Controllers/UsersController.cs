using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;

namespace OLX.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllUsersAsync()
        {
            return Ok(await _service.GetAllUserAsync());
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateUserAsync(UsersDTO users)
        {
            if (await _service.CreateUserAsync(users))
            {
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
                return Ok("deleted");
            }
            return BadRequest("Error");
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateUserAsync(int id,UsersDTO user)
        {
            if (await _service.UpdateUserAsync(id,user))
            {
                return Ok("Updated");
            }
            return BadRequest("Error!");
        }
    }
}
