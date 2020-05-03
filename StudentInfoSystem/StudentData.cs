using StudentInfoSystem.Models;
using System.Collections.Generic;

namespace StudentInfoSystem
{
    public class StudentData
    {
        private static List<Student> _testStudents;

        static bool reset = false;

        public static List<Student> TestStudents
        {
            get
            {
                if (!reset)
                {
                    resetTestStudentData();
                    reset = true;
                }

                return _testStudents;
            }
        }

        private static void resetTestStudentData()
        {
            _testStudents = new List<Student>();

            _testStudents.Add(new Student
            {
                Degree = "Bachelore",
                Faculty = "FKST",
                FacultyNumber = "121217099",
                FirstName = "Kris",
                MiddleName = "Georgiev",
                LastName = "Kamburov",
                Flow = 9,
                Group = 36,
                Specialty = "KSI",
                Status = "Active",
                Year = 3
            });

            _testStudents.Add(new Student
            {
                Degree = "Masters",
                Faculty = "FKST",
                FacultyNumber = "5785041212",
                FirstName = "george",
                MiddleName = "Gosho",
                LastName = "Goshov",
                Flow = 10,
                Group = 38,
                Specialty = "IT",
                Status = "Not Active",
                Year = 5
            });
        }
    }
}
