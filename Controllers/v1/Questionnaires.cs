using donet_test_by_carro.Authorization;
using donet_test_by_carro.Models;
using Microsoft.AspNetCore.Mvc;

namespace donet_test_by_carro.Controllers.v1
{
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiVersion}/questionnaires")]
    [ApiVersion("1.0")]
    public class Questionnaires : ControllerBase
    {

        public Questionnaires()
        {
            
        }

        [AllowAnonymous]
        [HttpGet("allow")]
        public string Get()
        {
          
            return "asdasd";
        }
        [HttpGet("all")]
        public User GetAll()
        {
            var context = (User?)HttpContext.Items["User"];
            return context!;
        }
    }
}
