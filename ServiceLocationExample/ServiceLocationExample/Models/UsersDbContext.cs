using System.Data.Entity;
using System.Diagnostics;

namespace ServiceLocationExample.Models
{
    public class UsersDbContext : DbContext, IUsersDbContext
    {
        public IDbSet<User> Users { get; set; }
    }
}