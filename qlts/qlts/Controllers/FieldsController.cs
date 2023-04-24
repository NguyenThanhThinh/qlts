using qlts.Extensions;
using qlts.Handlers;
using qlts.Models;
using qlts.ViewModels.Fields;
using System;
using System.Linq;
using System.Web.Mvc;

namespace qlts.Controllers
{
    public class FieldsController : BaseController
    {
        private readonly IFieldHandler _FieldHandler;

        public FieldsController(IFieldHandler _FieldHandler)
        {
            this._FieldHandler = _FieldHandler;
        }
        public ActionResult Index()
        {
            var data = _FieldHandler.GetAllFields();
            if (data != null && data.Count > 0)
                data = data.OrderByDescending(x => x.CreatedDate).ToList();

            return View(data);
        }

        public ActionResult CreateUpdate(Guid? id)
        {
            var data = _FieldHandler.GetFieldById(id);
            if (data == null)
                return RedirectToAction("Login", "Account");

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(FieldCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Field Field = null;

            try
            {
                if (model.Id != Guid.Empty)
                {
                    model.CreatedBy = GetCurrentUserName();
                    model.ModifiedBy = GetCurrentUserName();
                }
                Field = _FieldHandler.CreateUpdateField(model);
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return View(model);
            }

            if (Field.IsSuccess())
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
                success = _FieldHandler.DeleteField(id);
            }
            catch (Exception ex)
            {
                return Json(GetResponse(false, "Xóa không thành công !"));
            }

            return Json(GetResponse(success), JsonRequestBehavior.DenyGet);
        }
    }
}