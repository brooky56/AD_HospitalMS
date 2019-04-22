using ArangoDB.Client;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "TimeSlot", Naming = NamingConvention.UnChanged)]
    public class TimeSlot: DatabaseModel
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string[] Days { get; set; }
        public int RepeatWeeks { get; set; }

    }
}
