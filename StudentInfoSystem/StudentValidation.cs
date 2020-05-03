using StudentInfoSystem.Models;
using System.Linq;
using StudentInfoSystem.Data;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public Student GetStudentByUser(User user)
        {
            using (StudentInfoContext context = new StudentInfoContext())
            {
                return context.Students.FirstOrDefault(s => s.FacultyNumber == user.FacultyNumber);
            }
        }
    }
}
