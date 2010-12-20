using System.Web.Mvc;
using ServiceLocationExample.Models;
using System.Linq;

namespace ServiceLocationExample.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            var dbContext = new UsersDbContext();

            var users = dbContext.Users
                .OrderBy(u => u.UserName)
                .ToArray();

            return View(users);
        }
    }
}