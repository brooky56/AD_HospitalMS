using ArangoDB.Client;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "Appointment", Naming = NamingConvention.UnChanged)]
    public class Appointment : EdgeDatabaseModel
    {
        public string PatientKey { get; set; }
        public string DoctorKey { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string RoomKey { get; set; }
        public bool IsApproved { get; set; }
        public string ReportURL { get; set; }
    }
}
