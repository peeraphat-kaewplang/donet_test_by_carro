namespace donet_test_by_carro.Models
{
    public class AuthenticateResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Email = user.Email;
            Token = token;
        }
    }
}
