using HospitalMS_UWP.Helpers;

namespace HospitalMS_UWP.Controllers
{
    public abstract class DatabaseController
    {
        protected DatabaseManager databaseManager;

        public DatabaseController()
        {
            databaseManager = new DatabaseManager();
        }
    }
}
