using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class CourseCatalogController : Controller
    {
        // GET: CourseCatalog
        public ActionResult Index()
        {
            return View();
        }
    }
}