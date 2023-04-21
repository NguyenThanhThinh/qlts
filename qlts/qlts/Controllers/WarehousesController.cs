using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qlts.Controllers
{
    public class WarehousesController : Controller
    {
        // GET: Warehouses
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUpdate( )
        {
            return View ( );
        }
    }
}