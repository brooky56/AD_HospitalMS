namespace HospitalMS_UWP.Models.Authentication
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }

        public bool IsInvalid()
        {
            return string.IsNullOrEmpty(Email);
        }
    }
}
