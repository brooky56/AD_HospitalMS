using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.Database;
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
    public sealed partial class MonitorPage : Page
    {
        DatabaseManager databaseManager = new DatabaseManager();
        User user = null;
        public MonitorPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
                user = e.Parameter as User;
        }

        private void AppointmentDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void GetAllAppointmentsByDoctorId()
        {
            List<Appointment> appointmentsNotApproved = new List<Appointment>();
            List<Appointment> appointments = new List<Appointment>();
            appointments.Clear();
            appointments = Appointment.GetAppointmentsByDoctorId(databaseManager, user.Key).ToList();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.IsApproved == false)
                {
                    appointmentsNotApproved.Add(appointment);
                }
            }
            AppointmentDataGrid.ItemsSource = appointmentsNotApproved;
        }

        private void ShowFreeRoomsButton_Click(object sender, RoutedEventArgs e)
        {
            /*string data = DateRoomTextBox.Text;
            int k = data.IndexOf(" ");
            string date = data.Substring(0,k);
            string time = data.Substring(k+1);
            int minutesgap = Int32.Parse(TimeGapTextBox.Text);*/
            
            try
            {
                Common.GetAllFreeRoomsByDateAndTime(databaseManager, "2019-05-01", "12:00", 30);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            
            //string cpy = date;

            

           
        }

        private void LoadAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            GetAllAppointmentsByDoctorId();
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = AppointmentDataGrid.SelectedItem as Appointment;
            appointment.EditAppointment(databaseManager);
            GetAllAppointmentsByDoctorId();
        }
    }
}
