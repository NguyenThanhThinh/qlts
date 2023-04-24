using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using qlts.Datas;
using qlts.Enums;
using qlts.Models;

namespace qlts.Controllers
{
    public class BaseController : Controller
    {
        protected string UserId => User.Identity.GetUserId<string>();

        protected void Alert(string message, bool isError = false)
        {
            if (isError)
                TempData["error"] = message;
            else
                TempData["success"] = message;
        }

        protected User GetCurrentUser()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var value = identity.Claims.Where(c => c.Type == ClaimTypes.UserData).Select(c => c.Value).SingleOrDefault();

            return value == null ? new User() : JsonConvert.DeserializeObject<User>(value);
        }
        protected string GetCurrentWarehouseId()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var value = identity.Claims.Where(c => c.Type == ClaimTypes.SerialNumber)
                                .Select(c => c.Value).SingleOrDefault();

            if (value == null) return string.Empty;

            return value.ToUpper();
        }
        protected void ShowError(Exception exception)
        {

            if (exception is BusinessException)
            {
                // Alert(exception.Message, true);
                TempData["Exception"] = exception.Message;
            }
            else
            {
                // Alert(BusinessErrorMessages.BusinessError, true);
                TempData["Exception"] = BusinessErrorMessages.BusinessError;
            }
        }

        protected PositionType GetCurrentUserPosition()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var value = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();

            if (value == null) return PositionType.Warehouseman;

            if (value == PositionType.AccountingManager.ToString())
                return PositionType.AccountingManager;
            else if (value == PositionType.UnitManager.ToString())
                return PositionType.UnitManager;
            else
                return PositionType.Warehouseman;
        }

        protected JsonResponse GetResponse(bool success, string message = "", object data = null)
        {
            return new JsonResponse
            {
                Success = success,
                Message = message,
                Data = data
            };
        }

        protected string GenerateCode(string w, string m, int countCode)
        {
            string code = $"{w}.{m}.{(++countCode):D5}";
            return code;
        }
    }
}