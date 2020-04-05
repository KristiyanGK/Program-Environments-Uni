using System;
using System.Threading;

namespace UserLogin
{
    class Program
    {
        static void ActionOnError(string errorMsg)
        {
            Console.WriteLine($"Error: {errorMsg}");
        }

        static void Main()
        {
            int exit = 1;
            while (true)
            {
                if(!LoginValidation.CanUserLogin())
                {
                    Console.WriteLine("Too many failed login attempts!");
                    Thread.Sleep(5 * 1000);
                    continue;
                }

                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                LoginValidation loginValidation = new LoginValidation(username, password, ActionOnError);

                User user = null;

                if (loginValidation.ValidateUserInput(ref user))
                {
                    roleGreeting(LoginValidation.CurrUserRole);

                    if (LoginValidation.CurrUserRole == UserRoles.ADMIN)
                    {
                        exit = OpenAdminMenu();
                    }
                }

                if (exit == 0)
                {
                    break;
                }
            }
        }

        static int OpenAdminMenu()
        {
            Console.WriteLine("Options: ");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change user role");
            Console.WriteLine("2: Change user active to");
            Console.WriteLine("3: User list");
            Console.WriteLine("4: View all activity log");
            Console.WriteLine("5: View current activity log");

            while (true)
            {
                int option;
                bool isParsed = int.TryParse(Console.ReadLine(), out option);

                if (!isParsed)
                {
                    Console.WriteLine("Invalid command!");
                    continue;
                }

                switch(option)
                {
                    case 0:
                        return 0;
                    case 1:
                        changeUserRoleCommand();
                        break;
                    case 2:
                        changeUserActiveTo();
                        break;
                    case 3:
                        listUsersCommand();
                        break;
                    case 4:
                        viewLogCommand();
                        break;
                    case 5:
                        viewCurrLogCommand();
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }

        static void viewCurrLogCommand()
        {
            string log = Logger.GetCurrentSessionActivities();

            Console.WriteLine(log);
        }

        static void viewLogCommand()
        {
            string log = Logger.GetActivityLog();

            Console.WriteLine(log);
        }

        static void listUsersCommand()
        {
            Console.WriteLine("TODO");
        }

        static void changeUserRoleCommand()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Role: ");
            string userRoleString = Console.ReadLine();

            UserRoles role = Enum.Parse<UserRoles>(userRoleString.ToUpper());
            UserData.AssignUserRole(username, role);
        }

        static void changeUserActiveTo()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("ActiveTo date: ");
            string dateString = Console.ReadLine();

            DateTime date = DateTime.Parse(dateString);
            UserData.SetUserActiveTo(username, date);
        }

        static void roleGreeting(UserRoles role)
        {
            string message = "Hello, {0}";

            switch (role)
            {
                case UserRoles.ADMIN:
                {
                    message = string.Format(message, "Admin");
                    break;
                }
                case UserRoles.INSPECTOR:
                {
                    message = string.Format(message, "Inspector");
                    break;
                }
                case UserRoles.PROFESSOR:
                {
                    message = string.Format(message, "Professor");
                    break;
                }
                case UserRoles.STUDENT:
                {
                    message = string.Format(message, "Student");
                    break;
                }
            }

            Console.WriteLine(message);
        }
    }
}
