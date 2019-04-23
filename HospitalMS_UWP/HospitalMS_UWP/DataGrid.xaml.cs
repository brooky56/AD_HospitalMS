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
using HospitalMS_UWP.Models.Database;
using HospitalMS_UWP.Helpers;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace HospitalMS_UWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class DataGrid : Page
    {
        DatabaseManager databaseManager = new DatabaseManager();
        
        public DataGrid()
        {
            this.InitializeComponent();
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
         
            string str = UserTypeBox.SelectionBoxItem.ToString(); 

            if (str.Equals("All users"))
            {
                Show_AllUsers();
            }
            if (str.Equals("Doctors"))
            {
                Show_AllDoctors();
            }
            if (str.Equals("Patients"))
            {
                Show_AllPatients();
            }
            if (str.Equals("Nurses"))
            {
                Show_AllNurses();
            }
            if (str.Equals("Pharmacists"))
            {
                Show_AllPharmacists();
            }
            if (str.Equals("Laboratorists"))
            {
                Show_AllLaboratorists();
            }
            if (str.Equals("Reseptionists"))
            {
                Show_AllReseptionists();
            }
            if (str.Equals("Accountants"))
            {
                Show_AllAccountants();
            }

        }

        private void Show_AllDoctors() {

            List<Doctor> res = new List<Doctor>();
            List<User> result = new List<User>();
            result.Clear();

            try
            {
                result = User.GetAllUsers(databaseManager).ToList();
            }
            catch (Exception ex)
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = ex.Message;
            }
            foreach (User user in result)
            {
                if (user.GetType() == typeof(Doctor))
                {
                    res.Add(user as Doctor);
                }
            }
            WorkDataGrid.ItemsSource = res;
        }

        private void Show_AllPatients()
        {

            List<Patient> res = new List<Patient>();
            List<User> result = new List<User>();
            result.Clear();

            result = User.GetAllUsers(databaseManager).ToList();

            foreach (User user in result)
            {
                if (user.GetType() == typeof(Patient))
                {
                    res.Add(user as Patient);
                }
            }
            WorkDataGrid.ItemsSource = res;
        }

        private void Show_AllNurses()
        {

            List<Staff> res = new List<Staff>();
            List<User> result = new List<User>();
            result.Clear();

            result = User.GetAllUsers(databaseManager).ToList();

            foreach (User user in result)
            {
                if (user.GetType() == typeof(Staff))
                {
                    if (user.UserType.Equals("N"))
                    {
                        res.Add(user as Staff);
                    }
                    
                }
            }
            WorkDataGrid.ItemsSource = res;
        }
        private void Show_AllPharmacists()
        {

            List<Staff> res = new List<Staff>();
            List<User> result = new List<User>();
            result.Clear();

            result = User.GetAllUsers(databaseManager).ToList();

            foreach (User user in result)
            {
                if (user.GetType() == typeof(Staff))
                {
                    if (user.UserType.Equals("P"))
                    {
                        res.Add(user as Staff);
                    }

                }
            }
            WorkDataGrid.ItemsSource = res;
        }

        private void Show_AllLaboratorists()
        {

            List<Staff> res = new List<Staff>();
            List<User> result = new List<User>();
            result.Clear();

            result = User.GetAllUsers(databaseManager).ToList();

            foreach (User user in result)
            {
                if (user.GetType() == typeof(Staff))
                {
                    if (user.UserType.Equals("L"))
                    {
                        res.Add(user as Staff);
                    }

                }
            }
            WorkDataGrid.ItemsSource = res;
        }

        private void Show_AllReseptionists()
        {

            List<Staff> res = new List<Staff>();
            List<User> result = new List<User>();
            result.Clear();

            result = User.GetAllUsers(databaseManager).ToList();

            foreach (User user in result)
            {
                if (user.GetType() == typeof(Staff))
                {
                    if (user.UserType.Equals("R"))
                    {
                        res.Add(user as Staff);
                    }

                }
            }
            WorkDataGrid.ItemsSource = res;
        }

        private void Show_AllAccountants()
        {

            List<Staff> res = new List<Staff>();
            List<User> result = new List<User>();
            result.Clear();

            result = User.GetAllUsers(databaseManager).ToList();

            foreach (User user in result)
            {
                if (user.GetType() == typeof(Staff))
                {
                    if (user.UserType.Equals("A"))
                    {
                        res.Add(user as Staff);
                    }

                }
            }
            WorkDataGrid.ItemsSource = res;
        }

        private void Show_AllUsers() {

            List<User> result = new List<User>();
            result.Clear();

            result = User.GetAllUsers(databaseManager).ToList();
            
            WorkDataGrid.ItemsSource = result;

        }

        private void WorkDataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            User user = WorkDataGrid.SelectedItem as User;
            User.EditUser(user, databaseManager);
        }
    }
}
