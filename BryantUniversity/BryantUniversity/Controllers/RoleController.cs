using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class RoleController : Controller
    {

        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            return View();
        }
    }
}