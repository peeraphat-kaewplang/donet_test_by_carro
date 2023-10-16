using System.ComponentModel.DataAnnotations;

namespace donet_test_by_carro.Models
{
    public class UserRegisterRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 characters!")]
        public string Password { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
