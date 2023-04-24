using qlts.Enums;
using qlts.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace qlts.Controllers
{
    public class ReportsController : BaseController
    {
        private readonly IFixedAssetHandler _fixedAssetHandler;

        private readonly IWarehouseHandler _warehouseHandler;

        public ReportsController(IFixedAssetHandler fixedAssetHandler, IWarehouseHandler warehouseHandler)
        {
            _fixedAssetHandler = fixedAssetHandler;
            _warehouseHandler = warehouseHandler;
        }
        public ActionResult Index()
        {
            GetData();
            TempData["Warehouse"] = GetCurrentWarehouseId();
            TempData["FixedAssetTypeId"] = 0;
            var data = _fixedAssetHandler.GetAllFixedAssets().Where(n => n.Center == GetCurrentUnitForUser()).ToList();
            if (data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {
            var warehouseId      = form.Get ( "Warehouse" );
            var fixedAssetTypeId = form.Get ( "FixedAssetTypeId" );
            GetData();
            TempData["Warehouse"] = warehouseId;
            TempData["FixedAssetTypeId"] = fixedAssetTypeId;

            var data = _fixedAssetHandler.GetAllFixedAssets().Where(n => n.Center == GetCurrentUnitForUser()).ToList();

            if ( warehouseId != null && Guid.Parse ( warehouseId ) != Guid.Empty ) 
                data = data.Where ( n => n.WarehouseId == Guid.Parse ( warehouseId ) ).ToList();

            if ( fixedAssetTypeId != null && Convert.ToInt32 ( fixedAssetTypeId ) != 0 )
            {
                var fixedAssetType = Convert.ToInt32 ( fixedAssetTypeId );

                switch ( fixedAssetType )
                {
                    case 1:
                        data = data.Where ( n => n.FixedAssetType == FixedAssetType.LiquidationAsset ).ToList();
                        break;
                    case 2:
                        data = data.Where ( n => n.FixedAssetType == FixedAssetType.UseAsset ).ToList();
                        break;
                    case 3:
                        data = data.Where ( n => n.FixedAssetType == FixedAssetType.AssetsTransfer ).ToList();
                        break;
                    case 4:
                        data = data.Where ( n => n.FixedAssetType == FixedAssetType.AssetsExport ).ToList();
                        break;
                }
            }

            if ( data != null && data.Count > 0 )
                data = data.OrderByDescending ( x => x.CreatedDate ).ToList();

            return View ( data );
        }

        private void GetData()
        {
            TempData["Warehouses"] = _warehouseHandler.GetAllWarehouses();

            var list = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Thanh lý", 1),
                new KeyValuePair<string, int>("Nhập", 2),
                new KeyValuePair<string, int>("Điều chuyển", 3),
                new KeyValuePair<string, int>("Xuất", 4),
            };
            TempData["FixedAssetType"] = list;
        }


    }
}