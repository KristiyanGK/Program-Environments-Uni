using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        private DateTime lastChecked;

        public ExpenseItHome()
        {
            InitializeComponent();

            LastChecked = DateTime.Now;
            PersonsChecked = new ObservableCollection<string>();

            this.DataContext = this;
        }

        public DateTime LastChecked
        {
            get
            {
                return lastChecked;
            }
            set
            {
                lastChecked = value;

                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> PersonsChecked { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var dataToAdd = (this.peopleListBox.SelectedItem as System.Xml.XmlElement).Attributes["Name"].Value;

            PersonsChecked.Add(dataToAdd);

            LastChecked = DateTime.Now;
        }

        private void View_Expense_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReport report = new ExpenseReport(this.peopleListBox.SelectedItem);

            report.Height = this.Height;
            report.Width = this.Width;

            report.ShowDialog();
        }
    }
}
