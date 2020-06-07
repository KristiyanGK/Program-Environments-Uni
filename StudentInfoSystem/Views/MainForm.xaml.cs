using StudentInfoSystem.Models;
using StudentInfoSystem.ViewModels;
using System.Windows;

namespace StudentInfoSystem.Views
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm(Student student)
        {
            InitializeComponent();
            MainFormViewModel vm = new MainFormViewModel(student);
            this.DataContext = vm;
        }
    }
}
