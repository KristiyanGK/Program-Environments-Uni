using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> _testUsers;

        static bool reset = false;

        public static List<User> TestUsers
        { 
            get
            {
                if (!reset)
                {
                    resetTestUserData();
                    reset = true;
                }
                
                return _testUsers;
            }
            set { }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            return TestUsers.FirstOrDefault(u => u.Password == password &&
                u.Username == username);
        }

        public static void SetUserActiveTo(string username, DateTime activeTo)
        {
            User user = TestUsers.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                Logger.LogActivity($"Changed activity to of {username} from {user.ActiveTo} to {activeTo}");
                user.ActiveTo = activeTo;
            }
        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            User user = TestUsers.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                Logger.LogActivity($"Changed role of {username} from {user.Role} to {role}");
                user.Role = role;
            }
        }

        private static void resetTestUserData()
        {
            _testUsers = new List<User>(3);

            _testUsers.Add(new User
            {
                Username = "admin",
                Password = "admin",
                FacultyNumber = "121217066",
                Role = UserRoles.ADMIN,
                Created = DateTime.Now,
                ActiveTo = DateTime.MaxValue
            });

            _testUsers.Add(new User
            {
                Username = "pesho",
                Password = "12345",
                FacultyNumber = "121217099",
                Role = UserRoles.STUDENT,
                Created = DateTime.Now,
                ActiveTo = DateTime.MaxValue
            });

            _testUsers.Add(new User
            {
                Username = "george",
                Password = "54321",
                FacultyNumber = "5785041212",
                Role = UserRoles.STUDENT,
                Created = DateTime.Now,
                ActiveTo = DateTime.MaxValue
            });
        }
    }
}
