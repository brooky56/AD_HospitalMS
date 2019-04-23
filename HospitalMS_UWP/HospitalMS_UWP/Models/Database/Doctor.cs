using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "User", Naming = NamingConvention.UnChanged)]
    public class Doctor : Staff
    {        
        public string Designation { get; set; }
        public string DoctorType { get; set; }
        public bool[] WorkingDays { get; set; }

        public override void InsertIntoDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Insert<Doctor>(this);
        }

        public override void UpdateInDB(DatabaseManager databaseManager)
        {
            databaseManager.Database.Update<Doctor>(this);
        }

        public static IEnumerable<Doctor> GetAllDoctors(DatabaseManager databaseManager)
        {
            return databaseManager.Database.Query<Doctor>().Where(s => s.UserType == Database.UserType.DOCTOR);
        }
    }
}
