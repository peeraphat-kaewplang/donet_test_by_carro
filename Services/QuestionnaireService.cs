using donet_test_by_carro.Data;
using donet_test_by_carro.DTOs;
using donet_test_by_carro.Interfaces;
using donet_test_by_carro.Models;
using Microsoft.EntityFrameworkCore;

namespace donet_test_by_carro.Services
{
    public class QuestionnaireService : IQuestionnaire
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _context;

        public QuestionnaireService(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public async Task<(bool error, string errorMessage)> CreateQuestion(QuestionnaireDto request)
        {
            (bool error, string errorMessage) result = new();
            try
            {
                var user = (User?)_httpContextAccessor.HttpContext!.Items["User"];
                var question = new Questionnaires 
                {
                    Question = request.Question,
                    CreateAdd = DateTime.Now,
                    User = user!
                };

                _context.Questionnaires.Add(question);

                await _context.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                result.error = true;
                result.errorMessage = ex.Message;
                return result;
            }
           
        }
    }
}
