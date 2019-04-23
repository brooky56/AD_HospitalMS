using HospitalMS_UWP.Models.Database;
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
            if (e.Parameter != null)
                user = e.Parameter as User;


            if (user == null)
            {
                workFrame.Navigate(typeof(DataGrid));
                monitorHospitalPageButton.IsEnabled = false;
                manageAccountPageButton.IsEnabled = false;
                dataManageButton.IsEnabled = false;
            }
            else if (user.UserType == UserType.DOCTOR)
            {
                workFrame.Navigate(typeof(MonitorPage), user);
                mainAdminPageButton.IsEnabled = false;
                manageAccountPageButton.IsEnabled = false;
                dataManageButton.IsEnabled = false;
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
