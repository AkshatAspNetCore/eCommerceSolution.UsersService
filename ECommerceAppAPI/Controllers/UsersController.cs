using ECommerceApp.Core.DTO;
using ECommerceApp.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users/{userID}
        [HttpGet("userID")]
        public async Task<IActionResult> GetUserByUserID(Guid userID)
        {
            if (userID == Guid.Empty)
            {
                return BadRequest("UserID cannot be empty.");
            }

            UserDTO? response = await _userService.GetUserByUserID(userID);

            if (response == null)
                return NotFound($"No user found with ID: {userID}");

            return Ok(response);
        }
    }
}
