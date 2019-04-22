using ArangoDB.Client;
using HospitalMS_UWP.Helpers;

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
    }
}
