using System.Collections.Generic;
using System.Data.Entity;

namespace RemoteValidationExample.Models
{
    public class UsersDataContext : DbContext
    {
        public IDbSet<User> Users { get; set; }
    }
}