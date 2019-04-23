using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "TestType", Naming = NamingConvention.UnChanged)]
    public class TestType: DatabaseModel
    {
        public string Title { get; set; }
        public string TemplateURL { get; set; }

        public static bool IsInDB(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<TestType>().Where(u => u.Key == key).Count() > 0;
        }

        public void InsertIntoDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Insert<TestType>(this);
        }

        public void UpdateInDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Update<TestType>(this);
        }

        public MessageResponse AddTestType(DatabaseManager databaseManager)
        {
            if (IsInDB(databaseManager, Key))
            {
                return new MessageResponse("Test type already exists");
            }
            InsertIntoDB(databaseManager);
            return new MessageResponse("Test type added");
        }

        public MessageResponse EditTestType(DatabaseManager databaseManager)
        {
            if (IsInDB(databaseManager, Key))
            {
                UpdateInDB(databaseManager);
                return new MessageResponse("Test type updated");
            }
            return new MessageResponse("There is no such test type");
        }

        public static IEnumerable<TestType> GetAllTestTypes(DatabaseManager databaseManager)
        {
            return databaseManager.Database.Query<TestType>();
        }

        public static IEnumerable<TestType> GetTestType(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<TestType>().Where(s => s.Key == key);
        }
    }
}
