using System.Collections.Generic;
using SimpleUser.Models;

namespace SimpleUser.Data
{
    public interface ISimpleUserRepo
    {
        IEnumerable<User> GetUser();
        User GetUserbyId(int id);
        
    }
}