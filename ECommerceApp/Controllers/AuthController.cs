using ECommerceApp.Core.DTO;
using ECommerceApp.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAppAPI.Controllers
{
    [Route("api/[controller]")] // api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService; 

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")] // POST api/auth/register
        public async Task<IActionResult> Register(RegisterRequest registerRequest) 
        {
            //Check for null register request
            if (registerRequest == null)
                return BadRequest("Register request cannot be null.");

            //Call the RegisterUser method of the user service to register the user
            AuthenticationResponse? authenticationResponse = await _userService.RegisterUser(registerRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
                return BadRequest(authenticationResponse);

            return Ok(authenticationResponse);
        }

        [HttpPost("login")] //POST api/auth/login
        public async Task<IActionResult?> Login(LoginRequest loginRequest) 
        {
            //Check for invalid login request
            if (loginRequest == null)
                return BadRequest("Login request cannot be null.");

            AuthenticationResponse? authenticationResponse = await _userService.LoginUser(loginRequest);

            if(authenticationResponse == null || authenticationResponse.Success == false)
                return Unauthorized(authenticationResponse);

            return Ok(authenticationResponse);
        }
    }
}
