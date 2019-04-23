using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "User", Naming = NamingConvention.UnChanged)]
    public class Patient : User
    {
        public float Height { get; set; }
        public float Weight { get; set; }        

        public override void InsertIntoDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Insert<Patient>(this);
        }

        public override void UpdateInDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Update<Patient>(this);
        }

        public static IEnumerable<Patient> GetAllPatients(DatabaseManager databaseManager)
        {
            return databaseManager.Database.Query<Patient>().Where(s => s.UserType == Database.UserType.PATIENT);
        }
    }
}
