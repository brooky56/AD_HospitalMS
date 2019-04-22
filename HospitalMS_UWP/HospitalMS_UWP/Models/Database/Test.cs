using ArangoDB.Client;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "Test", Naming = NamingConvention.UnChanged)]
    public class Test: EdgeDatabaseModel
    {
        public string AppointmentKey { get; set; }
	    public string LaboratoristKey { get; set; }
	    public string DateTime { get; set; }
        public string ReportURL { get; set; }
    }
}
