using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qlts.Controllers
{
    public class FixedAssetsController : Controller
    {
        // GET: FixedAssets
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CreateModal()
        {
            return PartialView();
        }
    }
}