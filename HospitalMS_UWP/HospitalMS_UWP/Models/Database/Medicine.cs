using ArangoDB.Client;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "Medicine", Naming = NamingConvention.UnChanged)]
    public class Medicine: DatabaseModel
    {
        public string Title { get; set; }
        public float Price { get; set; }        
        public string ExpirationDate { get; set; }
        public int Amount { get; set; }
    }
}
