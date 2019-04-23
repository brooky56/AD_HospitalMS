using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    public class Room: DatabaseModel
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

        public static IEnumerable<Room> GetAllRooms(DatabaseManager databaseManager)
        {
            return databaseManager.Database.Query<Room>();
        }

        public static IEnumerable<Room> GetRoom(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Room>().Where(s => s.Key == key);
        }
    }
}
