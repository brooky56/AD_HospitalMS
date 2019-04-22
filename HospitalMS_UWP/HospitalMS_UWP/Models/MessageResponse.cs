namespace HospitalMS_UWP.Models.Models
{
    public class MessageResponse
    {
        public string Message { get; set; }
        public MessageResponse(string message)
        {
            Message = message;
        }
    }
}
