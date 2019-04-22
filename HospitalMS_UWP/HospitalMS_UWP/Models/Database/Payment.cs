using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.Models;
using System.Collections.Generic;
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
            return databaseManager.Database.Query<Payment>().Where(u => u.Key == key).Count() > 0;
        }

        public void InsertIntoDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Insert<Payment>(this);
        }

        public MessageResponse AddPayment(DatabaseManager databaseManager)
        {
            if (IsInDB(databaseManager, Key))
            {
                return new MessageResponse("Payment already exists");
            }
            InsertIntoDB(databaseManager);
            return new MessageResponse("Payment added");
        }

        public static IEnumerable<Payment> GetAllPayments(DatabaseManager databaseManager)
        {
            return databaseManager.Database.Query<Payment>();
        }

        public static IEnumerable<Payment> GetPayment(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<Payment>().Where(s => s.Key == key);
        }
    }    
}
