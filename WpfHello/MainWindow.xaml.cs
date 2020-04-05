using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void helloBtn_Click(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            
            foreach (var item in UserGrid.Children)
            {
                if (item is TextBox)
                {
                    sb.Append(((TextBox)item).Text + " ");
                }
            }

            if (txtName.Text.Length > 2)
            {
                MessageBox.Show("Hello there " + sb.ToString());
            } 
            else
            {
                MessageBox.Show("Length of text should be at least 2");
            }
        }

        private void Factoriel_Click(object sender, RoutedEventArgs e)
        {
            var input = int.Parse(numberInput.Text);

            BigInteger calcResult = 1;

            for (int i = input; i > 1; i--)
            {
                calcResult *= i;
            }

            result.Text = calcResult.ToString();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            var buttons = MessageBoxButton.YesNo;

            var result = MessageBox.Show("Are you sure?", "Quit?", buttons);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
