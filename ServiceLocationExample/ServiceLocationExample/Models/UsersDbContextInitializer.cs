namespace ServiceLocationExample.Models
{
    public class UsersDbContextInitializer : DropCreateCeDatabaseIfModelChanges<UsersDbContext>
    {
        protected override void Seed(UsersDbContext context)
        {
            context.Users.Add(new User {UserName = "DPadbury"});
            context.Users.Add(new User {UserName = "DMoore"});
            context.Users.Add(new User {UserName = "SWeinstein"});
        }
    }
}