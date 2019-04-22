using HospitalMS_UWP.Models.Database;

namespace HospitalMS_UWP.Models.Authentication
{
    public class SignUpRequest
    {
        public string Password { get; set; }
        public User User { get; set; }
        public bool IsInvalid()
        {
            return string.IsNullOrEmpty(Password) || User == null || User.IsInvalid();
        }
    }
}
