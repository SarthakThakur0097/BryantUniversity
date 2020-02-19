using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    [AllowAnonymous]
    public class HomepageController : Controller
    {
        // GET: Homepage
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Calendar()
        {

            return View();
        }

        public ActionResult Catalog()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            return View();
        }
    }
}