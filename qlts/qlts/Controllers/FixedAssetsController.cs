using qlts.Extensions;
using qlts.Handlers;
using qlts.Models;
using qlts.ViewModels.FixedAssets;
using System;
using System.Linq;
using System.Web.Mvc;
using qlts.Enums;

namespace qlts.Controllers
{
    public class FixedAssetsController : BaseController
    {

        private readonly IFixedAssetHandler _fixedAssetHandler;

        private readonly IWarehouseHandler _warehouseHandler;

        private readonly IManufacturerHandler _manufacturerHandler;

        public FixedAssetsController(IFixedAssetHandler fixedAssetHandler, IWarehouseHandler warehouseHandler,
            IManufacturerHandler manufacturerHandler)
        {
            this._fixedAssetHandler = fixedAssetHandler;
            this._warehouseHandler = warehouseHandler;
            _manufacturerHandler = manufacturerHandler;
        }
        public ActionResult Index()
        {
            var data = _fixedAssetHandler.GetAllFixedAssets().Where(n => n.Center == GetCurrentUnitForUser()).ToList();
            if (data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }

        public ActionResult ListFixedAssets()
        {
            var data = _fixedAssetHandler.GetAllFixedAssets().Where(n => n.FixedAssetType == FixedAssetType.UseAsset
                                                                         && n.Center == GetCurrentUnitForUser()).ToList();
            if (data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }
        public ActionResult CreateUpdate(Guid? id)
        {
            var data = _fixedAssetHandler.GetFixedAssetById(id);
            if (data == null)
                return RedirectToAction("Login", "Account");

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(FixedAssetCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(_fixedAssetHandler.FixedAssetWithDropdown(model));

            FixedAsset fixedAsset = null;

            var data = _fixedAssetHandler.GetAllFixedAssets().Where(n => n.FixedAssetType == Enums.FixedAssetType.UseAsset).ToList();

            var warehouse = _warehouseHandler.GetWarehouseById(model.WarehouseId);
            var manufacturer = _manufacturerHandler.GetManufacturerById(model.ManufacturerId);

            if (warehouse != null && manufacturer != null && model.Id == Guid.Empty)
            {
                model.Code = GenerateCode(warehouse.Name, manufacturer.Name, data.Count == 0 ? 0 : data.Count);
                model.FixedAssetType = Enums.FixedAssetType.UseAsset;
            }

            model.CreatedBy = GetCurrentUserName();

            if (model.Id != Guid.Empty)
            {
                model.ModifiedBy = GetCurrentUserName();
            }
            model.FixedAssetDate = model.Id != Guid.Empty
            ? (DateTime)DateTimeExtensions.ToDateTime(model.FixedAssetDateFormattedEdit)
            : (DateTime)DateTimeExtensions.ToDateTime(model.FixedAssetDateFormatted);

            try
            {
                fixedAsset = _fixedAssetHandler.CreateUpdateFixedAsset(model);
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return View(_fixedAssetHandler.FixedAssetWithDropdown(model));
            }

            if (fixedAsset.IsSuccess())
            {
                Alert("Lưu thành công!");
                return RedirectToAction(nameof(Index));
            }

            Alert("Lưu không thành công", true);
            return View(_fixedAssetHandler.FixedAssetWithDropdown(model));
        }


        [HttpPost]
        public JsonResult Delete(Guid? id)
        {
            var success = false;

            try
            {
                success = _fixedAssetHandler.DeleteFixedAsset(id);
            }
            catch (Exception ex)
            {
                return Json(GetResponse(false, "Xóa không thành công !"));
            }

            return Json(GetResponse(success), JsonRequestBehavior.DenyGet);
        }
    }
}