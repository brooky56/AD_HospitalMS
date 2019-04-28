using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "Medicine", Naming = NamingConvention.UnChanged)]
    public class Medicine : DatabaseModel
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string ExpirationDate { get; set; }
        public int Amount { get; set; }

        public static bool IsInDB(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Medicine>().Where(u => u.Key == key).Count() > 0;
        }

        public void InsertIntoDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Insert<Medicine>(this);
        }

        public void UpdateInDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Update<Medicine>(this);
        }

        public MessageResponse AddMedicine(DatabaseManager databaseManager)
        {
            if (IsInDB(databaseManager, Key))
            {
                return new MessageResponse("Medicine already exists");
            }
            InsertIntoDB(databaseManager);
            return new MessageResponse("Medicine added");
        }

        public MessageResponse EditMedicine(DatabaseManager databaseManager)
        {
            if (IsInDB(databaseManager, Key))
            {
                UpdateInDB(databaseManager);
                return new MessageResponse("Medicine updated");
            }
            return new MessageResponse("There is no such medicine");
        }

        public static MessageResponse DeleteMedicine(DatabaseManager databaseManager, string key)
        {
            if (!IsInDB(databaseManager, key))
            {
                return new MessageResponse("There is no such medicine");
            }
            databaseManager.Database.RemoveById<Medicine>(key);
            return new MessageResponse("Medicine removed");
        }

        public static List<Medicine> GetAllMedicines(DatabaseManager databaseManager)
        {
            return databaseManager.Database.Query<Medicine>().ToList();
        }

        public static Medicine GetMedicine(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Medicine>().Where(s => s.Key == key).ToList().First();
        }
    }
}
