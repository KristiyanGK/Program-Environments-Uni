using System;
using System.Windows;
using StudentInfoSystem.Data;
using StudentInfoSystem.Models;
using StudentInfoSystem.Services;
using UserLogin;

namespace StudentInfoSystem.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
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
                    Student student = validation.GetStudentByUser(user);
                    MainForm form = new MainForm(student);
                    form.Show();
                    this.Close();
                } else
                {
                    MessageBox.Show(RoleGreeting(LoginValidation.CurrUserRole));
                }
            }
        }

        static string RoleGreeting(UserRoles role)
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

        StudentService service = new StudentService();

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            if (service.TestStudentsIfEmpty())
            {
                service.CopyTestStudents();
            }

            MessageBox.Show(service.TestStudentsIfEmpty().ToString());
        }
    }
}
