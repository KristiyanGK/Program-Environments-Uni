using StudentInfoSystem.Data;
using System.Linq;

namespace StudentInfoSystem.Services
{
    public class StudentService
    {
        private readonly StudentInfoContext _context;

        public StudentService(StudentInfoContext context)
        {
            _context = context;
        }

        public bool TestStudentsIfEmpty()
        {
            return !_context.Students.Any();
        }

        public void CopyTestStudents()
        {
            foreach (var student in StudentData.TestStudents)
            {
                _context.Students.Add(student);
            }

            _context.SaveChanges();
        }
    }
}
