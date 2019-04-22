using HospitalMS_UWP.Helpers;
using HospitalMS_UWP.Models.Authentication;
using HospitalMS_UWP.Models.Database;
using HospitalMS_UWP.Models.Models;
using System.Collections.Generic;

namespace HospitalMS_UWP.Controllers
{
    public class UserController
    {
        private DatabaseManager databaseManager;

        public UserController()
        {
            databaseManager = new DatabaseManager();
        }

        public IEnumerable<User> GetUsers()
        {
            return databaseManager.Database.Query<User>().ToList();
        }

        public MessageResponse AddUser(User user)
        {            
            if (Models.Database.User.IsInDB(databaseManager, user.Key))
            {                
                return new MessageResponse("User already exists");
            }
            user.InsertIntoDB(databaseManager);
            return new MessageResponse("User added");
        }

        public MessageResponse EditUser(User user)
        {
            if (Models.Database.User.IsInDB(databaseManager, user.Key))
            {
                user.UpdateInDB(databaseManager);
                return new MessageResponse("User updated");
            }
            return new MessageResponse("There is no such user");
        }

        public MessageResponse DeleteUser(DeleteUserRequest request)
        {
            if (Models.Database.User.IsInDB(databaseManager, request.Key))
            {
                databaseManager.Database.RemoveById<User>(request.Key);
                return new MessageResponse("User removed");
            }
            return new MessageResponse("There is no such user");
        }
    }
}
