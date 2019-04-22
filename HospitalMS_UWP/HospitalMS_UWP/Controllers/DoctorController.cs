using HospitalMS_UWP.Models.Database;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS_UWP.Controllers
{
    public class DoctorController: DatabaseController
    {
        public IEnumerable<Doctor> GetAllDoctors()
        {
            return databaseManager.Database.Query<Doctor>().Where(s => s.UserType == UserType.DOCTOR);
        }

        public IEnumerable<Doctor> GetStaff(string key)
        {
            return databaseManager.Database.Query<Doctor>().Where(s => s.Key == key);
        }
    }
}
