using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qlts.Controllers
{
    public class ManufacturersController : Controller
    {
        // GET: Manufacturers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUpdate()
        {
            return View();
        }
    }
}