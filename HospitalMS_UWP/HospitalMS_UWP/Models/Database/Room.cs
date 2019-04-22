using HospitalMS_UWP.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    public class Room: DatabaseModel
    {
        public string Type { get; set; }
        public string[] Nurses { get; set; }

        public static IEnumerable<Room> GetAllRooms(DatabaseManager databaseManager)
        {
            return databaseManager.Database.Query<Room>();
        }

        public static IEnumerable<Room> GetRoom(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Room>().Where(s => s.Key == key);
        }

        public static void EditRoom(DatabaseManager databaseManager, Room room)
        {
            databaseManager.Database.Update<Room>(room);
        }
    }
}
