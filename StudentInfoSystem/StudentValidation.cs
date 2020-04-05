using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public Student GetStudentByUser(User user)
            => StudentData.TestUsers.FirstOrDefault(s => s.FacultyNumber == user.FacultyNumber);
    }
}
