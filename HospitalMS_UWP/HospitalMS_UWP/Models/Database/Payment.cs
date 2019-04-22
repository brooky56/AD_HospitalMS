using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "Payment", Naming = NamingConvention.UnChanged)]
    public class Payment : DatabaseModel
    {
        public string PatientKey { get; set; }
        public string[] Titles { get; set; }
        public float Cost { get; set; }
        public string Date { get; set; }

        public static bool IsInDB(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Payment>()
                .Where(u => u.Key == key)
                .Count() > 0;
        }

        public void InsertIntoDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Insert<Payment>(this);
        }
    }    
}
