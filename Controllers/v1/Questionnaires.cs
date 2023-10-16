using donet_test_by_carro.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace donet_test_by_carro.Controllers.v1
{
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiVersion}/questionnaires")]
    [ApiVersion("1.0")]
    public class Questionnaires : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("allow")]
        public string Get()
        {
            return "ming";
        }
        [HttpGet("all")]
        public string GetAll()
        {
            return "all";
        }
    }
}
