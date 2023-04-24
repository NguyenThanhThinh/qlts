using qlts.Extensions;
using qlts.Handlers;
using qlts.Models;
using qlts.ViewModels.FixedAssetStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qlts.Controllers
{
    public class FixedAssetStatusController : BaseController
    {
        private readonly IFixedAssetStatusHandler _FixedAssetStatusHandler;

        public FixedAssetStatusController(IFixedAssetStatusHandler _FixedAssetStatusHandler)
        {
            this._FixedAssetStatusHandler = _FixedAssetStatusHandler;
        }
        public ActionResult Index()
        {
            var data = _FixedAssetStatusHandler.GetAllFixedAssetStatuss();
            if (data != null && data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }

        public ActionResult CreateUpdate(Guid? id)
        {
            var data = _FixedAssetStatusHandler.GetFixedAssetStatusById(id);
            if (data == null)
                return RedirectToAction("Login", "Account");

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(FixedAssetStatusCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            FixedAssetStatus fixedAssetStatus = null;

            try
            {
                if (model.Id != Guid.Empty)
                {
                    model.CreatedBy = GetCurrentUserName();
                    model.ModifiedBy = GetCurrentUserName();
                }
                fixedAssetStatus = _FixedAssetStatusHandler.CreateUpdateFixedAssetStatus(model);
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return View(model);
            }

            if (fixedAssetStatus.IsSuccess())
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
                success = _FixedAssetStatusHandler.DeleteFixedAssetStatus(id);
            }
            catch (Exception ex)
            {
                return Json(GetResponse(false, "Xóa không thành công !"));
            }

            return Json(GetResponse(success), JsonRequestBehavior.DenyGet);
        }
    }
}