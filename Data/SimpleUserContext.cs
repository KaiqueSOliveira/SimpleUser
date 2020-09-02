using Microsoft.EntityFrameworkCore;
using SimpleUser.Models;

namespace SimpleUser.Data
{
    public  class SimpleUserContext : DbContext
    {   
        public SimpleUserContext(DbContextOptions<SimpleUserContext> opt) : base (opt)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}