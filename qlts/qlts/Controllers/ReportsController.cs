using qlts.Enums;
using qlts.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace qlts.Controllers
{
    public class ReportsController : Controller
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
            return View();
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