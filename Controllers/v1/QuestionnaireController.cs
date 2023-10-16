using donet_test_by_carro.Authorization;
using donet_test_by_carro.DTOs;
using donet_test_by_carro.Interfaces;
using donet_test_by_carro.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace donet_test_by_carro.Controllers.v1
{
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiVersion}/questionnaires")]
    [ApiVersion("1.0")]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IEmail _emailService;
        private readonly IQuestionnaire _questionnaireService;

        public QuestionnaireController(IEmail emailService , IQuestionnaire questionnaireService)
        {
            _emailService = emailService;
            _questionnaireService = questionnaireService;
        }

        [AllowAnonymous]
        [HttpGet("allow")]
        public string Get()
        {
            return "asdasd";
        }
        [HttpPost]
        public async Task<ActionResult> Create(QuestionnaireDto questionnaireDto)
        {

            var(error, errorMessage) = await _questionnaireService.CreateQuestion(questionnaireDto);
            if (error)
            {
                return BadRequest(errorMessage);
            }

            var mail = new EmailRequest
            {
                Subject = "Questionnaires",
                Body = questionnaireDto.Question!
            };

            _emailService.SendEmail(mail);

            return Ok();
        }
    }
}
