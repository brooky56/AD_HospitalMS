using ArangoDB.Client;
using HospitalMS_UWP.Helpers;

namespace HospitalMS_UWP.Models.Database
{
    public abstract class DatabaseModel
    {
        [DocumentProperty(Identifier = IdentifierType.Key)]
        public string Key { get; set; }
    }
}
