namespace donet_test_by_carro.DTOs
{
    public record struct UserRegisterDto(
        string name ,
        string lastName ,
        int age ,
        string email ,
        string password);
}
