using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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

            List<string> vs = new List<string>();

            foreach (TestType testType in TestType.GetAllTestTypes(databaseManager))
            {
                vs.Add(testType.Title);
            }
            TestTypeAvailableComboBox.ItemsSource = vs;
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
            string data = DateRoomTextBox.Text;
            int k = data.IndexOf(" ");
            string date = data.Substring(0, k);
            string time = data.Substring(k + 1);
            int minutesgap = Int32.Parse(TimeGapTextBox.Text);

            List<Room> rooms = Room.GetAllFreeRoomsByDateAndTime(databaseManager, date, time, minutesgap);
            List<string> roomsNames = new List<string>();

            foreach (Room room in rooms)
            {
                roomsNames.Add(room.Key + " : " + room.Type);

            }
            RoomAvailableComboBox.ItemsSource = roomsNames;

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

        private void AddTestButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedTest = TestTypeAvailableComboBox.SelectedItem.ToString();

            Appointment appointment = AppointmentDataGrid.SelectedItem as Appointment;

            List<TestType> testTypes = TestType.GetAllTestTypes(databaseManager);



            foreach (TestType testType in testTypes)
            {
                if (selectedTest == testType.Title)
                {
                    Test test = new Test()
                    {
                        AppointmentKey = appointment.Key,
                        DateTime = appointment.Date + " " + appointment.Time,
                        From = appointment.From,
                        To = "TestType/" + testType.Key,
                        ReportURL = appointment.ReportURL
                    };

                    test.AddTest(databaseManager);
                }
            }

        }

        private void BackButton_Checked(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(typeof(IntroPage));
        }
    }
}
