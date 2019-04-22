using HospitalMS_UWP.Models.Database;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS_UWP.Controllers
{
    public class StaffController : DatabaseController
    {
        public IEnumerable<Staff> GetAllStaff()
        {
            return databaseManager.Database.Query<Staff>().Where(s => s.UserType != UserType.PATIENT);
        }
        // Если есть подтаблица Staff, то зачем проверкка на тип?

        public IEnumerable<Staff> GetStaff(string key)
        {
            return databaseManager.Database.Query<Staff>().Where(s => s.Key == key);
        }
    }
}
