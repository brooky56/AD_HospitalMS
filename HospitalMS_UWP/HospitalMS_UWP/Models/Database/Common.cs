using HospitalMS_UWP.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    class Common
    {
        public static DateTime GetTimeFromString(string time)
        {
            return DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);
        }

        public static List<Room> GetAllFreeRoomsByDateAndTime(DatabaseManager databaseManager, string date, string time, int minutesgap)
        {
            List<Room> rooms = Room.GetAllRooms(databaseManager);
            List<Appointment> apps = Appointment.GetApprovedAppointmentsByDateAndTime(databaseManager, date, time, minutesgap);
            foreach (Room r in rooms) {
                if (apps.Exists(x => x.RoomKey == r.Key))
                {
                    rooms.Remove(r);
                }
            }
            return rooms;
        }
    }
}
