using qlts.Extensions;
using qlts.Handlers;
using qlts.Models;
using qlts.ViewModels.Manufacturers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace qlts.Controllers
{
    public class ManufacturersController : BaseController
    {
        private readonly IManufacturerHandler _ManufacturerHandler;

        public ManufacturersController(IManufacturerHandler _ManufacturerHandler)
        {
            this._ManufacturerHandler = _ManufacturerHandler;
        }
        public ActionResult Index()
        {
            var data = _ManufacturerHandler.GetAllManufacturers();
            if (data != null && data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }

        public ActionResult CreateUpdate(Guid? id)
        {
            var data = _ManufacturerHandler.GetManufacturerById(id);
            if (data == null)
                return RedirectToAction("Login", "Account");

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(ManufacturerCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Manufacturer manufacturer = null;

            model.Date = model.Id != Guid.Empty
           ? (DateTime)DateTimeExtensions.ToDateTime(model.DateFormattedEdit)
           : (DateTime)DateTimeExtensions.ToDateTime(model.DateFormatted);

            model.WarrantyPeriodDate = model.Id != Guid.Empty
                 ? (DateTime)DateTimeExtensions.ToDateTime(model.WarrantyPeriodDateFormattedEdit)
                 : (DateTime)DateTimeExtensions.ToDateTime(model.WarrantyPeriodDateFormatted);
            try
            {
                manufacturer = _ManufacturerHandler.CreateUpdateManufacturer(model);
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return View(model);
            }

            if (manufacturer.IsSuccess())
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
                success = _ManufacturerHandler.DeleteManufacturer(id);
            }
            catch (Exception ex)
            {
                return Json(GetResponse(false, "Xóa không thành công !"));
            }

            return Json(GetResponse(success), JsonRequestBehavior.DenyGet);
        }
    }
}