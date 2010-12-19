using System.Web.Mvc;
using RemoteValidationExample.Models;
using System.Linq;

namespace RemoteValidationExample.Controllers
{
    public class UserController : Controller
    {
        private readonly UsersDataContext _dataContext = new UsersDataContext();

        public ActionResult Index()
        {
            var users = _dataContext.Users
                .OrderByDescending(u => u.UserName)
                .ToList();

            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var newUser = new User();

            return View(newUser);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}