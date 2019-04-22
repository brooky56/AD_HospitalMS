using ArangoDB.Client;

namespace HospitalMS_UWP.Models.Database
{
    public abstract class EdgeDatabaseModel: DatabaseModel
    {
        [DocumentProperty(Identifier = IdentifierType.EdgeFrom)]
        public string From { get; set; }
        [DocumentProperty(Identifier = IdentifierType.EdgeTo)]
        public string To { get; set; }
    }
}
