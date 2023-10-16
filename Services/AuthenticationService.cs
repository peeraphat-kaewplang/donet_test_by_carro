using donet_test_by_carro.Data;
using donet_test_by_carro.Interfaces;
using donet_test_by_carro.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace donet_test_by_carro.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly AppDbContext _context;
        private readonly IJwtUtils _jwtUtils;

        public AuthenticationService(AppDbContext context , IJwtUtils jwtUtils)
        {
            _context = context;
            _jwtUtils = jwtUtils;
        }
        public async Task<(bool error, string errorMessage )> UserRegister(UserRegisterRequest request)
        {
            (bool error, string errorMessage) result = new();

            try
            {
                if (_context.User.Any(u => u.Email == request.Email))
                {
                    result.error = true;
                    result.errorMessage = "User already exists.";
                    return result;
                }

                var pwd = CreatePasswordHash(request.Password);

                var user = new User
                {
                    Email = request.Email,
                    PasswordHash = pwd.passwordHash,
                    PasswordSalt = pwd.passwordSalt,
                    VerificationToken = CreateRandomToken(),
                    Age = request.Age,
                    CreateAdd = DateTime.Now
                };

                _context.Add(user);

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

        public async Task<(bool error, string errorMessage, User user)> UserLogin(UserLoginRequest request)
        {
            (bool error, string errorMessage, User user) result = new();
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                result.error = true;
                result.errorMessage = "User not found.";
                return result;
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                result.error = true;
                result.errorMessage = "Password is incorrect.";
                return result;
            }

            result.user = user;
            return result;
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public AuthenticateResponse? Authenticate(User user)
        {
            var token = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private (byte[] passwordSalt , byte[] passwordHash) CreatePasswordHash(string password)
        {
            (byte[] passwordSalt, byte[] passwordHash) pwd = new();

            var hmac = new HMACSHA512();
            pwd.passwordSalt = hmac.Key;
            pwd.passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return pwd;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
    }
}
