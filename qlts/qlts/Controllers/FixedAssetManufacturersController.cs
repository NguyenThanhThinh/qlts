using qlts.Extensions;
using qlts.Handlers;
using qlts.Models;
using qlts.ViewModels.FixedAssetManufacturers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace qlts.Controllers
{
    public class FixedAssetManufacturersController : BaseController
    {
        private readonly IFixedAssetManufacturerHandler _FixedAssetManufacturerHandler;

        public FixedAssetManufacturersController(IFixedAssetManufacturerHandler _FixedAssetManufacturerHandler)
        {
            this._FixedAssetManufacturerHandler = _FixedAssetManufacturerHandler;
        }
        public ActionResult Index()
        {
            var data = _FixedAssetManufacturerHandler.GetAllFixedAssetManufacturers();
            if (data != null && data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }
        [HttpGet]
        public ActionResult CreateUpdate(Guid? id)
        {
            var data = _FixedAssetManufacturerHandler.GetFixedAssetManufacturerById(id);
            if (data == null)
                return RedirectToAction("Login", "Account");

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(FixedAssetManufacturerCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            FixedAssetManufacturer FixedAssetManufacturer = null;
            if (model.Id != Guid.Empty)
            {
                model.ModifiedBy = GetCurrentUserName();
            }
            model.Date = model.Id != Guid.Empty
           ? (DateTime)DateTimeExtensions.ToDateTime(model.DateFormattedEdit)
           : (DateTime)DateTimeExtensions.ToDateTime(model.DateFormatted);

            model.WarrantyPeriodDate = model.Id != Guid.Empty
                 ? (DateTime)DateTimeExtensions.ToDateTime(model.WarrantyPeriodDateFormattedEdit)
                 : (DateTime)DateTimeExtensions.ToDateTime(model.WarrantyPeriodDateFormatted);
            try
            {
                FixedAssetManufacturer = _FixedAssetManufacturerHandler.CreateUpdateFixedAssetManufacturer(model);
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return View(model);
            }

            if (FixedAssetManufacturer.IsSuccess())
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
                success = _FixedAssetManufacturerHandler.DeleteFixedAssetManufacturer(id);
            }
            catch (Exception ex)
            {
                return Json(GetResponse(false, "Xóa không thành công !"));
            }

            return Json(GetResponse(success), JsonRequestBehavior.DenyGet);
        }
    }
}