using donet_test_by_carro.DTOs;
using donet_test_by_carro.Models;

namespace donet_test_by_carro.Interfaces
{
    public interface IQuestionnaire
    {
        Task<(bool error, string errorMessage)> CreateQuestion(QuestionnaireDto request);
    }
}
