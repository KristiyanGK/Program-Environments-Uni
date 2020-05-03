using System;
using System.Collections.Generic;
using System.Linq;
using UserLogin.Data;

namespace UserLogin
{
    public static class UserData
    {
        static UserData()
        {
            using (UserLoginContext ctx = new UserLoginContext())
            {
                if (!ctx.Users.Any())
                {
                    ctx.Users.AddRange(TestUsers);

                    ctx.SaveChanges();
                }
            }
        }

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
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            using (UserLoginContext ctx = new UserLoginContext())
            {
                return ctx.Users.FirstOrDefault(u => u.Password == password &&
                                                     u.Username == username);
            }
        }

        public static void SetUserActiveTo(string username, DateTime activeTo)
        {
            using (UserLoginContext ctx = new UserLoginContext())
            {
                User user = ctx.Users.FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    Logger.LogActivity($"Changed activity to of {username} from {user.ActiveTo} to {activeTo}");
                    user.ActiveTo = activeTo;
                    ctx.SaveChanges();
                }
            }
        }

        public static void AssignUserRole(int userId, UserRoles role)
        {
            using (UserLoginContext ctx = new UserLoginContext())
            {
                User user = ctx.Users.FirstOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    return;
                }

                user.Role = role;

                ctx.SaveChanges();
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
