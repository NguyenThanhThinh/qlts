using System;
using Newtonsoft.Json;
using qlts.Handlers;
using qlts.ViewModels.Accounts;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using qlts.Enums;
using qlts.Extensions;
using qlts.Models;
using qlts.ViewModels.Users;

namespace qlts.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthenHandler authenHandler;
        private readonly IUserHandler _userHandler;

        public AccountController(IAuthenHandler authenHandler, IUserHandler userHandler)
        {
            this.authenHandler = authenHandler;
            _userHandler = userHandler;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Login(AccountLoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await authenHandler.CheckLogin(model);
            if (result is null)
            {
                TempData["error"] = "Sai tên đăng nhập hoặc mật khẩu.";
                return View(model);
            }

            string roleName;

            switch (result.Position)
            {
                case PositionType.AccountingManager:
                    roleName = PositionType.AccountingManager.ToString();
                    break;
                case PositionType.UnitManager:
                    roleName = PositionType.UnitManager.ToString();
                    break;
                default:
                    roleName = PositionType.Warehouseman.ToString();
                    break;
            }
            var identity = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, result.Name),
                    new Claim(ClaimTypes.GivenName, result.UserName),
                    new Claim(ClaimTypes.SerialNumber, result.Warehouse.Id.ToString()),
                    new Claim(ClaimTypes.Role, roleName),
                    new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(result)),
                    new Claim(ClaimTypes.NameIdentifier, result.Id.ToString())
                },
                "CookieAuth");

            var owinContext = Request.GetOwinContext();
            var authManager = owinContext.Authentication;
            authManager.SignIn(identity);

            return RedirectToLocal(returnUrl);
        }

        public ActionResult Logout()
        {
            var owinContext = Request.GetOwinContext();
            var authManager = owinContext.Authentication;
            authManager.SignOut("CookieAuth");
            return RedirectToAction("Login", "Account");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        public ActionResult Profile()
        {
            var user = _userHandler.GetUserById(Guid.Parse(UserId));

            return View(user);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(UserCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User user = null;

            try
            {
                user = _userHandler.CreateUpdateUser(model);
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return View(model);
            }

            if (user.IsSuccess())
            {
                Alert("Lưu thành công!");
                return View();
            }

            Alert("Lưu không thành công", true);
            return View(model);
        }

    }
}