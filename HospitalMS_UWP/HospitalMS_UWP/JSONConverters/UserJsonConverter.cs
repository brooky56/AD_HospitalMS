using HospitalMS_UWP.Models.Database;
using Newtonsoft.Json.Linq;
using System;

namespace HospitalMS_UWP.Models.JSONConverters
{
    public class UserJsonConverter : JsonCreationConverter<User>
    {
        protected override User Create(Type objectType, JObject jObject)
        {
            if (jObject == null)
            {
                throw new ArgumentNullException("jObject");
            }

            string type = jObject["UserType"].ToString();
            if (type == UserType.PATIENT)
            {
                return new Patient();
            }
            if (type == UserType.DOCTOR)
            {
                return new Doctor();
            }
            return new Staff();
        }
    }
}
