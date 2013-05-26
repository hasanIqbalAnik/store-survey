using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreSurvey.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace StoreSurvey.Implementations
{
    
    public class ImplUserService : IUserService
    {
        private StoreSurveyEntities _db = new StoreSurveyEntities();

        public User CreateUser(User user)
        {
            string hashPass = CalculateMD5Hash(user.Password);
            user.Password = hashPass;
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
            user.Password = CalculateMD5Hash(userToUpdate.Password);
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

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public bool CheckDuplicate(User chkUser) 
        {
            bool duplicate = false;
            var users = GetAllUsers();
            

            foreach (User user in users) 
            {
                if (user.UserName == chkUser.UserName || user.Email == chkUser.Email) duplicate = true;
            }

            return duplicate;
        }
    }
}