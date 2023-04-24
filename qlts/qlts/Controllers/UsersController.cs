using System;
using System.Linq;
using System.Web.Mvc;
using qlts.Extensions;
using qlts.Handlers;
using qlts.Models;
using qlts.ViewModels.Users;

namespace qlts.Controllers
{
    [Authorize(Roles = "AccountingManager")]
    public class UsersController : BaseController
    {

        private readonly IUserHandler _userHandler;

        public UsersController(IUserHandler _userHandler)
        {
            this._userHandler = _userHandler;
        }
        public ActionResult Index()
        {
            var data = _userHandler.GetAllUsers();
            if (data != null && data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }

        public ActionResult CreateUpdate(Guid? id)
        {
            var user = _userHandler.GetUserById(id, GetCurrentUnitForUser());
            if (user == null)
                return RedirectToAction("Login", "Account");

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(UserCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(_userHandler.UserWithDropdown(model,GetCurrentUnitForUser()));

            User user = null;

            try
            {
                if (model.Id != Guid.Empty)
                {
                    model.CreatedBy = GetCurrentUserName();
                    model.ModifiedBy = GetCurrentUserName();
                }
                user = _userHandler.CreateUpdateUser(model);
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return View(_userHandler.UserWithDropdown(model, GetCurrentUnitForUser()));
            }

            if (user.IsSuccess())
            {
                Alert("Lưu thành công!");
                return RedirectToAction(nameof(Index));
            }

            Alert("Lưu không thành công", true);
            return View(model);
        }

        [HttpPost]
        public JsonResult Delete(Guid? id)
        {
            var success = false;

            try
            {
                success = _userHandler.DeleteUser(id);
            }
            catch (Exception ex)
            {
                return Json(GetResponse(false, "Xóa không thành công !"));
            }

            return Json(GetResponse(success), JsonRequestBehavior.DenyGet);
        }
    }

}