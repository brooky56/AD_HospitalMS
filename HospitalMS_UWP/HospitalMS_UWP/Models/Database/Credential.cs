using ArangoDB.Client;
using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.Authentication;
using HospitalMS_UWP.Models.Models;
using System;
using System.Linq;

namespace HospitalMS_UWP.Models.Database
{
    [CollectionProperty(CollectionName = "Credential", Naming = NamingConvention.UnChanged)]
    public class Credential: DatabaseModel
    {
        public string PasswordHash { get; set; }

        public static Credential GetByLoginAndHashFromDB(DatabaseManager databaseManager, string login, string passwordHash)
        {
            return databaseManager.Database.Query<Credential>().FirstOrDefault(c => c.Key == login && c.PasswordHash == passwordHash);
        }

        public static MessageResponse SignIn(DatabaseManager databaseManager, EncryptionHelper encryptionHelper, SignInRequest request)
        {
            if (request == null)
            {
                return new MessageResponse("Wrong credentials");
            }

            if (Credential.GetByLoginAndHashFromDB(databaseManager, request.Login, encryptionHelper.GetHash(request.Password)) == null)
            {
                return new MessageResponse("Wrong login or password");
            }

            return new MessageResponse("Authenticated");
        }

        public static MessageResponse SignUp(DatabaseManager databaseManager, EncryptionHelper encryptionHelper, SignUpRequest request)
        {
            request.User.IsVerified = false;
            return User.AddUser(databaseManager, encryptionHelper, request);
        }

        public static string Verify(DatabaseManager databaseManager, string verificationLink)
        {
            User user = User.GetByVerificationLinkFromDB(databaseManager, verificationLink);

            if (user == null)
            {
                return "Wrong verification link";
            }

            user.IsVerified = true;
            user.UpdateInDB(databaseManager);
            return "User is verified";
        }

        public static string GetLoginFromName(DatabaseManager databaseManager, string name)
        {
            name = name.ToLower();
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }

            string[] parts = name.Split(' ');
            if (parts.Length != 2)
            {
                throw new ArgumentException();
            }

            string userName = parts[0][0].ToString() + "." + parts[1];
            int repeats = databaseManager.Database.Query<Credential>()
                .Where(c => AQL.Contains(c.Key, userName)).Count();
            return userName + Convert.ToString(repeats);
        }

        public static MessageResponse ChangePassword(DatabaseManager databaseManager, EncryptionHelper encryptionHelper, ChangePasswordRequest request)
        {
            if (request == null || request.IsInvalid())
            {
                return new MessageResponse("Wrong request");
            }

            Credential credential = Credential.GetByLoginAndHashFromDB(databaseManager, request.Login, encryptionHelper.GetHash(request.Password));

            if (credential == null)
            {
                return new MessageResponse("Wrong login or password");
            }
            credential.PasswordHash = encryptionHelper.GetHash(request.NewPassword);
            databaseManager.Database.Update<Credential>(credential);
            return new MessageResponse("Password was successfuly changed");
        }

        public static MessageResponse ResetPassword(DatabaseManager databaseManager, EncryptionHelper encryptionHelper, ResetPasswordRequest request)
        {
            if (request == null || request.IsInvalid())
            {
                return new MessageResponse("Wrong request");
            }

            User user = User.GetByEmailFromDB(databaseManager, request.Email);
            if (user == null)
            {
                return new MessageResponse("There are no such user");
            }

            Credential credential = databaseManager.Database.Query<Credential>().FirstOrDefault(c => c.Key == user.Key);
            string newPassword = EmailHelper.GetRandomVerificationLink();
            EmailHelper.SendPasswordResetEmail(request.Email, newPassword);
            credential.PasswordHash = encryptionHelper.GetHash(newPassword);
            databaseManager.Database.Update<Credential>(credential);

            return new MessageResponse("Reset");
        }
    }
}
