using System;
using System.Linq;

namespace UserLogin
{
    public class LoginValidation
    {
        private string username;

        private string password;

        private string error;

        private ActionOnError actionOnError;

        private static DateTime timeSinceLastCheck = DateTime.Now;

        private static int failedAttemptsLast3Mins = 0;

        private static bool isSet = false;

        public LoginValidation(string username, string password, ActionOnError actionOnError)
        {
            this.username = username;
            this.password = password;
            this.actionOnError = actionOnError;

            CurrUserRole = UserRoles.ANONYMOUS;
            CurrUsername = "";
            setAttempts();
        }

        public delegate void ActionOnError(string errorMsg);

        public static UserRoles CurrUserRole { get; private set; }
        public static string CurrUsername { get; private set; }

        public static void setAttempts()
        {
            if (isSet)
            {
                return;
            }

            isSet = true;

            var log = Logger.GetActivityLog()
                .Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Where(l => l.Contains("Failed login"))
                .Reverse()
                .Take(4);

            foreach (var item in log)
            {
                var dateString = item.Split(";")[0];
                var date = DateTime.Parse(dateString);
                var span = date - DateTime.Now;
                if (span.TotalMinutes < 3)
                {
                    failedAttemptsLast3Mins++;
                }
            }
        }

        public static bool CanUserLogin()
        {
            setAttempts();

            var span = timeSinceLastCheck - DateTime.Now;
            if (span.TotalMinutes > 3)
            {
                failedAttemptsLast3Mins = 0;
            }

            return failedAttemptsLast3Mins < 3;
        }

        public bool ValidateUserInput(ref User user)
        {
            bool result = validateUserInput(ref user);

            if (!result)
            {
                failedAttemptsLast3Mins++;
                Logger.LogActivity("Failed login");
                actionOnError(error);
            }

            return result;
        }

        private bool validateUserInput(ref User user)
        {
            username = username.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(username))
            {
                error = "Username must not be emtpy";
                return false;
            }

            password = password.Trim();

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password))
            {
                error = "Password must not be emtpy";
                return false;
            }

            if (username.Length < 5)
            {
                error = "Username must be more than 5 symbols long";
                return false;
            }

            if (password.Length < 5)
            {
                error = "Password must be more than 5 symbols long";
                return false;
            }

            user = UserData.IsUserPassCorrect(username, password);

            if (user == null)
            {
                error = "Invalid login credentials";
                return false;
            }

            CurrUserRole = user.Role;
            CurrUsername = username;

            Logger.LogActivity("Successful login!");

            return true;
        }
    }
}
