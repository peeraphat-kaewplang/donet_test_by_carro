﻿
namespace donet_test_by_carro.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string? VerificationToken { get; set; }
        public DateTime CreateAdd { get; set; }
        
        public List<Questionnaires> Questionnaires { get; set; }
    }
}
