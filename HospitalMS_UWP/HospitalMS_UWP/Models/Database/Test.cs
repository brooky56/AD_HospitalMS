using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "Test", Naming = NamingConvention.UnChanged)]
    public class Test : EdgeDatabaseModel
    {
        public string AppointmentKey { get; set; }
        public string LaboratoristKey { get; set; }
        public string DateTime { get; set; }
        public string ReportURL { get; set; }

        public static bool IsInDB(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Test>().Where(u => u.Key == key).Count() > 0;
        }

        public void InsertIntoDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Insert<Test>(this);
        }

        public void UpdateInDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Update<Test>(this);
        }

        public MessageResponse AddTest(DatabaseManager databaseManager)
        {
            if (IsInDB(databaseManager, Key))
            {
                return new MessageResponse("Test already exists");
            }
            InsertIntoDB(databaseManager);
            return new MessageResponse("Test added");
        }

        public MessageResponse EditTest(DatabaseManager databaseManager)
        {
            if (IsInDB(databaseManager, Key))
            {
                UpdateInDB(databaseManager);
                return new MessageResponse("Test updated");
            }
            return new MessageResponse("There is no such test");
        }

        public static List<Test> GetAllTests(DatabaseManager databaseManager)
        {
            return databaseManager.Database.Query<Test>().ToList();
        }

        public static Test GetTest(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Test>().Where(s => s.Key == key).ToList().First();
        }
    }
}
