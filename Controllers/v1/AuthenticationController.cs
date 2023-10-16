using donet_test_by_carro.Interfaces;
using donet_test_by_carro.Models;
using Microsoft.AspNetCore.Mvc;

namespace donet_test_by_carro.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/auth")]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authenticationService;

        public AuthenticationController(IAuthentication authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet()]
        public string Get()
        {
            return "ming";
        }
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(UserRegisterRequest user)
        {
            var (error, errorMessage) =  await _authenticationService.UserRegister(user);
            if(error)
            {
                return BadRequest(errorMessage);
            }
            return Created("" ,user);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var (error, errorMessage , user) = await _authenticationService.UserLogin(request);
            if (error)
            {
                return BadRequest(errorMessage);
            }

            var res = _authenticationService.Authenticate(user);

            return Ok(res);
        }
    }
}