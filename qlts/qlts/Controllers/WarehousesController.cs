using qlts.Extensions;
using qlts.Handlers;
using qlts.Models;
using qlts.ViewModels.Warehouses;
using System;
using System.Linq;
using System.Web.Mvc;

namespace qlts.Controllers
{
    public class WarehousesController : BaseController
    {
        private readonly IWarehouseHandler _warehouseHandler;

        public WarehousesController(IWarehouseHandler _warehouseHandler)
        {
            this._warehouseHandler = _warehouseHandler;
        }
        public ActionResult Index()
        {
            var data = _warehouseHandler.GetAllWarehouses();
            if (data != null && data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }

        public ActionResult CreateUpdate(Guid? id)
        {
            var data = _warehouseHandler.GetWarehouseById(id);
            if (data == null)
                return RedirectToAction("Login", "Account");

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(WarehouseCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Warehouse Warehouse = null;

            try
            {
                Warehouse = _warehouseHandler.CreateUpdateWarehouse(model);
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return View(model);
            }

            if (Warehouse.IsSuccess())
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
                success = _warehouseHandler.DeleteWarehouse(id);
            }
            catch (Exception ex)
            {
                return Json(GetResponse(false, "Xóa không thành công !"));
            }

            return Json(GetResponse(success), JsonRequestBehavior.DenyGet);
        }
    }
}