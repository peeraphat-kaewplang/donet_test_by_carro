using donet_test_by_carro.Models;
using Microsoft.EntityFrameworkCore;

namespace donet_test_by_carro.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> User { get;set; }
        public DbSet<Questionnaires> Questionnaires { get;set; }
    }
}
