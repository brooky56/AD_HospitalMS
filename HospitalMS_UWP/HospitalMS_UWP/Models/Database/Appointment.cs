using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "Appointment", Naming = NamingConvention.UnChanged)]
    public class Appointment : EdgeDatabaseModel
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string RoomKey { get; set; }
        public bool IsApproved { get; set; }
        public string ReportURL { get; set; }

        public static bool IsInDB(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Appointment>().Where(u => u.Key == key).Count() > 0;
        }

        public void InsertIntoDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Insert<Appointment>(this);
        }

        public void UpdateInDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Update<Appointment>(this);
        }

        public MessageResponse AddAppointment(DatabaseManager databaseManager)
        {
            if (IsInDB(databaseManager, Key))
            {
                return new MessageResponse("Appointment already exists");
            }
            InsertIntoDB(databaseManager);
            return new MessageResponse("Appointment added");
        }

        public MessageResponse EditAppointment(DatabaseManager databaseManager)
        {
            if (IsInDB(databaseManager, Key))
            {
                UpdateInDB(databaseManager);
                return new MessageResponse("Appointment updated");
            }
            return new MessageResponse("There is no such appointment");
        }

        public static List<Appointment> GetAllAppointments(DatabaseManager databaseManager)
        {
            return databaseManager.Database.Query<Appointment>().ToList();
        }

        public static Appointment GetAppointment(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Appointment>().Where(s => s.Key == key).ToList().First();
        }

        public static List<Appointment> GetApprovedAppointmentsByDateAndTime(DatabaseManager databaseManager, string date, string time, int minutesgap)
        {
            DateTime datetime = Common.GetTimeFromString(time);
            return databaseManager.Database.Query<Appointment>().
                Where(s => s.IsApproved && s.Date == date && Math.Abs((datetime - Common.GetTimeFromString(s.Time)).Minutes) <= minutesgap).ToList();
        }
    }
}
