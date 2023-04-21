using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qlts.Handlers;
using qlts.ViewModels.Users;

namespace qlts.Controllers
{
    public class UsersController : Controller
    {

        private readonly IUserHandler _userHandler;

        public UsersController(IUserHandler _userHandler)
        {
            this._userHandler = _userHandler;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUpdate(Guid? id)
        {
            var user = _userHandler.GetUserById(id);
            if (user == null)
                return RedirectToAction("Login", "Account");

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(UserCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(_userHandler.UserWithDropdown(model));

            return View(model);
        }
    }
}