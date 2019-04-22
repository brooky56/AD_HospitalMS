using ArangoDB.Client;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "TestType", Naming = NamingConvention.UnChanged)]
    public class TestType: DatabaseModel
    {
        public string Title { get; set; }
        public string TemplateURL { get; set; }
    }
}
