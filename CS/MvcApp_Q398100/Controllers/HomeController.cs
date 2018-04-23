using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace MvcApp_Q398100.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!";

            return View(NorthwindDataProvider.GetProducts());
        }

        public ActionResult GridViewPartial() {
             return PartialView("_GridViewPartial", NorthwindDataProvider.GetProducts());
        }
    }
}
