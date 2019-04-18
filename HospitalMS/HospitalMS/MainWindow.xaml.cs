using System;
using System.Collections.Generic;
using System.Linq;
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

namespace HospitalMS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            LogInStackPanel.Visibility = Visibility.Hidden;
            this.Title = "Sign Up"; 
            SignUpStackPanel.Visibility = Visibility.Visible;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpStackPanel.Visibility = Visibility.Hidden;
            this.Title = "Log In";
            LogInStackPanel.Visibility = Visibility.Visible;
        }

        private void LogInTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CheckLiteralValuesTextBox(LoginTextBox);
        }
    }
}
