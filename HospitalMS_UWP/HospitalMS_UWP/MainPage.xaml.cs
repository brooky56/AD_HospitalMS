using HospitalMS_UWP.Models.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace HospitalMS_UWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        User user = null;
        public MainPage()
        {
            this.InitializeComponent();
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e.Parameter != null && user != null)
            {
                user = e.Parameter as User;
                if (user.UserType == UserType.DOCTOR && user != null)
                {
                    workFrame.Navigate(typeof(MonitorPage), user);
                    mainAdminPageButton.IsEnabled = false;
                    mainAdminPageButton.Visibility = Visibility.Collapsed;
                    manageAccountPageButton.IsEnabled = false;
                    manageAccountPageButton.Visibility = Visibility.Collapsed;
                    dataManageButton.IsEnabled = false;
                    dataManageButton.Visibility = Visibility.Collapsed;

                }
            }

            if (e.Parameter as string == "root")
            {
                workFrame.Navigate(typeof(DataGrid));
                monitorHospitalPageButton.IsEnabled = false;
                monitorHospitalPageButton.Visibility = Visibility.Collapsed;
                manageAccountPageButton.IsEnabled = false;
                manageAccountPageButton.Visibility = Visibility.Collapsed;
                dataManageButton.IsEnabled = false;
                dataManageButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                List<RadioButton> buttons = new List<RadioButton>();
                buttons.Add(mainAdminPageButton);
                buttons.Add(manageAccountPageButton);
                buttons.Add(dataManageButton);
                buttons.Add(monitorHospitalPageButton);
                workFrame.Navigate(typeof(IntroPage),buttons);
                mainAdminPageButton.Visibility = Visibility.Collapsed;
                manageAccountPageButton.Visibility = Visibility.Collapsed;
                dataManageButton.Visibility = Visibility.Collapsed;
                monitorHospitalPageButton.Visibility = Visibility.Collapsed;
            }

        }
        private void MonitorHospitalPageButton_Click(object sender, RoutedEventArgs e)
        {
            workFrame.Navigate(typeof(MonitorPage));
            HandleSplitView(monitorHospitalPageButton);
        }

        private void MainAdminPageButton_Click(object sender, RoutedEventArgs e)
        {
            HandleSplitView(mainAdminPageButton);
            workFrame.Navigate(typeof(DataGrid));
        }

        private void ManageAccountPageButton_Click(object sender, RoutedEventArgs e)
        {
            workFrame.Navigate(typeof(AdminPage));
            HandleSplitView(manageAccountPageButton);
        }

        private void DataManageButton_Click(object sender, RoutedEventArgs e)
        {
            workFrame.Navigate(typeof(ManageData));
            HandleSplitView(dataManageButton);
        }

        private void HandleSplitView(RadioButton button)
        {
            if (MainSplitView.IsPaneOpen)
            {
                MainSplitView.IsPaneOpen = false;
            }
            else
            {
                MainSplitView.IsPaneOpen = true;
            }
            button.IsChecked = false;
        }
    }
}
