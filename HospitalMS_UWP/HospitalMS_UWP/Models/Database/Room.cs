namespace HospitalMS_UWP.Models.Database
{
    public class Room: DatabaseModel
    {
        public string Type { get; set; }
        public string[] Nurses { get; set; }
    }
}
