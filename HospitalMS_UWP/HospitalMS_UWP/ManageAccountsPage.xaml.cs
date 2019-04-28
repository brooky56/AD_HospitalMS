using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class ManageAccountsPage : Page
    {
        private ObservableCollection<string> _items = new ObservableCollection<string>();
        public ManageAccountsPage()
        {
            this.InitializeComponent();
            PersonTypeComboBox.Items.Add("Doctor");
            PersonTypeComboBox.Items.Add("Nurse");
            PersonTypeComboBox.Items.Add("Patient");
            PersonTypeComboBox.Items.Add("Stuff");
        }

        public ObservableCollection<string> Items
        {
            get { return this._items; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Items.Add("Item 1");
            Items.Add("Item 2");
            Items.Add("Item 3");
            Items.Add("Item 4");
            Items.Add("Item 5");
        }

        private async void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            string str = PersonTypeComboBox.SelectedItem.ToString();
            string str1 = WorkListView.SelectedItem.ToString();
            ContentDialog deleteFileDialog = new ContentDialog()
            {
                Title = str,
                Content = str1,
                PrimaryButtonText = "ОК",
                SecondaryButtonText = "Отмена"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();
        }

        private void WorkListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
    }
}
