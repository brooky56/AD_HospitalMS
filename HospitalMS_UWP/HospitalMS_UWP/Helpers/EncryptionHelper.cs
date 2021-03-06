﻿using System.Security.Cryptography;
using System.Text;

namespace HospitalMS_UWP.Helpers
{
    public class EncryptionHelper
    {
        private SHA512 sha;

        public EncryptionHelper()
        {
            sha = SHA512.Create();
        }

        public string GetHash(string password)
        {
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
