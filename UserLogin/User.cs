using System;

namespace UserLogin
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FacultyNumber { get; set; }

        public DateTime Created { get; set; }

        public DateTime ActiveTo { get; set; }

        public UserRoles Role { get; set; }

        public override string ToString()
        {
            return $"Username: {Username}\n" +
                $"Password: {Password}\n" +
                $"Faculty Number: {FacultyNumber}\n" +
                $"Role: {Role}\n" +
                $"Created: {Created}\n" +
                $"ActiveTo: {ActiveTo}";
        }
    }
}
