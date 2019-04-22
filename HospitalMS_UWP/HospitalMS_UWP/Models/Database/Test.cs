using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "Test", Naming = NamingConvention.UnChanged)]
    public class Test: EdgeDatabaseModel
    {
        public string AppointmentKey { get; set; }
	    public string LaboratoristKey { get; set; }
	    public string DateTime { get; set; }
        public string ReportURL { get; set; }

        public static IEnumerable<Test> GetAllTests(DatabaseManager databaseManager)
        {
            return databaseManager.Database.Query<Test>();
        }

        public static IEnumerable<Test> GetTest(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Test>().Where(s => s.Key == key);
        }

        public static void EditTest(DatabaseManager databaseManager, Test room)
        {
            databaseManager.Database.Update<Test>(room);
        }
    }
}
