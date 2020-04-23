using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace WpfExample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand hiButtonCommand;
        private ICommand toggleExecuteCommand;
        private string textGreeting;
        private bool canExecute = true;

        public MainWindowViewModel()
        {
            HiButtonCommand = new RelayCommand(ShowMessage, param => this.CanExecute);
            ToggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }

        public string HiButtonContent => "click to hi";

        public string TextGreeting
        {
            get => textGreeting;
            set
            {
                if (this.TextGreeting == value)
                {
                    return;
                }

                textGreeting = value;

                OnPropertyChanged();
            }
        }

        public bool CanExecute
        {
            get => this.canExecute;
            set
            {
                if (this.CanExecute == value)
                {
                    return;
                }

                this.canExecute = value;
            }
        }

        public ICommand ToggleExecuteCommand
        {
            get => toggleExecuteCommand;
            set => toggleExecuteCommand = value;
        }

        public ICommand HiButtonCommand
        {
            get => hiButtonCommand;
            set => hiButtonCommand = value;
        }

        public void ShowMessage(object obj)
        {
            string message = $"{obj} {DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}";
            this.TextGreeting = message;
        }

        public void ChangeCanExecute(object obj)
        {
            CanExecute = !CanExecute;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
