using StudentInfoSystem.Models;
using System.Linq;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public Student GetStudentByUser(User user)
            => StudentData.TestUsers.FirstOrDefault(s => s.FacultyNumber == user.FacultyNumber);
    }
}
