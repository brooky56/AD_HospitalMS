using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    public class Room : DatabaseModel
    {
        public string Type { get; set; }
        public string[] Nurses { get; set; }

        public static bool IsInDB(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Room>().Where(u => u.Key == key).Count() > 0;
        }

        public void InsertIntoDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Insert<Room>(this);
        }

        public void UpdateInDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Update<Room>(this);
        }

        public MessageResponse AddRoom(DatabaseManager databaseManager)
        {
            if (IsInDB(databaseManager, Key))
            {
                return new MessageResponse("Room already exists");
            }
            InsertIntoDB(databaseManager);
            return new MessageResponse("Room added");
        }

        public MessageResponse EditRoom(DatabaseManager databaseManager)
        {
            if (IsInDB(databaseManager, Key))
            {
                UpdateInDB(databaseManager);
                return new MessageResponse("Room updated");
            }
            return new MessageResponse("There is no such room");
        }

        public static List<Room> GetAllRooms(DatabaseManager databaseManager)
        {
            return databaseManager.Database.Query<Room>().ToList();
        }

        public static Room GetRoom(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Room>().Where(s => s.Key == key).ToList().First();
        }

        public static List<Room> GetAllFreeRoomsByDateAndTime(DatabaseManager databaseManager, string date, string time, int minutesgap)
        {
            List<Room> rooms = Room.GetAllRooms(databaseManager);
            List<Appointment> apps = Appointment.GetApprovedAppointmentsByDateAndTime(databaseManager, date, time, minutesgap);
            foreach (Room r in rooms)
            {
                if (apps.Exists(x => x.RoomKey == r.Key))
                {
                    rooms.Remove(r);
                }
            }
            return rooms;
        }
    }
}
