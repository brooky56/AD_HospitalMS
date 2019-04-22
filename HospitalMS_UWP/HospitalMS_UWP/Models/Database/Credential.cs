using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "Credential", Naming = NamingConvention.UnChanged)]
    public class Credential: DatabaseModel
    {
        public string PasswordHash { get; set; }

        public static Credential GetByLoginAndHashFromDB(DatabaseManager databaseManager, string login, string passwordHash)
        {
            return databaseManager.Database.Query<Credential>().FirstOrDefault(c => c.Key == login && c.PasswordHash == passwordHash);
        }
    }
}
