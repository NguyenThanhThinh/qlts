using qlts.Enums;
using qlts.Extensions;
using qlts.Handlers;
using qlts.ViewModels.AssetsTransfers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace qlts.Controllers
{
    public class AssetsExportController : BaseController
    {
        private readonly IFixedAssetHandler _fixedAssetHandler;

        private readonly IWarehouseHandler _warehouseHandler;

        public AssetsExportController(IFixedAssetHandler fixedAssetHandler, IWarehouseHandler warehouseHandler)
        {
            _fixedAssetHandler = fixedAssetHandler;
            _warehouseHandler = warehouseHandler;
        }
        public ActionResult Index()
        {
            GetData();
            TempData["Warehouse"] = GetCurrentWarehouseId();
            var data = _fixedAssetHandler.GetAllFixedAssets();
            if (data != null && data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }
        public ActionResult ListAssetsExport()
        {
            GetData();
            TempData["Warehouse"] = GetCurrentWarehouseId();
            var data = _fixedAssetHandler.GetAllFixedAssets().Where(n => n.FixedAssetType == FixedAssetType.AssetsExport).ToList();
            if (data != null && data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {
            var warehouseId = form.Get("Warehouse");
            GetData();
            TempData["Warehouse"] = warehouseId;
            var data = _fixedAssetHandler.GetAllFixedAssets();

            if (warehouseId != null && Guid.Parse(warehouseId) != Guid.Empty)
            {
                data = data.Where(n => n.WarehouseId == Guid.Parse(warehouseId)).ToList();
            }
            if (data != null && data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }

        public ActionResult CreateModal()
        {
            GetData();

            return View();
        }

        private void GetData()
        {
            TempData["FixedAssetDate"] = DateTime.Now.ToString("dd/MM/yyyy");
            TempData["Warehouses"] = _warehouseHandler.GetAllWarehouses();
        }

        [HttpPost]
        public JsonResult CreateTransfer(CreateTransferViewModel model)
        {

            var success = false;
            try
            {
                foreach (var item in model.AssetIds)
                {
                    if (item == null) continue;
                    if (item.Length == 0) continue;
                    InsertTransfer(model, item);
                    UpdateTransfer(model, item);
                }

                return Json(GetResponse(success), JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {
                return Json(GetResponse(success), JsonRequestBehavior.DenyGet);
            }
        }

        private void InsertTransfer(CreateTransferViewModel model, string item)
        {
            ViewModels.FixedAssets.FixedAssetCreateUpdateViewModel asset =
                _fixedAssetHandler.GetFixedAssetById(Guid.Parse(item.ToUpper().ToString()));
            if (asset != null)
            {
                asset.Id = Guid.Empty;
                asset.WarehouseId = Guid.Parse(model.WarehouseId);
                asset.Note = model.Note;
                asset.FixedAssetDate = (DateTime)DateTimeExtensions.ToDateTime(model.FixedAssetDate);
                asset.CreatedDate = DateTime.Now;
                asset.FixedAssetType = Enums.FixedAssetType.AssetsExport;
                model.ModifiedBy = GetCurrentUserName();
                _fixedAssetHandler.CreateUpdateFixedAsset(asset);
            }
        }

        private void UpdateTransfer(CreateTransferViewModel model, string item)
        {
            ViewModels.FixedAssets.FixedAssetCreateUpdateViewModel asset =
                _fixedAssetHandler.GetFixedAssetById(Guid.Parse(item.ToUpper().ToString()));
            if (asset != null)
            {
                asset.Quantity = 0;
                asset.ModifiedDate = DateTime.Now;
                _fixedAssetHandler.CreateUpdateFixedAsset(asset);
            }
        }
    }
}