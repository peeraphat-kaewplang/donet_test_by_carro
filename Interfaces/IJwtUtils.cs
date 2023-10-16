using donet_test_by_carro.Models;

namespace donet_test_by_carro.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public int? ValidateJwtToken(string? token);
    }
}
