using System.Collections.Generic;
using SimpleUser.Models;

namespace SimpleUser.Data
{
    public class MockSimpleUserRepo : ISimpleUserRepo
    {
        public IEnumerable<User> GetUser()
        {
            var users = new List<User>
            {
                new User {id=0, Username="Kaique", Email="kaique30@hotmail.com",Password="123"},
                new User {id=1, Username="Joao", Email="joao@hotmail.com",Password="123"},
                new User {id=2, Username="Maria", Email="maria@hotmail.com",Password="123"},

            };

            return users;
        }

        public User GetUserbyId(int id)
        {
                return new User {id=0, Username="Kaique", Email="kaique30@hotmail.com",Password="123"};
        }
    }
}