using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreSurvey.Interfaces
{
    interface IUserService
    {

         List<User> GetAllUsers();
         User CreateUser(User user);
         User GetUserById(int userId);
         void DeleteUser(int userId);
         User UpdateUser(User user);

         void LockUser(int userId);
         void ResetUserPassword(User user);
    }
}
