using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;

namespace OLX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllUsers()
        {
            return Ok(await _service.GetAllUsersAsync());
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateUserAsync(UserDTO user)
        {
            bool result = await _service.CreateUserAsync(user);
            if (result is true)
            {
                return Ok("Added!");
            }
            return BadRequest("Error!");
        }
    }
}
