using System.Collections.Generic;
using SimpleUser.Models;

namespace SimpleUser.Data
{
    public class MockSimpleUserRepo : ISimpleUserRepo
    {
        public void CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAllUser()
        {
            var users = new List<User>
            {
                new User {Id=0, Username="Kaique", Email="kaique30@hotmail.com",Password="123"},
                new User {Id=1, Username="Joao", Email="joao@hotmail.com",Password="123"},
                new User {Id=2, Username="Maria", Email="maria@hotmail.com",Password="123"},

            };

            return users;
        }

        public User GetUserbyId(int id)
        {
                return new User {Id=0, Username="Kaique", Email="kaique30@hotmail.com",Password="123"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}