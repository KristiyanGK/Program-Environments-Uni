using StudentInfoSystem.Models;
using System.Linq;
using StudentInfoSystem.Data;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        private readonly StudentInfoContext _context;

        public StudentValidation(StudentInfoContext context)
        {
            _context = context;
        }

        public Student GetStudentByUser(User user) => 
            _context.Students.FirstOrDefault(s => s.FacultyNumber == user.FacultyNumber);
    }
}
