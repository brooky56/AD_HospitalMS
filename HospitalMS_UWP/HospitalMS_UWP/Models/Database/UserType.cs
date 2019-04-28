using ArangoDB.Client;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "UserType", Naming = NamingConvention.UnChanged)]
    public class UserType: DatabaseModel
    {
        public const string ADMIN = "A";

        public const string PATIENT = "P";
        public const string DOCTOR = "D";
        public const string NURSE = "N";
        public const string RECEPTIONIST = "R";
        public const string PHARMACIST = "H";
        public const string ACCOUNTANT = "A";
        public const string LABORATORIST = "L";

        public string Type { get; set; }
    }
}
