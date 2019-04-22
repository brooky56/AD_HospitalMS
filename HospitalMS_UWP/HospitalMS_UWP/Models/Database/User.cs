using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.JSONConverters;
using Newtonsoft.Json;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    [JsonConverter(typeof(UserJsonConverter))]
    [CollectionProperty(CollectionName = "User", Naming = NamingConvention.UnChanged)]
    public abstract class User: DatabaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public string VerificationLink { get; set; }        
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Appartment { get; set; }
        public string BirthDate { get; set; }
        public char Gender { get; set; }
        public string PhotoLink { get; set; }
        public string UserType { get; set; }
        public abstract void InsertIntoDB(DatabaseManager databaseManager);
        public abstract void UpdateInDB(DatabaseManager databaseManager);

        public static bool IsInDB(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<User>()
                .Where(u => u.Key == key)
                .Count() > 0;
        }

        public static User GetByEmailFromDB(DatabaseManager databaseManager, string email)
        {
            return databaseManager.Database.Query<User>().FirstOrDefault(u => u.Email == email);
        }

        public bool IsInvalid()
        {
            return string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Email);
        }

        public static User GetByVerificationLinkFromDB(DatabaseManager databaseManager, string link)
        {
            return databaseManager.Database.Query<User>().FirstOrDefault(u => u.VerificationLink == link);
        }
    }
}
