using qlts.Extensions;
using qlts.Handlers;
using qlts.Models;
using qlts.ViewModels.FixedAssets;
using qlts.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var data = _fixedAssetHandler.GetAllFixedAssets();
            if (data != null && data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }

        public ActionResult CreateModal()
        {
            return View();
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

            var data = _fixedAssetHandler.GetAllFixedAssets();

            var warehouse = _warehouseHandler.GetWarehouseById(Guid.Parse(model.WarehouseId));
            var manufacturer = _manufacturerHandler.GetManufacturerById(Guid.Parse(model.ManufacturerId));

            if (warehouse != null && manufacturer != null)
            {
                fixedAsset.Code = GenerateCode(warehouse.Name, manufacturer.Name, data.Count == 0 ? 0 : data.Count);
            }

            model.FixedAssetDate = model.Id != null
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
    }
}