using Microsoft.AspNetCore.Mvc;

namespace donet_test_by_carro.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/auth")]
    [ApiVersion("2.0")]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet()]
        public string Get()
        {
            return "Peeraphat";
        }
    }
}