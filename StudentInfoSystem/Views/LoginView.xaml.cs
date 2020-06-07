using StudentInfoSystem.Models;
using StudentInfoSystem.Services;
using System;
using System.Windows;
using UserLogin;

namespace StudentInfoSystem.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private readonly StudentValidation _validation;
        private readonly StudentService _studentService;

        public LoginView(StudentValidation validation, StudentService studentService)
        {
            _validation = validation;
            _studentService = studentService;
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
                    Student student = _validation.GetStudentByUser(user);
                    MainForm form = new MainForm(student);
                    form.Show();
                    this.Close();
                } else
                {
                    string greetingTemplate = "Hello, {0}";
                    MessageBox.Show(RoleGreeting(LoginValidation.CurrUserRole, greetingTemplate));
                }
            }
        }

        public string RoleGreeting(UserRoles role, string message) =>
            role switch
                {
                    UserRoles.ADMIN => string.Format(message, "Administrator"),
                    UserRoles.INSPECTOR => string.Format(message, "Inspector"),
                    UserRoles.PROFESSOR => string.Format(message, "Prof"),
                    UserRoles.STUDENT => string.Format(message, "Student"),
                    _  => throw new ArgumentException("Invalid Role!")
                };

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            if (_studentService.TestStudentsIfEmpty())
            {
                _studentService.CopyTestStudents();
            }

            MessageBox.Show(_studentService.TestStudentsIfEmpty().ToString());
        }
    }
}
