﻿using HospitalMS_UWP.Models.Database;
using Newtonsoft.Json.Linq;
using System;

namespace HospitalMS_UWP.Models.JSONConverters
{
    public class UserJsonConverter: JsonCreationConverter<User>
    {
        protected override User Create(Type objectType, JObject jObject)
        {
            if (jObject == null)
            {
                throw new ArgumentNullException("jObject");
            }

            if (jObject["UserType"].ToString() == UserType.PATIENT)
            {
                return new Patient();
            }
            else if (jObject["UserType"].ToString() == UserType.DOCTOR)
            {
                return new Doctor();
            }
            else
            {
                return new Staff();
            }
        }
    }
}
