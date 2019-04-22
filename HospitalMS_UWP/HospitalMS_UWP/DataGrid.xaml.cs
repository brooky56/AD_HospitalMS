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
using Microsoft.Toolkit.Uwp.UI.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace HospitalMS_UWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class DataGrid : Page
    {
        public DataGrid()
        {
            this.InitializeComponent();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Customer> result = new List<Customer>();
            result.Clear();
            result = Customer.Customers();
            WorkDataGrid.ItemsSource = result;
        }

        private async void WorkDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string str = UserTypeBox.SelectionBoxItem.ToString();
            string str1 = WorkDataGrid.SelectedItem.ToString();
            ContentDialog deleteFileDialog = new ContentDialog()
            {
                Title = str,
                Content = str1,
                PrimaryButtonText = "ОК",
                SecondaryButtonText = "Отмена"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();
        }
    }
}
