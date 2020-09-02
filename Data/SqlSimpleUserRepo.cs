using System;
using System.Collections.Generic;
using System.Linq;
using SimpleUser.Models;

namespace SimpleUser.Data
{
    public class SqlSimpleUserRepo : ISimpleUserRepo
    {
        private readonly SimpleUserContext _context;

        public SqlSimpleUserRepo(SimpleUserContext context)
        {
            _context=context;
        }

        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user); 
        }

        public IEnumerable<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public User GetUserbyId(int id)
        {
           return _context.Users.FirstOrDefault(p => p.Id == id);   
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}