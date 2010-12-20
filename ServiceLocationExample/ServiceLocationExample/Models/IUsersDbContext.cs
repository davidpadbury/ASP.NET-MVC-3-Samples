using System.Data.Entity;

namespace ServiceLocationExample.Models
{
    public interface IUsersDbContext
    {
        IDbSet<User> Users { get; set; }
    }
}