using ArangoDB.Client;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "Payment", Naming = NamingConvention.UnChanged)]
    public class Payment: DatabaseModel
    {
        public string PatientKey { get; set; }
        public string Title { get; set; }
        public float Cost { get; set; }
        public string Date { get; set; }
    }
}
