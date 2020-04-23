using System.Windows.Input;
using StudentInfoSystem.Commands;
using StudentInfoSystem.Contracts;
using StudentInfoSystem.Models;

namespace StudentInfoSystem.ViewModels
{
    public class MainFormViewModel : ObservableObject
    {
        private Student student;

        public MainFormViewModel(Student student)
        {
            this.Student = student;
            this.ClearCommand = new RelayCommand(Clear);
        }

        public Student Student
        {
            get => student;
            set
            {
                this.student = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClearCommand { get; set; }

        private void Clear()
        {
            this.Student = new Student();
        }
    }
}
