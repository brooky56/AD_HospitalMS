using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.Authentication;
using HospitalMS_UWP.Models.JSONConverters;
using HospitalMS_UWP.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    [JsonConverter(typeof(UserJsonConverter))]
    [CollectionProperty(CollectionName = "User", Naming = NamingConvention.UnChanged)]
    public abstract class User : DatabaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public string VerificationLink { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Appartment { get; set; }
        public string BirthDate { get; set; }
        public char Gender { get; set; }
        public string PhotoLink { get; set; }
        public string UserType { get; set; }

        public abstract void InsertIntoDB(DatabaseManager databaseManager);
        public abstract void UpdateInDB(DatabaseManager databaseManager);

        public static bool IsInDB(DatabaseManager databaseManager, string key)
        {
            return databaseManager.Database.Query<User>()
                .Where(u => u.Key == key)
                .Count() > 0;
        }

        public static User GetByEmailFromDB(DatabaseManager databaseManager, string email)
        {
            return databaseManager.Database.Query<User>().FirstOrDefault(u => u.Email == email);
        }

        public bool IsInvalid()
        {
            return string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Email);
        }

        public static User GetByVerificationLinkFromDB(DatabaseManager databaseManager, string link)
        {
            return databaseManager.Database.Query<User>().FirstOrDefault(u => u.VerificationLink == link);
        }

        public static MessageResponse AddUser(DatabaseManager databaseManager, EncryptionHelper encryptionHelper, SignUpRequest request)
        {
            if (request == null || request.IsInvalid() || request.User.IsInvalid())
            {
                return new MessageResponse("Wrong data");
            }

            if (User.GetByEmailFromDB(databaseManager, request.User.Email) != null)
            {
                return new MessageResponse("This email already registered");
            }

            if (request.User.UserType == Database.UserType.ADMIN)
            {
                return new MessageResponse("Security violation");
            }


            if (!request.User.IsVerified)
            {
                request.User.VerificationLink = EmailHelper.GetRandomVerificationLink();

                try
                {
                    EmailHelper.SendVerificationEmail(request.User.Email, request.User.VerificationLink);
                }
                catch (Exception ex)
                {
                    return new MessageResponse(ex.Message);
                }
            }

            databaseManager.Database.Insert<User>(request.User);

            Credential credentials = new Credential();

            try
            {
                credentials.Key = Credential.GetLoginFromName(databaseManager, request.User.Name);
            }
            catch (ArgumentException)
            {
                return new MessageResponse("Wrong name format");
            }

            credentials.PasswordHash = encryptionHelper.GetHash(request.Password);
            databaseManager.Database.Insert<Credential>(credentials);

            return new MessageResponse("Registered");
        }

        public static MessageResponse EditUser(User user, DatabaseManager databaseManager)
        {
            if (IsInDB(databaseManager, user.Key))
            {
                user.UpdateInDB(databaseManager);
                return new MessageResponse("User updated");
            }
            return new MessageResponse("There is no such user");
        }

        public static MessageResponse DeleteUser(DatabaseManager databaseManager, DeleteUserRequest request)
        {
            if (IsInDB(databaseManager, request.Key))
            {
                databaseManager.Database.RemoveById<User>(request.Key);
                return new MessageResponse("User removed");
            }
            return new MessageResponse("There is no such user");
        }

        public static List<User> GetAllUsers(DatabaseManager databaseManager)
        {
            return databaseManager.Database.Query<User>().ToList();
        }

        public static User GetUser(DatabaseManager databaseManager, string key)
        { 
            return databaseManager.Database.Query<User>().Where(s => s.Key == key).ToList().First();
        }
    }
}
