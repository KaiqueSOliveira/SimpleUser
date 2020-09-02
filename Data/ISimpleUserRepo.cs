using System.Collections.Generic;
using SimpleUser.Models;

namespace SimpleUser.Data
{
    public interface ISimpleUserRepo
    {
        bool SaveChanges();

        IEnumerable<User> GetAllUser();
        User GetUserbyId(int id);

        void CreateUser(User user);

        
    }
}