namespace donet_test_by_carro.Models
{
    public class Questionnaires
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public DateTime CreateAdd { get; set; }
        public User User { get; set; }
    }
}
