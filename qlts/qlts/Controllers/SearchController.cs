using qlts.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qlts.Controllers
{
    public class SearchController : Controller
    {
        private readonly IFixedAssetHandler _fixedAssetHandler;

        private readonly IWarehouseHandler _warehouseHandler;

        public SearchController(IFixedAssetHandler fixedAssetHandler, IWarehouseHandler warehouseHandler)
        {
            _fixedAssetHandler = fixedAssetHandler;
            _warehouseHandler = warehouseHandler;
        }
        public ActionResult Index()
        {
            TempData["Warehouse"] = Guid.NewGuid();
            GetData();
            var data = _fixedAssetHandler.GetAllFixedAssets();
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
        private void GetData()
        {
            TempData["Warehouses"] = _warehouseHandler.GetAllWarehouses();
        }
    }
}