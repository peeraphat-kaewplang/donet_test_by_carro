﻿using donet_test_by_carro.Models;

namespace donet_test_by_carro.Interfaces
{
    public interface IEmail
    {
        void SendEmail(EmailRequest request);
    }
}
