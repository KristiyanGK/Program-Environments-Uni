using Microsoft.EntityFrameworkCore;
using StudentInfoSystem.Models;
using UserLogin;
using UserLogin.Models;

namespace StudentInfoSystem.Data
{
    public class StudentInfoContext : DbContext
    {
        // To Create database run in Package Manager Console: Database-Update

        public StudentInfoContext(DbContextOptions<StudentInfoContext> options)
            :base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Logs> Logs { get; set; }

    }
}
