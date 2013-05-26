using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreSurvey.Interfaces;

namespace StoreSurvey.Implementations
{
    
    public class ImplUserService : IUserService
    {
        private StoreSurveyEntities _db = new StoreSurveyEntities();

        public User CreateUser(User user)
        {
            user.Active = 1;
            this._db.Users.Add(user);
            this._db.SaveChanges();
            return user;
        }
        
        public List<User> GetAllUsers()
        {
            var listOfUsers = (from m in this._db.Users
                               select m).ToList();
            return listOfUsers ;
        }
        public User GetUserById(int userId)
        {
            var user = (from m in this._db.Users
                       where m.ID == userId
                       select m).FirstOrDefault();

            return user;

        }
        public void DeleteUser(int userId)
        {
            var userToDelete = GetUserById(userId);
            this._db.Users.Remove(userToDelete);
            this._db.SaveChanges();
        }
        public User UpdateUser(User userToUpdate)
        {

            var user = this.GetUserById(userToUpdate.ID);
            
            user.Name = userToUpdate.Name;
            user.RoleID = userToUpdate.RoleID;
            user.Email = userToUpdate.Email;
            user.Active = 1;
            user.Password = userToUpdate.Password;
            this._db.SaveChanges();

            return user;
        }

        public void LockUser(int userId) 
        {
            var user = GetUserById(userId);
            user.Active = 0;
            _db.SaveChanges();
        }

        public void ResetUserPassword(User userToResetPass)
        {
            var user = GetUserById(userToResetPass.ID);


        }


        public void UnLockUser(int userId)
        {
            var user = GetUserById(userId);
            user.Active = 1;
            _db.SaveChanges();
        }
    }
}