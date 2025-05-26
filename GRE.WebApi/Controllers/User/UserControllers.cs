using GRE.Application.Interfaces.Services.User;
using GRE.Shared.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GRE.WebApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IUserService _userService;
        public UserControllers(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] UsersDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _userService.AddUserAsync(userDto));
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateUser([FromBody] UsersDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _userService.UpdateUserAsync(userDto));
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteUser([FromBody] int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _userService.DeleteUserAsync(userId));
        }
    }
}
