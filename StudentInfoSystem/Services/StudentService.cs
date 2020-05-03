using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentInfoSystem.Data;
using StudentInfoSystem.Models;

namespace StudentInfoSystem.Services
{
    public class StudentService
    {
        private StudentInfoContext context;

        public StudentService()
        {
            if (this.TestStudentsIfEmpty())
            {
                this.CopyTestStudents();
            }
        }

        public bool TestStudentsIfEmpty()
        {
            using (context = new StudentInfoContext())
            {
                return !context.Students.Any();
            }
        }

        public void CopyTestStudents()
        {
            using (context = new StudentInfoContext())
            {
                foreach (var student in StudentData.TestStudents)
                {
                    context.Students.Add(student);
                }

                context.SaveChanges();
            }
        }
    }
}
