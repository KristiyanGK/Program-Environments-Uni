using Microsoft.EntityFrameworkCore;
using UserLogin.Models;

namespace UserLogin.Data
{
    public class UserLoginContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Logs> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=StudentInfoDatabase;Integrated Security=True");
        }
    }
}
