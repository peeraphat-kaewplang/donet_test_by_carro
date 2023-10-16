using donet_test_by_carro.Models;

namespace donet_test_by_carro.Interfaces
{
    public interface IAuthentication
    {
        Task<(bool error , string errorMessage)> UserRegister(UserRegisterRequest request);
        Task<(bool error , string errorMessage , User user)> UserLogin(UserLoginRequest request);
        AuthenticateResponse? Authenticate(User user);
        Task<User?> GetById(int id);
    }
}
