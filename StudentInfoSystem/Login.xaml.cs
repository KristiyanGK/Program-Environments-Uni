using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ActionOnError(string errorMsg)
        {
            ErrorTxt.Text = errorMsg;
            ErrorTxt.Visibility = Visibility.Visible;
            Console.WriteLine($"Error: {errorMsg}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ErrorTxt.Visibility = Visibility.Hidden;

            string name = NameTxt.Text;
            string password = PassTxt.Password;

            NameTxt.Text = "";
            PassTxt.Password = "";

            LoginValidation loginValidation = new LoginValidation(name, password, ActionOnError);

            User user = null;

            if (loginValidation.ValidateUserInput(ref user))
            {
                if (LoginValidation.CurrUserRole == UserRoles.STUDENT)
                {
                    StudentValidation validation = new StudentValidation();
                    var student = validation.GetStudentByUser(user);
                    StudentForm form = new StudentForm(student);
                    form.Show();
                    this.Close();
                } else
                {
                    MessageBox.Show(roleGreeting(LoginValidation.CurrUserRole));
                }
            }
        }

        static string roleGreeting(UserRoles role)
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

            return message;
        }
    }
}
