using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace HospitalMS_UWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class IntroPage : Page
    {
        Controller controller;
        public IntroPage()
        {
            this.InitializeComponent();
            controller = new Controller();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(typeof(MainPage)); 
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignInStackPanel.Visibility = Visibility.Collapsed;
            RegStackPanel.Visibility = Visibility.Visible;
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CheckLiteralValuesTextBox(NameTextBox);
        }

        private void PhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CheckNumericValuesTextBox(PhoneTextBox);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            controller.CheckPasswordBox(RegPasswordBox);
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CheckLiteralValuesTextBox(EmailTextBox);
        }

        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CheckLiteralValuesTextBox(LoginTextBox);
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            RegStackPanel.Visibility = Visibility.Collapsed;
            SignInStackPanel.Visibility = Visibility.Visible;
        }

        private void InPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            controller.CheckPasswordBox(InPasswordBox);
        }
    }
}
