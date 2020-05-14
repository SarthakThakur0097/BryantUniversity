using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class ResearcherController : Controller
    {
        // GET: Researcher
        [HttpGet]
        public ActionResult StudentStasitics()
        {
            return View();
        }
    }
}