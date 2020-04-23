using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace EasyMVVM
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        private ObservableCollection<string> _backingProperty;

        public MainWindowVM()
        {
            Model m = new Model();

            BoundProperty = m.GetData();
        }

        public ObservableCollection<string> BoundProperty
        {
            get => _backingProperty;
            set
            {
                _backingProperty = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
